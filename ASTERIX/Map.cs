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
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

namespace ASTERIX
{
    public partial class Map : Form
    {
        #region База

        int Loadchcksum;
        int Markerschcksum;
        int Polygonschcksum;
        bool clearBox = false;
        bool FirstSetting = false;
        bool userDeleting = true;
        static int UPDATEGRIDMILLISECONDS;
        int SearchSplitterPosition = 100;
        bool SearchSplitterLock = false;
        static int RowOfPage;

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
            if ((BeginTime != "") && (BeginTimePicker.Checked) && (BeginTime != null))
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
            if ((EndTime != "") && (EndTimePicker.Checked) && (EndTime != null))
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
            int newLoadchcksum = checksum("Load");
            if (Loadchcksum != newLoadchcksum)
            {
                Loadchcksum = newLoadchcksum;
                ShowDataGridView(true, Convert.ToInt32(PageTextBox.Text));
                UpdateRoute(routeOverlay);
            }
            int newMarkerschcksum = checksum("Markers");
            if (Markerschcksum != newMarkerschcksum)
            {
                Markerschcksum = newMarkerschcksum;
                UpdateMarkerGridView();
            }
            int newPolygonschcksum = checksum("Polygons");
            if (Polygonschcksum != newPolygonschcksum)
            {
                Polygonschcksum = newPolygonschcksum;
                UpdatePolygonGridView();
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
            }

