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
    public partial class GUI : Form
    {
        Thread updateThread;

        int chcksum;
    
        bool FirstSetting = false;
        bool EnableBeginTimePicker = true;
        bool EnableEndTimePicker = false;
        public bool start = false;
        bool userDeleting = true;

        int UPDATEGRIDMILLISECONDS = 5000;

        int SearchSplitterPosition = 100;
        bool SearchSplitterLock = false;
        int RouteSplitterPosition = 100;
        bool RouteSplitterLock = false;

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

            if (TargetAddress != "")
            {
                filter = "WHERE TargetAddress LIKE '" + TargetAddress + "%'";
            }
            if (AircraftIdentification != "")
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
            if (Registration != "")
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
            if (TypeAircraft != "")
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
            if (Mode3A != "")
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
            if (EmitterCategory != "")
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
            if (Country != "")
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
            if (AirportDepature != "")
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
            if (AirportArrival != "")
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
            if ((BeginTime != "") && (EnableBeginTimePicker))
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
            if ((EndTime != "") && (EnableEndTimePicker))
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
            if (CAT != "")
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
            if (SAC != "")
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
            if (SIC != "")
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

            return filter;
        }
        /// <summary>
        /// Возвращает контрольную сумму таблицы.
        /// </summary>
        /// <param name="TableName">Имя таблицы</param>
        /// <returns>Контрольная сумма.</returns>
        int checksum(string TableName)
        {
            DataTable Category = SQL.query("SELECT CHECKSUM_AGG(GETCHECKSUM()) FROM dbo.[" + TableName + "]");
            if (Convert.ToString(Category.Rows[0][0]) != "")
            {
                return Convert.ToInt32(Category.Rows[0][0]);
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
            if (chcksum != newchcksum)
            {
                chcksum = newchcksum;
                ShowDataGridView(true);
            }
            updateThread.Abort();
        }
        /// <summary>
        /// Запускает таймер контроля состояний маршрутов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTimer_Tick(object sender, System.EventArgs e)
        {
            updateThread = new Thread(timerThread);
            updateThread.Start();
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

            LoadGridView1.Columns["Id"].Visible = false;
            for (int column = 1; column < LoadGridView1.ColumnCount; column++)
            {
                LoadGridView1.Columns[column].Visible = true;
            }
        }
        /// <summary>
        /// Удаляет строки из БД, выбранные в LoadGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (userDeleting)
            {
                DataGridViewSelectedRowCollection deleteCollection = LoadGridView1.SelectedRows;
                string delete = "DELETE FROM dbo.[Load] WHERE ";
                for (int i = 0; i < deleteCollection.Count; i++)
                {
                    if (i == 0)
                    {
                        delete += "Id = '" + Convert.ToString(LoadGridView1[0, deleteCollection[i].Index].Value) + "'";
                    }
                    else
                    {
                        delete += " OR Id = '" + Convert.ToString(LoadGridView1[0, deleteCollection[i].Index].Value) + "'";
                    }
                }
                SQL.query(delete);

                if (LoadGridView1.SelectedRows.Count > 1)
                {
                    userDeleting = false;
                }
            }

            if (LoadGridView1.SelectedRows.Count == 1)
            {
                userDeleting = true;
            }
        }
        /// <summary>
        /// Двойной клик по маршруту. Отображает маршрут.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (e.RowIndex >= 0))
            {
                Thread DeleteThread = new Thread(() => openGPXThread(e.RowIndex));
                DeleteThread.Start();
            }
        }
        /// <summary>
        /// Выбор маршрута клавишей Enter. Отображает маршрут.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;
                if (LoadGridView1.CurrentRow != null)
                {
                    Thread DeleteThread = new Thread(() => openGPXThread(LoadGridView1.CurrentRow.Index));
                    DeleteThread.Start();
                }
            }
        }
        /// <summary>
        /// Отображает LoadGridView с учетом фильтра.
        /// </summary>
        /// <param name="autoPosition">Фиксация положения в таблице. Использовать только при добавлении данных в таблицу (когда предыдущие строки не изменяются).</param>
        void ShowDataGridView(bool autoPosition)
        {
            string f = filter();
            UpdateDataGridView(SQL.query("SELECT Id, TargetAddress AS 'ICAO24', Mode3A, AircraftIdentification AS 'Позывной', Registration AS 'Бортовой', EmitterCategory AS 'Категория', TypeAircraft AS 'Тип', Class AS 'Класс', Country AS 'Государство', AirportDepature AS 'Аэропорт вылета', AirportArrival AS 'Аэропорт прибытия', SAC, SIC, CAT, BeginTime AS 'Начало маршрута', EndTime AS 'Конец маршрута', Interval AS 'Продолжительность', Status AS 'Статус' FROM dbo.[Load] " + f), autoPosition);
        }
        /// <summary>
        /// Обновляет данные в LoadGridView.
        /// </summary>
        /// <param name="table">Таблица данных.</param>
        /// <param name="autoPosition">Фиксация положения в таблице. Использовать только при добавлении данных в таблицу (когда предыдущие строки не изменяются).</param>
        public void UpdateDataGridView(DataTable table, bool autoPosition)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<DataTable, bool>(UpdateDataGridView), new object[] { table, autoPosition });
                return;
            }

            int selectedId = 0;
            int firstRow = 0;
            int sortedColumn = 0;
            ListSortDirection sortDirection = ListSortDirection.Ascending;

            if (LoadGridView1.Rows.Count > 0)
            {
                if (LoadGridView1.CurrentCell != null)
                {
                    selectedId = Convert.ToInt32(LoadGridView1[0, LoadGridView1.CurrentCell.RowIndex].Value);
                }
                firstRow = LoadGridView1.FirstDisplayedScrollingRowIndex;
            }

            if (LoadGridView1.SortedColumn != null)
            {
                sortedColumn = LoadGridView1.SortedColumn.Index;
                if (LoadGridView1.SortOrder == System.Windows.Forms.SortOrder.Ascending)
                {
                    sortDirection = ListSortDirection.Ascending;
                }
                else
                {
                    sortDirection = ListSortDirection.Descending;
                }
            }

            LoadGridView1.DataSource = table;  

            if (FirstSetting == false)
            {
                for (int column = 0; column < LoadGridView1.ColumnCount; column++)
                {
                    LoadGridView1.Columns[column].Visible = false;
                }

                LoadGridViewSetting();
                FirstSetting = true;
            }

            LoadGridView1.Sort(LoadGridView1.Columns[sortedColumn], sortDirection);

            if (LoadGridView1.Rows.Count > 0)
            {
                if (autoPosition)
                {
                    for (int row = 0; row < LoadGridView1.Rows.Count; row++)
                    {
                        if (Convert.ToInt32(LoadGridView1[0, row].Value) == selectedId)
                        {
                            LoadGridView1.CurrentCell = LoadGridView1[1, row];
                            break;
                        }
                    }
                    LoadGridView1.FirstDisplayedScrollingRowIndex = firstRow;
                }
            }
        }
        /// <summary>
        /// Отображает выбранный маршрут.
        /// </summary>
        /// <param name="RowIndex">Индекс выбранной строки в LoadGridView.</param>
        void openGPXThread(object RowIndex)
        {
            string TargetAddress = Convert.ToString(LoadGridView1[1, Convert.ToInt32(RowIndex)].Value);
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.InnerXml = Convert.ToString(SQL.query("SELECT GPX FROM [LOAD] WHERE ID = '" + Convert.ToString(LoadGridView1[0, Convert.ToInt32(RowIndex)].Value) + "'").Rows[0][0]);
                if (File.Exists(TargetAddress + ".gpx"))
                {
                    File.Delete(TargetAddress + ".gpx");
                }
                doc.Save(TargetAddress + ".gpx");
                File.SetAttributes(TargetAddress + ".gpx", FileAttributes.Hidden);
                Process.Start(TargetAddress + ".gpx");
                Thread.Sleep(10000);
                File.Delete(TargetAddress + ".gpx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (File.Exists(TargetAddress + ".gpx"))
                {
                    File.Delete(TargetAddress + ".gpx");
                }
            }
            Thread.CurrentThread.Abort();
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
                        result = EmitterCategoryComboBox.Text;
                        break;
                    }
                case "Country":
                    {
                        result = CountryComboBox.Text;
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
                        result = CATcomboBox.Text;
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
            }
            return result;
        }
        /// <summary>
        /// Заполняет ComboBox данными EmitterCategory.
        /// </summary>
        public void ComboBoxFill()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ComboBoxFill));
                return;
            }
            EmitterCategoryComboBox.Items.Clear();
            DataTable Category = SQL.query("SELECT DISTINCT(EmitterCategory) FROM dbo.[Load]");
            for (int row = 0; row < Category.Rows.Count; row++)
            {
                EmitterCategoryComboBox.Items.Add(Convert.ToString(Category.Rows[row][0]));
            }
        }

        /// <summary>
        /// Устанавливает максимальное значение ProgressBar.
        /// </summary>
        /// <param name="max">Максимальное значание</param>
        public void ProgressBarMax(int max)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(ProgressBarMax), new object[] { max });
                return;
            }
            progressBar1.Maximum = max;
        }
        /// <summary>
        /// Устанавливает минимальное значение ProgressBar.
        /// </summary>
        /// <param name="value">Минимальное значение.</param>
        public void ProgressBarValue(int value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(ProgressBarValue), new object[] { value });
                return;
            }
            progressBar1.Value = value;
        }

        /// <summary>
        /// Обновляет LoadGridView при изменении текста в TargetAddressTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TargetAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }
        /// <summary>
        /// Обновляет LoadGridView при изменении текста в AircraftIdetificationTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AircraftIdetificationTextBox_TextChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }
        /// <summary>
        /// Обновляет LoadGridView при изменении текста в AirportDepatureTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AirportDepatureTextBox_TextChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }
        /// <summary>
        /// Обновляет LoadGridView при изменении текста в AirportArrivalTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AirportArrivalTextBox_TextChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }
        /// <summary>
        /// Обновляет LoadGridView при изменении текста в RegistrationTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistrationTextBox_ControlTextChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }
        /// <summary>
        /// Обновляет LoadGridView при изменении текста в TypeAircraftTextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TypeAircraftTextBox_ControlTextChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }
        /// <summary>
        /// Обновляет LoadGridView при изменении текста в Mode3ATextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mode3ATextBox_ControlTextChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }
        /// <summary>
        /// Обновляет LoadGridView при изменении текста в SACtextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SACtextBox_ControlTextChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }
        /// <summary>
        /// Обновляет LoadGridView при изменении текста в SICtextBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SICtextBox_ControlTextChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }
        /// <summary>
        /// Обновляет LoadGridView при выборе EmitterCategory в EmitterCategoryComboBox. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmitterCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }
        /// <summary>
        /// Обновляет содержимое ComboBox по клику.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmitterCategoryComboBox_Click(object sender, EventArgs e)
        {
            ComboBoxFill();
        }


        /// <summary>
        /// Выбор меню "Сканирование"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanPicture_Click(object sender, EventArgs e)
        {
            StartStopBTN_Click(null, null);
        }
        /// <summary>
        /// Обрабатывает нажатие клавиши СТАРТ/СТОП. Запускает, либо останавливает обработку протокола.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartStopBTN_Click(object sender, EventArgs e)
        {
            if (start == false)
            {
                tabTable.RowStyles[1].Height = 15;
                progressBar1.Visible = true;
                start = true;

              /*  if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    start = true;

                    Protocol.START(folderBrowserDialog1.SelectedPath, "*.sig");
                }    */         
            }

            else
            {
                tabTable.RowStyles[1].Height = 0;
                progressBar1.Visible = false;

                progressBar1.Value = 0;
                start = false;

                Protocol.STOP();                
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
            ShowDataGridView(false);
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
                ShowDataGridView(false);
            }
        }
        /// <summary>
        ///  Обновляет LoadGridView при изменении значения календаря.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }

        /// <summary>
        /// Обновляет LoadGridView при развертывании календаря.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeginTimePicker_DropDown(object sender, EventArgs e)
        {
            EnableBeginTimePicker = true;
            ShowDataGridView(false);
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
                ShowDataGridView(false);
            }
        }
        /// <summary>
        /// Обновляет LoadGridView при изменении значения календаря.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BeginTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }

        /// <summary>
        /// Останавливает процесс обработки, завершает все потоки. Происходит при закрытии формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Protocol.STOP();

            if (updateThread != null)
            {
                updateThread.Abort();
            }
        }

        /// <summary>
        /// Основная функция формы. Производит инициализацию компонентов.
        /// </summary>
        public GUI()
        {
            if (SQL.Connect())
            {
                InitializeComponent();

                MapBTN_Click(null, null);
                HideSearchBTN_MouseUp(null, null);
                HideRouteBTN_MouseUp(null, null);

                Protocol.Init(this);
                chcksum = checksum("Load");
                ShowDataGridView(false);
                UpdateTimer.Interval = UPDATEGRIDMILLISECONDS;
                UpdateTimer.Enabled = true;
            }
        }

        /// <summary>
        /// Сбрасывает BackColor для контролов меню.
        /// </summary>
        void ResetBackColor()
        {
            ScanPicture.BackColor = Color.Transparent;
            StartStopBTN.BackColor = Color.Transparent;
            MapPicture.BackColor = Color.Transparent;
            MapBTN.BackColor = Color.Transparent;
            AircraftPicture.BackColor = Color.Transparent;
            AircraftBTN.BackColor = Color.Transparent;
            SettingsPicture.BackColor = Color.Transparent;
            SettingsBTN.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Выбор меню "Карта".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapPicture_Click(object sender, EventArgs e)
        {
            MapBTN_Click(null, null);
        }
        /// <summary>
        /// Выбор меню "Карта".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapBTN_Click(object sender, EventArgs e)
        {
            ResetBackColor();

            MapPicture.BackColor = Color.CornflowerBlue;
            MapBTN.BackColor = Color.CornflowerBlue;
            ColorPanel.BackColor = Color.CornflowerBlue;

            pagePanel.Controls.Clear();
            pagePanel.Controls.Add(MapPanel);
        }
        /// <summary>
        /// Выбор меню "Привязки".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AircraftPicture_Click(object sender, EventArgs e)
        {
            AircraftBTN_Click(null, null);
        }
        /// <summary>
        /// Выбор меню "Привязки".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AircraftBTN_Click(object sender, EventArgs e)
        {
            ResetBackColor();

            AircraftPicture.BackColor = Color.LightSeaGreen;
            AircraftBTN.BackColor = Color.LightSeaGreen;
            ColorPanel.BackColor = Color.LightSeaGreen;

            pagePanel.Controls.Clear();
            pagePanel.Controls.Add(AircraftPanel);
        }
        /// <summary>
        /// Выбор меню "Настройки".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsPicture_Click(object sender, EventArgs e)
        {
            SettingsBTN_Click(null, null);
        }
        /// <summary>
        /// Выбор меню "Настройки".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingsBTN_Click(object sender, EventArgs e)
        {
            ResetBackColor();

            SettingsPicture.BackColor = Color.DarkGray;
            SettingsBTN.BackColor = Color.DarkGray;
            ColorPanel.BackColor = Color.DarkGray;

            pagePanel.Controls.Clear();
            pagePanel.Controls.Add(SettingsPanel);
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
            GMaps.Instance.ImportFromGMDB(@"C:\Users\АРМ\Desktop\RADAR_TCP_WORK_VER_SUPER\TileDBv5\en\Data.gmdb");
        }

    }
}