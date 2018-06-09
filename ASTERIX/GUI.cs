using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ASTERIX
{
    public partial class GUI : Form
    {
        Map Map;
        Aircraft Aircraft;
        Settings Settings;
        Control MapPanel, AircraftPanel, SettingsPanel;

        public bool start = false;

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
        /// Сбрасывает BackColor для контролов меню.
        /// </summary>
        void ClearBackColor()
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
            ClearBackColor();

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
            ClearBackColor();

            AircraftPicture.BackColor = Color.LightSeaGreen;
            AircraftBTN.BackColor = Color.LightSeaGreen;
            ColorPanel.BackColor = Color.LightSeaGreen;

            Aircraft.UpdateGrid();

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
            ClearBackColor();

            SettingsPicture.BackColor = Color.DarkGray;
            SettingsBTN.BackColor = Color.DarkGray;
            ColorPanel.BackColor = Color.DarkGray;

            pagePanel.Controls.Clear();
            pagePanel.Controls.Add(SettingsPanel);
        }

        /// <summary>
        /// Останавливает процесс обработки, завершает все потоки. Происходит при закрытии формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Protocol.STOP();

            if (Map.updateThread != null)
            {
                Map.updateThread.Abort();
            }
        }

        /// <summary>
        /// Закрывает все comboBox.
        /// </summary>
        /// 
        private void GUI_LocationChanged(object sender, EventArgs e)
        {
            Map.closeAllCombobox();
        }
        private void GUI_SizeChanged(object sender, EventArgs e)
        {
            Map.closeAllCombobox();
        }
        private void tabTable_Click(object sender, EventArgs e)
        {
            Map.closeAllCombobox();
        }
        private void tabPanel_Click(object sender, EventArgs e)
        {
            Map.closeAllCombobox();
        }

        /// <summary>
        /// Основная функция формы. Производит инициализацию компонентов.
        /// </summary>
        public GUI()
        {
            if (SQL.Connect())
            {
                InitializeComponent();
                Protocol.Init(this);

                Map = new Map();
                MapPanel = Map.Controls.Find("MapPanel", false).First();
                Aircraft = new Aircraft();
                AircraftPanel = Aircraft.Controls.Find("AircraftPanel", false).First();
                Settings = new Settings();
                SettingsPanel = Settings.Controls.Find("SettingsPanel", false).First();

                MapBTN_Click(null, null);
            }
          
        }
    }
}