            if (LoadGridView.SelectedRows.Count == 1)
            {
                userDeleting = true;

                UpdateRoute(routeOverlay);
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
                    ClearNotFixedRoute(routeOverlay);
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
                        ClearNotFixedRoute(routeOverlay);
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


                if (LoadGridView.FirstDisplayedScrollingRowIndex >= 0)
                {
                    firstRow = LoadGridView.FirstDisplayedScrollingRowIndex;
                }
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
        /// Обновляет переменные.
        /// </summary>
        public void UpdateVariable()
        {
            ShowDataGridView(true, Convert.ToInt32(PageTextBox.Text));

            UpdateTimer.Interval = UPDATEGRIDMILLISECONDS;
            UpdateTimer.Enabled = true;
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
            ShowDataGridView(false, 1);
        }
        /// <summary>
        ///  Обновляет LoadGridView по клику на календарь.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndTimePicker_MouseDown(object sender, MouseEventArgs e)
        {
            if (EndTimePicker.Checked)
            {
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
            ShowDataGridView(false, 1);
        }
        /// <summary>
        /// Обновляет LoadGridView по клику на календарь.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeginTimePicker_MouseDown(object sender, MouseEventArgs e)
        {
            if (BeginTimePicker.Checked)
            {
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
        static Color DefaultColor;
        static Color SelectedColor;
        static Color DefaultPolygonColor;
        static Color DefaultMarkerColor;
        public static Color[] colors = { Color.DarkRed, Color.Red, Color.Orange, Color.Yellow, Color.YellowGreen, Color.DarkGreen, Color.Aqua, Color.Blue, Color.Purple, Color.DeepPink };
        public static Color[] Markercolors = { Color.LightBlue, Color.Blue, Color.Green, Color.Orange, Color.Pink, Color.Purple, Color.Red, Color.Yellow };

        GMapOverlay routeOverlay = new GMapOverlay("route");
        GMapOverlay polyOverlay = new GMapOverlay("polygons");
        GMapOverlay markersOverlay = new GMapOverlay("markers");

        string Tool = "Free";

        #region Маршруты
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
            foreach (Color clr in colors)
            {
                colorColumn.Items.Add("");
            }

            DataGridViewCheckBoxColumn fixColumn = new DataGridViewCheckBoxColumn();
            fixColumn.Name = "Fix";

            RouteGridView.Columns.Add("Id", "Id");
            RouteGridView.Columns.Add("CRC", "CRC");
            RouteGridView.Columns.Add("TargetAddress", "TargetAddress");
            RouteGridView.Columns.Add(colorColumn);
            RouteGridView.Columns.Add(fixColumn);

            RouteGridView.Columns["Id"].Visible = false;
            RouteGridView.Columns["CRC"].Visible = false;

            RouteGridView.Columns["Color"].Width = 20;
            RouteGridView.Columns["Fix"].Width = 30;

            RouteGridView.Columns["TargetAddress"].ReadOnly = true;
        }

        /// <summary>
        /// Добавляет маршрут к overlay
        /// </summary>
        /// <param name="routeOverlay">overlay</param>
        /// <param name="xml">gpx</param>
        GMapRoute GetRoute(string xml, string id)
        {
            GMapRoute r = null;
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

                r = new GMapRoute(PoinList, id);
                r.IsHitTestVisible = true;
                r.Stroke = new Pen(DefaultColor, 2);
            }

            return r;
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
                string CRC = Convert.ToString(SQL.query("SELECT GETCHECKSUM() FROM [LOAD] WHERE ID = '" + Id + "'").Rows[0][0]);
                string xml = Convert.ToString(SQL.query("SELECT GPX FROM [LOAD] WHERE ID = '" + Id + "'").Rows[0][0]);
                string name = Convert.ToString(SQL.query("SELECT TargetAddress FROM [LOAD] WHERE ID = '" + Id + "'").Rows[0][0]);

                Action action = () =>
                {
                    GMapRoute route = GetRoute(xml, Id);
                    routeOverlay.Markers.Add(new GMarkerCross(route.Points.Last()) { ToolTipText = name, IsVisible = false, ToolTipMode = MarkerTooltipMode.Always });
                    routeOverlay.Routes.Add(route);

                    RouteGridView.Rows.Add();
                    RouteGridView.Rows[RouteGridView.Rows.Count - 1].Cells["Id"].Value = Id;
                    RouteGridView.Rows[RouteGridView.Rows.Count - 1].Cells["CRC"].Value = CRC;
                    RouteGridView.Rows[RouteGridView.Rows.Count - 1].Cells["TargetAddress"].Value = TargetAddress;
                    RouteGridView.Rows[RouteGridView.Rows.Count - 1].Cells["Fix"].Value = false;
                    ((DataGridViewComboBoxCell)(RouteGridView.Rows[RouteGridView.Rows.Count - 1].Cells["Color"])).Value = "";
                    ((DataGridViewComboBoxCell)(RouteGridView.Rows[RouteGridView.Rows.Count - 1].Cells["Color"])).Style.BackColor = DefaultColor;

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
        /// Обновляет маршруты.
        /// </summary>
        /// <param name="routeOverlay"></param>
        void UpdateRoute(GMapOverlay routeOverlay)
        {
            if (gMapControl.InvokeRequired)
            {
                gMapControl.BeginInvoke(new Action<GMapOverlay>(UpdateRoute), new object[] { routeOverlay });
                return;
            }
            for (int route = RouteGridView.Rows.Count - 1; route >= 0; route--)
            {
                string Id = Convert.ToString(RouteGridView["Id", route].Value);
                string OldCRC = Convert.ToString(RouteGridView["CRC", route].Value);

                if (Convert.ToInt32(SQL.query("SELECT COUNT(GPX) FROM [LOAD] WHERE ID = '" + Id + "'").Rows[0][0]) > 0)
                {
                    string NewCRC = Convert.ToString(SQL.query("SELECT GETCHECKSUM() FROM [LOAD] WHERE ID = '" + Id + "'").Rows[0][0]);

                    if (OldCRC != NewCRC)
                    {
                        for (int trek = 0; trek < routeOverlay.Routes.Count; trek++)
                        {
                            if (routeOverlay.Routes[trek].Name == Id)
                            {
                                string xml = Convert.ToString(SQL.query("SELECT GPX FROM [LOAD] WHERE ID = '" + Id + "'").Rows[0][0]);
                                GMapRoute newRoute = GetRoute(xml, Id);

                                routeOverlay.Markers[trek].Position = newRoute.Points.Last();
                                routeOverlay.Routes[trek].Points.Clear();
                                routeOverlay.Routes[trek].Points.AddRange(newRoute.Points);

                                RouteGridView["CRC", trek].Value = NewCRC;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    for (int trek = 0; trek < routeOverlay.Routes.Count; trek++)
                    {
                        if (routeOverlay.Routes[trek].Name == Id)
                        {
                            routeOverlay.Markers.Remove(routeOverlay.Markers[routeOverlay.Routes.IndexOf(routeOverlay.Routes[trek])]);
                            routeOverlay.Routes.Remove(routeOverlay.Routes[trek]);
                            RouteGridView.Rows.Remove(RouteGridView.Rows[trek]);
                            break;
                        }
                    }
                }
            }
            routeOverlay.IsVisibile = false;
            routeOverlay.IsVisibile = true;
        }
        /// <summary>
        /// Изменяет цвет маршрута.
        /// </summary>
        /// <param name="routeOverlay"></param>
        /// <param name="Id"></param>
        /// <param name="newColor"></param>
        void UpdateColorRoute(GMapOverlay routeOverlay, string Id, Color newColor)
        {
            for (int route = 0; route < routeOverlay.Routes.Count; route++)
            {
                if (routeOverlay.Routes[route].Name == Id)
                {
                    routeOverlay.Routes[route].Stroke.Color = newColor;

                    routeOverlay.IsVisibile = false;
                    routeOverlay.IsVisibile = true;
                    break;
                }
            }
        }

        /// <summary>
        /// Удаляет не зафиксированные маршруты.
        /// </summary>
        /// <param name="routeOverlay"></param>
        void ClearNotFixedRoute(GMapOverlay routeOverlay)
        {
            if (RouteGridView.InvokeRequired)
            {
                RouteGridView.BeginInvoke(new Action<GMapOverlay>(ClearNotFixedRoute), new object[] { routeOverlay });
                return;
            }
            for (int route = routeOverlay.Routes.Count - 1; route >= 0; route--)
            {
                if ((bool)(RouteGridView["Fix", route].Value) == false)
                {
                    routeOverlay.Markers.Remove(routeOverlay.Markers[routeOverlay.Routes.IndexOf(routeOverlay.Routes[route])]);
                    routeOverlay.Routes.Remove(routeOverlay.Routes[route]);
                    RouteGridView.Rows.Remove(RouteGridView.Rows[route]);
                }
            }
        }

        /// <summary>
        /// Устанавливает фокус на выбранный маршрут.
        /// </summary>
        void setFocusRoute()
        {
            if (gMapControl.InvokeRequired)
            {
                gMapControl.BeginInvoke(new Action(setFocusRoute));
                return;
            }
            if (RouteGridView.CurrentCell != null)
            {
                for (int route = 0; route < routeOverlay.Routes.Count; route++)
                {
                    if (routeOverlay.Routes[route].Name == Convert.ToString(RouteGridView.CurrentCell.OwningRow.Cells["Id"].Value))
                    {
                        routeOverlay.Routes[route].Stroke.Color = SelectedColor;
                        gMapControl.Position = routeOverlay.Routes[route].Points.Last();
                    }
                    else
                    {
                        routeOverlay.Routes[route].Stroke.Color = ((DataGridViewComboBoxCell)(RouteGridView["Color", route])).Style.BackColor;
                    }
                }
                routeOverlay.IsVisibile = false;
                routeOverlay.IsVisibile = true;
            }
        }
        private void RouteGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            new Thread(() =>
            {
                setFocusRoute();
            }).Start();
        }
        private void RouteGridView_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in RouteGridView.SelectedCells)
            {
                if ((cell.OwningColumn.Name == "Color") || (cell.OwningColumn.Name == "Fix"))
                {
                    cell.Selected = false;
                    cell.OwningRow.Cells["TargetAddress"].Selected = true;
                }
            }
            new Thread(() =>
            {
                setFocusRoute();
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
        /// Обрабатывает нажатия клавиш.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RouteGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;
                if (RouteGridView.CurrentCell != null)
                {
                    new Graphics(Convert.ToString(RouteGridView.CurrentCell.OwningRow.Cells["Id"].Value));
                }
            }
            if (e.KeyData == Keys.Delete)
            {
                foreach (DataGridViewCell cell in RouteGridView.SelectedCells)
                {
                    if (cell.OwningColumn.Name == "TargetAddress")
                    {
                        GMapRoute deleting = null;
                        for (int route = 0; route < routeOverlay.Routes.Count; route++)
                        {
                            if (routeOverlay.Routes[route].Name == Convert.ToString(cell.OwningRow.Cells["Id"].Value))
                            {
                                deleting = routeOverlay.Routes[route];
                                break;
                            }
                        }
                        routeOverlay.Markers.Remove(routeOverlay.Markers[routeOverlay.Routes.IndexOf(deleting)]);
                        routeOverlay.Routes.Remove(deleting);
                        RouteGridView.Rows.Remove(cell.OwningRow);
                    }
                }
            }
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
                ClearNotFixedRoute(routeOverlay);
                for (int RowIndex = 0; RowIndex < LoadGridView.Rows.Count; RowIndex++)
                {
                    openGPXThread(RowIndex, false);
                }
            }).Start();
        }

        /// <summary>
        /// Заполняет comboBox выборанным цветом.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RouteGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (RouteGridView.CurrentCell is DataGridViewComboBoxCell)
            {
                RouteGridView.CurrentCell.Style.BackColor = colors[((DataGridViewComboBoxEditingControl)RouteGridView.EditingControl).SelectedIndex];

                string Id = (string)RouteGridView.CurrentCell.OwningRow.Cells["Id"].Value;
                UpdateColorRoute(routeOverlay, Id, RouteGridView.CurrentCell.Style.BackColor);
            }
        }
        /// <summary>
        /// Добавляет обработчики событий к comboBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RouteGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name == "Color")
            {
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    cb.DrawItem += new System.Windows.Forms.DrawItemEventHandler(cb_DrawItem);
                    cb.DrawMode = DrawMode.OwnerDrawFixed;
                }
            }
        }
        /// <summary>
        /// Заполняет comboBox цветами.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_DrawItem(object sender, DrawItemEventArgs e)
        {
            using (Brush br = new SolidBrush(colors[e.Index]))
            {
                e.Graphics.FillRectangle(br, e.Bounds);
            }
        }

