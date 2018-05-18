using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Xml;
using System.Data.SqlClient;
using System.Threading;

namespace ASTERIX
{
    public partial class Form1 : Form
    {
        Stream binStream;
        DataTable FSPECtable21, FSPECtable62;
        List<string> ASCIIlist, EmitterCategorylist;
        SqlDataAdapter adapt;
        SqlConnection sqlConnection1;
        Thread mythread, updateThread;

        List<string> pathList;
        FileSystemWatcher watcher;

        int chcksum;

        bool FirstSetting = false;
        bool EnableBeginTimePicker = true;
        bool EnableEndTimePicker = false;

        bool start = false;

        bool userDeleting = true;

        object locker = new object();

        int UPDATEGRIDMILLISECONDS = 5000;
        int UPDATESTATUSMINUTE = 20;

        DataTable query(string query)
        {
            lock (locker)
            {
                try
                {
                    adapt = new SqlDataAdapter(query, sqlConnection1);
                    DataTable table = new DataTable();
                    adapt.Fill(table);
                    return table;
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return null;
        }
        void INSERT(object[] Trek)
        {
            string Status = "Активен";

            string TargetAddress = (string)Trek[0];
            string AircraftIdentification = (string)Trek[1];
            string EmitterCategory = (string)Trek[2];
            string AirportDepature = (string)Trek[3];
            string AirportArrival = (string)Trek[4];
            string BeginTime = (string)Trek[5];
            string EndTime = (string)Trek[6];
            string Interval = (string)Trek[7];
            DataTable Aircraftmessage = (DataTable)Trek[8];

            XmlDocument doc = new XmlDocument();
            doc.InnerXml = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?> <gpx xmlns = \"http://www.topografix.com/GPX/1/1\" creator = \"MapSource 6.16.3\" version = \"1.1\"> </gpx>";

            XmlElement name = doc.CreateElement("name");
            name.InnerText = TargetAddress;

            XmlElement rte = doc.CreateElement("rte");
            rte.AppendChild(name);

            for (int point = 0; point < Aircraftmessage.Rows.Count; point++)
            {
                XmlElement rtept = doc.CreateElement("rtept");
                rtept.IsEmpty = true;
                rtept.SetAttribute("lon", Convert.ToString(Aircraftmessage.Rows[point]["Longitude"]).Replace(",", "."));
                rtept.SetAttribute("lat", Convert.ToString(Aircraftmessage.Rows[point]["Latitude"]).Replace(",", "."));
               // if (point != 0)
             //   {
                    XmlElement sym = doc.CreateElement("sym");
                    sym.InnerText = "Airport";
                    rtept.AppendChild(sym);
                //}
                rte.AppendChild(rtept);
            }

            doc.DocumentElement.AppendChild(rte);
            doc.DocumentElement.InnerXml = doc.DocumentElement.InnerXml.Replace("xmlns=\"\"", "");

            string insert = "INSERT INTO dbo.[Load] (TargetAddress, AircraftIdentification, EmitterCategory, AirportDepature, AirportArrival, BeginTime, EndTime, Interval, Status, Gpx, AddTime) VALUES('" + TargetAddress + "','" + AircraftIdentification + "','" + EmitterCategory + "','" + AirportDepature + "','" + AirportArrival + "','" + BeginTime + "','" + EndTime + "','" + Interval + "','" + Status + "','" + doc.InnerXml + "', GETDATE())";
            query(insert);
        }
        void UPDATE(object[] Trek, DataRow oldRow)
        {
            string OldEndTime = Convert.ToString(oldRow[7]);
            string BeginTime = (string)Trek[5];

            if ((DateTime.Parse(BeginTime) - DateTime.Parse(OldEndTime)) > TimeSpan.Parse("00:" + Convert.ToString(UPDATESTATUSMINUTE) + ":00"))
            {
                query("UPDATE dbo.[Load] SET Status = 'Завершен' WHERE Id =" + Convert.ToString(oldRow[0]));
                INSERT(Trek);
                return;
            }
            string OldBeginTime = Convert.ToString(oldRow[6]);
            string EndTime = (string)Trek[6];
            string Interval = (DateTime.Parse(EndTime) - DateTime.Parse(OldBeginTime)).ToString();

            Interval = Interval.Replace("-","");

            if (BeginTime != OldBeginTime)
            {
                DataTable Aircraftmessage = (DataTable)Trek[8];

                XmlDocument doc = new XmlDocument();
                doc.InnerXml = Convert.ToString(oldRow[10]);
                XmlNodeList node = doc.DocumentElement.ChildNodes;

                XmlNode newNode = node[0];
                for (int point = 0; point < Aircraftmessage.Rows.Count; point++)
                {
                    XmlElement rtept = doc.CreateElement("rtept");
                    rtept.IsEmpty = true;
                    rtept.SetAttribute("lon", Convert.ToString(Aircraftmessage.Rows[point]["Longitude"]).Replace(",", "."));
                    rtept.SetAttribute("lat", Convert.ToString(Aircraftmessage.Rows[point]["Latitude"]).Replace(",", "."));
                    newNode.AppendChild(rtept);
                }
                doc.DocumentElement.ReplaceChild(node[0], newNode);
                doc.DocumentElement.InnerXml = doc.DocumentElement.InnerXml.Replace("xmlns=\"\"", "");

                string update = "UPDATE dbo.[Load] SET EndTime = '" + EndTime + "', Interval = '" + Interval + "', Gpx = '" + doc.InnerXml + "', AddTime = GETDATE() WHERE Id = " + Convert.ToString(oldRow[0]);
                query(update);
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
                query(delete);

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
        void ShowDataGridView(bool autoPosition)
        {
            string f = filter();
            UpdateDataGridView(query("SELECT Id, TargetAddress AS 'Адрес', AircraftIdentification AS 'Идентификатор', EmitterCategory AS 'Категория', AirportDepature AS 'Аэропорт вылета', AirportArrival AS 'Аэропорт прибытитя', BeginTime AS 'Начало маршрута', EndTime AS 'Конец маршрута', Interval AS 'Продолжительность', Status AS 'Статус' FROM dbo.[Load] " + f), autoPosition);
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
        public void ComboBoxFill()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ComboBoxFill));
                return;
            }
            EmitterCategoryComboBox.Items.Clear();
            DataTable Category = query("SELECT DISTINCT(EmitterCategory) FROM dbo.[Load]");
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
        public void LoadGridViewSetting()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(LoadGridViewSetting));
                return;
            }

