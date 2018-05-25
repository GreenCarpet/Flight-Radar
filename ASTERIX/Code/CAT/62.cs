/*using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Collections;
using System.Text;

namespace ASTERIX.CAT
{
    class _62
    {
        static BitArray FSPEC;

        static int[] FSPEC110Length = { 1, 4, 6, 2, 2, 1, 1, 0 };
        static int[] FSPEC290Length = { 1, 1, 1, 1, 2, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0, 0 };
        static int[] FSPEC295Length = { 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0 };
        static int[] FSPEC340Length = { 2, 4, 2, 2, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        static int[] FSPEC380Length = { 3, 6, 2, 2, 2, 2, 2, 0, 1, 16, 2, 2, 7, 2, 2, 0, 2, 2, 2, 2, 1, 8, 1, 0, 6, 2, 1, 9, 2, 2, 2, 0 };
        static int[] FSPEC390Length = { 2, 7, 4, 1, 4, 1, 4, 0, 4, 3, 2, 2, 5, 6, 1, 0, 7, 7, 2, 7, 0, 0, 0, 0 };
        static int[] FSPEC500Length = { 4, 2, 4, 1, 1, 2, 2, 0, 1, 0, 0, 0, 0, 0, 0, 0 };

        /// <summary>
        /// Декодирует координату. 105 спецификация.
        /// </summary>
        /// <param name="coordinatebytes">Массив байт координаты.</param>
        /// <returns>Координата.</returns>
        static double CoordinateDecoder105(byte[] coordinatebytes)
        {
            return Convert.ToDouble(BitConverter.ToInt32(coordinatebytes.Reverse().ToArray(), 0) * 0.00000536441802978515625);
        }

        /// <summary>
        /// Обрабатывает категорию.
        /// </summary>
        /// <param name="ProtocolStream">ASTERIX пакет.</param>
        /// <param name="message">Таблица маршрутных точек.</param>
        public static void Decode(MemoryStream ProtocolStream, DataTable message)
        {
            while (ProtocolStream.Position != ProtocolStream.Length)
            {
                byte[] TargetAddressbytes = new byte[4];
                byte[] TimePosition = new byte[4];
                byte[] Latitudebytes = new byte[4];
                byte[] Longitudebytes = new byte[4];
                byte[] AircraftIdentificationbytes = new byte[6];
                byte[] AirportDepaturebytes = new byte[4];
                byte[] AirportArrivalbytes = new byte[4];
                byte[] Callsing = new byte[7];
                byte[] Heightbytes = new byte[2];

                string TargetAddress = "";
                string AircraftIdentification = "";
                string Latitude = "";
                string Longitude = "";
                string EmitterCategory = "";
                string AirportDepature = "";
                string AirportArrival = "";
                string Height = "";

                FSPEC = Protocol.GetVariableField(ProtocolStream);
                if (FSPEC.Length <= Protocol.FSPECtable62.Rows.Count)
                {
                    for (int FSPECbit = 0; FSPECbit < FSPEC.Length; FSPECbit++)
                    {
                        if (FSPEC.Get((FSPEC.Length - 1) - FSPECbit) == true)
                        {
                            string di = Convert.ToString(Protocol.FSPECtable62.Rows[FSPECbit]["Data Item"]);

                            switch (di)
                            {
                                case "070":
                                    {
                                        if (Protocol.ChekEndPacket(ProtocolStream, 3))
                                        {
                                            ProtocolStream.Read(TimePosition, 1, 3);
                                        }
                                        break;
                                    }
                                case "105":
                                    {
                                        if (Protocol.ChekEndPacket(ProtocolStream, 4))
                                        {
                                            ProtocolStream.Read(Latitudebytes, 0, 4);
                                            Latitude = Convert.ToString(CoordinateDecoder105(Latitudebytes));
                                        }
                                        else
                                        {
                                            break;
                                        }
                                        if (Protocol.ChekEndPacket(ProtocolStream, 4))
                                        {
                                            ProtocolStream.Read(Longitudebytes, 0, 4);
                                            Longitude = Convert.ToString(CoordinateDecoder105(Longitudebytes));
                                        }
                                        else
                                        {
                                            break;
                                        }
                                        break;
                                    }
                                case "110":
                                    {
                                        BitArray DataAgesFSPEC = Protocol.GetVariableField(ProtocolStream);
                                        for (int bit = DataAgesFSPEC.Length - 1; bit >= 0; bit--)
                                        {
                                            if ((DataAgesFSPEC.Get(bit) == true) && (bit > DataAgesFSPEC.Length - FSPEC110Length.Length))
                                            {
                                                if (Protocol.ChekEndPacket(ProtocolStream, FSPEC110Length[DataAgesFSPEC.Length - bit - 1]))
                                                {
                                                    ProtocolStream.Seek(FSPEC110Length[DataAgesFSPEC.Length - bit - 1], SeekOrigin.Current);
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
                                        BitArray DataAgesFSPEC = Protocol.GetVariableField(ProtocolStream);
                                        for (int bit = DataAgesFSPEC.Length - 1; bit >= 0; bit--)
                                        {
                                            if ((DataAgesFSPEC.Get(bit) == true) && (bit > DataAgesFSPEC.Length - FSPEC290Length.Length))
                                            {
                                                if (Protocol.ChekEndPacket(ProtocolStream, FSPEC290Length[DataAgesFSPEC.Length - bit - 1]))
                                                {
                                                    ProtocolStream.Seek(FSPEC290Length[DataAgesFSPEC.Length - bit - 1], SeekOrigin.Current);
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
                                        BitArray DataAgesFSPEC = Protocol.GetVariableField(ProtocolStream);
                                        for (int bit = DataAgesFSPEC.Length - 1; bit >= 0; bit--)
                                        {
                                            if ((DataAgesFSPEC.Get(bit) == true) && (bit > DataAgesFSPEC.Length - FSPEC295Length.Length))
                                            {
                                                if (Protocol.ChekEndPacket(ProtocolStream, FSPEC295Length[DataAgesFSPEC.Length - bit - 1]))
                                                {
                                                    ProtocolStream.Seek(FSPEC295Length[DataAgesFSPEC.Length - bit - 1], SeekOrigin.Current);
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
                                        BitArray DataAgesFSPEC = Protocol.GetVariableField(ProtocolStream);
                                        for (int bit = DataAgesFSPEC.Length - 1; bit >= 0; bit--)
                                        {
                                            if ((DataAgesFSPEC.Get(bit) == true) && (bit > DataAgesFSPEC.Length - FSPEC340Length.Length))
                                            {
                                                if (Protocol.ChekEndPacket(ProtocolStream, FSPEC340Length[DataAgesFSPEC.Length - bit - 1]))
                                                {
                                                    ProtocolStream.Seek(FSPEC340Length[DataAgesFSPEC.Length - bit - 1], SeekOrigin.Current);
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
                                        BitArray DataAgesFSPEC = Protocol.GetVariableField(ProtocolStream);
                                        for (int bit = DataAgesFSPEC.Length - 1; bit >= 0; bit--)
                                        {
                                            if (DataAgesFSPEC.Get(bit) == true)
                                            {
                                                if (bit == DataAgesFSPEC.Length - 1)
                                                {
                                                    if (Protocol.ChekEndPacket(ProtocolStream, 3))
                                                    {
                                                        ProtocolStream.Read(TargetAddressbytes, 0, 3);
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
                                                        if (Protocol.ChekEndPacket(ProtocolStream, 6))
                                                        {
                                                            ProtocolStream.Read(AircraftIdentificationbytes, 0, 6);
                                                        }
                                                        else
                                                        {
                                                            break;
                                                        }
                                                        AircraftIdentification = Protocol.ASCIIDecoder(AircraftIdentificationbytes, Protocol.ASCIIlist);
                                                    }
                                                    else
                                                    {
                                                        if (bit > DataAgesFSPEC.Length - FSPEC380Length.Length)
                                                        {
                                                            if (Protocol.ChekEndPacket(ProtocolStream, FSPEC380Length[DataAgesFSPEC.Length - bit - 1]))
                                                            {
                                                                ProtocolStream.Seek(FSPEC380Length[DataAgesFSPEC.Length - bit - 1], SeekOrigin.Current);
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
                                        BitArray DataAgesFSPEC = Protocol.GetVariableField(ProtocolStream);
                                        for (int bit = DataAgesFSPEC.Length - 1; bit >= 0; bit--)
                                        {
                                            if (DataAgesFSPEC.Get(bit) == true)
                                            {
                                                if ((bit == DataAgesFSPEC.Length - 2) || (bit == DataAgesFSPEC.Length - 6) || (bit == DataAgesFSPEC.Length - 7) || (bit == DataAgesFSPEC.Length - 9))
                                                {
                                                    if (bit == DataAgesFSPEC.Length - 2)
                                                    {
                                                        if (Protocol.ChekEndPacket(ProtocolStream, 7))
                                                        {
                                                            ProtocolStream.Read(Callsing, 0, 7);
                                                        }
                                                        else
                                                        {
                                                            break;
                                                        }
                                                        AircraftIdentification = Encoding.ASCII.GetString(Callsing).Replace("'", "");
                                                    }
                                                    if (bit == DataAgesFSPEC.Length - 6)
                                                    {
                                                        switch (Convert.ToChar(ProtocolStream.ReadByte()))
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
                                                        if (Protocol.ChekEndPacket(ProtocolStream, 4))
                                                        {
                                                            ProtocolStream.Read(AirportDepaturebytes, 0, 4);
                                                        }
                                                        else
                                                        {
                                                            break;
                                                        }
                                                        AirportDepature = Encoding.ASCII.GetString(AirportDepaturebytes);
                                                    }
                                                    if (bit == DataAgesFSPEC.Length - 9)
                                                    {
                                                        if (Protocol.ChekEndPacket(ProtocolStream, 4))
                                                        {
                                                            ProtocolStream.Read(AirportArrivalbytes, 0, 4);
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
                                                        if (Protocol.ChekEndPacket(ProtocolStream, FSPEC390Length[DataAgesFSPEC.Length - bit - 1]))
                                                        {
                                                            ProtocolStream.Seek(FSPEC390Length[DataAgesFSPEC.Length - bit - 1], SeekOrigin.Current);
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
                                        BitArray DataAgesFSPEC = Protocol.GetVariableField(ProtocolStream);
                                        for (int bit = DataAgesFSPEC.Length - 1; bit >= 0; bit--)
                                        {
                                            if ((DataAgesFSPEC.Get(bit) == true) && (bit > DataAgesFSPEC.Length - FSPEC500Length.Length))
                                            {
                                                if (Protocol.ChekEndPacket(ProtocolStream, FSPEC500Length[DataAgesFSPEC.Length - bit - 1]))
                                                {
                                                    ProtocolStream.Seek(FSPEC500Length[DataAgesFSPEC.Length - bit - 1], SeekOrigin.Current);
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
                                        if (Protocol.ChekEndPacket(ProtocolStream, ProtocolStream.ReadByte() - 1))
                                        {
                                            ProtocolStream.Position -= 1;
                                            ProtocolStream.Seek(ProtocolStream.ReadByte() - 1, SeekOrigin.Current);
                                        }
                                        break;
                                    }
                                default:
                                    {
                                        string length = Convert.ToString(Protocol.FSPECtable62.Rows[FSPECbit]["length"]);
                                        switch (length)
                                        {
                                            case "variable":
                                                {
                                                    Protocol.GetVariableField(ProtocolStream);
                                                    break;
                                                }
                                            case "":
                                                {
                                                    break;
                                                }
                                            default:
                                                {
                                                    ProtocolStream.Seek(Convert.ToInt32(length), SeekOrigin.Current);
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                            }
                        }
                    }

                    if ((TargetAddress != "") && (Latitude != "") && (Longitude != ""))
                    {
                        message.Rows.Add(new object[] { TargetAddress, AircraftIdentification, EmitterCategory, AirportDepature, AirportArrival, Latitude, Longitude, Height, Convert.ToDouble(BitConverter.ToInt32(TimePosition.Reverse().ToArray(), 0) / 128) });
                    }
                }
            }
        }
}
}*/