        /// <summary>
        /// Клик по маршруту.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="e"></param>
        private void gMapControl_OnRouteClick(GMapRoute item, MouseEventArgs e)
        {
            DataGridViewRow routeRow = null;
            for (int cell = 0; cell < RouteGridView.Rows.Count; cell++)
            {
                if (RouteGridView["Id", cell].Value.ToString() == item.Name)
                {
                    if (RouteGridView.CurrentCell != null)
                    {
                        RouteGridView.CurrentCell.OwningRow.Selected = false;
                    }
                    routeRow = RouteGridView.Rows[cell];
                    RouteGridView.Rows[cell].Selected = true;
                    RouteGridView.CurrentCell = RouteGridView["TargetAddress", cell];
                    break;
                }
            }
            setFocusRoute();

            Color color = ((DataGridViewComboBoxCell)(routeRow.Cells["Color"])).Style.BackColor;
            Edit edit = new Edit("route", color, RouteGridView.CurrentCell.OwningRow.Cells["TargetAddress"].Value.ToString(), "ГРАФИК ВЫСОТЫ");
            edit.ShowDialog();

            string onClick = edit.onClick;
            switch (onClick)
            {
                case "OK":
                    {
                        string name = edit.name;
                        color = edit.color;

                        item.Stroke.Color = color;
                        ((DataGridViewComboBoxCell)(routeRow.Cells["Color"])).Style.BackColor = color;
                        break;
                    }
                case "GRAPHICS":
                    {
                        new Graphics(item.Name);
                        break;
                    }
                case "DELETE":
                    {
                        routeOverlay.Markers.Remove(routeOverlay.Markers[routeOverlay.Routes.IndexOf(item)]);
                        routeOverlay.Routes.Remove(item);
                        RouteGridView.Rows.Remove(RouteGridView.CurrentCell.OwningRow);
                        break;
                    }
            }
        }

        /// <summary>
        /// Вывод названия маршрута.
        /// </summary>
        /// <param name="item"></param>
        private void gMapControl_OnRouteEnter(GMapRoute item)
        {
            routeOverlay.Markers[routeOverlay.Routes.IndexOf(item)].IsVisible = true;
        }
        private void gMapControl_OnRouteLeave(GMapRoute item)
        {
            routeOverlay.Markers[routeOverlay.Routes.IndexOf(item)].IsVisible = false;
        }
        #endregion

        #region Шаблоны
        /// <summary>
        /// Инициализирует PolygonGridView.
        /// </summary>
        void PolygonGridViewInit()
        {
            DataGridViewComboBoxColumn colorColumn = new DataGridViewComboBoxColumn();
            colorColumn.Name = "Color";
            colorColumn.FlatStyle = FlatStyle.Flat;
            foreach (Color clr in colors)
            {
                colorColumn.Items.Add("");
            }

            DataGridViewCheckBoxColumn fixColumn = new DataGridViewCheckBoxColumn();
            fixColumn.Name = "Fix";

            PolygonGridView.Columns.Add("Id", "Id");
            PolygonGridView.Columns.Add("Name", "Name");
            PolygonGridView.Columns.Add("gpx", "gpx");
            PolygonGridView.Columns.Add(colorColumn);
            PolygonGridView.Columns.Add(fixColumn);

            PolygonGridView.Columns["Id"].Visible = false;
            PolygonGridView.Columns["gpx"].Visible = false;

            PolygonGridView.Columns["Color"].Width = 20;
            PolygonGridView.Columns["Fix"].Width = 30;

            PolygonGridView.Columns["Name"].ReadOnly = true;
        }

        /// <summary>
        /// Обновляет таблицу полигонов.
        /// </summary>
        void UpdatePolygonGridView()
        {
            if (PolygonGridView.InvokeRequired)
            {
                PolygonGridView.BeginInvoke(new Action(UpdatePolygonGridView));
                return;
            }
            DataTable polygons = SQL.query("SELECT [Id], [Name], [Color] FROM dbo.[Polygons]");
            List<string> OnPolygon = new List<string>();
            foreach (DataGridViewRow row in PolygonGridView.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Fix"].Value) == true)
                {
                    OnPolygon.Add(row.Cells["Id"].Value.ToString());
                }
            }
            string selectedId = null;
            if (PolygonGridView.SelectedCells.Count > 0)
            {
                selectedId = PolygonGridView.SelectedCells[0].OwningRow.Cells["Id"].Value.ToString();
            }
            this.PolygonGridView.CurrentCellDirtyStateChanged -= new System.EventHandler(this.PolygonGridView_CurrentCellDirtyStateChanged);
            PolygonGridView.Rows.Clear();

            for (int pol = 0; pol < polygons.Rows.Count; pol++)
            {
                PolygonGridView.Rows.Add();
                PolygonGridView.Rows[PolygonGridView.Rows.Count - 1].Cells["Id"].Value = polygons.Rows[pol]["Id"];
                PolygonGridView.Rows[PolygonGridView.Rows.Count - 1].Cells["Name"].Value = polygons.Rows[pol]["Name"];

                ((DataGridViewComboBoxCell)(PolygonGridView.Rows[PolygonGridView.Rows.Count - 1].Cells["Color"])).Value = "";
                ((DataGridViewComboBoxCell)(PolygonGridView.Rows[PolygonGridView.Rows.Count - 1].Cells["Color"])).Style.BackColor = Color.FromName(polygons.Rows[pol]["Color"].ToString());

                if (OnPolygon.Contains(polygons.Rows[pol]["Id"].ToString()))
                {
                    PolygonGridView.Rows[PolygonGridView.Rows.Count - 1].Cells["Fix"].Value = true;
                }
            }

            List<string> id = new List<string>();
            foreach (DataGridViewRow row in PolygonGridView.Rows)
            {
                id.Add(row.Cells["Id"].Value.ToString());
                if (row.Cells["Id"].Value.ToString() == selectedId)
                {
                    PolygonGridView.CurrentCell = row.Cells["Name"];
                }
            }

            for (int pol = polyOverlay.Polygons.Count - 1; pol >= 0; pol--)
            {
                GMapPolygon polygon = polyOverlay.Polygons[pol];
                if (polygon.Name != "tempPolygon")
                {
                    if (!id.Contains(polygon.Name))
                    {
                        polyOverlay.Markers.Remove(getMarkerOfPolygons(polyOverlay, polygon.Name));
                        polyOverlay.Polygons.Remove(polygon);
                    }
                }
            }

            this.PolygonGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.PolygonGridView_CurrentCellDirtyStateChanged);
        }

