using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;

namespace ASTERIX
{
    class SQL
    {
        static SqlDataAdapter adapt;
        static SqlConnection sqlConnection1;

        static object locker = new object();
        /// <summary>
        /// Устанавливает соединение с БД.
        /// </summary>
        /// <returns>Состояние подключения.</returns>
        public static bool Connect()
        {
            try
            {
                sqlConnection1 =
              new SqlConnection("Data Source=SERVER-OTO\\SQLEXPRESS;Initial Catalog=ADS-B;Persist Security Info=True;User ID=Adm;Password=Analiz2");
                sqlConnection1.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(0);
            }
            if (sqlConnection1.State == ConnectionState.Open)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Выполняет запрос к БД.
        /// </summary>
        /// <param name="query">Строка запроса.</param>
        /// <returns>Результат запроса.</returns>
        public static DataTable query(string query)
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
        /// <summary>
        /// Добавляет маршрут в БД.
        /// </summary>
        /// <param name="Trek">Маршрут. Содержит поля { string TargetAddress, string AircraftIdentification, string EmitterCategory, string AirportDepature, string AirportArrival, string BeginTime, string EndTime, string Interval, DataTable Aircraftmessage }.</param>
        public static void INSERT(object[] Trek)
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
            string SAC = (string)Trek[9];
            string SIC = (string)Trek[10];
            string Mode3A = (string)Trek[11];
            string CAT = (string)Trek[12];


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
                if (Convert.ToString(Aircraftmessage.Rows[point]["Height"]) != "")
                {
                    XmlElement ele = doc.CreateElement("ele");
                    ele.InnerText = Convert.ToString(Aircraftmessage.Rows[point]["Height"]);
                    rtept.AppendChild(ele);
                }

                XmlElement sym = doc.CreateElement("sym");
                if (point == 0)
                {
                    sym.InnerText = "Airport";
                }
                else
                {
                    sym.InnerText = "Waypoint";
                }
                rtept.AppendChild(sym);

                rte.AppendChild(rtept);
            }

            doc.DocumentElement.AppendChild(rte);
            doc.DocumentElement.InnerXml = doc.DocumentElement.InnerXml.Replace("xmlns=\"\"", "");

            string insert = "INSERT INTO dbo.[Load] (TargetAddress, AircraftIdentification, EmitterCategory, AirportDepature, AirportArrival, BeginTime, EndTime, Interval, Status, Gpx, AddTime, SAC, SIC, Mode3A, CAT) VALUES('" + TargetAddress + "','" + AircraftIdentification + "','" + EmitterCategory + "','" + AirportDepature + "','" + AirportArrival + "','" + BeginTime + "','" + EndTime + "','" + Interval + "','" + Status + "','" + doc.InnerXml + "', GETDATE(), " + SAC + "," + SIC + ",'" + Mode3A +"'," +  CAT + ")";
            query(insert);
        }
        /// <summary>
        /// Обновляет маршрут в БД.
        /// </summary>
        /// <param name="Trek">Маршрут. Содержит поля { string TargetAddress, string AircraftIdentification, string EmitterCategory, string AirportDepature, string AirportArrival, string BeginTime, string EndTime, string Interval, DataTable Aircraftmessage }.</param>
        /// <param name="oldRow">Редактируемая строка.</param>
        public static void UPDATE(object[] Trek, DataRow oldRow)
        {
            string OldEndTime = Convert.ToString(oldRow[7]);
            string BeginTime = (string)Trek[5];

            if ((DateTime.Parse(BeginTime) - DateTime.Parse(OldEndTime)) > TimeSpan.Parse("00:" + Convert.ToString(Protocol.UPDATESTATUSMINUTE) + ":00"))
            {
                query("UPDATE dbo.[Load] SET Status = 'Завершен' WHERE Id =" + Convert.ToString(oldRow[0]));
                INSERT(Trek);
                return;
            }
            string OldBeginTime = Convert.ToString(oldRow[6]);
            string EndTime = (string)Trek[6];
            string Interval = (DateTime.Parse(EndTime) - DateTime.Parse(OldBeginTime)).ToString();

            Interval = Interval.Replace("-", "");

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

                    if (Convert.ToString(Aircraftmessage.Rows[point]["Height"]) != "")
                    {
                        XmlElement ele = doc.CreateElement("ele");
                        ele.InnerText = Convert.ToString(Aircraftmessage.Rows[point]["Height"]);
                        rtept.AppendChild(ele);
                    }

                    XmlElement sym = doc.CreateElement("sym");
                    if (point == 0)
                    {
                        sym.InnerText = "Airport";
                    }
                    else
                    {
                        sym.InnerText = "Waypoint";
                    }
                    rtept.AppendChild(sym);

                    newNode.AppendChild(rtept);
                }
                doc.DocumentElement.ReplaceChild(node[0], newNode);
                doc.DocumentElement.InnerXml = doc.DocumentElement.InnerXml.Replace("xmlns=\"\"", "");

                string update = "UPDATE dbo.[Load] SET EndTime = '" + EndTime + "', Interval = '" + Interval + "', Gpx = '" + doc.InnerXml + "', AddTime = GETDATE() WHERE Id = " + Convert.ToString(oldRow[0]);
                query(update);
            }
        }
    }
}
