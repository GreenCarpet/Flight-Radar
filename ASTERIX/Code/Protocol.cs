using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Threading;

namespace ASTERIX
{
    class Protocol
    {
        static GUI gui;

        static Stream binStream;
        static DataTable FSPECtable21, FSPECtable62;
        static List<string> ASCIIlist, EmitterCategorylist;
        public static Thread mythread;

        static List<string> pathList;
        static FileSystemWatcher watcher;

        public static int UPDATESTATUSMINUTE = 20;

        #region CAT
        static double CoordinateDecoder105(byte[] coordinatebytes)
        {
            return Convert.ToDouble(BitConverter.ToInt32(coordinatebytes.Reverse().ToArray(), 0) * 0.00000536441802978515625);
        }
        static string ASCIIDecoder(byte[] codebytes, List<string> ASCIItable)
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
        static string TimeDecoder(double second)
        {
            return Convert.ToString(DateTime.UtcNow.Date.AddSeconds(second).ToLocalTime());
            // return Convert.ToString(query("SELECT CONVERT(DATETIME, SWITCHOFFSET(TODATETIMEOFFSET(DATEADD(SECOND, 10, CONVERT(DATETIME, CONVERT(DATE, GETUTCDATE()))), '+00:00'), DATENAME(TZ, SYSDATETIMEOFFSET())))").Rows[0][0]);    
        }
        static double CoordinateDecoder130(byte[] coordinatebytes)
        {
            return Convert.ToDouble(BitConverter.ToInt32(coordinatebytes.Reverse().ToArray(), 0) * 0.000021457672119140625);
        }
        static double CoordinateDecoder131(byte[] coordinatebytes)
        {
            return Convert.ToDouble(BitConverter.ToInt32(coordinatebytes.Reverse().ToArray(), 0) / 5965232.3555555599221118074846386);
        }
        static double HeightDecoder140(byte[] heightbytes)
        {
            return Convert.ToInt32(BitConverter.ToInt16(heightbytes.Reverse().ToArray(), 0) * 6.25 * 0.3048);
        }
        #endregion

        public static void Init(GUI guiForm)
        {
            gui = guiForm;
            FSPECtable21 = GetFSPECtable(21);
            FSPECtable62 = GetFSPECtable(62);
            ASCIIlist = GetList(Properties.Resources.Symbol);
            EmitterCategorylist = GetList(Properties.Resources.Emitter_Category);
        }
        public static void START()
        {
            mythread = new Thread(Thread);
            mythread.Start();
        }
        public static void STOP()
        {
            if (mythread != null)
            {
                mythread.Abort();
            }

            if (binStream != null)
            {
                binStream.Close();
            }
        }

        public static void GetFiles(string path, string format)
        {
            pathList = new List<string>();
            string[] files = Directory.GetFiles(path);
            for (int i = 0; i < files.Length; i++)
                pathList.Add(files[i]);
        }
        static void OnChanged(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType.ToString() == "Created")
                pathList.Add(e.FullPath);
            else
                pathList.Remove(e.FullPath);
        }
        public static void STARTscanfolder(string path, string format)
        {
            watcher = new FileSystemWatcher();
            watcher.Path = path;
            watcher.Filter = format;
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }
        public static void STOPscanfolder()
        {
            if (watcher != null)
            {
                watcher.EnableRaisingEvents = false;
            }
        }

        static BitArray GetVariableField()
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
        static DataTable GetFSPECtable(int category)
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
        static List<string> GetList(string data)
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

            BitArray FSPEC;

            byte[] TargetAddressbytes = new byte[4];
            byte[] TimePosition = new byte[4];
            byte[] Latitudebytes = new byte[4];
            byte[] Longitudebytes = new byte[4];
            byte[] AircraftIdentificationbytes = new byte[6];
            byte[] AirportDepaturebytes = new byte[4];
            byte[] AirportArrivalbytes = new byte[4];
            byte[] Callsing = new byte[7];
            byte[] Heightbytes = new byte[2];

