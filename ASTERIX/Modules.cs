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
    public partial class Modules : Form
    {
        DataTable modules;

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

                IList <CustomAttributeData> attr = asm.GetCustomAttributesData();

                string DllType = attr.Where(x => x.Constructor.DeclaringType == typeof(AssemblyTitleAttribute)).First().ConstructorArguments.ElementAt(0).Value.ToString();

                if (DllType == "Module")
                {
                    string Name = Path.GetFileNameWithoutExtension(pathModules[path]);
                    string CAT = attr.Where(x => x.Constructor.DeclaringType == typeof(AssemblyDescriptionAttribute)).First().ConstructorArguments.ElementAt(0).ToString().Replace("\"", "");
                    string Version = attr.Where(x => x.Constructor.DeclaringType == typeof(AssemblyFileVersionAttribute)).First().ConstructorArguments.ElementAt(0).ToString().Replace("\"", "");
                    string Developer = attr.Where(x => x.Constructor.DeclaringType == typeof(AssemblyCompanyAttribute)).First().ConstructorArguments.ElementAt(0).ToString().Replace("\"", "");

                    DirectoryModules.Rows.Add(new object[] { false, Name, CAT, Version, Developer, asm });


                    //asm.GetType("Module").GetMethod("Init").Invoke(null, null);
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
        static DataTable GetModules()
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddModuleButton_Click(object sender, EventArgs e)
        {
            try
            {
                ImportModuleDialog.Filter = "DLL files (*.dll)|*.dll";
                if (ImportModuleDialog.ShowDialog() == DialogResult.OK)
                {
                    Assembly asm = Assembly.Load(LoadFile(ImportModuleDialog.FileName));

                    IList<CustomAttributeData> attr = asm.GetCustomAttributesData();

                    string DllType = attr.Where(x => x.Constructor.DeclaringType == typeof(AssemblyTitleAttribute)).First().ConstructorArguments.ElementAt(0).Value.ToString();

                    if (DllType == "Module")
                    {
                        File.Copy(ImportModuleDialog.FileName, "Modules/" + ImportModuleDialog.SafeFileName);
                        Modules_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Выбранный файл не является модулем Flight Radar");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Удаляет файл модуля.
        /// </summary>
        /// <param name="module"></param>
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
        /// Изменяет состояние модуля.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModulesGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            modules.Rows[e.RowIndex]["Status"] = !(bool)modules.Rows[e.RowIndex]["Status"];
            UpdateModules(modules);
        }
        /// <summary>
        /// Удаляет выбранный модуль.
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
        /// Обновляет таблицу модулей.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModulesGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            UpdateModules(modules);
        }

        public Modules()
        {
            InitializeComponent();
        }

        private void Modules_Load(object sender, EventArgs e)
        {
            modules = GetModules();
            UpdateModules(modules);

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

    }
}