        /// <summary>
        /// Возвращает полигон из overlay.
        /// </summary>
        /// <param name="polyOverlay">Overlay.</param>
        /// <param name="Name">Имя полигона.</param>
        /// <returns></returns>
        GMapPolygon getPolygon(GMapOverlay polyOverlay, string Name)
        {
            GMapPolygon polygon = null;

            foreach (GMapPolygon pol in polyOverlay.Polygons)
            {
                if (pol.Name == Name)
                {
                    polygon = pol;
                }
            }

            return polygon;
        }
        /// <summary>
        /// Создает пустой полигон.
        /// </summary>
        /// <param name="color">Цвет полигона.</param>
        /// <param name="name">Название полигона.</param>
        /// <returns></returns>
        GMapPolygon CreatePolygon(Color color, string name)
        {
            GMapPolygon tempPolygon;
            List<PointLatLng> points = new List<PointLatLng>();
            tempPolygon = new GMapPolygon(points, "tempPolygon");
            tempPolygon.IsHitTestVisible = true;
            tempPolygon.Stroke = new Pen(color, 3);

            return tempPolygon;
        }

        GMapMarker getMarkerOfPolygons(GMapOverlay polyOverlay, string Id)
        {
            GMapMarker getMarker = null;
            
            foreach(GMapMarker marker in polyOverlay.Markers)
            {
                if (Convert.ToString(marker.Tag) == Id)
                {
                    getMarker = marker;
                    break;
                }
            }

            return getMarker;
        }

