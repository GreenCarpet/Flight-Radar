using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Xml;
using System.Threading;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace ASTERIX
{
    public partial class Map : Form
    {
        #region База

        int Loadchcksum;

        bool clearBox = false;

        bool FirstSetting = false;
        bool EnableBeginTimePicker = true;
        bool EnableEndTimePicker = false;
        bool userDeleting = true;

        int UPDATEGRIDMILLISECONDS = 5000;

        int SearchSplitterPosition = 100;
        bool SearchSplitterLock = false;

        int RowOfPage = 100;

        /// <summary>
        /// Формирует текущий фильтр.
        /// </summary>
        /// <returns>Фильтр.</returns>
        string filter()
        {
            string filter = "";
            string TargetAddress = GetBoxValue("TargetAddress");
            string AircraftIdentification = GetBoxValue("AircraftIdentification");
            string Registration = GetBoxValue("Registration");
            string TypeAircraft = GetBoxValue("TypeAircraft");
            string Mode3A = GetBoxValue("Mode3A");
            string EmitterCategory = GetBoxValue("EmitterCategory");
            string Country = GetBoxValue("Country");
            string AirportDepature = GetBoxValue("AirportDepature");
            string AirportArrival = GetBoxValue("AirportArrival");
            string BeginTime = GetBoxValue("BeginTime");
            string EndTime = GetBoxValue("EndTime");
            string CAT = GetBoxValue("CAT");
            string SAC = GetBoxValue("SAC");
            string SIC = GetBoxValue("SIC");
            string Class = GetBoxValue("Class");

            if ((TargetAddress != "") && (TargetAddress != null))
            {
                filter = "WHERE TargetAddress LIKE '" + TargetAddress + "%'";
            }
            if ((AircraftIdentification != "") && (AircraftIdentification != null))
            {
                if (filter == "")
                {
                    filter = "WHERE AircraftIdentification LIKE '" + AircraftIdentification + "%'";
                }
                else
                {
                    filter += " AND AircraftIdentification LIKE '" + AircraftIdentification + "%'";
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
            if ((Mode3A != "") && (Mode3A != null))
            {
                if (filter == "")
                {
                    filter = "WHERE Mode3A LIKE '" + Mode3A + "%'";
                }
                else
                {
                    filter += " AND Mode3A LIKE '" + Mode3A + "%'";
                }
            }
            if ((EmitterCategory != "") && (EmitterCategory != null))
            {
                if (filter == "")
                {
                    filter = "WHERE EmitterCategory = '" + EmitterCategory + "'";
                }
                else
                {
                    filter += " AND EmitterCategory = '" + EmitterCategory + "'";
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
            if ((AirportDepature != "") && (AirportDepature != null))
            {
                if (filter == "")
                {
                    filter = "WHERE AirportDepature LIKE '" + AirportDepature + "%'";
                }
                else
                {
                    filter += " AND AirportDepature LIKE '" + AirportDepature + "%'";
                }
            }
            if ((AirportArrival != "") && (AirportArrival != null))
            {
                if (filter == "")
                {
                    filter = "WHERE AirportArrival LIKE '" + AirportArrival + "%'";
                }
                else
                {
                    filter += " AND AirportArrival LIKE '" + AirportArrival + "%'";
                }
            }
            if ((BeginTime != "") && (EnableBeginTimePicker) && (BeginTime != null))
            {
                if (filter == "")
                {
                    filter = "WHERE BeginTime > '" + BeginTime + "'";
                }
                else
                {
                    filter += " AND BeginTime > '" + BeginTime + "'";
                }
            }
            if ((EndTime != "") && (EnableEndTimePicker) && (EndTime != null))
            {
                if (filter == "")
                {
                    filter = "WHERE EndTime < '" + EndTime + "'";
                }
                else
                {
                    filter += " AND EndTime < '" + EndTime + "'";
                }
            }
            if ((CAT != "") && (CAT != null))
            {
                if (filter == "")
                {
                    filter = "WHERE CAT LIKE '" + CAT + "%'";
                }
                else
                {
                    filter += " AND CAT LIKE '" + CAT + "%'";
                }
            }
            if ((SAC != "") && (SAC != null))
            {
                if (filter == "")
                {
                    filter = "WHERE SAC LIKE '" + SAC + "%'";
                }
                else
                {
                    filter += " AND SAC LIKE '" + SAC + "%'";
                }
            }
            if ((SIC != "") && (SIC != null))
            {
                if (filter == "")
                {
                    filter = "WHERE SIC LIKE '" + SIC + "%'";
                }
                else
                {
                    filter += " AND SIC LIKE '" + SIC + "%'";
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

            return filter;
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
        /// Контролирует состояние маршрутов. При необходимости изменяет статус на 'Завершен'.
        /// </summary>
        void timerThread()
        {
            SQL.query("UPDATE dbo.[Load] SET Status = 'Завершен' WHERE AddTime < DATEADD(MINUTE, -" + Convert.ToString(Protocol.UPDATESTATUSMINUTE) + ", GETDATE()) AND Status = 'Активен'");
            int newchcksum = checksum("Load");
            if (Loadchcksum != newchcksum)
            {
                Loadchcksum = newchcksum;
                ShowDataGridView(true, Convert.ToInt32(PageTextBox.Text));
            }
        }
        /// <summary>
        /// Запускает таймер контроля состояний маршрутов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTimer_Tick(object sender, System.EventArgs e)
        {
            new Thread(() =>
            {
                timerThread();
            }).Start();
        }

        /// <summary>
        /// Начальная установка LoadGridView.
        /// </summary>
        public void LoadGridViewSetting()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(LoadGridViewSetting));
                return;
            }

            LoadGridView.Columns["Id"].Visible = false;
            for (int column = 1; column < LoadGridView.ColumnCount; column++)
            {
                LoadGridView.Columns[column].Visible = true;
            }
        }
        /// <summary>
        /// Удаляет строки из БД, выбранные в LoadGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (userDeleting)
            {
                DataGridViewSelectedRowCollection deleteCollection = LoadGridView.SelectedRows;
                string delete = "DELETE FROM dbo.[Load] WHERE ";
                for (int i = 0; i < deleteCollection.Count; i++)
                {
                    if (i == 0)
                    {
                        delete += "Id = '" + Convert.ToString(LoadGridView["Id", deleteCollection[i].Index].Value) + "'";
                    }
                    else
                    {
                        delete += " OR Id = '" + Convert.ToString(LoadGridView["Id", deleteCollection[i].Index].Value) + "'";
                    }
                }
                SQL.query(delete);

                if (LoadGridView.SelectedRows.Count > 1)
                {
                    userDeleting = false;
                }

                int page = Convert.ToInt32(PageTextBox.Text);
                if (page > 1)
                {

                    ShowDataGridView(false, page - 1);
                }
                else
                {
                    ShowDataGridView(false, 1);
                }
                }

            if (LoadGridView.SelectedRows.Count == 1)
            {
                userDeleting = true;
            }
        }
        /// <summary>
        /// Двойной клик по маршруту. Отображает маршрут.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (e.RowIndex >= 0))
            {
                new Thread(() =>
                {
                    openGPXThread(e.RowIndex, true);
                }
                ).Start();
            }
        }
        /// <summary>
        /// Выбор маршрута клавишей Enter. Отображает маршрут.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;
                if (LoadGridView.CurrentRow != null)
                {
                    new Thread(() =>
                    {
                        openGPXThread(LoadGridView.CurrentRow.Index, true);
                    }
                    ).Start();
                }
            }
        }
        /// <summary>
        /// Фокус при наведении на LoadGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadGridView_MouseHover(object sender, EventArgs e)
        {
            LoadGridView.Focus();
        }
        /// <summary>
        /// Отображает LoadGridView с учетом фильтра.
        /// </summary>
        /// <param name="autoPosition">Фиксация положения в таблице. Использовать только при добавлении данных в таблицу (когда предыдущие строки не изменяются).</param>
        void ShowDataGridView(bool autoPosition, int page)
        {
            if (LoadGridView.InvokeRequired)
            {
                LoadGridView.BeginInvoke(new Action<bool, int>(ShowDataGridView), new object[] { autoPosition, page });
                return;
            }
            string f = filter();
            double AllPage = Convert.ToDouble(SQL.query("SELECT COUNT(*) FROM [Load] " + f).Rows[0][0]) / RowOfPage;
            if (AllPage > Math.Truncate(AllPage))
            {
                AllPage = Math.Truncate(AllPage) + 1;
            }
            if (AllPage == 0)
            {
                AllPage++;
            }
            UpdateDataGridView(SQL.query("SELECT TOP " + RowOfPage.ToString() + " * FROM (SELECT TOP " + Convert.ToString(page * RowOfPage) + " Id, TargetAddress AS 'ICAO24', Mode3A, AircraftIdentification AS 'Позывной', Registration AS 'Бортовой', EmitterCategory AS 'Категория', TypeAircraft AS 'Тип', Class AS 'Класс', Country AS 'Государство', AirportDepature AS 'Аэропорт вылета', AirportArrival AS 'Аэропорт прибытия', SAC, SIC, CAT, BeginTime AS 'Начало маршрута', EndTime AS 'Конец маршрута', Interval AS 'Продолжительность', Status AS 'Статус' FROM dbo.[Load] " + f + " ORDER BY [Id] desc) t ORDER BY [Id]"), autoPosition);
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
        /// Обновляет данные в LoadGridView.
        /// </summary>
        /// <param name="table">Таблица данных.</param>
        /// <param name="autoPosition">Фиксация положения в таблице. Использовать только при добавлении данных в таблицу (когда предыдущие строки не изменяются).</param>
        public void UpdateDataGridView(DataTable table, bool autoPosition)
        {
            if (LoadGridView.InvokeRequired)
            {
                LoadGridView.BeginInvoke(new Action<DataTable, bool>(UpdateDataGridView), new object[] { table, autoPosition });
                return;
            }
            int selectedId = 0;
                int firstRow = 0;
                int sortedColumn = 0;
                ListSortDirection sortDirection = ListSortDirection.Descending;

                if (LoadGridView.Rows.Count > 0)
                {
                    if (LoadGridView.CurrentCell != null)
                    {
                        selectedId = Convert.ToInt32(LoadGridView["Id", LoadGridView.CurrentCell.RowIndex].Value);
                    }
                    firstRow = LoadGridView.FirstDisplayedScrollingRowIndex;
                }

                if (LoadGridView.SortedColumn != null)
                {
                    sortedColumn = LoadGridView.SortedColumn.Index;
                    if (LoadGridView.SortOrder == System.Windows.Forms.SortOrder.Ascending)
                    {
                        sortDirection = ListSortDirection.Ascending;
                    }
                    else
                    {
                        sortDirection = ListSortDirection.Descending;
                    }
                }

                LoadGridView.DataSource = table;

                if (FirstSetting == false)
                {
                    for (int column = 0; column < LoadGridView.ColumnCount; column++)
                    {
                        LoadGridView.Columns[column].Visible = false;
                    }

                    LoadGridViewSetting();
                    FirstSetting = true;
                }

                LoadGridView.Sort(LoadGridView.Columns[sortedColumn], sortDirection);

                if (LoadGridView.Rows.Count > 0)
                {
                    if (autoPosition)
                    {
                        for (int row = 0; row < LoadGridView.Rows.Count; row++)
                        {
                            if (Convert.ToInt32(LoadGridView["Id", row].Value) == selectedId)
                            {
                                LoadGridView.CurrentCell = LoadGridView[1, row];
                                break;
                            }
                        }
                        LoadGridView.FirstDisplayedScrollingRowIndex = firstRow;
                    }
                }
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
                case "AircraftIdentification":
                    {
                        result = AircraftIdetificationTextBox.TextField;
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
                case "Mode3A":
                    {
                        result = Mode3ATextBox.TextField;
                        break;
                    }
                case "EmitterCategory":
                    {
                        result = EmitterCategoryComboBox.TextField;
                        break;
                    }
                case "Country":
                    {
                        result = CountryComboBox.TextField;
                        break;
                    }
                case "AirportDepature":
                    {
                        result = AirportDepatureTextBox.TextField;
                        break;
                    }
                case "AirportArrival":
                    {
                        result = AirportArrivalTextBox.TextField;
                        break;
                    }
                case "BeginTime":
                    {
                        result = BeginTimePicker.Value.ToShortDateString();
                        break;
                    }
                case "EndTime":
                    {
                        result = EndTimePicker.Value.ToShortDateString();
                        break;
                    }
                case "CAT":
                    {
                        result = CATcomboBox.TextField;
                        break;
                    }
                case "SAC":
                    {
                        result = SACtextBox.TextField;
                        break;
                    }
                case "SIC":
                    {
                        result = SICtextBox.TextField;
                        break;
                    }
                case "Class":
                    {
                        result = ClassComboBox.TextField;
                        break;
                    }
            }
            return result;
        }
        /// <summary>
        /// Заполняет ComboBox данными EmitterCategory.
        /// </summary>
        public void EmitterCategoryComboBoxFill()
        {
            if (EmitterCategoryComboBox.InvokeRequired)
            {
                EmitterCategoryComboBox.BeginInvoke(new Action(EmitterCategoryComboBoxFill));
                return;
            }
            EmitterCategoryComboBox.DataSource = new List<string>();
            DataTable Category;
            Category = SQL.query("SELECT DISTINCT(EmitterCategory) FROM dbo.[Load] WHERE EmitterCategory <> '' ORDER BY(EmitterCategory)");

            EmitterCategoryComboBox.Add("");
            for (int row = 0; row < Category.Rows.Count; row++)
            {
                EmitterCategoryComboBox.Add(Convert.ToString(Category.Rows[row][0]));
            }
        }
        /// <summary>
        /// Заполняет ComboBox данными Country.
        /// </summary>
        public void CountryComboBoxFill()
        {
            if (CountryComboBox.InvokeRequired)
            {
                CountryComboBox.BeginInvoke(new Action(CountryComboBoxFill));
                return;
            }
            CountryComboBox.DataSource = new List<string>();
            DataTable Country = SQL.query("SELECT DISTINCT(Country) FROM dbo.[Load] WHERE Country <> '' ORDER BY(Country)");
            CountryComboBox.Add("");
            for (int row = 0; row < Country.Rows.Count; row++)
            {
                CountryComboBox.Add(Convert.ToString(Country.Rows[row][0]));
            }
        }
        /// <summary>
        /// Заполняет ComboBox данными CAT.
        /// </summary>
        public void CATcomboBoxFill()
        {
            if (CATcomboBox.InvokeRequired)
            {
                CATcomboBox.BeginInvoke(new Action(CATcomboBoxFill));
                return;
            }
            CATcomboBox.DataSource = new List<string>();
            DataTable CAT = SQL.query("SELECT DISTINCT(CAT) FROM dbo.[Load] WHERE CAT <> '' ORDER BY(CAT)");
            CATcomboBox.Add("");
            for (int row = 0; row < CAT.Rows.Count; row++)
            {
                CATcomboBox.Add(Convert.ToString(CAT.Rows[row][0]));
            }
        }
        /// <summary>
        /// Заполняет ComboBox данными Class.
        /// </summary>
        public void ClassComboBoxFill()
        {
            if (ClassComboBox.InvokeRequired)
            {
                ClassComboBox.BeginInvoke(new Action(ClassComboBoxFill));
                return;
            }
            ClassComboBox.DataSource = new List<string>();
            DataTable Class = SQL.query("SELECT DISTINCT(Class) FROM dbo.[Load] WHERE Class <> '' ORDER BY(Class)");
            ClassComboBox.Add("");
            for (int row = 0; row < Class.Rows.Count; row++)
            {
                ClassComboBox.Add(Convert.ToString(Class.Rows[row][0]));
            }
        }

        /// <summary>
        /// Обновляет LoadGridView при изменении текста в TargetAddressTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TargetAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                ShowDataGridView(false, 1);
            }
        }
        /// <summary>
        /// Обновляет LoadGridView при изменении текста в AircraftIdetificationTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AircraftIdetificationTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                ShowDataGridView(false, 1);
            }
        }
        /// <summary>
        /// Обновляет LoadGridView при изменении текста в AirportDepatureTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AirportDepatureTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                ShowDataGridView(false, 1);
            }
        }
        /// <summary>
        /// Обновляет LoadGridView при изменении текста в AirportArrivalTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AirportArrivalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                ShowDataGridView(false, 1);
            }
        }
        /// <summary>
        /// Обновляет LoadGridView при изменении текста в RegistrationTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistrationTextBox_ControlTextChanged(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                ShowDataGridView(false, 1);
            }
        }
        /// <summary>
        /// Обновляет LoadGridView при изменении текста в TypeAircraftTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TypeAircraftTextBox_ControlTextChanged(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                ShowDataGridView(false, 1);
            }
        }
        /// <summary>
        /// Обновляет LoadGridView при изменении текста в Mode3ATextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mode3ATextBox_ControlTextChanged(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                ShowDataGridView(false, 1);
            }
        }
        /// <summary>
        /// Обновляет LoadGridView при изменении текста в SACtextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SACtextBox_ControlTextChanged(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                ShowDataGridView(false, 1);
            }
        }
        /// <summary>
        /// Обновляет LoadGridView при изменении текста в SICtextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SICtextBox_ControlTextChanged(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                ShowDataGridView(false, 1);
            }
        }
        /// <summary>
        /// Обновляет содержимое ComboBox по установке фокуса.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmitterCategoryComboBox_Enter(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                EmitterCategoryComboBoxFill();
                EmitterCategoryComboBox.DroppedDown = true;
            }
        }
        /// <summary>
        /// Обновляет LoadGridView при выборе EmitterCategory в EmitterCategoryComboBox. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmitterCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                ShowDataGridView(false, 1);
            }
        }
        /// <summary>
        /// LoadGridView при выборе Country в CountryComboBox. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CountryComboBox_Enter(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                CountryComboBoxFill();
                CountryComboBox.DroppedDown = true;
            }
        }
        /// <summary>
        /// Обновляет содержимое ComboBox по клику.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CountryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                ShowDataGridView(false, 1);
            }
        }
        /// <summary>
        /// LoadGridView при выборе CAT в CATcomboBox. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CATcomboBox_Enter(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                CATcomboBoxFill();
                CATcomboBox.DroppedDown = true;
            }
        }
        /// <summary>
        /// Обновляет содержимое ComboBox по клику.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CATcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                ShowDataGridView(false, 1);
            }
        }
        /// <summary>
        /// LoadGridView при выборе Class в ClassComboBox. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassComboBox_Enter(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                ClassComboBoxFill();
                ClassComboBox.DroppedDown = true;
            }
        }
        /// <summary>
        /// Обновляет содержимое ComboBox по клику.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                ShowDataGridView(false, 1);
            }
        }

        /// <summary>
        /// Обновляет LoadGridView при развертывании календаря.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndTimePicker_DropDown(object sender, EventArgs e)
        {
            EnableEndTimePicker = true;
            ShowDataGridView(false, 1);
        }
        /// <summary>
        ///  Обновляет LoadGridView по клику на календарь.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndTimePicker_MouseDown(object sender, MouseEventArgs e)
        {
            if (EnableEndTimePicker != EndTimePicker.Checked)
            {
                EnableEndTimePicker = !EnableEndTimePicker;
                ShowDataGridView(false, 1);
            }
        }
        /// <summary>
        ///  Обновляет LoadGridView при изменении значения календаря.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                ShowDataGridView(false, 1);
            }
        }

        /// <summary>
        /// Обновляет LoadGridView при развертывании календаря.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeginTimePicker_DropDown(object sender, EventArgs e)
        {
            EnableBeginTimePicker = true;
            ShowDataGridView(false, 1);
        }
        /// <summary>
        /// Обновляет LoadGridView по клику на календарь.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeginTimePicker_MouseDown(object sender, MouseEventArgs e)
        {
            if (EnableBeginTimePicker != BeginTimePicker.Checked)
            {
                EnableBeginTimePicker = !EnableBeginTimePicker;
                ShowDataGridView(false, 1);
            }
        }
        /// <summary>
        /// Обновляет LoadGridView при изменении значения календаря.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeginTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!clearBox)
            {
                ShowDataGridView(false, 1);
            }
        }

        /// <summary>
        /// Убирает фокус с кнопки фильтра.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideSearchBTN_MouseDown(object sender, MouseEventArgs e)
        {
            SearchPanel.Focus();
        }
        /// <summary>
        /// Открывает/Закрывает панель фильтра.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideSearchBTN_MouseUp(object sender, MouseEventArgs e)
        {
            if (SearchSplitterLock)
            {
                HideSearchBTN.Text = "Фильтр";
                SearchSplitterLock = false;
                SearchContainer.IsSplitterFixed = false;
                SearchContainer.Panel1MinSize = 100;
                SearchContainer.SplitterDistance = SearchSplitterPosition;
            }
            else
            {
                HideSearchBTN.Text = "Нажмите для настройки фильтра";
                SearchSplitterLock = true;
                SearchContainer.IsSplitterFixed = true;
                SearchContainer.Panel1MinSize = HideSearchBTN.Size.Height;
                SearchSplitterPosition = SearchContainer.SplitterDistance;
                SearchContainer.SplitterDistance = HideSearchBTN.Size.Height;
            }
        }
        void HideSearchBTNInit()
        {
            SearchContainer.SplitterDistance = SearchSplitterPosition;
            HideSearchBTN_MouseUp(null, null);
        }

        /// <summary>
        /// Закрывает все открытые comboBox.
        /// </summary>
        public void closeAllCombobox()
        {
            if (EmitterCategoryComboBox.DroppedDown)
            {
                EmitterCategoryComboBox.DroppedDown = false;
            }
            if (CountryComboBox.DroppedDown)
            {
                CountryComboBox.DroppedDown = false;
            }
            if (CATcomboBox.DroppedDown)
            {
                CATcomboBox.DroppedDown = false;
            }
            if (ClassComboBox.DroppedDown)
            {
                ClassComboBox.DroppedDown = false;
            }
        }
        /// <summary>
        /// Закрывает открытые comboBox по клику на панель поиска.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTableLayoutPanel_Click(object sender, EventArgs e)
        {
            closeAllCombobox();
        }

        /// <summary>
        /// Убирает фокус с кнопки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearFilterBTN_MouseUp(object sender, MouseEventArgs e)
        {
            TargetAddressTextBox.Focus();
        }
        /// <summary>
        /// Очищает фильтр.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearFilterBTN_MouseDown(object sender, MouseEventArgs e)
        {
            clearBox = true;
            TargetAddressTextBox.Clear();
            AircraftIdetificationTextBox.Clear();
            RegistrationTextBox.Clear();
            EmitterCategoryComboBox.Clear();
            TypeAircraftTextBox.Clear();
            Mode3ATextBox.Clear();
            CountryComboBox.Clear();
            AirportDepatureTextBox.Clear();
            AirportArrivalTextBox.Clear();
            BeginTimePicker.Value = DateTime.Now;
            EndTimePicker.Checked = false;
            CATcomboBox.Clear();
            SACtextBox.Clear();
            SICtextBox.Clear();
            ClassComboBox.Clear();
            clearBox = false;
            ShowDataGridView(false, 1);
        }

        /// <summary>
        /// Убирает фокус.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_MouseDown(object sender, MouseEventArgs e)
        {
            PagePanel.Focus();
        }
        private void Up_MouseDown(object sender, MouseEventArgs e)
        {
            PagePanel.Focus();
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
            ShowDataGridView(false, page);
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
            ShowDataGridView(false, page);
        }

        #endregion

        #region Карта

        int RouteSplitterPosition = 300;
        bool RouteSplitterLock = false;
        GMapOverlay routeOverlay = new GMapOverlay("route");

        /// <summary>
        /// Убирает фокус с кнопки маршрутов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideRouteBTN_MouseDown(object sender, MouseEventArgs e)
        {
            RouteControl.Focus();
        }
        /// <summary>
        /// Открывает/Закрывает панель маршрутов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideRouteBTN_MouseUp(object sender, MouseEventArgs e)
        {
            if (RouteSplitterLock)
            {
                RouteSplitterLock = false;
                RouteContainer.IsSplitterFixed = false;
                RouteContainer.Panel1MinSize = 100;
                RouteContainer.SplitterDistance = RouteSplitterPosition;
            }
            else
            {
                RouteSplitterLock = true;
                RouteContainer.IsSplitterFixed = true;
                RouteContainer.Panel1MinSize = HideRouteBTN.Size.Width;
                RouteSplitterPosition = RouteContainer.SplitterDistance;
                RouteContainer.SplitterDistance = HideRouteBTN.Size.Width;
            }
        }

        /// <summary>
        /// Инициализирует открывающуюся панель.
        /// </summary>
        void HideRouteBTNInit()
        {
            RouteContainer.SplitterDistance = RouteSplitterPosition;
            HideRouteBTN_MouseUp(null, null);
        }
        /// <summary>
        /// Инициализирует RouteGridView.
        /// </summary>
        void RoteGridViewInit()
        {
            DataGridViewComboBoxColumn colorColumn = new DataGridViewComboBoxColumn();
            colorColumn.Name = "Color";
            colorColumn.FlatStyle = FlatStyle.Flat;

            colorColumn.Items.Add(Color.Orange);
            colorColumn.Items.Add(Color.Blue);

            DataGridViewCheckBoxColumn fixColumn = new DataGridViewCheckBoxColumn();
            fixColumn.Name = "Fix";

            RouteGridView.Columns.Add("Id", "Id");
            RouteGridView.Columns.Add("TargetAddress", "TargetAddress");
            RouteGridView.Columns.Add(colorColumn);
            RouteGridView.Columns.Add(fixColumn);

            RouteGridView.Columns["Id"].ValueType = typeof(string);
            RouteGridView.Columns["TargetAddress"].ValueType = typeof(string);

            RouteGridView.Columns["Id"].Visible = false;
            RouteGridView.Columns["Color"].Visible = false;
            RouteGridView.Columns["Fix"].Visible = false;

            RouteGridView.Columns["TargetAddress"].ReadOnly = true;
        }
        /// <summary>
        /// Инициализирует карту.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gMapControl_Load(object sender, EventArgs e)
        {
            gMapControl.Bearing = 0;

            gMapControl.CanDragMap = true;
            gMapControl.DragButton = MouseButtons.Left;

            gMapControl.GrayScaleMode = true;

            gMapControl.MarkersEnabled = true;

            gMapControl.MaxZoom = 18;
            gMapControl.MinZoom = 2;

            gMapControl.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;

            gMapControl.NegativeMode = false;

            gMapControl.RoutesEnabled = true;

            gMapControl.ShowTileGridLines = false;

            gMapControl.Zoom = 5;

            gMapControl.Dock = DockStyle.Fill;

            gMapControl.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.CacheOnly;
            GMaps.Instance.ImportFromGMDB("Data.gmdb");

            gMapControl.Overlays.Add(routeOverlay);
        }

        /// <summary>
        /// Добавляет маршрут к overlay
        /// </summary>
        /// <param name="routeOverlay">overlay</param>
        /// <param name="xml">gpx</param>
        void AddRoute(GMapOverlay routeOverlay, string xml, string id)
        {
            gpxType gpx = GMaps.Instance.DeserializeGPX(xml);
            rteType[] rte = gpx.rte;

            for (int route = 0; route < rte.Length; route++)
            {
                List<PointLatLng> PoinList = new List<PointLatLng>();
                for (int i = 0; i < rte[route].rtept.Length; i++)
                {
                    PointLatLng point = new PointLatLng(Convert.ToDouble(rte[route].rtept[i].lat), Convert.ToDouble(rte[route].rtept[i].lon));
                    PoinList.Add(point);
                }

                GMapRoute r = new GMapRoute(PoinList, id);
                r.Stroke.Width = 2;
                r.Stroke.Color = Color.Orange;

                routeOverlay.Routes.Add(r);
            }
        }
        /// <summary>
        /// Отображает выбранный маршрут.
        /// </summary>
        /// <param name="RowIndex">Индекс выбранной строки в LoadGridView.</param>
        void openGPXThread(object RowIndex, bool autoFocus)
        {
            string TargetAddress = Convert.ToString(LoadGridView["ICAO24", Convert.ToInt32(RowIndex)].Value);
            try
            {
                string Id = Convert.ToString(LoadGridView["Id", Convert.ToInt32(RowIndex)].Value);
                string xml = Convert.ToString(SQL.query("SELECT GPX FROM [LOAD] WHERE ID = '" + Id + "'").Rows[0][0]);

                Action action = () =>
                {
                    AddRoute(routeOverlay, xml, Id);
                    RouteGridView.Rows.Add(new object[] { Id, TargetAddress, Color.Blue, false });

                    if (autoFocus)
                    {
                        gMapControl.Position = routeOverlay.Routes.Last().Points.Last();
                        RouteGridView.CurrentCell = RouteGridView.Rows[RouteGridView.Rows.Count - 1].Cells["TargetAddress"];
                    }
                };
                gMapControl.BeginInvoke(action);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Удаляет маршрут из overlay.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RouteGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            GMapRoute deleting = null;
            for (int route = 0; route < routeOverlay.Routes.Count; route++) {

                if (routeOverlay.Routes[route].Name == Convert.ToString(e.Row.Cells["Id"].Value))
                {
                    deleting = routeOverlay.Routes[route];
                    break;
                }
            }
            routeOverlay.Routes.Remove(deleting);
        }

        /// <summary>
        /// Устанавливает фокус на выбранный маршрут.
        /// </summary>
        void setFocusRoute()
        {
            Action action = () =>
            {
                if (RouteGridView.SelectedRows.Count > 0)
                {
                    for (int route = 0; route < routeOverlay.Routes.Count; route++)
                    {
                        if (routeOverlay.Routes[route].Name == Convert.ToString(RouteGridView.SelectedRows[0].Cells["Id"].Value))
                        {
                            gMapControl.Position = routeOverlay.Routes[route].Points.Last();
                            break;
                        }
                    }
                }
            };
            gMapControl.BeginInvoke(action);
        }
        private void RouteGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            new Thread(() =>
            {
                setFocusRoute();
                Thread.CurrentThread.Abort();
            }).Start();
        }
        private void RouteGridView_SelectionChanged(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                setFocusRoute();
                Thread.CurrentThread.Abort();
            }).Start();
        }
        private void RouteGridView_MouseEnter(object sender, EventArgs e)
        {
            RouteGridView.Focus();
        }

        /// <summary>
        /// Строит график высот.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RouteGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new Graphics(Convert.ToString(RouteGridView.Rows[e.RowIndex].Cells["Id"].Value));
        }

        /// <summary>
        /// Убирает фокус с кнопки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toMapBTN_MouseUp(object sender, MouseEventArgs e)
        {
            TargetAddressTextBox.Focus();
        }
        /// <summary>
        /// Выводит содержимое LoadGridView на карту.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toMapBTN_MouseDown(object sender, MouseEventArgs e)
        {
            new Thread(() => {
                for (int RowIndex = 0; RowIndex < LoadGridView.Rows.Count; RowIndex++)
                {
                    openGPXThread(RowIndex, false);
                }
            }).Start();
        }

        #endregion

        public Map()
        {
            InitializeComponent();

            HideSearchBTNInit();
            HideRouteBTNInit();

            RoteGridViewInit();

            Loadchcksum = checksum("Load");
            ShowDataGridView(false, 1);

            UpdateTimer.Interval = UPDATEGRIDMILLISECONDS;
            UpdateTimer.Enabled = true;
        }

    }
}
