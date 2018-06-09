using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ASTERIX
{
    public partial class Aircraft : Form
    {
        int Aircraftchcksum = 0;

        public Aircraft()
        {
            InitializeComponent();

            UpdateGrid();
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
        /// Проверяет необходимость обновления GridView.
        /// </summary>
        public void UpdateGrid()
        {
            int chcksum = checksum("Aircraft");
            if (Aircraftchcksum != chcksum)
            {
                Aircraftchcksum = chcksum;
                ShowAircraftGridView();
            }
        }
        /// <summary>
        /// Обновляет GridView.
        /// </summary>
        private void ShowAircraftGridView()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ShowAircraftGridView));
                return;
            }
            AircraftGridView.DataSource = SQL.query("SELECT TOP 100 [Id], [TargetAddress] AS 'ICAO24',[Country] AS 'Государство', [Registration] AS 'Бортовой', [ICAOTypeCode] AS 'ICAOType', [TypeAircraft] AS 'Тип', [EmitterCategory] AS 'Категория', [Class] AS 'Класс', [UserText] AS 'Примечение' FROM [Aircraft]");
            AircraftGridView.Columns["Id"].Visible = false;
        }
    }
}
