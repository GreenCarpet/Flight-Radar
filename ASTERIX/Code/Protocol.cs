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

        static object[] modules;
        static List<int> categories;

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
        /// Сканирует папку Modules на наличие модулей.
        /// </summary>
        /// <returns>Таблица модулей. </returns>
        public static DataTable GetDirectoryModules()
        {
            List<string> pathModules = new List<string>();
            pathModules = Directory.GetFiles("Modules", "*.dll").ToList();

            DataTable modules = new DataTable();
            modules.Columns.Add("Status", Type.GetType("System.Boolean"));
            modules.Columns.Add("Name", Type.GetType("System.String"));
            modules.Columns.Add("CAT", Type.GetType("System.String"));
            modules.Columns.Add("Version", Type.GetType("System.String"));
            modules.Columns.Add("Developer", Type.GetType("System.String"));
            modules.Columns.Add("Assembly", Type.GetType("System.Reflection.Assembly"));
            
            for (int path = 0; path < pathModules.Count; path++)
            {
                Assembly asm = Assembly.LoadFile(Path.GetFullPath(pathModules[path]));

                IList<CustomAttributeData> attr = asm.GetCustomAttributesData();

                string DllType = attr.Where(x => x.Constructor.DeclaringType == typeof(AssemblyTitleAttribute)).First().ConstructorArguments.ElementAt(0).Value.ToString();

                if (DllType == "Module")
                {
                    string Name = Path.GetFileNameWithoutExtension(pathModules[path]);
                    string CAT = attr.Where(x => x.Constructor.DeclaringType == typeof(AssemblyDescriptionAttribute)).First().ConstructorArguments.ElementAt(0).ToString();
                    string Version = attr.Where(x => x.Constructor.DeclaringType == typeof(AssemblyFileVersionAttribute)).First().ConstructorArguments.ElementAt(0).ToString();
                    string Developer  = attr.Where(x => x.Constructor.DeclaringType == typeof(AssemblyCompanyAttribute)).First().ConstructorArguments.ElementAt(0).ToString();
                    
                    modules.Rows.Add(new object[] { false, Name, CAT, Version, Developer, asm });
                    asm.GetType("Module").GetMethod("Init").Invoke(null, null);
                }
            }
            return modules;
        }


        /// <summary>
        /// Инициализирует переменные, необходимые для вызова функций текущего класса.
        /// </summary>
        /// <param name="guiForm">Основная форма.</param>
        public static void Init(GUI guiForm)
        {
            gui = guiForm;

            GetDirectoryModules();

            string mod = "Обнаружены модули:\n";
            for (int i =0; i < categories.Count; i++)
            {
                mod += Convert.ToString(categories[i]) + ".dll\n";
            }
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

        static DataTable ReadFile(string filename)
        {
            DataTable message = new DataTable();
            message.Columns.Add("TargetAddress", System.Type.GetType("System.String"));
            message.Columns.Add("AircraftIdentification", System.Type.GetType("System.String"));
            message.Columns.Add("EmitterCategory", System.Type.GetType("System.String"));
            message.Columns.Add("AirportDepature", System.Type.GetType("System.String"));
            message.Columns.Add("AirportArrival", System.Type.GetType("System.String"));
            message.Columns.Add("Latitude", System.Type.GetType("System.Double"));
            message.Columns.Add("Longitude", System.Type.GetType("System.Double"));
            message.Columns.Add("Height", System.Type.GetType("System.String"));
            message.Columns.Add("DTime", System.Type.GetType("System.Double"));

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

                    if (categories.Contains(category))
                    {
                        binStream.Read(lengthPacketBytes, 0, 2);
                        lengthPacket = BitConverter.ToInt16(lengthPacketBytes.Reverse().ToArray(), 0);

                        byte[] ProtocolStreamBytes = new byte[lengthPacket - 3];
                        binStream.Read(ProtocolStreamBytes, 0, lengthPacket - 3);
                        MemoryStream ProtocolStream = new MemoryStream(ProtocolStreamBytes);

                        ((Assembly)modules[categories.IndexOf(category)]).GetType("Module").GetMethod("Decode").Invoke(null, new object[] { ProtocolStream, message });

                        ProtocolStream.Close();
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
            NewTrek.Columns.Add("Latitude", System.Type.GetType("System.Double"));
            NewTrek.Columns.Add("Longitude", System.Type.GetType("System.Double"));
            NewTrek.Columns.Add("Height", System.Type.GetType("System.String"));
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
                        NewTrek.Columns.Add("Height", System.Type.GetType("System.String"));
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

        /// <summary>
        /// Проверяет целостность пакета.
        /// </summary>
        /// <param name="lengthSIG">Длина .sig заголовка пакета.</param>
        /// <param name="lengthPacket">Длина, указанная в пакете.</param>
        /// <param name="category">Категория.</param>
        /// <returns>Целостность пакета.</returns>
        static bool Chekcrash(int lengthSIG, int lengthPacket, int category)
        {
            if (category == 62)
            {
                lengthSIG -= 2;
            }
            if (lengthPacket == lengthSIG)
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
            int file = 0;
            while (gui.start)
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

                        gui.ProgressBarMax(TargetAddress.Count);
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
