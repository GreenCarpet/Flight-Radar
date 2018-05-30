using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Threading;
using System.Xml;
using System.Reflection;

namespace ASTERIX
{
    class Protocol
    {
        static GUI gui;

        static Stream binStream;
        public static Thread mythread;

        static List<string> pathList;
        static FileSystemWatcher watcher;

        public static int UPDATESTATUSMINUTE = 20;

        /// <summary>
        /// Рассчитывает время, относительно полуночи текущей даты в формате UTC.
        /// </summary>
        /// <param name="second">Количество секунд.</param>
        /// <returns>Строковое представление DateTime.</returns>
        static string TimeDecoder(double second)
        {
            return Convert.ToString(DateTime.UtcNow.Date.AddSeconds(second).ToLocalTime());
            // return Convert.ToString(query("SELECT CONVERT(DATETIME, SWITCHOFFSET(TODATETIMEOFFSET(DATEADD(SECOND, 10, CONVERT(DATETIME, CONVERT(DATE, GETUTCDATE()))), '+00:00'), DATENAME(TZ, SYSDATETIMEOFFSET())))").Rows[0][0]);    
        }

        /// <summary>
        /// Инициализирует переменные, необходимые для вызова функций текущего класса.
        /// </summary>
        /// <param name="guiForm">Основная форма.</param>
        public static void Init(GUI guiForm)
        {
            gui = guiForm;
        }
        /// <summary>
        /// Запускает обработку протокола.
        /// </summary>
        public static void START(string path, string format)
        {
            pathList = Directory.GetFiles(path, "*" + format).ToList();
            STARTscanfolder(path, format);

            mythread = new Thread(Thread);
            mythread.Start();
        } 
        /// <summary>
        /// Останавливает обработку протокола.
        /// </summary>
        public static void STOP()
        {
            STOPscanfolder();

            if (mythread != null)
            {
                mythread.Abort();
            }

            if (binStream != null)
            {
                binStream.Close();
            }
        }

        /// <summary>
        /// Обрабатывает изменения в директории.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        static void OnChanged(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType.ToString() == "Created")
                pathList.Add(e.FullPath);
            else
                pathList.Remove(e.FullPath);
        }
        /// <summary>
        /// Запускает сканирование директории.
        /// </summary>
        /// <param name="path">Путь директории.</param>
        /// <param name="format">Формат файлов.</param>
        public static void STARTscanfolder(string path, string format)
        {
            watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.Filter = format;
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }
        /// <summary>
        /// Останавливает сканирование директории.
        /// </summary>
        public static void STOPscanfolder()
        {
            if (watcher != null)
            {
                watcher.EnableRaisingEvents = false;
            }
        }

