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
        /// Обработчик кнопки. Добавляет новый модуль.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddModuleButton_Click(object sender, EventArgs e)
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
        private void DeleteModuleButton_Click(object sender, EventArgs e)
        {
            if (DeleteModule(ModulesGridView.SelectedRows[0]))
            {
                ModulesGridView.Rows.Remove(ModulesGridView.SelectedRows[0]);
                ModulesGridView.Refresh();
                UpdateModules(modules);
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

        public Settings()
        {
            InitializeComponent();

            LoadModules();
        }
    }
}