            if ((binStream = File.Open(filename, FileMode.Open)) != null)
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
                                if (Chekcrash(lengthSIG))
                                {
                                    binStream.Position = startPacket + 3;
                                    lengthPacket = lengthSIG;
                                    endPacket = Convert.ToInt32(startPacket) + lengthPacket;

                                    while (binStream.Position != endPacket)
                                    {
                                        string TargetAddress = "";
                                        string AircraftIdentification = "";
                                        string Latitude = "";
                                        string Longitude = "";
                                        string EmitterCategory = "";
                                        string Height = "";

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
                                                                if (ChekEndPacket(endPacket, 1))
                                                                {
                                                                    EmitterCategory = EmitterCategorylist[binStream.ReadByte()];
                                                                }
                                                                break;
                                                            }
                                                        case "073":
                                                            {
                                                                if (ChekEndPacket(endPacket, 3))
                                                                {
                                                                    binStream.Read(TimePosition, 1, 3);
                                                                }
                                                                break;
                                                            }
                                                        case "080":
                                                            {
                                                                if (ChekEndPacket(endPacket, 3))
                                                                {
                                                                    binStream.Read(TargetAddressbytes, 0, 3);
                                                                }
                                                                TargetAddress = "";
                                                                for (int i = 0; i < 3; i++)
                                                                {
                                                                    if (Convert.ToString(TargetAddressbytes[i], 16).Length < 2)
                                                                    {
                                                                        TargetAddress += "0";
                                                                    }
                                                                    TargetAddress += Convert.ToString(TargetAddressbytes[i], 16).ToUpper();
                                                                }
                                                                break;
                                                            }
                                                        case "130":
                                                            {
                                                                if (ChekEndPacket(endPacket, 3))
                                                                {
                                                                    binStream.Read(Latitudebytes, 1, 3);
                                                                }
                                                                Latitude = Convert.ToString(CoordinateDecoder130(Latitudebytes));
                                                                if (ChekEndPacket(endPacket, 3))
                                                                {
                                                                    binStream.Read(Longitudebytes, 1, 3);
                                                                }
                                                                Longitude = Convert.ToString(CoordinateDecoder130(Longitudebytes));
                                                                break;
                                                            }
                                                        case "131":
                                                            {
                                                                if (ChekEndPacket(endPacket, 4))
                                                                {
                                                                    binStream.Read(Latitudebytes, 0, 4);
                                                                }
                                                                Latitude = Convert.ToString(CoordinateDecoder131(Latitudebytes));
                                                                if (ChekEndPacket(endPacket, 4))
                                                                {
                                                                    binStream.Read(Longitudebytes, 0, 4);
                                                                }
                                                                Longitude = Convert.ToString(CoordinateDecoder131(Longitudebytes));
                                                                break;
                                                            }
                                                        case "140":
                                                            {
                                                                if (ChekEndPacket(endPacket, 2))
                                                                {
                                                                    binStream.Read(Heightbytes, 0, 2);
                                                                }
                                                                Height = Convert.ToString(HeightDecoder140(Heightbytes));
                                                                break;
                                                            }
                                                        case "170":
                                                            {
                                                                if (ChekEndPacket(endPacket, 6))
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
                                                                if (ChekEndPacket(endPacket, countoctet))
                                                                {
                                                                    binStream.Seek(countoctet, SeekOrigin.Current);
                                                                }
                                                                break;
                                                            }
                                                        case "RE":
                                                            {
                                                                if (ChekEndPacket(endPacket, binStream.ReadByte() - 1))
                                                                {
                                                                    binStream.Position -= 1;
                                                                    binStream.Seek(binStream.ReadByte() - 1, SeekOrigin.Current);
                                                                }
                                                                break;
                                                            }
                                                        case "SP":
                                                            {
                                                                if (ChekEndPacket(endPacket, binStream.ReadByte() - 1))
                                                                {
                                                                    binStream.Position -= 1;
                                                                    binStream.Seek(binStream.ReadByte() - 1, SeekOrigin.Current);
                                                                }
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                if (ChekEndPacket(endPacket, Convert.ToInt32(FSPECtable21.Rows[FSPECbit]["length"])))
                                                                {
                                                                    binStream.Seek(Convert.ToInt32(FSPECtable21.Rows[FSPECbit]["length"]), SeekOrigin.Current);
                                                                }
                                                                break;
                                                            }
                                                    }
                                                }
                                            }
                                        }
                                        if ((TargetAddress != "") && (Latitude != "") && (Longitude != ""))
                                        {
                                            message.Rows.Add(new object[] { TargetAddress, AircraftIdentification, EmitterCategory, "", "", Latitude, Longitude, Height, Convert.ToDouble(BitConverter.ToInt32(TimePosition.Reverse().ToArray(), 0) / 128) });
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
                                if (Chekcrash(lengthSIG - 2))
                                {
                                    binStream.Position = startPacket + 3;
                                    lengthPacket = lengthSIG - 2;
                                    endPacket = Convert.ToInt32(startPacket) + lengthPacket;

                                    while (binStream.Position != endPacket)
                                    {
                                        string TargetAddress = "";
                                        string AircraftIdentification = "";
                                        string Latitude = "";
                                        string Longitude = "";
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
                                                                if (ChekEndPacket(endPacket, 3))
                                                                {
                                                                    binStream.Read(TimePosition, 1, 3);
                                                                }
                                                                break;
                                                            }
                                                        case "105":
                                                            {
                                                                if (ChekEndPacket(endPacket, 4))
                                                                {
                                                                    binStream.Read(Latitudebytes, 0, 4);
                                                                }
                                                                else
                                                                {
                                                                    break;
                                                                }
                                                                Latitude = Convert.ToString(CoordinateDecoder105(Latitudebytes));
                                                                if (ChekEndPacket(endPacket, 4))
                                                                {
                                                                    binStream.Read(Longitudebytes, 0, 4);
                                                                }
                                                                else
                                                                {
                                                                    break;
                                                                }
                                                                Longitude = Convert.ToString(CoordinateDecoder105(Longitudebytes));
                                                                break;
                                                            }
                                                        case "110":
                                                            {
                                                                BitArray DataAgesFSPEC = GetVariableField();
                                                                for (int bit = DataAgesFSPEC.Length - 1; bit >= 0; bit--)
                                                                {
                                                                    if ((DataAgesFSPEC.Get(bit) == true) && (bit > DataAgesFSPEC.Length - FSPEC110Length.Length))
                                                                    {
                                                                        if (ChekEndPacket(endPacket, FSPEC110Length[DataAgesFSPEC.Length - bit - 1]))
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
                                                                        if (ChekEndPacket(endPacket, FSPEC290Length[DataAgesFSPEC.Length - bit - 1]))
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
                                                                        if (ChekEndPacket(endPacket, FSPEC295Length[DataAgesFSPEC.Length - bit - 1]))
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
                                                                        if (ChekEndPacket(endPacket, FSPEC340Length[DataAgesFSPEC.Length - bit - 1]))
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
                                                                            if (ChekEndPacket(endPacket, 3))
                                                                            {
                                                                                binStream.Read(TargetAddressbytes, 0, 3);
                                                                            }
                                                                            else
                                                                            {
                                                                                break;
                                                                            }
                                                                            TargetAddress = "";
                                                                            for (int i = 0; i < 3; i++)
                                                                            {
                                                                                if (Convert.ToString(TargetAddressbytes[i], 16).Length < 2)
                                                                                {
                                                                                    TargetAddress += "0";
                                                                                }
                                                                                TargetAddress += Convert.ToString(TargetAddressbytes[i], 16).ToUpper();
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (bit == DataAgesFSPEC.Length - 2)
                                                                            {
                                                                                if (ChekEndPacket(endPacket, 6))
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
                                                                                    if (ChekEndPacket(endPacket, FSPEC380Length[DataAgesFSPEC.Length - bit - 1]))
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
                                                                                if (ChekEndPacket(endPacket, 7))
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
                                                                                if (ChekEndPacket(endPacket, 4))
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
                                                                                if (ChekEndPacket(endPacket, 4))
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
                                                                                if (ChekEndPacket(endPacket, FSPEC390Length[DataAgesFSPEC.Length - bit - 1]))
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
                                                                        if (ChekEndPacket(endPacket, FSPEC500Length[DataAgesFSPEC.Length - bit - 1]))
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
                                                                if (ChekEndPacket(endPacket, binStream.ReadByte() - 1))
                                                                {
                                                                    binStream.Position -= 1;
                                                                    binStream.Seek(binStream.ReadByte() - 1, SeekOrigin.Current);
                                                                }
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                if (ChekEndPacket(endPacket, Convert.ToInt32(FSPECtable62.Rows[FSPECbit]["length"])))
                                                                {
                                                                    binStream.Seek(Convert.ToInt32(FSPECtable62.Rows[FSPECbit]["length"]), SeekOrigin.Current);
                                                                }
                                                                break;
                                                            }
                                                    }
                                                }
                                            }
                                        }

                                        if ((TargetAddress != "") && (Latitude != "") && (Longitude != ""))
                                        {
                                            message.Rows.Add(new object[] { TargetAddress, AircraftIdentification, EmitterCategory, AirportDepature, AirportArrival, Latitude, Longitude, "", Convert.ToDouble(BitConverter.ToInt32(TimePosition.Reverse().ToArray(), 0) / 128) });
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
        static bool Chekcrash(int lengthSIG)
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
        static bool ChekEndPacket(int endPacket, int offset)
        {
            if (binStream.Position + offset > endPacket)
            {
                binStream.Position = endPacket;
                return false;
            }
            return true;
        }

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