        /// <summary>
        /// Клик по полигону.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="e"></param>
        private void gMapControl_OnPolygonClick(GMapPolygon item, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((item.Name == "tempPolygon") || (Convert.ToInt32(SQL.query("SELECT COUNT(*) FROM dbo.[Polygons] WHERE Id =" + item.Name).Rows[0][0]) > 0))
                {
                    string buttonType;
                    string name = null;
                    if (item.Name == "tempPolygon")
                    {
                        buttonType = "ДОБАВИТЬ В БД";
                    }
                    else
                    {
                        name = SQL.query("SELECT [Name] FROM dbo.[Polygons] WHERE [Id] = " + item.Name + "").Rows[0]["Name"].ToString();
                        if (name == "")
                        {
                            name = null;
                        }
                        buttonType = "УДАЛИТЬ ИЗ БД";
                    }

                    Edit edit = new Edit("polygons", item.Stroke.Color, name, buttonType);
                    edit.ShowDialog();

                    string onClick = edit.onClick;
                    switch (onClick)
                    {
                        case "OK":
                            {
                                name = edit.name;
                                Color color = edit.color;

                                item.Stroke.Color = color;
                                if (item.Name != "tempPolygon")
                                {
                                    SQL.query("UPDATE dbo.[Polygons] SET [Name] = '" + name + "', [Color] = '" + color.Name + "' WHERE[Id] = " + item.Name);
                                    UpdatePolygonGridView();
                                }
                                break;
                            }
                        case "DELETE":
                            {
                                if (item.Name != "tempPolygon")
                                {
                                    polyOverlay.Markers.Remove(getMarkerOfPolygons(polyOverlay, item.Name));

                                    foreach (DataGridViewRow row in PolygonGridView.Rows)
                                    {
                                        if (row.Cells["Id"].Value.ToString() == item.Name)
                                        {
                                            row.Cells["Fix"].Value = false;
                                            break;
                                        }
                                    }
                                }

                                polyOverlay.Polygons.Remove(item);
                                break;
                            }
                        case "INSERTDB":
                            {
                                name = edit.name;
                                Color color = edit.color;

                                gpxType gpx = new gpxType();
                                wptType[] wpt = new wptType[item.Points.Count];

                                for (int point = 0; point < item.Points.Count; point++)
                                {
                                    wpt[point] = new wptType();
                                    wpt[point].lat = Convert.ToDecimal(item.Points[point].Lat);
                                    wpt[point].lon = Convert.ToDecimal(item.Points[point].Lng);
                                }

                                gpx.wpt = wpt;

                                string xml = GMaps.Instance.SerializeGPX(gpx);

                                SQL.query("INSERT INTO dbo.[Polygons] (Name, Gpx, Color) VALUES ('" + name + "', '" + xml + "', '" + color.Name + "')");
                                UpdatePolygonGridView();

                                PointLatLng ToolPoint = new PointLatLng();
                                List<double> Lat = new List<double>();
                                List<double> Lng = new List<double>();
                                foreach (PointLatLng point in item.Points)
                                {
                                    Lat.Add(point.Lat);
                                    Lng.Add(point.Lng);
                                }
                                ToolPoint.Lat = Lat.Average();
                                ToolPoint.Lng = Lng.Average();


                                item.Name = SQL.query("SELECT scope_identity()").Rows[0][0].ToString();
                                item.Stroke.Color = color;

                                polyOverlay.Markers.Add(new GMarkerCross(ToolPoint) { Tag = item.Name, ToolTipText = name, IsVisible = false, ToolTipMode = MarkerTooltipMode.Always });

                                foreach (DataGridViewRow row in PolygonGridView.Rows)
                                {
                                    if (row.Cells["Id"].Value.ToString() == item.Name)
                                    {
                                        row.Cells["Fix"].Value = true;
                                    }
                                }
                                break;
                            }
                        case "DELETEDB":
                            {
                                polyOverlay.Markers.Remove(getMarkerOfPolygons(polyOverlay, item.Name));
                                polyOverlay.Polygons.Remove(item);

                                SQL.query("DELETE FROM dbo.[Polygons] WHERE [Id] = " + item.Name);
                                UpdatePolygonGridView();
                                break;
                            }
                    }
                }
                else
                {
                    polyOverlay.Markers.Remove(getMarkerOfPolygons(polyOverlay, item.Name));
                    polyOverlay.Polygons.Remove(item);
                }
            }
        }

        /// <summary>
        /// Убирает лишнее выделение столбцов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PolygonGridView_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in PolygonGridView.SelectedCells)
            {
                if ((cell.OwningColumn.Name == "Color") || (cell.OwningColumn.Name == "Fix"))
                {
                    cell.Selected = false;
                    cell.OwningRow.Cells["Name"].Selected = true;
                }
            }
        }

        /// <summary>
        /// Добавляет обработчик для comboBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PolygonGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name == "Color")
            {
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    cb.DrawItem += new System.Windows.Forms.DrawItemEventHandler(polygon_cb_DrawItem);
                    cb.DrawMode = DrawMode.OwnerDrawFixed;
                }
            }
        }
        /// <summary>
        /// Заполняет comboBox цветами.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void polygon_cb_DrawItem(object sender, DrawItemEventArgs e)
        {
            using (Brush br = new SolidBrush(colors[e.Index]))
            {
                e.Graphics.FillRectangle(br, e.Bounds);
            }
        }

        /// <summary>
        /// Изменяет цвет полигона.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PolygonGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (PolygonGridView.CurrentCell is DataGridViewComboBoxCell)
            {
                Color color = colors[((DataGridViewComboBoxEditingControl)PolygonGridView.EditingControl).SelectedIndex];
                string Id = PolygonGridView.CurrentCell.OwningRow.Cells["Id"].Value.ToString();

                SQL.query("UPDATE dbo.[Polygons] SET [Color] = '" + color.Name + "'  WHERE [Id] = " + Id);
                UpdatePolygonGridView();

                if (Convert.ToBoolean(PolygonGridView.CurrentCell.OwningRow.Cells["Fix"].Value) == true)
                {
                    getPolygon(polyOverlay, Id).Stroke.Color = color;

                    polyOverlay.IsVisibile = false;
                    polyOverlay.IsVisibile = true;
                }
            }
        }

        /// <summary>
        /// Завершает режим редактирования checkBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PolygonGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (PolygonGridView.CurrentCell is DataGridViewCheckBoxCell)
            {
                PolygonGridView.EndEdit();
            }
        }
        /// <summary>
        /// Выводит полигон на карту.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PolygonGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (PolygonGridView.CurrentCell is DataGridViewCheckBoxCell)
            {
                string Id = Convert.ToString(PolygonGridView.CurrentCell.OwningRow.Cells["Id"].Value);
                Color color = ((DataGridViewComboBoxCell)(PolygonGridView.CurrentCell.OwningRow.Cells["Color"])).Style.BackColor;
                List<PointLatLng> points = new List<PointLatLng>();

                if (Convert.ToBoolean(PolygonGridView.CurrentCell.Value) == true)
                {
                    string xml = SQL.query("SELECT [Gpx] FROM dbo.[Polygons] WHERE Id = " + Id).Rows[0]["Gpx"].ToString();
                    string name = SQL.query("SELECT [Name] FROM dbo.[Polygons] WHERE Id = " + Id).Rows[0]["Name"].ToString();

                    gpxType gpx = GMaps.Instance.DeserializeGPX(xml);

                    GMapPolygon polygon = CreatePolygon(color, Id);

                    foreach (wptType wpt in gpx.wpt)
                    {
                        PointLatLng point = new PointLatLng(Convert.ToDouble(wpt.lat), Convert.ToDouble(wpt.lon));
                        points.Add(point);
                    }

                    polygon.Name = Id;
                    polygon.Points.AddRange(points);

                    PointLatLng ToolPoint = new PointLatLng();
                    List<double> Lat = new List<double>();
                    List<double> Lng = new List<double>();
                    foreach (PointLatLng point in points)
                    {
                        Lat.Add(point.Lat);
                        Lng.Add(point.Lng);
                    }
                    ToolPoint.Lat = Lat.Average();
                    ToolPoint.Lng = Lng.Average();

                    polyOverlay.Markers.Add(new GMarkerCross(ToolPoint) {Tag = Id, ToolTipText = name, IsVisible = false, ToolTipMode = MarkerTooltipMode.Always });
                    polyOverlay.Polygons.Add(polygon);
                }
                else
                {
                    GMapPolygon polygon = getPolygon(polyOverlay, Id);
                    polyOverlay.Markers.Remove(getMarkerOfPolygons(polyOverlay, polygon.Name));
                    polyOverlay.Polygons.Remove(polygon);
                }

                PolygonGridView.CurrentCell = PolygonGridView.CurrentCell.OwningRow.Cells["Name"];
            }
        }

        /// <summary>
        /// Выводит название полигона.
        /// </summary>
        /// <param name="item"></param>
        private void gMapControl_OnPolygonEnter(GMapPolygon item)
        {
            if (item.Name != "tempPolygon")
            {

                getMarkerOfPolygons(polyOverlay, item.Name).IsVisible = true;
            }
        }
        private void gMapControl_OnPolygonLeave(GMapPolygon item)
        {
            if (item.Name != "tempPolygon")
            {
                getMarkerOfPolygons(polyOverlay, item.Name).IsVisible = false;
            }
        }
        #endregion

        #region Маркеры
        /// <summary>
        /// Инициализирует MarkerGridView.
        /// </summary>
        void MarkerGridViewInit()
        {
            DataGridViewComboBoxColumn colorColumn = new DataGridViewComboBoxColumn();
            colorColumn.Name = "Color";
            colorColumn.FlatStyle = FlatStyle.Flat;
            foreach (Color clr in Markercolors)
            {
                colorColumn.Items.Add("");
            }

            DataGridViewCheckBoxColumn fixColumn = new DataGridViewCheckBoxColumn();
            fixColumn.Name = "Fix";

            MarkerGridView.Columns.Add("Id", "Id");
            MarkerGridView.Columns.Add("Name", "Name");
            MarkerGridView.Columns.Add("Lat", "Lat");
            MarkerGridView.Columns.Add("Lng", "Lng");
            MarkerGridView.Columns.Add(colorColumn);
            MarkerGridView.Columns.Add(fixColumn);

            MarkerGridView.Columns["Id"].Visible = false;
            MarkerGridView.Columns["Lat"].Visible = false;
            MarkerGridView.Columns["Lng"].Visible = false;

            MarkerGridView.Columns["Color"].Width = 20;
            MarkerGridView.Columns["Fix"].Width = 30;

            MarkerGridView.Columns["Name"].ReadOnly = true;
        }

        /// <summary>
        /// Обновляет таблицу маркеров.
        /// </summary>
        /// <param name="routeOverlay"></param>
        void UpdateMarkerGridView()
        {
            if (MarkerGridView.InvokeRequired)
            {
                MarkerGridView.BeginInvoke(new Action(UpdateMarkerGridView));
                return;
            }
            DataTable markers = SQL.query("SELECT * FROM dbo.[Markers]");
            List<string> OnMarkers = new List<string>();
            foreach (DataGridViewRow row in MarkerGridView.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Fix"].Value) == true)
                {
                    OnMarkers.Add(row.Cells["Id"].Value.ToString());
                }
            }
            string selectedId = null;
            if (MarkerGridView.SelectedCells.Count > 0)
            {
                selectedId = MarkerGridView.SelectedCells[0].OwningRow.Cells["Id"].Value.ToString();
            }
            this.MarkerGridView.CurrentCellDirtyStateChanged -= new System.EventHandler(this.MarkerGridView_CurrentCellDirtyStateChanged);
            MarkerGridView.Rows.Clear();

            for (int mark = 0; mark < markers.Rows.Count; mark++)
            {
                MarkerGridView.Rows.Add();
                MarkerGridView.Rows[MarkerGridView.Rows.Count - 1].Cells["Id"].Value = markers.Rows[mark]["Id"];
                MarkerGridView.Rows[MarkerGridView.Rows.Count - 1].Cells["Name"].Value = markers.Rows[mark]["Name"];
                MarkerGridView.Rows[MarkerGridView.Rows.Count - 1].Cells["Lat"].Value = markers.Rows[mark]["Lat"];
                MarkerGridView.Rows[MarkerGridView.Rows.Count - 1].Cells["Lng"].Value = markers.Rows[mark]["Lng"];

                ((DataGridViewComboBoxCell)(MarkerGridView.Rows[MarkerGridView.Rows.Count - 1].Cells["Color"])).Value = "";
                ((DataGridViewComboBoxCell)(MarkerGridView.Rows[MarkerGridView.Rows.Count - 1].Cells["Color"])).Style.BackColor = Color.FromName(markers.Rows[mark]["Color"].ToString());

                if (OnMarkers.Contains(markers.Rows[mark]["Id"].ToString()))
                {
                    MarkerGridView.Rows[MarkerGridView.Rows.Count - 1].Cells["Fix"].Value = true;
                }
            }

            foreach (DataGridViewRow row in MarkerGridView.Rows)
            {
                if (row.Cells["Id"].Value.ToString() == selectedId)
                {
                    MarkerGridView.CurrentCell = row.Cells["Name"];
                }
            }
            this.MarkerGridView.CurrentCellDirtyStateChanged += new System.EventHandler(this.MarkerGridView_CurrentCellDirtyStateChanged);
        }

        /// <summary>
        /// Возвращает маркер из overlay.
        /// </summary>
        /// <param name="markersOverlay">Overlay</param>
        /// <param name="point">Координаты.</param>
        /// <returns></returns>
        GMarkerGoogle getMarker(GMapOverlay markersOverlay, PointLatLng point)
        {
            GMarkerGoogle marker = null;

            foreach (GMarkerGoogle mark in markersOverlay.Markers)
            {
                if (mark.Position == point)
                {
                    marker = mark;
                }
            }

            return marker;
        }
        /// <summary>
        /// Создает маркер.
        /// </summary>
        /// <param name="point">Координаты.</param>
        /// <param name="color">Тип маркера.</param>
        /// <param name="name">Название маркера.</param>
        /// <returns></returns>
        GMarkerGoogle CreateGMarker(PointLatLng point, GMarkerGoogleType color, string name)
        {
            GMarkerGoogle marker = new GMarkerGoogle(point, color);
            marker.ToolTip = new GMapRoundedToolTip(marker);
            marker.ToolTipText = name;

            return marker;
        }

        /// <summary>
        /// Возвращает GMarkerGoogleType по названию цвета.
        /// </summary>
        /// <param name="ColorName">Название цвета.</param>
        /// <returns></returns>
        GMarkerGoogleType getGMarkerGoogleType(string ColorName)
        {
            GMarkerGoogleType type = GMarkerGoogleType.none;

            switch (ColorName)
            {
                case "LightBlue":
                    {
                        type = GMarkerGoogleType.lightblue;
                        break;
                    }
                case "Blue":
                    {
                        type = GMarkerGoogleType.blue;
                        break;
                    }
                case "Green":
                    {
                        type = GMarkerGoogleType.green;
                        break;
                    }
                case "Orange":
                    {
                        type = GMarkerGoogleType.orange;
                        break;
                    }
                case "Pink":
                    {
                        type = GMarkerGoogleType.pink;
                        break;
                    }
                case "Purple":
                    {
                        type = GMarkerGoogleType.purple;
                        break;
                    }
                case "Red":
                    {
                        type = GMarkerGoogleType.red;
                        break;
                    }
                case "Yellow":
                    {
                        type = GMarkerGoogleType.yellow;
                        break;
                    }
            }

            return type;
        }

        /// <summary>
        /// Выводит маркер на карту.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarkerGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (MarkerGridView.CurrentCell is DataGridViewCheckBoxCell)
            {
                PointLatLng point = new PointLatLng(Convert.ToDouble(MarkerGridView.CurrentCell.OwningRow.Cells["Lat"].Value), Convert.ToDouble(MarkerGridView.CurrentCell.OwningRow.Cells["Lng"].Value));
                if (Convert.ToBoolean(MarkerGridView.CurrentCell.Value) == true)
                {
                    string name = MarkerGridView.CurrentCell.OwningRow.Cells["Name"].Value.ToString();
                    GMarkerGoogleType type = getGMarkerGoogleType(((DataGridViewComboBoxCell)(MarkerGridView.CurrentCell.OwningRow.Cells["Color"])).Style.BackColor.Name);
                    GMarkerGoogle marker = CreateGMarker(point, type, name);

                    markersOverlay.Markers.Add(marker);
                }
                else
                {
                    markersOverlay.Markers.Remove(getMarker(markersOverlay, point));
                }

                MarkerGridView.CurrentCell = MarkerGridView.CurrentCell.OwningRow.Cells["Name"];
            }
        }
        /// <summary>
        /// Завершает режим редактирования checkBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarkerGridView_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (MarkerGridView.CurrentCell is DataGridViewCheckBoxCell)
            {
                MarkerGridView.EndEdit();
            }
        }

        /// <summary>
        /// Клик по маркеру.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="e"></param>
        private void gMapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataTable MarkerSelect = SQL.query("SELECT [Id], [Name], [Lat], [Lng], [Color] FROM dbo.[Markers] WHERE [Lat] = '" + item.Position.Lat.ToString() + "' AND [Lng] = '" + item.Position.Lng.ToString() + "'");
                DataRow MarkerRow = null;
                if (MarkerSelect.Rows.Count > 0)
                {
                    MarkerRow = MarkerSelect.Rows[0];
                }
                string buttonType;
                Color oldColor;
                if (MarkerRow == null)
                {
                    buttonType = "ДОБАВИТЬ В БД";
                    oldColor = DefaultMarkerColor;
                }
                else
                {
                    buttonType = "УДАЛИТЬ ИЗ БД";
                    oldColor = Color.FromName(MarkerRow["Color"].ToString());
                }

                Edit edit = new Edit("markers", oldColor, item.ToolTipText, buttonType);
                edit.ShowDialog();

                string onClick = edit.onClick;
                switch (onClick)
                {
                    case "OK":
                        {
                            markersOverlay.Markers.Remove(item);

                            string name = edit.name;
                            Color color = edit.color;
                            GMarkerGoogleType type = getGMarkerGoogleType(color.Name);
                            PointLatLng point = item.Position;

                            GMarkerGoogle marker = CreateGMarker(point, type, name);

                            markersOverlay.Markers.Add(marker);

                            SQL.query("UPDATE dbo.[Markers] SET [Name] = '" + name + "', [Color] = '" + color.Name + "'  WHERE[Lat] = '" + point.Lat.ToString() + "' AND[Lng] = '" + point.Lng.ToString() + "'");
                            UpdateMarkerGridView();
                            break;
                        }
                    case "DELETE":
                        {
                            markersOverlay.Markers.Remove(item);

                            if (MarkerRow != null)
                            {
                                foreach (DataGridViewRow row in MarkerGridView.Rows)
                                {
                                    if (row.Cells["Id"].Value.ToString() == MarkerRow["Id"].ToString())
                                    {
                                        row.Cells["Fix"].Value = false;
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    case "INSERTDB":
                        {
                            string name = edit.name;
                            Color color = edit.color;
                            PointLatLng point = item.Position;

                            SQL.query("INSERT INTO dbo.[Markers] (Name, Lat, Lng, Color) VALUES ('" + name + "', '" + point.Lat.ToString() + "', '" + point.Lng.ToString() + "', '" + color.Name + "')");
                            UpdateMarkerGridView();

                            markersOverlay.Markers.Remove(item);

                            MarkerGridView.CurrentCell = MarkerGridView.Rows[MarkerGridView.Rows.Count - 1].Cells["Fix"];
                            MarkerGridView.Rows[MarkerGridView.Rows.Count - 1].Cells["Fix"].Value = true;
                            break;
                        }
                    case "DELETEDB":
                        {
                            markersOverlay.Markers.Remove(item);

                            string Id = MarkerRow["Id"].ToString();
                            SQL.query("DELETE FROM dbo.[Markers] WHERE [Id] = " + Id);
                            UpdateMarkerGridView();
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// Добавляет обработчик для comboBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarkerGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.OwningColumn.Name == "Color")
            {
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    cb.DrawItem += new System.Windows.Forms.DrawItemEventHandler(marker_cb_DrawItem);
                    cb.DrawMode = DrawMode.OwnerDrawFixed;
                }
            }
        }
        /// <summary>
        /// Заполняет comboBox цветами.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void marker_cb_DrawItem(object sender, DrawItemEventArgs e)
        {
            using (Brush br = new SolidBrush(Markercolors[e.Index]))
            {
                e.Graphics.FillRectangle(br, e.Bounds);
            }
        }

        /// <summary>
        /// Изменение цвета маркеров.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarkerGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (MarkerGridView.CurrentCell is DataGridViewComboBoxCell)
            {
                Color color = Markercolors[((DataGridViewComboBoxEditingControl)MarkerGridView.EditingControl).SelectedIndex];
                string Id = MarkerGridView.CurrentCell.OwningRow.Cells["Id"].Value.ToString();

                SQL.query("UPDATE dbo.[Markers] SET [Color] = '" + color.Name + "'  WHERE [Id] = " + Id);
                UpdateMarkerGridView();

                MarkerGridView.CurrentCell = MarkerGridView.CurrentCell.OwningRow.Cells["Fix"];
                foreach (DataGridViewRow row in MarkerGridView.Rows)
                {
                    if (row.Cells["Id"].Value.ToString() == Id)
                    {
                        if (Convert.ToBoolean(row.Cells["Fix"].Value) == true)
                        {
                            PointLatLng point = new PointLatLng(Convert.ToDouble(row.Cells["Lat"].Value), Convert.ToDouble(row.Cells["Lng"].Value));

                            markersOverlay.Markers.Remove(getMarker(markersOverlay, point));

                            string name = row.Cells["Name"].Value.ToString();
                            GMarkerGoogleType type = getGMarkerGoogleType(((DataGridViewComboBoxCell)(row.Cells["Color"])).Style.BackColor.Name);
                            GMarkerGoogle marker = CreateGMarker(point, type, name);

                            markersOverlay.Markers.Add(marker);
                        }

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Убирает лишнее выделение столбцов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MarkerGridView_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in MarkerGridView.SelectedCells)
            {
                if ((cell.OwningColumn.Name == "Color") || (cell.OwningColumn.Name == "Fix"))
                {
                    cell.Selected = false;
                    cell.OwningRow.Cells["Name"].Selected = true;
                }
            }
        }
        #endregion

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

            gMapControl.RoutesEnabled = true;
            gMapControl.MarkersEnabled = true;
            gMapControl.PolygonsEnabled = true;

            gMapControl.MaxZoom = 18;
            gMapControl.MinZoom = 2;

            gMapControl.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;

            gMapControl.NegativeMode = false;

            gMapControl.ShowTileGridLines = false;

            gMapControl.Zoom = 5;

            gMapControl.Dock = DockStyle.Fill;

            gMapControl.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.CacheOnly;
            GMaps.Instance.ImportFromGMDB("Data.gmdb");

            gMapControl.Overlays.Add(routeOverlay);
            gMapControl.Overlays.Add(polyOverlay);
            gMapControl.Overlays.Add(markersOverlay);

            UpdateCoordinatePanel(gMapControl.Position);
        }

        /// <summary>
        /// Обновление панели координат.
        /// </summary>
        /// <param name="point">Координаты.</param>
        void UpdateCoordinatePanel(PointLatLng point)
        {
            double Lat = point.Lat;
            double Lng = point.Lng;
            if (Lat > 0)
            {
                LatLBL.Text = "N" + Math.Abs(Lat).ToString();
            }
            else
            {
                LatLBL.Text = "S" + Math.Abs(Lat).ToString();
            }

            if (Lng > 0)
            {
                LngLBL.Text = "E" + Math.Abs(Lng).ToString();
            }
            else
            {
                LngLBL.Text = "W" + Math.Abs(Lng).ToString();
            }
        }
        /// <summary>
        /// Получение координат по курсору.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gMapControl_MouseMove(object sender, MouseEventArgs e)
        {
            PointLatLng point = gMapControl.FromLocalToLatLng(e.X, e.Y);
            UpdateCoordinatePanel(point);

            if (e.Button == MouseButtons.Right)
            {
                switch (Tool)
                {
                    case "Free":
                        {
                            GMapPolygon tempPolygon = getPolygon(polyOverlay, "tempPolygon");
                            tempPolygon.Points.Add(point);

                            polyOverlay.IsVisibile = false;
                            polyOverlay.IsVisibile = true;
                            break;
                        }
                    case "Rectangle":
                        {
                            GMapPolygon tempPolygon = getPolygon(polyOverlay, "tempPolygon");
                            if (tempPolygon.Points.Count == 0)
                            {
                                tempPolygon.Points.Add(point);
                            }
                            else
                            {
                                PointLatLng firstPoint = tempPolygon.Points.First();
                                tempPolygon.Points.Clear();
                                tempPolygon.Points.Add(firstPoint);
                                tempPolygon.Points.Add(new PointLatLng(firstPoint.Lat, point.Lng));
                                tempPolygon.Points.Add(new PointLatLng(point.Lat, point.Lng));
                                tempPolygon.Points.Add(new PointLatLng(point.Lat, firstPoint.Lng));
                            }
                            break;
                        }
                }

                polyOverlay.IsVisibile = false;
                polyOverlay.IsVisibile = true;
            }
        }

        /// <summary>
        /// Прямоугольное выделение.
        /// </summary>
        private void RectangleBTN_MouseClick(object sender, MouseEventArgs e)
        {
            Tool = "Rectangle";
        }
        /// <summary>
        /// Произвольное выделение.
        /// </summary>
        private void FreeBTN_MouseClick(object sender, MouseEventArgs e)
        {
            Tool = "Free";
        }
        /// <summary>
        /// Маркер.
        /// </summary>
        private void MarkerBTN_MouseClick(object sender, MouseEventArgs e)
        {
            Tool = "Marker";
        }

        /// <summary>
        /// Набор инструментов.
        /// </summary>
        /// <param name="point"></param>
        void Tools(PointLatLng point)
        {
            switch (Tool)
            {
                case "Free":
                    {
                        GMapPolygon tempPolygon = getPolygon(polyOverlay, "tempPolygon");
                        polyOverlay.Polygons.Remove(tempPolygon);

                        tempPolygon = CreatePolygon(DefaultPolygonColor, "tempPolygon");
                        polyOverlay.Polygons.Add(tempPolygon);
                        break;
                    }
                case "Rectangle":
                    {
                        GMapPolygon tempPolygon = getPolygon(polyOverlay, "tempPolygon");
                        polyOverlay.Polygons.Remove(tempPolygon);

                        tempPolygon = CreatePolygon(DefaultPolygonColor, "tempPolygon");
                        polyOverlay.Polygons.Add(tempPolygon);
                        break;
                    }
                case "Marker":
                    {
                        Edit edit = new Edit("markers", DefaultMarkerColor, "ДОБАВИТЬ В БД");
                        edit.ShowDialog();

                        string onClick = edit.onClick;
                        switch (onClick)
                        {
                            case "OK":
                                {
                                    string name = edit.name;
                                    Color color = edit.color;
                                    GMarkerGoogleType type = getGMarkerGoogleType(color.Name);

                                    GMarkerGoogle marker = CreateGMarker(point, type, name);

                                    markersOverlay.Markers.Add(marker);
                                    break;
                                }

                            case "INSERTDB":
                                {
                                    string name = edit.name;
                                    Color color = edit.color;

                                    SQL.query("INSERT INTO dbo.[Markers] (Name, Lat, Lng, Color) VALUES ('" + name + "', '" + point.Lat.ToString() + "', '" + point.Lng.ToString() + "', '" + color.Name + "')");
                                    UpdateMarkerGridView();

                                    MarkerGridView.CurrentCell = MarkerGridView.Rows[MarkerGridView.Rows.Count - 1].Cells["Fix"];
                                    MarkerGridView.Rows[MarkerGridView.Rows.Count - 1].Cells["Fix"].Value = true;
                                    break;
                                }
                        }
                        break;
                    }
            }
        }
        /// <summary>
        /// Обработка клика по карте.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gMapControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PointLatLng point = gMapControl.FromLocalToLatLng(e.X, e.Y);
                Tools(point);
            }
        }
        #endregion

        public Map()
        {
            InitializeComponent();

            HideSearchBTNInit();
            HideRouteBTNInit();

            RoteGridViewInit();
            MarkerGridViewInit();
            PolygonGridViewInit();

            Polygonschcksum = checksum("Polygons");
            UpdatePolygonGridView();

            Markerschcksum = checksum("Markers");
            UpdateMarkerGridView();

            Loadchcksum = checksum("Load");
            ShowDataGridView(false, 1);

            UpdateTimer.Interval = UPDATEGRIDMILLISECONDS;
            UpdateTimer.Enabled = true;
        }

        /// <summary>
        /// Инициализирует переменные.
        /// </summary>
        /// <param name="UpdateScreen">Частота обновления данных.</param>
        /// <param name="RouteOfPage">Число маршрутов на странице.</param>
        /// <param name="ColorNewRoute">Цвет нового маршрута.</param>
        /// <param name="ColorSelected">Цвет выделенного маршрута.</param>
        public static void Init(int UpdateScreen, int RouteOfPage, Color ColorNewRoute, Color ColorSelected, Color PolygonColor, Color MarkerColor)
        {
            UPDATEGRIDMILLISECONDS = UpdateScreen * 1000;
            RowOfPage = RouteOfPage;

            DefaultColor = ColorNewRoute;
            SelectedColor = ColorSelected;
            DefaultPolygonColor = PolygonColor;
            DefaultMarkerColor = MarkerColor;
        }
    }
}
