using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Xml;

namespace ASTERIX
{
    public partial class Settings : Form
    {
        #region Modules

        public static DataTable modules;

        /// <summary>
        /// Возвращает байтовое представление файла.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <returns>Байтовое представление файла</returns>
        static byte[] LoadFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            return buffer;
        }

        /// <summary>
        /// Сканирует папку Modules на наличие модулей.
        /// </summary>
        /// <returns>Таблица модулей. </returns>
        static DataTable GetDirectoryModules()
        {
            List<string> pathModules = new List<string>();
            pathModules = Directory.GetFiles("Modules", "*.dll").ToList();

            DataTable DirectoryModules = new DataTable();
            DirectoryModules.Columns.Add("Status", Type.GetType("System.Boolean"));
            DirectoryModules.Columns.Add("Name", Type.GetType("System.String"));
            DirectoryModules.Columns.Add("CAT", Type.GetType("System.String"));
            DirectoryModules.Columns.Add("Version", Type.GetType("System.String"));
            DirectoryModules.Columns.Add("Developer", Type.GetType("System.String"));
            DirectoryModules.Columns.Add("Assembly", Type.GetType("System.Reflection.Assembly"));

            for (int path = 0; path < pathModules.Count; path++)
            {
                Assembly asm = Assembly.Load(LoadFile(Path.GetFullPath(pathModules[path])));

                IList<CustomAttributeData> attr = asm.GetCustomAttributesData();

                string DllType = attr.Where(x => x.Constructor.DeclaringType == typeof(AssemblyTitleAttribute)).First().ConstructorArguments.ElementAt(0).Value.ToString();

                if (DllType == "Module")
                {
                    string Name = Path.GetFileNameWithoutExtension(pathModules[path]);
                    string CAT = attr.Where(x => x.Constructor.DeclaringType == typeof(AssemblyDescriptionAttribute)).First().ConstructorArguments.ElementAt(0).ToString().Replace("\"", "");
                    string Version = attr.Where(x => x.Constructor.DeclaringType == typeof(AssemblyFileVersionAttribute)).First().ConstructorArguments.ElementAt(0).ToString().Replace("\"", "");
                    string Developer = attr.Where(x => x.Constructor.DeclaringType == typeof(AssemblyCompanyAttribute)).First().ConstructorArguments.ElementAt(0).ToString().Replace("\"", "");

                    DirectoryModules.Rows.Add(new object[] { false, Name, CAT, Version, Developer, asm });
                }

            }
            return DirectoryModules;
        }
        /// <summary>
        /// Возвращает включенные модули из настроек.
        /// </summary>
        /// <returns>Включенные модули из настроек.</returns>
        static DataTable GetModulesSettings()
        {
            DataTable SettingsModules = new DataTable();
            SettingsModules.Columns.Add("Name", Type.GetType("System.String"));
            SettingsModules.Columns.Add("CAT", Type.GetType("System.String"));
            SettingsModules.Columns.Add("Version", Type.GetType("System.String"));
            SettingsModules.Columns.Add("Developer", Type.GetType("System.String"));

            XmlDocument doc = new XmlDocument();
            doc.Load("Settings.xml");

            XmlNodeList moduleList = doc.GetElementsByTagName("Modules")[0].ChildNodes;

            foreach (XmlElement module in moduleList)
            {
                string Name = module.GetAttributeNode("Name").InnerText;
                string CAT = module.GetAttributeNode("CAT").InnerText;
                string Version = module.GetAttributeNode("Version").InnerText;
                string Developer = module.GetAttributeNode("Developer").InnerText;

                SettingsModules.Rows.Add(new object[] { Name, CAT, Version, Developer });
            }

            return SettingsModules;
        }
        /// <summary>
        /// Возвращает модули текущей конфигурации.
        /// </summary>
        /// <returns>Модули текущей конфигурации.</returns>
        public static DataTable GetModules()
        {
            DataTable DirectoryModules = GetDirectoryModules();
            DataTable SettingsModules = GetModulesSettings();

            for (int module = 0; module < DirectoryModules.Rows.Count; module++)
            {
                DataRow[] on = SettingsModules.Select().Where(x => x["Name"].ToString() == DirectoryModules.Rows[module]["Name"].ToString() && x["CAT"].ToString() == DirectoryModules.Rows[module]["CAT"].ToString() && x["Version"].ToString() == DirectoryModules.Rows[module]["Version"].ToString() && x["Developer"].ToString() == DirectoryModules.Rows[module]["Developer"].ToString()).ToArray();
                if (on.Count() != 0)
                {
                    DirectoryModules.Rows[module]["Status"] = true;
                }
            }

            return DirectoryModules;
        }
        /// <summary>
        /// Выгружает текущию конфигурацию модулей в Settings.xml
        /// </summary>
        /// <param name="modules">Таблица модулей</param>
        static void UpdateModules(DataTable modules)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Settings.xml");

