using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ASTERIX
{
    public partial class Aircraft : Form
    {
        int Aircraftchcksum = 0;
        bool search = false;
        bool update = false;
        int RowOfPage = 1000;

        bool clearBox = false;

        public Aircraft()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Возвращает контрольную сумму таблицы.
        /// </summary>
        /// <param name="TableName">Имя таблицы</param>
        /// <returns>Контрольная сумма.</returns>
        int checksum(string TableName)
        {
            DataTable Chcksum = SQL.query("SELECT CHECKSUM_AGG(GETCHECKSUM()) FROM dbo.[" + TableName + "]");
            if (Convert.ToString(Chcksum.Rows[0][0]) != "")
            {
                return Convert.ToInt32(Chcksum.Rows[0][0]);
            }
            return 0;
        }
        /// <summary>
        /// Получает значение бокса. Необходимо при обращении к боксу, не принадлежащему данному потоку.
        /// </summary>
        /// <param name="Box">Имя бокса.</param>
        /// <returns>Значение бокса.</returns>
        public string GetBoxValue(string Box)
        {
            string result = "";
            if (InvokeRequired)
            {
                result = (string)Invoke(new Func<string, string>(GetBoxValue), new object[] { Box });
                return result;
            }
            switch (Box)
            {
                case "TargetAddress":
                    {
                        result = TargetAddressTextBox.TextField;
                        break;
                    }
                case "ICAOTypeCode":
                    {
                        result = ICAOTypeCodeTextBox.TextField;
                        break;
                    }
                case "Registration":
                    {
                        result = RegistrationTextBox.TextField;
                        break;
                    }
                case "TypeAircraft":
                    {
                        result = TypeAircraftTextBox.TextField;
                        break;
                    }
                case "Country":
                    {
                        result = CountryTextBox.TextField;
                        break;
                    }
                case "Class":
                    {
                        result = ClassTextBox.TextField;
                        break;
                    }
                case "User":
                    {
                        result = UserTextBox.TextField;
                        break;
                    }
            }
            return result;
        }
        /// <summary>
        /// Формирует текущий фильтр.
        /// </summary>
        /// <returns>Фильтр.</returns>
        string filter()
        {
            string filter = "";
            string TargetAddress = GetBoxValue("TargetAddress");
            string ICAOTypeCode = GetBoxValue("ICAOTypeCode");
            string Registration = GetBoxValue("Registration");
            string TypeAircraft = GetBoxValue("TypeAircraft");
            string Country = GetBoxValue("Country");
            string Class = GetBoxValue("Class");
            string User = GetBoxValue("User");

            if ((TargetAddress != "") && (TargetAddress != null))
            {
                filter = "WHERE TargetAddress LIKE '" + TargetAddress + "%'";
            }
            if ((ICAOTypeCode != "") && (ICAOTypeCode != null))
            {
                if (filter == "")
                {
                    filter = "WHERE ICAOTypeCode LIKE '" + ICAOTypeCode + "%'";
                }
                else
                {
                    filter += " AND ICAOTypeCode LIKE '" + ICAOTypeCode + "%'";
                }
            }
            if ((Registration != "") && (Registration != null))
            {
                if (filter == "")
                {
                    filter = "WHERE Registration LIKE '" + Registration + "%'";
                }
                else
                {
                    filter += " AND Registration LIKE '" + Registration + "%'";
                }
            }
            if ((TypeAircraft != "") && (TypeAircraft != null))
            {
                if (filter == "")
                {
                    filter = "WHERE TypeAircraft LIKE '" + TypeAircraft + "%'";
                }
                else
                {
                    filter += " AND TypeAircraft LIKE '" + TypeAircraft + "%'";
                }
            }
            if ((Country != "") && (Country != null))
            {
                if (filter == "")
                {
                    filter = "WHERE Country LIKE '" + Country + "%'";
                }
                else
                {
                    filter += " AND Country LIKE '" + Country + "%'";
                }
            }
            if ((Class != "") && (Class != null))
            {
                if (filter == "")
                {
                    filter = "WHERE Class LIKE '" + Class + "%'";
                }
                else
                {
                    filter += " AND Class LIKE '" + Class + "%'";
                }
            }
            if ((User != "") && (User != null))
            {
                if (filter == "")
                {
                    filter = "WHERE UserText LIKE '" + User + "%'";
                }
                else
                {
                    filter += " AND UserText LIKE '" + User + "%'";
                }
            }    
            
            return filter;
        }
        
        /// <summary>
        /// Проверяет необходимость обновления GridView.
        /// </summary>
        public void UpdateGrid()
        {
            int chcksum = checksum("Aircraft");
            if (Aircraftchcksum != chcksum)
            {
                Aircraftchcksum = chcksum;
                ShowAircraftGridView(true, 1);
            }
        }
        /// <summary>
        /// Обновляет GridView.
        /// </summary>
        public void ShowAircraftGridView(bool autoPosition, int page)
        {
            if (AircraftGridView.InvokeRequired)
            {
                AircraftGridView.BeginInvoke(new Action<bool, int >(ShowAircraftGridView), new object[] { autoPosition, page });
                return;
            }
            string f = "";
            if (search)
            {
            f = filter();
            }
            double AllPage = Convert.ToDouble(SQL.query("SELECT COUNT(*) FROM [Aircraft] " + f).Rows[0][0])/RowOfPage;
            if (AllPage > Math.Truncate(AllPage))
            {
                AllPage = Math.Truncate(AllPage) + 1;
            } 
            if (AllPage == 0)
            {
                AllPage++;
            }
            UpdateDataGridView(SQL.query("SELECT TOP " + RowOfPage.ToString() + " * FROM (SELECT TOP " + Convert.ToString(page * RowOfPage) + " [Id], [TargetAddress] AS 'ICAO24',[Country] AS 'Государство', [Registration] AS 'Бортовой', [ICAOTypeCode] AS 'ICAOType', [TypeAircraft] AS 'Тип', [EmitterCategory] AS 'Категория', [Class] AS 'Класс', [UserText] AS 'Примечание' FROM [Aircraft] " + f + " ORDER BY [Id] desc) t ORDER BY [Id]"), autoPosition);
            if (page == 1)
            {
                Back.Enabled = false;
            }
            if ((AllPage > 1) && (page != AllPage))
            {
                Up.Enabled = true;
            }
            PageTextBox.Text = page.ToString();
            AllPageTextBox.Text = AllPage.ToString();
        }
        /// <summary>
        /// Обновляет данные в AircraftGridView.
        /// </summary>
        /// <param name="table">Таблица данных.</param>
        /// <param name="autoPosition">Фиксация положения в таблице. Использовать только при добавлении данных в таблицу (когда предыдущие строки не изменяются).</param>
        public void UpdateDataGridView(DataTable table, bool autoPosition)
        {
            if (AircraftGridView.InvokeRequired)
            {
                AircraftGridView.BeginInvoke(new Action<DataTable, bool>(UpdateDataGridView), new object[] { table, autoPosition });
                return;
            }

            int selectedId = 0;
            int firstRow = 0;
            int sortedColumn = 0;
            ListSortDirection sortDirection = ListSortDirection.Descending;

            if (AircraftGridView.Rows.Count > 0)
            {
                if (AircraftGridView.CurrentCell != null)
                {
                    selectedId = Convert.ToInt32(AircraftGridView[0, AircraftGridView.CurrentCell.RowIndex].Value);
                }
                if (AircraftGridView.FirstDisplayedScrollingRowIndex >= 0)
                {
                    firstRow = AircraftGridView.FirstDisplayedScrollingRowIndex;
                }
            }

            if (AircraftGridView.SortedColumn != null)
            {
                sortedColumn = AircraftGridView.SortedColumn.Index;
                if (AircraftGridView.SortOrder == System.Windows.Forms.SortOrder.Ascending)
                {
                    sortDirection = ListSortDirection.Ascending;
                }
                else
                {
                    sortDirection = ListSortDirection.Descending;
                }
            }

            AircraftGridView.DataSource = table;
            AircraftGridView.Columns["Id"].Visible = false;

            AircraftGridView.Sort(AircraftGridView.Columns[sortedColumn], sortDirection);

            if (AircraftGridView.Rows.Count > 0)
            {
                if (autoPosition)
                {
                    for (int row = 0; row < AircraftGridView.Rows.Count; row++)
                    {
                        if (Convert.ToInt32(AircraftGridView[0, row].Value) == selectedId)
                        {
                            AircraftGridView.CurrentCell = AircraftGridView[1, row];
                            break;
                        }
                    }
                    AircraftGridView.FirstDisplayedScrollingRowIndex = firstRow;
                }
            }
        }

        /// <summary>
        /// Обновление Grid по изменению текста в текст боксах.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TargetAddressTextBox_ControlTextChanged(object sender, EventArgs e)
        {
            if ((search) && (!clearBox))
            {
                ShowAircraftGridView(false, 1);
            }
        }
        private void ICAOTypeCodeTextBox_ControlTextChanged(object sender, EventArgs e)
        {
            if ((search) && (!clearBox))
            {
                ShowAircraftGridView(false, 1);
            }
        }
        private void RegistrationTextBox_ControlTextChanged(object sender, EventArgs e)
        {
            if ((search) && (!clearBox))
            {
                ShowAircraftGridView(false, 1);
            }
        }
        private void TypeAircraftTextBox_ControlTextChanged(object sender, EventArgs e)
        {
            if ((search) && (!clearBox))
            {
                ShowAircraftGridView(false, 1);
            }
        }
        private void CountryTextBox_ControlTextChanged(object sender, EventArgs e)
        {
            if ((search) && (!clearBox))
            {
                ShowAircraftGridView(false, 1);
            }
        }
        private void ClassTextBox_ControlTextChanged(object sender, EventArgs e)
        {
            if ((search) && (!clearBox))
            {
                ShowAircraftGridView(false, 1);
            }
        }
        private void UserTextBox_ControlTextChanged(object sender, EventArgs e)
        {
            if ((search) && (!clearBox))
            {
                ShowAircraftGridView(false, 1);
            }
        }
        
        /// <summary>
        /// Очищает все TextBox.
        /// </summary>
        void ClearTextBox()
        {
            TargetAddressTextBox.Clear();
            ICAOTypeCodeTextBox.Clear();
            RegistrationTextBox.Clear();
            TypeAircraftTextBox.Clear();
            CountryTextBox.Clear();
            ClassTextBox.Clear();
            UserTextBox.Clear();
        }

        /// <summary>
        /// Убирает фокус.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBTN_MouseDown(object sender, MouseEventArgs e)
        {
            TargetAddressTextBox.Focus();
        }
        private void UpdateBTN_MouseDown(object sender, MouseEventArgs e)
        {
            TargetAddressTextBox.Focus();
        }
        private void DeleteBTN_MouseDown(object sender, MouseEventArgs e)
        {
            TargetAddressTextBox.Focus();
        }
        private void SearchBTN_MouseDown(object sender, MouseEventArgs e)
        {
            TargetAddressTextBox.Focus();
        }
        private void ResetBTN_MouseDown(object sender, MouseEventArgs e)
        {
            TargetAddressTextBox.Focus();
        }
        private void Up_MouseDown(object sender, MouseEventArgs e)
        {
            PagePanel.Focus();
        }
        private void Back_MouseDown(object sender, MouseEventArgs e)
        {
            PagePanel.Focus();
        }

        /// <summary>
        /// Добавить.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBTN_MouseUp(object sender, MouseEventArgs e)
        {
            string TargetAddress = GetBoxValue("TargetAddress");
            string ICAOTypeCode = GetBoxValue("ICAOTypeCode");
            string Registration = GetBoxValue("Registration");
            string TypeAircraft = GetBoxValue("TypeAircraft");
            string Country = GetBoxValue("Country");
            string Class = GetBoxValue("Class");
            string User = GetBoxValue("User");
            if ((TargetAddress != "") && (TargetAddress != null))
            {
                SQL.query("INSERT INTO dbo.[Aircraft] (TargetAddress, ICAOTypeCode, Registration, TypeAircraft, Country, Class, UserText) VALUES('" + TargetAddress + "','" + ICAOTypeCode + "','" + Registration + "','" + TypeAircraft + "','" + Country + "','" + Class + "','" + User + "')");
            }
            else
            {
                MessageBox.Show("Заполните поле ICAO24");
            }
            UpdateGrid();
            ClearTextBox();
        }
        /// <summary>
        /// Изменить.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateBTN_MouseUp(object sender, MouseEventArgs e)
        {
            string TargetAddress;
            string ICAOTypeCode;
            string Registration;
            string TypeAircraft;
            string Country;
            string Class;
            string User;

            if (update)
            {
                TargetAddress = GetBoxValue("TargetAddress");
                ICAOTypeCode = GetBoxValue("ICAOTypeCode");
                Registration = GetBoxValue("Registration");
                TypeAircraft = GetBoxValue("TypeAircraft");
                Country = GetBoxValue("Country");
                Class = GetBoxValue("Class");
                User = GetBoxValue("User");

                if (AircraftGridView.SelectedRows.Count > 0)
                {
                    string Id = Convert.ToString(AircraftGridView.SelectedRows[0].Cells["Id"].Value);
                    if ((TargetAddress != "") && (TargetAddress != null))
                    {
                        SQL.query("UPDATE dbo.[Aircraft] SET TargetAddress = '" + TargetAddress + "', ICAOTypeCode = '" + ICAOTypeCode + "', Registration = '" + Registration + "', TypeAircraft = '" + TypeAircraft + "', Country = '" + Country + "', Class = '" + Class + "', UserText = '" + User + "'  WHERE Id = " + Id);
                    }
                    else
                    {
                        MessageBox.Show("Заполните поле ICAO24");
                    }
                    UpdateGrid();
                    ClearTextBox();
                }

                update = false;
                UpdateBTN.Text = "ИЗМЕНИТЬ";

                AddBTN.Enabled = true;
                DeleteBTN.Enabled = true;
            }
            else
            {
                if (AircraftGridView.SelectedRows.Count > 0)
                {
                    TargetAddress = Convert.ToString(AircraftGridView.SelectedRows[0].Cells["ICAO24"].Value);
                    ICAOTypeCode = Convert.ToString(AircraftGridView.SelectedRows[0].Cells["ICAOType"].Value);
                    Registration = Convert.ToString(AircraftGridView.SelectedRows[0].Cells["Бортовой"].Value);
                    TypeAircraft = Convert.ToString(AircraftGridView.SelectedRows[0].Cells["Тип"].Value);
                    Country = Convert.ToString(AircraftGridView.SelectedRows[0].Cells["Государство"].Value);
                    Class = Convert.ToString(AircraftGridView.SelectedRows[0].Cells["Класс"].Value);
                    User = Convert.ToString(AircraftGridView.SelectedRows[0].Cells["Примечание"].Value);

                    if (TargetAddress != "")
                    {
                        TargetAddressTextBox.TextField = TargetAddress;
                    }
                    if (ICAOTypeCode != "")
                    {
                        ICAOTypeCodeTextBox.TextField = ICAOTypeCode;
                    }
                    if (Registration != "")
                    {
                        RegistrationTextBox.TextField = Registration;
                    }
                    if (TypeAircraft != "")
                    {
                        TypeAircraftTextBox.TextField = TypeAircraft;
                    }
                    if (Country != "")
                    {
                        CountryTextBox.TextField = Country;
                    }
                    if (Class != "")
                    {
                        ClassTextBox.TextField = Class;
                    }
                    if (User != "")
                    {
                        UserTextBox.TextField = User;
                    }

                    update = true;
                    UpdateBTN.Text = "СОХРАНИТЬ";

                    AddBTN.Enabled = false;
                    DeleteBTN.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Выберите строку");
                }
            }
        }
        /// <summary>
        /// Удалить.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBTN_MouseUp(object sender, MouseEventArgs e)
        {
            if (AircraftGridView.SelectedRows.Count > 0)
            {
                string Id = Convert.ToString(AircraftGridView.SelectedRows[0].Cells["Id"].Value);

                SQL.query("DELETE FROM dbo.[Aircraft] WHERE Id = " + Id);

                UpdateGrid();
                ClearTextBox();
            }
        }
        /// <summary>
        /// Поиск.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBTN_MouseUp(object sender, MouseEventArgs e)
        {
            if (search)
            {
                search = false;
                AddBTN.Enabled = true;
                DeleteBTN.Enabled = true;
                UpdateBTN.Enabled = true;
                SearchBTN.BackColor = Color.LightSlateGray;
                TargetAddressTextBox.Focus();
            }
            else
            {
                search = true;
                AddBTN.Enabled = false;
                DeleteBTN.Enabled = false;
                UpdateBTN.Enabled = false;
                SearchBTN.BackColor = Color.LightSeaGreen;
                TargetAddressTextBox.Focus();

                ShowAircraftGridView(true, 1);
            }
        }
        /// <summary>
        /// Сброс.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetBTN_MouseUp(object sender, MouseEventArgs e)
        {
            clearBox = true;
            ClearTextBox();
            clearBox = false;
            ShowAircraftGridView(true, 1);
        }

        /// <summary>
        /// Вперед.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Up_MouseUp(object sender, MouseEventArgs e)
        {
            int page = Convert.ToInt32(PageTextBox.Text);
            int maxpage = Convert.ToInt32(AllPageTextBox.Text);
            if (page >= maxpage - 1)
            {
                page = maxpage;
                PageTextBox.Text = page.ToString();
                Up.Enabled = false;
            }
            else
            {
                page++;
            }
            if (!Back.Enabled)
            {
                Back.Enabled = true;
            }
            ShowAircraftGridView(false, page);
        }
        /// <summary>
        /// Назад.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_MouseUp(object sender, MouseEventArgs e)
        {
            int page = Convert.ToInt32(PageTextBox.Text);
            int maxpage = Convert.ToInt32(AllPageTextBox.Text);
            if (page <= 2)
            {
                page = 1;
                PageTextBox.Text = page.ToString();
                Back.Enabled = false;
            }
            else
            {
                page--;
            }
            if (!Up.Enabled)
            {
                Up.Enabled = true;
            }
            ShowAircraftGridView(false, page);
        }

    }
    }