        /// <summary>
        /// Считывает все маршрутные точки, содержащиеся в файле.
        /// </summary>
        /// <param name="filename">Путь к файлу.</param>
        /// <param name="modules">Включенные модули.</param>
        /// <returns>Маршрутные точки.</returns>
        static DataTable ReadFile(string filename, DataRow[] modules)
        {
            DataTable message = new DataTable();
            message.Columns.Add("TargetAddress", System.Type.GetType("System.String"));
            message.Columns.Add("AircraftIdentification", System.Type.GetType("System.String"));
            message.Columns.Add("EmitterCategory", System.Type.GetType("System.String"));
            message.Columns.Add("AirportDepature", System.Type.GetType("System.String"));
            message.Columns.Add("AirportArrival", System.Type.GetType("System.String"));
            message.Columns.Add("Latitude", System.Type.GetType("System.String"));
            message.Columns.Add("Longitude", System.Type.GetType("System.String"));
            message.Columns.Add("Height", System.Type.GetType("System.String"));
            message.Columns.Add("DTime", System.Type.GetType("System.Double"));
            message.Columns.Add("SAC", System.Type.GetType("System.String"));
            message.Columns.Add("SIC", System.Type.GetType("System.String"));
            message.Columns.Add("Mode3A", System.Type.GetType("System.String"));
            message.Columns.Add("CAT", System.Type.GetType("System.String"));

            if ((binStream = File.Open(filename, FileMode.Open)) != null)
            {
                byte[] lengthSIGBytes = new byte[2];
                byte[] lengthPacketBytes = new byte[2];
                int lengthPacket, lengthSIG;
                long endPacket;

                while (binStream.Position != binStream.Length)
                {
                    binStream.Read(lengthSIGBytes, 0, 2);
                    lengthSIG = BitConverter.ToInt16(lengthSIGBytes.ToArray(), 0);
                    endPacket = binStream.Position + lengthSIG;
                    int category = binStream.ReadByte();

                    DataRow[] mod = modules.Where(module => module["CAT"].ToString() == Convert.ToString(category)).ToArray();

                    if (mod.Length != 0)
                    {
                        binStream.Read(lengthPacketBytes, 0, 2);
                        lengthPacket = Math.Abs(BitConverter.ToInt16(lengthPacketBytes.Reverse().ToArray(), 0));

                        if (Chekcrash(lengthSIG, lengthPacket))
                        {
                            byte[] ProtocolStreamBytes = new byte[lengthPacket - 3];
                            binStream.Read(ProtocolStreamBytes, 0, lengthPacket - 3);
                            MemoryStream ProtocolStream = new MemoryStream(ProtocolStreamBytes);

                            ((Assembly)mod.First()["Assembly"]).GetType("Module").GetMethod("Decode").Invoke(null, new object[] { ProtocolStream, message, category });

                            ProtocolStream.Close();
                        }
                    }
                    if (binStream.Position != endPacket)
                    {
                        binStream.Position = endPacket;
                    }
                }
                binStream.Close();
            }
            return message;
        }
        /// <summary>
        /// Обрабатывает маршрутные точки. Формирует массив маршрутов.
        /// </summary>
        /// <param name="CoordinateTable">Маршрутные точки.</param>
        /// <param name="TargetAddress">Адрес.</param>
        /// <returns>Массив маршрутов</returns>
        static object[,] ReadTrek(DataTable CoordinateTable, string TargetAddress)
        {
            DataTable TrekCoordinate = CoordinateTable.Select("TargetAddress = '" + TargetAddress + "'").CopyToDataTable().Select().OrderBy(ms => ms["DTime"]).CopyToDataTable();
            DataTable NewTrek = new DataTable();
            NewTrek.Columns.Add("TargetAddress", System.Type.GetType("System.String"));
            NewTrek.Columns.Add("AircraftIdentification", System.Type.GetType("System.String"));
            NewTrek.Columns.Add("EmitterCategory", System.Type.GetType("System.String"));
            NewTrek.Columns.Add("AirportDepature", System.Type.GetType("System.String"));
            NewTrek.Columns.Add("AirportArrival", System.Type.GetType("System.String"));
            NewTrek.Columns.Add("Latitude", System.Type.GetType("System.String"));
            NewTrek.Columns.Add("Longitude", System.Type.GetType("System.String"));
            NewTrek.Columns.Add("Height", System.Type.GetType("System.String"));
            NewTrek.Columns.Add("DTime", System.Type.GetType("System.Double"));
            NewTrek.Columns.Add("SAC", System.Type.GetType("System.String"));
            NewTrek.Columns.Add("SIC", System.Type.GetType("System.String"));
            NewTrek.Columns.Add("Mode3A", System.Type.GetType("System.String"));
            NewTrek.Columns.Add("CAT", System.Type.GetType("System.String"));

            int i = 0;

            for (int time = 0; time < TrekCoordinate.Rows.Count - 1; time++)
            {
                if (Convert.ToDouble(TrekCoordinate.Rows[time + 1]["DTime"]) - Convert.ToDouble(TrekCoordinate.Rows[time]["DTime"]) > UPDATESTATUSMINUTE * 60)
                {
                    i++;
                }
            }

            object[,] TrekInfo = new object[i + 1, 13];

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
                        TrekInfo[i, 9] = NewTrek.Rows[0]["SAC"];
                        TrekInfo[i, 10] = NewTrek.Rows[0]["SIC"];
                        TrekInfo[i, 11] = NewTrek.Rows[0]["Mode3A"];
                        TrekInfo[i, 12] = NewTrek.Rows[0]["CAT"];