            XmlNode ModulesNode = doc.GetElementsByTagName("Modules")[0];
            ModulesNode.RemoveAll();

            DataRow[] on = modules.Select().Where(x => (bool)x["Status"] == true).ToArray();

            foreach (DataRow module in on)
            {
                XmlElement NewModuleNode = doc.CreateElement("module");
                NewModuleNode.IsEmpty = true;
                NewModuleNode.SetAttribute("Name", module["Name"].ToString());
                NewModuleNode.SetAttribute("CAT", module["CAT"].ToString());
                NewModuleNode.SetAttribute("Version", module["Version"].ToString());
                NewModuleNode.SetAttribute("Developer", module["Developer"].ToString());

                ModulesNode.AppendChild(NewModuleNode);
            }

            doc.Save("Settings.xml");
        }

        /// <summary>
        /// Добавляет новый модуль.
        /// </summary>
        /// <param name="filename">Путь к модулю.</param>
        /// <returns>Результат операции.</returns>
        bool AddModule(string filename)
        {
            Assembly asm = Assembly.Load(LoadFile(filename));

            IList<CustomAttributeData> attr = asm.GetCustomAttributesData();

            string DllType = attr.Where(x => x.Constructor.DeclaringType == typeof(AssemblyTitleAttribute)).First().ConstructorArguments.ElementAt(0).Value.ToString();

            if (DllType == "Module")
            {
                File.Copy(filename, "Modules/" + Path.GetFileName(filename));
                return true;
            }
            else
            {
                MessageBox.Show("Выбранный файл не является модулем Flight Radar");
                return false;
            }
        }
        /// <summary>
        /// Удаляет модуль.
        /// </summary>
        /// <param name="module">Таблица модулей.</param>
        /// <returns>Результат операции.</returns>
        bool DeleteModule(DataGridViewRow module)
        {
            if (MessageBox.Show("Удалить модуль?", "Подтверждение", MessageBoxButtons.YesNo,
   MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                string ModuleFileName = module.Cells["Name"].Value.ToString() + ".dll";
                File.Delete("Modules/" + ModuleFileName);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Изменяет состояние модуля.
        /// </summary>
        /// <param name="modules">Таблица модулей.</param>
        /// <param name="row">Индекс изменяемой позиции.</param>
        static void UpdateStatus(DataTable modules, int row)
        {
            if ((bool)modules.Rows[row]["Status"] == true)
            {
                modules.Rows[row]["Status"] = false;
            }
            else
            {
                string CAT = modules.Rows[row]["CAT"].ToString();
                for (int module = 0; module < modules.Rows.Count; module++)
                {
                    if (modules.Rows[module]["CAT"].ToString() == CAT)
                    {
                        modules.Rows[module]["Status"] = false;
                    }
                }
                modules.Rows[row]["Status"] = true;
            }

        }

        /// <summary>
        /// Обработчик клика под модулю. Изменяет состояние.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModulesGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                UpdateStatus(modules, e.RowIndex);
                UpdateModules(modules);
            }
        }
        /// <summary>
        /// Обработчик удаления строки из GridView. Удаляет выбранный модуль.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModulesGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!DeleteModule(e.Row))
            {
                e.Cancel = true;
            }
        }
        /// <summary>
        /// Обработчик после удаления строки из GridView. Обновляет таблицу модулей.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModulesGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            UpdateModules(modules);
        }

        /// <summary>
        /// Убирает фокус.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddModuleBTN_MouseDown(object sender, MouseEventArgs e)
        {
            ModulesGridView.Focus();
        }
        private void DeleteModuleBTN_MouseDown(object sender, MouseEventArgs e)
        {
            ModulesGridView.Focus();
        }

        /// <summary>
        /// Обработчик кнопки. Добавляет новый модуль.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddModuleBTN_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ImportModuleDialog.Filter = "DLL files (*.dll)|*.dll";
                if (ImportModuleDialog.ShowDialog() == DialogResult.OK)
                {
                    if (AddModule(ImportModuleDialog.FileName))
                    {
                        LoadModules();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Обработчик кнопки. Удаляет файл модуля.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteModuleBTN_MouseUp(object sender, MouseEventArgs e)
        {
            if (DeleteModule(ModulesGridView.SelectedRows[0]))
            {
                ModulesGridView.Rows.Remove(ModulesGridView.SelectedRows[0]);
                ModulesGridView.Refresh();
                UpdateModules(modules);
            }
        }

        void LoadModules()
        {
            modules = GetModules();

            ModulesGridView.DataSource = modules;
            ModulesGridView.Columns["Assembly"].Visible = false;
            ModulesGridView.Columns["Status"].HeaderText = "Состояние";
            ModulesGridView.Columns["Name"].HeaderText = "Имя модуля";
            ModulesGridView.Columns["CAT"].HeaderText = "Категория";
            ModulesGridView.Columns["Version"].HeaderText = "Версия модуля";
            ModulesGridView.Columns["Developer"].HeaderText = "Разработчик";

            ModulesGridView.Columns["Status"].SortMode = DataGridViewColumnSortMode.NotSortable;
            ModulesGridView.Columns["Name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            ModulesGridView.Columns["CAT"].SortMode = DataGridViewColumnSortMode.NotSortable;
            ModulesGridView.Columns["Version"].SortMode = DataGridViewColumnSortMode.NotSortable;
            ModulesGridView.Columns["Developer"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        #endregion

        #region Setting

        public static int UpdateScreen;
        public static int RouteOfPage;
        public static int AircraftOfPage;
        public static Color ColorNewPolygon;
        public static Color ColorNewMarker;
        public static Color ColorNewRoute;
        public static Color ColorSelected;

        /// <summary>
        /// Загружает пользовательские настройки.
        /// </summary>
        void GetSettings()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Settings.xml");

            UpdateScreen = Convert.ToInt32(doc.GetElementsByTagName("Update")[0].FirstChild.Value);
            RouteOfPage = Convert.ToInt32(doc.GetElementsByTagName("RouteOfPage")[0].FirstChild.Value);
            AircraftOfPage = Convert.ToInt32(doc.GetElementsByTagName("AircraftOfPage")[0].FirstChild.Value);
            ColorNewPolygon = Color.FromName(doc.GetElementsByTagName("ColorNewPolygon")[0].FirstChild.Value);
            ColorNewMarker = Color.FromName(doc.GetElementsByTagName("ColorNewMarker")[0].FirstChild.Value);
            ColorNewRoute = Color.FromName(doc.GetElementsByTagName("ColorNewRoute")[0].FirstChild.Value);
            ColorSelected = Color.FromName(doc.GetElementsByTagName("ColorSelected")[0].FirstChild.Value);

            UpdateTextBox.Text = UpdateScreen.ToString();
            RouteOfPageTextBox.Text = RouteOfPage.ToString();
            AircraftOfPageTextBox.Text = AircraftOfPage.ToString();
            ColorNewPolygonСomboBox.BackColor = ColorNewPolygon;
            ColorNewMarkerComboBox.BackColor = ColorNewMarker;
            ColorNewRouteComboBox.BackColor = ColorNewRoute;
            ColorSelectedComboBox.BackColor = ColorSelected;

            Aircraft.Init(AircraftOfPage);
            Map.Init(UpdateScreen, RouteOfPage, ColorNewRoute, ColorSelected, ColorNewPolygon, ColorNewMarker);
        }
        /// <summary>
        /// Выгружает пользовательские настройки.
        /// </summary>
        void SetSettings()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Settings.xml");

            UpdateScreen = Convert.ToInt32(UpdateTextBox.Text);
            RouteOfPage = Convert.ToInt32(RouteOfPageTextBox.Text);
            AircraftOfPage = Convert.ToInt32(AircraftOfPageTextBox.Text);
            ColorNewPolygon = ColorNewPolygonСomboBox.BackColor;
            ColorNewMarker = ColorNewMarkerComboBox.BackColor;
            ColorNewRoute = ColorNewRouteComboBox.BackColor;
            ColorSelected = ColorSelectedComboBox.BackColor;

            doc.GetElementsByTagName("Update")[0].FirstChild.Value = UpdateScreen.ToString();
            doc.GetElementsByTagName("RouteOfPage")[0].FirstChild.Value = RouteOfPage.ToString();
            doc.GetElementsByTagName("AircraftOfPage")[0].FirstChild.Value = AircraftOfPage.ToString();
            doc.GetElementsByTagName("ColorNewPolygon")[0].FirstChild.Value = ColorNewPolygon.Name;
            doc.GetElementsByTagName("ColorNewMarker")[0].FirstChild.Value = ColorNewMarker.Name;
            doc.GetElementsByTagName("ColorNewRoute")[0].FirstChild.Value = ColorNewRoute.Name;
            doc.GetElementsByTagName("ColorSelected")[0].FirstChild.Value = ColorSelected.Name;
            
            Aircraft.Init(AircraftOfPage);
            Map.Init(UpdateScreen, RouteOfPage, ColorNewRoute, ColorSelected, ColorNewPolygon, ColorNewMarker);

            doc.Save("Settings.xml");
        }

        /// <summary>
        /// Убирает фокус.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBTN_MouseDown(object sender, MouseEventArgs e)
        {
            SettingsPanel.Focus();
        }
        private void BackBTN_MouseDown(object sender, MouseEventArgs e)
        {
            SettingsPanel.Focus();
        }

        /// <summary>
        /// Кнопка "Сохранить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveBTN_MouseUp(object sender, MouseEventArgs e)
        {
            SetSettings();
            MessageBox.Show("Сохранено");
        }
        /// <summary>
        /// Кнопка "Отменить"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackBTN_MouseUp(object sender, MouseEventArgs e)
        {
            UpdateTextBox.Text = UpdateScreen.ToString();
            RouteOfPageTextBox.Text = RouteOfPage.ToString();
            AircraftOfPageTextBox.Text = AircraftOfPage.ToString();
            ColorNewRouteComboBox.BackColor = ColorNewRoute;
            ColorSelectedComboBox.BackColor = ColorSelected;
        }

        /// <summary>
        /// Устанавливает курсор в начало.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            UpdateTextBox.SelectionStart = 0;
        }
        private void RoutOfPageTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            RouteOfPageTextBox.SelectionStart = 0;
        }
        private void AircraftOfPageTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            AircraftOfPageTextBox.SelectionStart = 0;
        }
        
        /// <summary>
        /// Заполнение ComboBox цветами.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorNewRouteComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            using (Brush br = new SolidBrush(Map.colors[e.Index]))
            {
                e.Graphics.FillRectangle(br, e.Bounds);
            }

        }
        private void ColorSelectedComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            using (Brush br = new SolidBrush(Map.colors[e.Index]))
            {
                e.Graphics.FillRectangle(br, e.Bounds);
            }
        }
        private void ColorNewPolygonСomboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            using (Brush br = new SolidBrush(Map.colors[e.Index]))
            {
                e.Graphics.FillRectangle(br, e.Bounds);
            }
        }
        private void ColorNewMarkerComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            using (Brush br = new SolidBrush(Map.Markercolors[e.Index]))
            {
                e.Graphics.FillRectangle(br, e.Bounds);
            }
        }

        /// <summary>
        /// ВЫбор цвета нового маршрута.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorNewRouteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColorNewRouteComboBox.BackColor = Map.colors[ColorNewRouteComboBox.SelectedIndex];
        }
        /// <summary>
        /// ВЫбор цвета выделенного маршрута.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorSelectedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColorSelectedComboBox.BackColor = Map.colors[ColorSelectedComboBox.SelectedIndex];
        }
        /// <summary>
        /// Выбор цвета нового полигона.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorNewPolygonСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColorNewPolygonСomboBox.BackColor = Map.colors[ColorNewPolygonСomboBox.SelectedIndex];
        }
        /// <summary>
        /// Выбор цвета нового маркера.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorNewMarkerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColorNewMarkerComboBox.BackColor = Map.Markercolors[ColorNewMarkerComboBox.SelectedIndex];
        }

        /// <summary>
        /// Инициализация настроек.
        /// </summary>
        void InitSettings()
        {
            foreach (Color clr in Map.colors)
            {
                ColorNewPolygonСomboBox.Items.Add("");
                ColorNewRouteComboBox.Items.Add("");
                ColorSelectedComboBox.Items.Add("");
            }
            foreach (Color clr in Map.Markercolors)
            {
                ColorNewMarkerComboBox.Items.Add("");
            }
            ColorNewPolygonСomboBox.DrawMode = DrawMode.OwnerDrawFixed;
            ColorNewMarkerComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            ColorNewRouteComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            ColorSelectedComboBox.DrawMode = DrawMode.OwnerDrawFixed;
        }

        #endregion

        public Settings()
        {
            InitializeComponent();

            InitSettings();
            LoadModules();

            GetSettings();
        }
    }
}
