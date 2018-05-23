using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Collections;
using System.Text;

namespace ASTERIX.CAT
{
    class _21
    {
        static BitArray FSPEC;

        /// <summary>
        /// Декодирует координату. 130 спецификация.
        /// </summary>
        /// <param name="coordinatebytes">Массив байт координаты.</param>
        /// <returns>Координата.</returns>
        static double CoordinateDecoder130(byte[] coordinatebytes)
        {
            return Convert.ToDouble(BitConverter.ToInt32(coordinatebytes.Reverse().ToArray(), 0) * 0.000021457672119140625);
        }
        /// <summary>
        /// Декодирует координату. 131 спецификация.
        /// </summary>
        /// <param name="coordinatebytes">Массив байт координаты.</param>
        /// <returns>Координата.</returns>
        static double CoordinateDecoder131(byte[] coordinatebytes)
        {
            return Convert.ToDouble(BitConverter.ToInt32(coordinatebytes.Reverse().ToArray(), 0) / 5965232.3555555599221118074846386);
        }
        /// <summary>
        /// Декодирует высоту. 140 спецификация.
        /// </summary>
        /// <param name="heightbytes">Массив байт высоты.</param>
        /// <returns>Высота.</returns>
        static double HeightDecoder140(byte[] heightbytes)
        {
            return Convert.ToInt32(BitConverter.ToInt16(heightbytes.Reverse().ToArray(), 0) * 6.25 * 0.3048);
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
                for (int FSPECbit = 0; FSPECbit < FSPEC.Length; FSPECbit++)
                {
                    if (FSPEC.Get((FSPEC.Length - 1) - FSPECbit) == true)
                    {
                        string di = Convert.ToString(Protocol.FSPECtable21.Rows[FSPECbit]["Data Item"]);
                        if ((di == "040") || (di == "090") || (di == "220") || (di == "110") || (di == "271"))
                        {
                            Protocol.GetVariableField(ProtocolStream);
                        }
                        else
                        {
                            switch (di)
                            {
                                case "020":
                                    {
                                        if (Protocol.ChekEndPacket(ProtocolStream, 1))
                                        {
                                            EmitterCategory = Protocol.EmitterCategorylist[ProtocolStream.ReadByte()];
                                        }
                                        break;
                                    }
                                case "073":
                                    {
                                        if (Protocol.ChekEndPacket(ProtocolStream, 3))
                                        {
                                            ProtocolStream.Read(TimePosition, 1, 3);
                                        }
                                        break;
                                    }
                                case "080":
                                    {
                                        if (Protocol.ChekEndPacket(ProtocolStream, 3))
                                        {
                                            ProtocolStream.Read(TargetAddressbytes, 0, 3);

                                            TargetAddress = "";
                                            for (int i = 0; i < 3; i++)
                                            {
                                                if (Convert.ToString(TargetAddressbytes[i], 16).Length < 2)
                                                {
                                                    TargetAddress += "0";
                                                }
                                                TargetAddress += Convert.ToString(TargetAddressbytes[i], 16).ToUpper();
                                            }
                                            if (TargetAddress == "781085")
                                            {

                                            }
                                        }
                                        break;
                                    }
                                case "130":
                                    {
                                        if (Protocol.ChekEndPacket(ProtocolStream, 3))
                                        {
                                            ProtocolStream.Read(Latitudebytes, 1, 3);
                                            Latitude = Convert.ToString(CoordinateDecoder130(Latitudebytes));
                                        }
                                        if (Protocol.ChekEndPacket(ProtocolStream, 3))
                                        {
                                            ProtocolStream.Read(Longitudebytes, 1, 3);
                                            Longitude = Convert.ToString(CoordinateDecoder130(Longitudebytes));
                                        }
                                        break;
                                    }
                                case "131":
                                    {
                                        if (Protocol.ChekEndPacket(ProtocolStream, 4))
                                        {
                                            ProtocolStream.Read(Latitudebytes, 0, 4);
                                            Latitude = Convert.ToString(CoordinateDecoder131(Latitudebytes));
                                        }
                                        if (Protocol.ChekEndPacket(ProtocolStream, 4))
                                        {
                                            ProtocolStream.Read(Longitudebytes, 0, 4);
                                            Longitude = Convert.ToString(CoordinateDecoder131(Longitudebytes));
                                        }
                                        break;
                                    }
                                case "140":
                                    {
                                        if (Protocol.ChekEndPacket(ProtocolStream, 2))
                                        {
                                            ProtocolStream.Read(Heightbytes, 0, 2);
                                            Height = Convert.ToString(HeightDecoder140(Heightbytes));
                                        }
                                        break;
                                    }
                                case "170":
                                    {
                                        if (Protocol.ChekEndPacket(ProtocolStream, 6))
                                        {
                                            ProtocolStream.Read(AircraftIdentificationbytes, 0, 6);
                                            AircraftIdentification = Protocol.ASCIIDecoder(AircraftIdentificationbytes, Protocol.ASCIIlist);
                                        }
                                        break;
                                    }
                                case "295":
                                    {
                                        BitArray DataAgesFSPEC = Protocol.GetVariableField(ProtocolStream);
                                        int countoctet = 0;
                                        for (int bit = 0; bit < DataAgesFSPEC.Length; bit++)
                                        {
                                            if (DataAgesFSPEC.Get(bit) == true)
                                            {
                                                countoctet++;
                                            }
                                        }
                                        countoctet -= (DataAgesFSPEC.Length / 8 - 1);
                                        if (Protocol.ChekEndPacket(ProtocolStream, countoctet))
                                        {
                                            ProtocolStream.Seek(countoctet, SeekOrigin.Current);
                                        }
                                        break;
                                    }
                                case "RE":
                                    {
                                        if (Protocol.ChekEndPacket(ProtocolStream, ProtocolStream.ReadByte() - 1))
                                        {
                                            ProtocolStream.Position -= 1;
                                            ProtocolStream.Seek(ProtocolStream.ReadByte() - 1, SeekOrigin.Current);
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
                                        if (Protocol.ChekEndPacket(ProtocolStream, Convert.ToInt32(Protocol.FSPECtable21.Rows[FSPECbit]["length"])))
                                        {
                                            ProtocolStream.Seek(Convert.ToInt32(Protocol.FSPECtable21.Rows[FSPECbit]["length"]), SeekOrigin.Current);
                                        }
                                        break;
                                    }
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