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

        string filter()
        {
            string filter = "";
            string TargetAddress = GetBoxValue("TargetAddress");
            string AircraftIdentification = GetBoxValue("AircraftIdentification");
            string EmitterCategory = GetBoxValue("EmitterCategory");
            string AirportDepature = GetBoxValue("AirportDepature");
            string AirportArrival = GetBoxValue("AirportArrival");
            string BeginTime = GetBoxValue("BeginTime");
            string EndTime = GetBoxValue("EndTime");

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
            return filter;
        }
        int checksum()
        {
            DataTable Category = SQL.query("SELECT CHECKSUM_AGG(GETCHECKSUM()) FROM dbo.[Load]");
            if (Convert.ToString(Category.Rows[0][0]) != "")
            {
                return Convert.ToInt32(Category.Rows[0][0]);
            }
            return 0;
        }

        void timerThread()
        {
            SQL.query("UPDATE dbo.[Load] SET Status = 'Завершен' WHERE AddTime < DATEADD(MINUTE, -" + Convert.ToString(Protocol.UPDATESTATUSMINUTE) + ", GETDATE()) AND Status = 'Активен'");
            int newchcksum = checksum();
            if (chcksum != newchcksum)
            {
                chcksum = newchcksum;
                ShowDataGridView(true);
            }
            updateThread.Abort();
        }
        private void UpdateTimer_Tick(object sender, System.EventArgs e)
        {
            updateThread = new Thread(timerThread);
            updateThread.Start();
        }

        public void LoadGridViewSetting()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(LoadGridViewSetting));
                return;
            }

            int[] WidthColumn = { 90, 130, 150, 130, 130, 130, 130, 150, 115 };

            for (int column = 1; column < LoadGridView1.ColumnCount; column++)
            {
                LoadGridView1.Columns[column].Width = WidthColumn[column - 1];
            }

            LoadGridView1.Columns[0].Visible = false;
            for (int column = 1; column < LoadGridView1.ColumnCount; column++)
            {
                LoadGridView1.Columns[column].Visible = true;
            }
        }
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
        private void LoadGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (e.RowIndex >= 0))
            {
                Thread DeleteThread = new Thread(() => openGPXThread(e.RowIndex));
                DeleteThread.Start();
            }
        }
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
        void ShowDataGridView(bool autoPosition)
        {
            string f = filter();
            UpdateDataGridView(SQL.query("SELECT Id, TargetAddress AS 'Адрес', AircraftIdentification AS 'Идентификатор', EmitterCategory AS 'Категория', AirportDepature AS 'Аэропорт вылета', AirportArrival AS 'Аэропорт прибытитя', BeginTime AS 'Начало маршрута', EndTime AS 'Конец маршрута', Interval AS 'Продолжительность', Status AS 'Статус' FROM dbo.[Load] " + f), autoPosition);
        }
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
                        result = TargetAddressTextBox.Text;
                        break;
                    }
                case "AircraftIdentification":
                    {
                        result = AircraftIdetificationTextBox.Text;
                        break;
                    }
                case "EmitterCategory":
                    {
                        result = EmitterCategoryComboBox.Text;
                        break;
                    }
                case "AirportDepature":
                    {
                        result = AirportDepatureTextBox.Text;
                        break;
                    }
                case "AirportArrival":
                    {
                        result = AirportArrivalTextBox.Text;
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
            }
            return result;
        }
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

        public void ProgressBarMax(int max)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(ProgressBarMax), new object[] { max });
                return;
            }
            progressBar1.Maximum = max;
        }
        public void ProgressBarValue(int value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(ProgressBarValue), new object[] { value });
                return;
            }
            progressBar1.Value = value;
        }

        private void TargetAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }
        private void AircraftIdetificationTextBox_TextChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }
        private void AircraftIdetificationTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AircraftIdetificationTextBox.BackColor = Color.FromKnownColor(KnownColor.ScrollBar);
        }
        private void AirportDepatureTextBox_TextChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }
        private void AirportArrivalTextBox_TextChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }

        private void EmitterCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }
        private void EmitterCategoryComboBox_Click(object sender, EventArgs e)
        {
            ComboBoxFill();
        }

        private void StartStopBTN_Click(object sender, EventArgs e)
        {
            if (start == false)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    StartStopBTN.BackgroundImage = Properties.Resources.stop;
                    start = true;

                    Protocol.GetFiles(folderBrowserDialog1.SelectedPath, "*.sig");
                    Protocol.STARTscanfolder(folderBrowserDialog1.SelectedPath, "*.sig");
                    Protocol.START();
                }             
            }

            else
            {
                StartStopBTN.BackgroundImage = Properties.Resources.mouseenterStop;
                progressBar1.Value = 0;
                start = false;

                Protocol.STOPscanfolder();
                Protocol.STOP();                
            }
        }
        private void StartStopBTN_MouseEnter(object sender, EventArgs e)
        {
            if (start)
            {
                StartStopBTN.BackgroundImage = Properties.Resources.mouseenterStart;
            }
            else
            {
                StartStopBTN.BackgroundImage = Properties.Resources.mouseenterStop;
            }
        }
        private void StartStopBTN_MouseLeave(object sender, EventArgs e)
        {
            if (start)
            {
                StartStopBTN.BackgroundImage = Properties.Resources.stop;
            }
            else
            {
                StartStopBTN.BackgroundImage = Properties.Resources.start;
            }
        }

        private void EndTimePicker_DropDown(object sender, EventArgs e)
        {
            EnableEndTimePicker = true;
            ShowDataGridView(false);
        }
        private void EndTimePicker_MouseDown(object sender, MouseEventArgs e)
        {
            if (EnableEndTimePicker != EndTimePicker.Checked)
            {
                EnableEndTimePicker = !EnableEndTimePicker;
                ShowDataGridView(false);
            }
        }
        private void EndTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }

        private void BeginTimePicker_DropDown(object sender, EventArgs e)
        {
            EnableBeginTimePicker = true;
            ShowDataGridView(false);
        }
        private void BeginTimePicker_MouseDown(object sender, MouseEventArgs e)
        {
            if (EnableBeginTimePicker != BeginTimePicker.Checked)
            {
                EnableBeginTimePicker = !EnableBeginTimePicker;
                ShowDataGridView(false);
            }
        }
        private void BeginTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Protocol.STOP();

            if (updateThread != null)
            {
                updateThread.Abort();
            }
        }

        public GUI()
        {
            if (SQL.Connect())
            {
                InitializeComponent();
                Protocol.Init(this);
                chcksum = checksum();
                ShowDataGridView(false);
                UpdateTimer.Interval = UPDATEGRIDMILLISECONDS;
                UpdateTimer.Enabled = true;
            }
        }
    }
}