            int[] WidthColumn = { 90, 130, 150, 130, 130, 130, 130, 150, 115 };

            for (int column = 1; column < LoadGridView1.ColumnCount - 1; column++)
            {
                LoadGridView1.Columns[column].Width = WidthColumn[column - 1];
            }

            for (int column = 0; column < LoadGridView1.ColumnCount; column++)
            {
                if ((column == 0) || (column == 10))
                {
                    LoadGridView1.Columns[column].Visible = false;
                }
                else
                {
                    LoadGridView1.Columns[column].Visible = true;
                }
            }
        }
        BitArray GetVariableField()
        {
            List<byte> bytes = new List<byte>();
            do
            {
                bytes.Add(Convert.ToByte(binStream.ReadByte()));
            }
            while (new BitArray(BitConverter.GetBytes(bytes.Last())).Get(0) == true);
            bytes.Reverse();
            return (new BitArray(bytes.ToArray()));
        }
        DataTable GetFSPECtable(int category)
        {
            DataTable FSPECtable = new DataTable();
            FSPECtable.Columns.Add("Data Item", System.Type.GetType("System.String"));
            FSPECtable.Columns.Add("Length", System.Type.GetType("System.Int32"));

            string data;
            string length;

            StringReader dataReader;
            StringReader lengthReader;

            if (category == 21)
            {
                data = Properties.Resources.Data_Item_21;
                length = Properties.Resources.Length_21;

                dataReader = new StringReader(data);
                lengthReader = new StringReader(length);

                for (int i = 0; i < 55; i++)
                {
                    FSPECtable.Rows.Add(new object[] { dataReader.ReadLine(), Convert.ToInt32(lengthReader.ReadLine()) });
                }
            }

            if (category == 62)
            {
                data = Properties.Resources.Data_Item_62;
                length = Properties.Resources.Length_62;

                dataReader = new StringReader(data);
                lengthReader = new StringReader(length);

                for (int i = 0; i < 39; i++)
                {
                    FSPECtable.Rows.Add(new object[] { dataReader.ReadLine(), Convert.ToInt32(lengthReader.ReadLine()) });
                }
            }

            return FSPECtable;
        }
        List<string> GetList(string data)
        {
            List<string> list = new List<string>();
            StringReader dataReader = new StringReader(data);
            string str = "";
            while ((str = dataReader.ReadLine()) != null)
            {
                list.Add(str);
            }
            return list;
        }
        string ASCIIDecoder(byte[] codebytes, List<string> ASCIItable)
        {
            BitArray bits = new BitArray(codebytes.Reverse().ToArray());
            BitArray codebits = new BitArray(8);
            string result = "";
            byte[] code = new byte[1];
            int pos = bits.Length - 1;
            while (pos > 5)
            {
                codebits.SetAll(false);
                for (int bit = 5; bit >= 0; bit--)
                {
                    codebits.Set(bit, bits.Get(pos));
                    pos--;
                }
                codebits.CopyTo(code, 0);
                result += ASCIItable[Convert.ToInt32(code[0])];
            }
            return result;
        }
        double CoordinateDecoder130(byte[] coordinatebytes)
        {
            return Convert.ToDouble(BitConverter.ToInt32(coordinatebytes.Reverse().ToArray(), 0) * 0.000021457672119140625);
        }
        double CoordinateDecoder131(byte[] coordinatebytes)
        {
            return Convert.ToDouble(BitConverter.ToInt32(coordinatebytes.Reverse().ToArray(), 0) / 5965232.3555555599221118074846386);
        }
        double CoordinateDecoder105(byte[] coordinatebytes)
        {
            return Convert.ToDouble(BitConverter.ToInt32(coordinatebytes.Reverse().ToArray(), 0) * 0.00000536441802978515625);
        }
        string TimeDecoder(double second)
        {
            return Convert.ToString(DateTime.UtcNow.Date.AddSeconds(second).ToLocalTime());
            // return Convert.ToString(query("SELECT CONVERT(DATETIME, SWITCHOFFSET(TODATETIMEOFFSET(DATEADD(SECOND, 10, CONVERT(DATETIME, CONVERT(DATE, GETUTCDATE()))), '+00:00'), DATENAME(TZ, SYSDATETIMEOFFSET())))").Rows[0][0]);    
        }