                        NewTrek = new DataTable();
                        NewTrek.Columns.Add("TargetAddress", System.Type.GetType("System.String"));
                        NewTrek.Columns.Add("AircraftIdentification", System.Type.GetType("System.String"));
                        NewTrek.Columns.Add("EmitterCategory", System.Type.GetType("System.String"));
                        NewTrek.Columns.Add("AirportDepature", System.Type.GetType("System.String"));
                        NewTrek.Columns.Add("AirportArrival", System.Type.GetType("System.String"));
                        NewTrek.Columns.Add("Latitude", System.Type.GetType("System.String"));
                        NewTrek.Columns.Add("Longitude", System.Type.GetType("System.String"));
                        NewTrek.Columns.Add("Height", System.Type.GetType("System.String"));
                        NewTrek.Columns.Add("DTime", System.Type.GetType("System.Double"));
                        NewTrek.Columns.Add("SAC", System.Type.GetType("System.String"));
                        NewTrek.Columns.Add("SIC", System.Type.GetType("System.String"));
                        NewTrek.Columns.Add("Mode3A", System.Type.GetType("System.String"));
                        NewTrek.Columns.Add("CAT", System.Type.GetType("System.String"));

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

        /// <summary>
        /// Проверяет целостность пакета.
        /// </summary>
        /// <param name="lengthSIG">Длина .sig заголовка пакета.</param>
        /// <param name="lengthPacket">Длина, указанная в пакете.</param>
        /// <param name="category">Категория.</param>
        /// <returns>Целостность пакета.</returns>
        static bool Chekcrash(int lengthSIG, int lengthPacket)
        {
            if (lengthPacket <= lengthSIG)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Основной поток обработки протокола.
        /// </summary>
        static void Thread()
        {
            DataRow[] modules = Modules.GetModules().Select().Where(module => (bool)module["Status"] == true).ToArray();
            for (int mod = 0; mod < modules.Length; mod++)
            {
                ((Assembly)modules[mod]["Assembly"]).GetType("Module").GetMethod("Init").Invoke(null, null);
            }

            int file = 0;
            while (gui.start)
            {
                if (pathList.Count != 0)
                {
                    try
                    {
                        DataTable CoordinateTable = ReadFile(Convert.ToString(pathList[file]), modules);

                        List<string> TargetAddress = new List<string>();

                        for (int TAddress = 0; TAddress < CoordinateTable.Rows.Count; TAddress++)
                        {
                            TargetAddress.Add(Convert.ToString(CoordinateTable.Rows[TAddress]["TargetAddress"]));
                        }
                        TargetAddress = TargetAddress.Distinct().ToList();

                        gui.ProgressBarMax(TargetAddress.Count);
                        for (int Address = 0; Address < TargetAddress.Count; Address++)
                        {
                            object[,] Treks = ReadTrek(CoordinateTable, TargetAddress[Address]);
                            for (int i = 0; i <= Treks.GetUpperBound(0); i++)
                            {
                                if (Treks[i, 0] != null)
                                {
                                    object[] Trek = new object[13];
                                    for (int n = 0; n < Trek.Length; n++)
                                    {
                                        Trek[n] = Treks[i, n];
                                    }

                                    SQL.query("UPDATE dbo.[Load] SET Status = 'Завершен' WHERE AddTime < DATEADD(MINUTE, -" + Convert.ToString(UPDATESTATUSMINUTE) + ", GETDATE()) AND Status = 'Активен'");

                                    int countTargetAddress = Convert.ToInt32(SQL.query("SELECT COUNT(*) FROM dbo.[Load] WHERE TargetAddress = '" + TargetAddress[Address] + "' AND AircraftIdentification = '" + Convert.ToString(Trek[1]) + "' AND Status = 'Активен'").Rows[0][0]);

                                    if (countTargetAddress > 0)
                                    {
                                        SQL.UPDATE(Trek, SQL.query("SELECT * FROM dbo.[Load] WHERE TargetAddress = '" + TargetAddress[Address] + "' AND AircraftIdentification = '" + Convert.ToString(Trek[1]) + "' AND Status = 'Активен'").Rows[0]);
                                    }
                                    else
                                    {
                                        SQL.INSERT(Trek);
                                    }
                                }
                            }

                            gui.ProgressBarValue(Address + 1);
                        }
                        File.Delete(pathList[file]);
                        gui.ProgressBarValue(0);
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
    }
}