        bool chekcrash(int lengthSIG)
        {
            byte[] lengthPacket = new byte[2];
            int length = 0;

            binStream.Read(lengthPacket, 0, 2);
            length = BitConverter.ToInt16(lengthPacket.Reverse().ToArray(), 0);
            if (length == lengthSIG)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool chekEndPacket(int endPacket, int offset)
        {
            if (binStream.Position + offset > endPacket)
            {
                binStream.Position = endPacket;
                return false;
            }
            return true;
        }

        DataTable ReadFile(string filename)
        {
            DataTable message = new DataTable();
            message.Columns.Add("TargetAddress", System.Type.GetType("System.String"));
            message.Columns.Add("AircraftIdentification", System.Type.GetType("System.String"));
            message.Columns.Add("EmitterCategory", System.Type.GetType("System.String"));
            message.Columns.Add("AirportDepature", System.Type.GetType("System.String"));
            message.Columns.Add("AirportArrival", System.Type.GetType("System.String"));
            message.Columns.Add("Latitude", System.Type.GetType("System.Double"));
            message.Columns.Add("Longitude", System.Type.GetType("System.Double"));
            message.Columns.Add("DTime", System.Type.GetType("System.Double"));

            BitArray FSPEC;

            byte[] TargetAddressbytes = new byte[4];
            byte[] TimePosition = new byte[4];
            byte[] Latitudebytes = new byte[4];
            byte[] Longitudebytes = new byte[4];
            byte[] AircraftIdentificationbytes = new byte[6];
            byte[] AirportDepaturebytes = new byte[4];
            byte[] AirportArrivalbytes = new byte[4];
            byte[] Callsing = new byte[7];

            openFileDialog1.FileName = filename;

            if ((binStream = File.Open(filename,FileMode.Open)) != null)
            {
                byte[] lengthSIGBytes = new byte[2];
                int lengthPacket, lengthSIG;
                long startPacket;
                int endPacket = 0;

                while (binStream.Position != binStream.Length)
                {
                    binStream.Read(lengthSIGBytes, 0, 2);
                    lengthSIG = BitConverter.ToInt16(lengthSIGBytes.ToArray(), 0);
                    startPacket = binStream.Position;
                    int category = binStream.ReadByte();

                    switch (category)
                    {
                        case 21:
                            {
                                if (chekcrash(lengthSIG))
                                {
                                    binStream.Position = startPacket + 3;
                                    lengthPacket = lengthSIG;
                                    endPacket = Convert.ToInt32(startPacket) + lengthPacket;

                                    while (binStream.Position != endPacket)
                                    {
                                        string TargetAddress = "";
                                        string AircraftIdentification = "";
                                        double Latitude = 0;
                                        double Longitude = 0;
                                        string EmitterCategory = "";

                                        FSPEC = GetVariableField();
                                        for (int FSPECbit = 0; FSPECbit < FSPEC.Length; FSPECbit++)
                                        {
                                            if (FSPEC.Get((FSPEC.Length - 1) - FSPECbit) == true)
                                            {
                                                string di = Convert.ToString(FSPECtable21.Rows[FSPECbit]["Data Item"]);
                                                if ((di == "040") || (di == "090") || (di == "220") || (di == "110") || (di == "271"))
                                                {
                                                    GetVariableField();
                                                }
                                                else
                                                {
                                                    switch (di)
                                                    {
                                                        case "020":
                                                            {
                                                                if (chekEndPacket(endPacket, 1))
                                                                {
                                                                    EmitterCategory = EmitterCategorylist[binStream.ReadByte()];
                                                                }
                                                                break;
                                                            }
                                                        case "073":
                                                            {
                                                                if (chekEndPacket(endPacket, 3))
                                                                {
                                                                    binStream.Read(TimePosition, 1, 3);
                                                                }
                                                                break;
                                                            }
                                                        case "080":
                                                            {
                                                                if (chekEndPacket(endPacket, 3))
                                                                {
                                                                    binStream.Read(TargetAddressbytes, 0, 3);
                                                                }
                                                                TargetAddress = "0x";
                                                                for (int i = 0; i < 3; i++)
                                                                {
                                                                    if (Convert.ToString(TargetAddressbytes[i], 16).Length < 2)
                                                                    {
                                                                        TargetAddress += "0";
                                                                    }
                                                                    TargetAddress += Convert.ToString(TargetAddressbytes[i], 16);
                                                                }
                                                                break;
                                                            }
                                                        case "130":
                                                            {
                                                                if (chekEndPacket(endPacket, 3))
                                                                {
                                                                    binStream.Read(Latitudebytes, 1, 3);
                                                                }
                                                                Latitude = CoordinateDecoder130(Latitudebytes);
                                                                if (chekEndPacket(endPacket, 3))
                                                                {
                                                                    binStream.Read(Longitudebytes, 1, 3);
                                                                }
                                                                Longitude = CoordinateDecoder130(Longitudebytes);
                                                                break;
                                                            }
                                                        case "131":
                                                            {
                                                                if (chekEndPacket(endPacket, 4))
                                                                {
                                                                    binStream.Read(Latitudebytes, 0, 4);
                                                                }
                                                                Latitude = CoordinateDecoder131(Latitudebytes);
                                                                if (chekEndPacket(endPacket, 4))
                                                                {
                                                                    binStream.Read(Longitudebytes, 0, 4);
                                                                }
                                                                Longitude = CoordinateDecoder131(Longitudebytes);
                                                                break;
                                                            }
                                                        case "170":
                                                            {
                                                                if (chekEndPacket(endPacket, 6))
                                                                {
                                                                    binStream.Read(AircraftIdentificationbytes, 0, 6);
                                                                }
                                                                AircraftIdentification = ASCIIDecoder(AircraftIdentificationbytes, ASCIIlist);
                                                                break;
                                                            }
                                                        case "295":
                                                            {
                                                                BitArray DataAgesFSPEC = GetVariableField();
                                                                int countoctet = 0;
                                                                for (int bit = 0; bit < DataAgesFSPEC.Length; bit++)
                                                                {
                                                                    if (DataAgesFSPEC.Get(bit) == true)
                                                                    {
                                                                        countoctet++;
                                                                    }
                                                                }
                                                                countoctet -= (DataAgesFSPEC.Length / 8 - 1);
                                                                if (chekEndPacket(endPacket, countoctet))
                                                                {
                                                                    binStream.Seek(countoctet, SeekOrigin.Current);
                                                                }
                                                                break;
                                                            }
                                                        case "RE":
                                                            {
                                                                if (chekEndPacket(endPacket, binStream.ReadByte() - 1))
                                                                {
                                                                    binStream.Position -= 1;
                                                                    binStream.Seek(binStream.ReadByte() - 1, SeekOrigin.Current);
                                                                }
                                                                break;
                                                            }
                                                        case "SP":
                                                            {
                                                                if (chekEndPacket(endPacket, binStream.ReadByte() - 1))
                                                                {
                                                                    binStream.Position -= 1;
                                                                    binStream.Seek(binStream.ReadByte() - 1, SeekOrigin.Current);
                                                                }
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                if (chekEndPacket(endPacket, Convert.ToInt32(FSPECtable21.Rows[FSPECbit]["length"])))
                                                                {
                                                                    binStream.Seek(Convert.ToInt32(FSPECtable21.Rows[FSPECbit]["length"]), SeekOrigin.Current);
                                                                }
                                                                break;
                                                            }
                                                    }
                                                }
                                            }
                                        }
                                        if (TargetAddress != "")
                                        {
                                            message.Rows.Add(new object[] { TargetAddress, AircraftIdentification, EmitterCategory, "", "", Latitude, Longitude, Convert.ToDouble(BitConverter.ToInt32(TimePosition.Reverse().ToArray(), 0) / 128) });
                                        }
                                    }
                                }
                                else
                                {
                                    binStream.Position += (lengthSIG - 3);
                                }
                                break;
                            }
                        case 62:
                            {
                                if (chekcrash(lengthSIG - 2))
                                {
                                    binStream.Position = startPacket + 3;
                                    lengthPacket = lengthSIG - 2;
                                    endPacket = Convert.ToInt32(startPacket) + lengthPacket;

                                    while (binStream.Position != endPacket)
                                    {
                                        string TargetAddress = "";
                                        string AircraftIdentification = "";
                                        double Latitude = 0;
                                        double Longitude = 0;
                                        string EmitterCategory = "";
                                        string AirportDepature = "";
                                        string AirportArrival = "";

                                        FSPEC = GetVariableField();
                                        int[] FSPEC110Length = { 1, 4, 6, 2, 2, 1, 1, 0 };
                                        int[] FSPEC290Length = { 1, 1, 1, 1, 2, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0 };
                                        int[] FSPEC295Length = { 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0 };
                                        int[] FSPEC340Length = { 2, 4, 2, 2, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                                        int[] FSPEC380Length = { 0, 2, 2, 2, 9, 1, 2, 6, 0, 1, 8, 1, 2, 2, 2, 2, 0, 2, 2, 7, 2, 2, 16, 1, 0, 2, 2, 2, 2, 2, 6, 3 };
                                        FSPEC380Length = FSPEC380Length.Reverse().ToArray();
                                        int[] FSPEC390Length = { 0, 0, 0, 0, 7, 2, 7, 7, 0, 1, 6, 5, 2, 2, 3, 4, 0, 4, 1, 4, 1, 4, 7, 2 };
                                        FSPEC390Length = FSPEC390Length.Reverse().ToArray();
                                        int[] FSPEC500Length = { 4, 2, 4, 1, 1, 2, 2, 0, 1, 0, 0, 0, 0, 0, 0, 0 };

                                        for (int FSPECbit = 0; FSPECbit < FSPEC.Length; FSPECbit++)
                                        {
                                            if ((FSPEC.Get((FSPEC.Length - 1) - FSPECbit) == true) && (FSPECbit < 39))
                                            {
                                                string di = Convert.ToString(FSPECtable62.Rows[FSPECbit]["Data Item"]);
                                                if ((di == "080") || (di == "270") || (di == "RE"))
                                                {
                                                    GetVariableField();
                                                }
                                                else
                                                {
                                                    switch (di)
                                                    {
                                                        case "070":
                                                            {
                                                                if (chekEndPacket(endPacket, 3))
                                                                {
                                                                    binStream.Read(TimePosition, 1, 3);
                                                                }
                                                                break;
                                                            }
                                                        case "105":
                                                            {
                                                                if (chekEndPacket(endPacket, 4))
                                                                {
                                                                    binStream.Read(Latitudebytes, 0, 4);
                                                                }
                                                                else
                                                                {
                                                                    break;
                                                                }
                                                                Latitude = CoordinateDecoder105(Latitudebytes);
                                                                if (chekEndPacket(endPacket, 4))
                                                                {
                                                                    binStream.Read(Longitudebytes, 0, 4);
                                                                }
                                                                else
                                                                {
                                                                    break;
                                                                }
                                                                Longitude = CoordinateDecoder105(Longitudebytes);
                                                                break;
                                                            }
                                                        case "110":
                                                            {
                                                                BitArray DataAgesFSPEC = GetVariableField();
                                                                for (int bit = DataAgesFSPEC.Length - 1; bit >= 0; bit--)
                                                                {
                                                                    if ((DataAgesFSPEC.Get(bit) == true) && (bit > DataAgesFSPEC.Length - FSPEC110Length.Length))
                                                                    {
                                                                        if (chekEndPacket(endPacket, FSPEC110Length[DataAgesFSPEC.Length - bit - 1]))
                                                                        {
                                                                            binStream.Seek(FSPEC110Length[DataAgesFSPEC.Length - bit - 1], SeekOrigin.Current);
                                                                        }
                                                                        else
                                                                        {
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                                break;
                                                            }
                                                        case "290":
                                                            {
                                                                BitArray DataAgesFSPEC = GetVariableField();
                                                                for (int bit = DataAgesFSPEC.Length - 1; bit >= 0; bit--)
                                                                {
                                                                    if ((DataAgesFSPEC.Get(bit) == true) && (bit > DataAgesFSPEC.Length - FSPEC290Length.Length))
                                                                    {
                                                                        if (chekEndPacket(endPacket, FSPEC290Length[DataAgesFSPEC.Length - bit - 1]))
                                                                        {
                                                                            binStream.Seek(FSPEC290Length[DataAgesFSPEC.Length - bit - 1], SeekOrigin.Current);
                                                                        }
                                                                        else
                                                                        {
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                                break;
                                                            }
                                                        case "295":
                                                            {
                                                                BitArray DataAgesFSPEC = GetVariableField();
                                                                for (int bit = DataAgesFSPEC.Length - 1; bit >= 0; bit--)
                                                                {
                                                                    if ((DataAgesFSPEC.Get(bit) == true) && (bit > DataAgesFSPEC.Length - FSPEC295Length.Length))
                                                                    {
                                                                        if (chekEndPacket(endPacket, FSPEC295Length[DataAgesFSPEC.Length - bit - 1]))
                                                                        {
                                                                            binStream.Seek(FSPEC295Length[DataAgesFSPEC.Length - bit - 1], SeekOrigin.Current);
                                                                        }
                                                                        else
                                                                        {
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                                break;
                                                            }
                                                        case "340":
                                                            {
                                                                BitArray DataAgesFSPEC = GetVariableField();
                                                                for (int bit = DataAgesFSPEC.Length - 1; bit >= 0; bit--)
                                                                {
                                                                    if ((DataAgesFSPEC.Get(bit) == true) && (bit > DataAgesFSPEC.Length - FSPEC340Length.Length))
                                                                    {
                                                                        if (chekEndPacket(endPacket, FSPEC340Length[DataAgesFSPEC.Length - bit - 1]))
                                                                        {
                                                                            binStream.Seek(FSPEC340Length[DataAgesFSPEC.Length - bit - 1], SeekOrigin.Current);
                                                                        }
                                                                        else
                                                                        {
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                                break;
                                                            }
                                                        case "380":
                                                            {
                                                                BitArray DataAgesFSPEC = GetVariableField();
                                                                for (int bit = DataAgesFSPEC.Length - 1; bit >= 0; bit--)
                                                                {
                                                                    if (DataAgesFSPEC.Get(bit) == true)
                                                                    {
                                                                        if (bit == DataAgesFSPEC.Length - 1)
                                                                        {
                                                                            if (chekEndPacket(endPacket, 3))
                                                                            {
                                                                                binStream.Read(TargetAddressbytes, 0, 3);
                                                                            }
                                                                            else
                                                                            {
                                                                                break;
                                                                            }
                                                                            TargetAddress = "0x";
                                                                            for (int i = 0; i < 3; i++)
                                                                            {
                                                                                if (Convert.ToString(TargetAddressbytes[i], 16).Length < 2)
                                                                                {
                                                                                    TargetAddress += "0";
                                                                                }
                                                                                TargetAddress += Convert.ToString(TargetAddressbytes[i], 16);
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (bit == DataAgesFSPEC.Length - 2)
                                                                            {
                                                                                if (chekEndPacket(endPacket, 6))
                                                                                {
                                                                                    binStream.Read(AircraftIdentificationbytes, 0, 6);
                                                                                }
                                                                                else
                                                                                {
                                                                                    break;
                                                                                }
                                                                                AircraftIdentification = ASCIIDecoder(AircraftIdentificationbytes, ASCIIlist);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (bit > DataAgesFSPEC.Length - FSPEC380Length.Length)
                                                                                {
                                                                                    if (chekEndPacket(endPacket, FSPEC380Length[DataAgesFSPEC.Length - bit - 1]))
                                                                                    {
                                                                                        binStream.Seek(FSPEC380Length[DataAgesFSPEC.Length - bit - 1], SeekOrigin.Current);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        break;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                break;
                                                            }
                                                        case "390":
                                                            {
                                                                BitArray DataAgesFSPEC = GetVariableField();
                                                                for (int bit = DataAgesFSPEC.Length - 1; bit >= 0; bit--)
                                                                {
                                                                    if (DataAgesFSPEC.Get(bit) == true)
                                                                    {
                                                                        if ((bit == DataAgesFSPEC.Length - 2) || (bit == DataAgesFSPEC.Length - 6) || (bit == DataAgesFSPEC.Length - 7) || (bit == DataAgesFSPEC.Length - 9))
                                                                        {
                                                                            if (bit == DataAgesFSPEC.Length - 2)
                                                                            {
                                                                                if (chekEndPacket(endPacket, 7))
                                                                                {
                                                                                    binStream.Read(Callsing, 0, 7);
                                                                                }
                                                                                else
                                                                                {
                                                                                    break;
                                                                                }
                                                                                AircraftIdentification = Encoding.ASCII.GetString(Callsing).Replace("'", "");
                                                                            }
                                                                            if (bit == DataAgesFSPEC.Length - 6)
                                                                            {
                                                                                switch (Convert.ToChar(binStream.ReadByte()))
                                                                                {
                                                                                    case 'L':
                                                                                        {
                                                                                            EmitterCategory = "LIGHT AIRCRAFT";
                                                                                            break;
                                                                                        }
                                                                                    case 'M':
                                                                                        {
                                                                                            EmitterCategory = "MEDIUM AIRCRAFT";
                                                                                            break;
                                                                                        }
                                                                                    case 'H':
                                                                                        {
                                                                                            EmitterCategory = "HIGH AIRCRAFT";
                                                                                            break;
                                                                                        }
                                                                                }
                                                                            }
                                                                            if (bit == DataAgesFSPEC.Length - 7)
                                                                            {
                                                                                if (chekEndPacket(endPacket, 4))
                                                                                {
                                                                                    binStream.Read(AirportDepaturebytes, 0, 4);
                                                                                }
                                                                                else
                                                                                {
                                                                                    break;
                                                                                }
                                                                                AirportDepature = Encoding.ASCII.GetString(AirportDepaturebytes);
                                                                            }
                                                                            if (bit == DataAgesFSPEC.Length - 9)
                                                                            {
                                                                                if (chekEndPacket(endPacket, 4))
                                                                                {
                                                                                    binStream.Read(AirportArrivalbytes, 0, 4);
                                                                                }
                                                                                else
                                                                                {
                                                                                    break;
                                                                                }
                                                                                AirportArrival = Encoding.ASCII.GetString(AirportArrivalbytes);
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (bit > DataAgesFSPEC.Length - FSPEC390Length.Length)
                                                                            {
                                                                                if (chekEndPacket(endPacket, FSPEC390Length[DataAgesFSPEC.Length - bit - 1]))
                                                                                {
                                                                                    binStream.Seek(FSPEC390Length[DataAgesFSPEC.Length - bit - 1], SeekOrigin.Current);
                                                                                }
                                                                                else
                                                                                {
                                                                                    break;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                break;
                                                            }
                                                        case "500":
                                                            {
                                                                BitArray DataAgesFSPEC = GetVariableField();
                                                                for (int bit = DataAgesFSPEC.Length - 1; bit >= 0; bit--)
                                                                {
                                                                    if ((DataAgesFSPEC.Get(bit) == true) && (bit > DataAgesFSPEC.Length - FSPEC500Length.Length))
                                                                    {
                                                                        if (chekEndPacket(endPacket, FSPEC500Length[DataAgesFSPEC.Length - bit - 1]))
                                                                        {
                                                                            binStream.Seek(FSPEC500Length[DataAgesFSPEC.Length - bit - 1], SeekOrigin.Current);
                                                                        }
                                                                        else
                                                                        {
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                                break;
                                                            }
                                                        case "SP":
                                                            {
                                                                if (chekEndPacket(endPacket, binStream.ReadByte() - 1))
                                                                {
                                                                    binStream.Position -= 1;
                                                                    binStream.Seek(binStream.ReadByte() - 1, SeekOrigin.Current);
                                                                }
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                if (chekEndPacket(endPacket, Convert.ToInt32(FSPECtable62.Rows[FSPECbit]["length"])))
                                                                {
                                                                    binStream.Seek(Convert.ToInt32(FSPECtable62.Rows[FSPECbit]["length"]), SeekOrigin.Current);
                                                                }
                                                                break;
                                                            }
                                                    }
                                                }
                                            }
                                        }

                                        if (TargetAddress != "")
                                        {
                                            message.Rows.Add(new object[] { TargetAddress, AircraftIdentification, EmitterCategory, AirportDepature, AirportArrival, Latitude, Longitude, Convert.ToDouble(BitConverter.ToInt32(TimePosition.Reverse().ToArray(), 0) / 128) });
                                        }
                                    }

                                    binStream.Position += 2;
                                }
                                else
                                {
                                    binStream.Position += (lengthSIG - 3);
                                }
                                break;
                            }
                        default:
                            {
                                binStream.Position += lengthSIG - 1;
                                break;
                            }
                    }
                }
                binStream.Close();
            }
            return message;
        }
        object[,] ReadTrek(DataTable CoordinateTable, string TargetAddress)
        {
            DataTable TrekCoordinate = CoordinateTable.Select("TargetAddress = '" + TargetAddress + "'").CopyToDataTable().Select().OrderBy(ms => ms["DTime"]).CopyToDataTable();
            DataTable NewTrek = new DataTable();
            NewTrek.Columns.Add("TargetAddress", System.Type.GetType("System.String"));
            NewTrek.Columns.Add("AircraftIdentification", System.Type.GetType("System.String"));
            NewTrek.Columns.Add("EmitterCategory", System.Type.GetType("System.String"));
            NewTrek.Columns.Add("AirportDepature", System.Type.GetType("System.String"));
            NewTrek.Columns.Add("AirportArrival", System.Type.GetType("System.String"));
            NewTrek.Columns.Add("Latitude", System.Type.GetType("System.Double"));
            NewTrek.Columns.Add("Longitude", System.Type.GetType("System.Double"));
            NewTrek.Columns.Add("DTime", System.Type.GetType("System.Double"));

            int i = 0;

            for (int time = 0; time < TrekCoordinate.Rows.Count - 1; time++)
            {
                if (Convert.ToDouble(TrekCoordinate.Rows[time + 1]["DTime"]) - Convert.ToDouble(TrekCoordinate.Rows[time]["DTime"]) > UPDATESTATUSMINUTE * 60)
                {
                    i++;
                }
            }

            object[,] TrekInfo = new object[i + 1, 9];

            i = 0;

            for (int time = 0; time < TrekCoordinate.Rows.Count; time++)
            {
                if (time > 0)
                {
                    if (((Convert.ToDouble(TrekCoordinate.Rows[time]["DTime"]) - Convert.ToDouble(TrekCoordinate.Rows[time - 1]["DTime"]) > UPDATESTATUSMINUTE * 60) || (time == TrekCoordinate.Rows.Count - 1)) && (NewTrek.Rows.Count > 0))
                    {
                        string BeginTime = TimeDecoder(Convert.ToDouble(NewTrek.Rows[0]["DTime"]));
                        string EndTime = TimeDecoder(Convert.ToDouble(NewTrek.Rows[NewTrek.Rows.Count - 1]["DTime"]));
                        string Interval = (DateTime.Parse(EndTime) - DateTime.Parse(BeginTime)).ToString();

                        TrekInfo[i, 0] = NewTrek.Rows[0]["TargetAddress"];
                        TrekInfo[i, 1] = NewTrek.Rows[0]["AircraftIdentification"];
                        TrekInfo[i, 2] = NewTrek.Rows[0]["EmitterCategory"];
                        TrekInfo[i, 3] = NewTrek.Rows[0]["AirportDepature"];
                        TrekInfo[i, 4] = NewTrek.Rows[0]["AirportArrival"];
                        TrekInfo[i, 5] = BeginTime;
                        TrekInfo[i, 6] = EndTime;
                        TrekInfo[i, 7] = Interval;
                        TrekInfo[i, 8] = NewTrek;

                        NewTrek = new DataTable();
                        NewTrek.Columns.Add("TargetAddress", System.Type.GetType("System.String"));
                        NewTrek.Columns.Add("AircraftIdentification", System.Type.GetType("System.String"));
                        NewTrek.Columns.Add("EmitterCategory", System.Type.GetType("System.String"));
                        NewTrek.Columns.Add("AirportDepature", System.Type.GetType("System.String"));
                        NewTrek.Columns.Add("AirportArrival", System.Type.GetType("System.String"));
                        NewTrek.Columns.Add("Latitude", System.Type.GetType("System.Double"));
                        NewTrek.Columns.Add("Longitude", System.Type.GetType("System.Double"));
                        NewTrek.Columns.Add("DTime", System.Type.GetType("System.Double"));

                        i++;
                    }
                    else
                    {
                        NewTrek.LoadDataRow(TrekCoordinate.Rows[time].ItemArray, true);
                    }
                }
                else
                {
                    NewTrek.LoadDataRow(TrekCoordinate.Rows[time].ItemArray, true);
                }
            }

            return TrekInfo;
        }
        void thread()
        {
            int file = 0;
            while (start)
            {
                if (pathList.Count != 0)
                {
                    try
                    {
                        DataTable CoordinateTable = ReadFile(Convert.ToString(pathList[file]));

                        List<string> TargetAddress = new List<string>();

                        for (int TAddress = 0; TAddress < CoordinateTable.Rows.Count; TAddress++)
                        {
                            TargetAddress.Add(Convert.ToString(CoordinateTable.Rows[TAddress]["TargetAddress"]));
                        }
                        TargetAddress = TargetAddress.Distinct().ToList();
                        ProgressBarMax(TargetAddress.Count);
                        for (int Address = 0; Address < TargetAddress.Count; Address++)
                        {
                            object[,] Treks = ReadTrek(CoordinateTable, TargetAddress[Address]);
                            for (int i = 0; i <= Treks.GetUpperBound(0); i++)
                            {
                                if (Treks[i, 0] != null)
                                {
                                    object[] Trek = new object[9];
                                    for (int n = 0; n < 9; n++)
                                    {
                                        Trek[n] = Treks[i, n];
                                    }

                                    query("UPDATE dbo.[Load] SET Status = 'Завершен' WHERE AddTime < DATEADD(MINUTE, -" + Convert.ToString(UPDATESTATUSMINUTE) + ", GETDATE()) AND Status = 'Активен'");

                                    int countTargetAddress = Convert.ToInt32(query("SELECT COUNT(*) FROM dbo.[Load] WHERE TargetAddress = '" + TargetAddress[Address] + "' AND AircraftIdentification = '" + Convert.ToString(Trek[1]) + "' AND Status = 'Активен'").Rows[0][0]);

                                    if (countTargetAddress > 0)
                                    {
                                        UPDATE(Trek, query("SELECT * FROM dbo.[Load] WHERE TargetAddress = '" + TargetAddress[Address] + "' AND AircraftIdentification = '" + Convert.ToString(Trek[1]) + "' AND Status = 'Активен'").Rows[0]);
                                    }
                                    else
                                    {
                                        INSERT(Trek);
                                    }
                                }
                            }
                            
                            ProgressBarValue(Address + 1);
                        }
                        File.Delete(pathList[file]);
                        ProgressBarValue(0);
                    }
                    catch (Exception ex)
                    {
                       // MessageBox.Show(ex.Message);
                        if (binStream != null)
                        {
                            binStream.Close();
                        }
                        file++;
                        if (file >= pathList.Count)
                            file = 0;
                        continue;
                    }
                } 
            }
            mythread.Abort();
        }
        void openGPXThread(object RowIndex)
        {
            string TargetAddress = Convert.ToString(LoadGridView1[1, Convert.ToInt32(RowIndex)].Value);
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.InnerXml = Convert.ToString(query("SELECT GPX FROM [LOAD] WHERE ID = '" + Convert.ToString(LoadGridView1[0, Convert.ToInt32(RowIndex)].Value) + "'").Rows[0][0]);
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
                filter = "WHERE TargetAddress LIKE '0x" + TargetAddress + "%'";
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

        private void TargetAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }
        private void AircraftIdetificationTextBox_TextChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }
        private void EmitterCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }
        private void AirportDepatureTextBox_TextChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }
        private void AirportArrivalTextBox_TextChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }

        private void BeginTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ShowDataGridView(false);
        }

        private void EndTimePicker_ValueChanged(object sender, EventArgs e)
        {
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

        private void EmitterCategoryComboBox_Click(object sender, EventArgs e)
        {
            ComboBoxFill();
        }
        void OnChanged(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType.ToString() == "Created")
                pathList.Add(e.FullPath);
            else
                pathList.Remove(e.FullPath);
        }

        private void StartStopBTN_Click(object sender, EventArgs e)
        {
            if (start == false)
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    StartStopBTN.BackgroundImage = Properties.Resources.stop;

                    start = true;

                    pathList = new List<string>();
                    string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath, "*.sig");
                    for (int i = 0; i < files.Length; i++)
                        pathList.Add(files[i]);
                    watcher = new FileSystemWatcher();
                    watcher.Path = folderBrowserDialog1.SelectedPath; 
                    watcher.Filter = "*.sig";
                    watcher.Created += new FileSystemEventHandler(OnChanged);
                    watcher.Deleted += new FileSystemEventHandler(OnChanged);
                    watcher.EnableRaisingEvents = true;

                    mythread = new Thread(thread);
                    mythread.Start();
                }
                
            }

            else
            {
                StartStopBTN.BackgroundImage = Properties.Resources.mouseenterStop;

                mythread.Abort();

                progressBar1.Value = 0;
                if (binStream != null)
                {
                    binStream.Close();
                }
                
                start = false;

                watcher.EnableRaisingEvents = false;
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

        private void EndTimePicker_MouseDown(object sender, MouseEventArgs e)
        {
            if (EnableEndTimePicker != EndTimePicker.Checked)
            {
                EnableEndTimePicker = !EnableEndTimePicker;
                ShowDataGridView(false);
            }
        }

        private void EndTimePicker_DropDown(object sender, EventArgs e)
        {
            EnableEndTimePicker = true;
            ShowDataGridView(false);
        }

        private void BeginTimePicker_DropDown(object sender, EventArgs e)
        {
            EnableBeginTimePicker = true;
            ShowDataGridView(false);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mythread != null)
            {
                mythread.Abort();
            }
            if (updateThread != null)
            {
                updateThread.Abort();
            }
        }

        int checksum()
        {
            DataTable Category = query("SELECT CHECKSUM_AGG(GETCHECKSUM()) FROM dbo.[Load]");
            if (Convert.ToString(Category.Rows[0][0]) != "")
            {
                return Convert.ToInt32(Category.Rows[0][0]);
            }
            return 0;
        }

        private void AircraftIdetificationTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AircraftIdetificationTextBox.BackColor =Color.FromKnownColor (KnownColor.ScrollBar);
        }

        void timerThread()
        {
            query("UPDATE dbo.[Load] SET Status = 'Завершен' WHERE AddTime < DATEADD(MINUTE, -" + Convert.ToString(UPDATESTATUSMINUTE) + ", GETDATE()) AND Status = 'Активен'");
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

        public Form1()
        {
            try
            {
                sqlConnection1 =
              new SqlConnection("Data Source=SERVER-OTO\\SQLEXPRESS;Initial Catalog=ADS-B(TEST);Persist Security Info=True;User ID=Adm;Password=Analiz2");
                sqlConnection1.Open();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
            if (sqlConnection1.State == ConnectionState.Open)
            {
                InitializeComponent();
                FSPECtable21 = GetFSPECtable(21);
                FSPECtable62 = GetFSPECtable(62);
                ASCIIlist = GetList(Properties.Resources.Symbol);
                EmitterCategorylist = GetList(Properties.Resources.Emitter_Category);
                chcksum = checksum();
                ShowDataGridView(false);
                UpdateTimer.Interval = UPDATEGRIDMILLISECONDS;
                UpdateTimer.Enabled = true;
            }
        }
    }
}