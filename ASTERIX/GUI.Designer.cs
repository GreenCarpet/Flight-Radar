namespace ASTERIX
{
    partial class GUI
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabPanel = new System.Windows.Forms.Panel();
            this.tabTable = new System.Windows.Forms.TableLayoutPanel();
            this.AircraftBTN = new System.Windows.Forms.Label();
            this.AircraftPicture = new System.Windows.Forms.PictureBox();
            this.ScanPicture = new System.Windows.Forms.PictureBox();
            this.StartStopBTN = new System.Windows.Forms.Label();
            this.MapPicture = new System.Windows.Forms.PictureBox();
            this.MapBTN = new System.Windows.Forms.Label();
            this.SettingsPicture = new System.Windows.Forms.PictureBox();
            this.SettingsBTN = new System.Windows.Forms.Label();
            this.ColorPanel = new System.Windows.Forms.Panel();
            this.pagePanel = new System.Windows.Forms.Panel();
            this.tabPanel.SuspendLayout();
            this.tabTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AircraftPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScanPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.tabTable.SetColumnSpan(this.progressBar1, 2);
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 40);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(167, 1);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // tabPanel
            // 
            this.tabPanel.BackColor = System.Drawing.Color.LightGray;
            this.tabPanel.Controls.Add(this.tabTable);
            this.tabPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabPanel.Location = new System.Drawing.Point(0, 0);
            this.tabPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.Size = new System.Drawing.Size(167, 562);
            this.tabPanel.TabIndex = 2;
            this.tabPanel.Click += new System.EventHandler(this.tabPanel_Click);
            // 
            // tabTable
            // 
            this.tabTable.ColumnCount = 2;
            this.tabTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tabTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76F));
            this.tabTable.Controls.Add(this.AircraftBTN, 1, 3);
            this.tabTable.Controls.Add(this.AircraftPicture, 0, 3);
            this.tabTable.Controls.Add(this.progressBar1, 0, 1);
            this.tabTable.Controls.Add(this.ScanPicture, 0, 0);
            this.tabTable.Controls.Add(this.StartStopBTN, 1, 0);
            this.tabTable.Controls.Add(this.MapPicture, 0, 2);
            this.tabTable.Controls.Add(this.MapBTN, 1, 2);
            this.tabTable.Controls.Add(this.SettingsPicture, 0, 4);
            this.tabTable.Controls.Add(this.SettingsBTN, 1, 4);
            this.tabTable.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabTable.Location = new System.Drawing.Point(0, 0);
            this.tabTable.Margin = new System.Windows.Forms.Padding(0);
            this.tabTable.Name = "tabTable";
            this.tabTable.RowCount = 6;
            this.tabTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tabTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tabTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tabTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tabTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tabTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tabTable.Size = new System.Drawing.Size(167, 193);
            this.tabTable.TabIndex = 0;
            this.tabTable.Click += new System.EventHandler(this.tabTable_Click);
            // 
            // AircraftBTN
            // 
            this.AircraftBTN.AutoSize = true;
            this.AircraftBTN.BackColor = System.Drawing.Color.Transparent;
            this.AircraftBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AircraftBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AircraftBTN.Location = new System.Drawing.Point(40, 80);
            this.AircraftBTN.Margin = new System.Windows.Forms.Padding(0);
            this.AircraftBTN.Name = "AircraftBTN";
            this.AircraftBTN.Size = new System.Drawing.Size(127, 40);
            this.AircraftBTN.TabIndex = 6;
            this.AircraftBTN.Text = "Привязки";
            this.AircraftBTN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AircraftBTN.Click += new System.EventHandler(this.AircraftBTN_Click);
            // 
            // AircraftPicture
            // 
            this.AircraftPicture.BackColor = System.Drawing.Color.Transparent;
            this.AircraftPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AircraftPicture.Image = ((System.Drawing.Image)(resources.GetObject("AircraftPicture.Image")));
            this.AircraftPicture.Location = new System.Drawing.Point(0, 80);
            this.AircraftPicture.Margin = new System.Windows.Forms.Padding(0);
            this.AircraftPicture.Name = "AircraftPicture";
            this.AircraftPicture.Padding = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.AircraftPicture.Size = new System.Drawing.Size(40, 40);
            this.AircraftPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AircraftPicture.TabIndex = 5;
            this.AircraftPicture.TabStop = false;
            this.AircraftPicture.Click += new System.EventHandler(this.AircraftPicture_Click);
            // 
            // ScanPicture
            // 
            this.ScanPicture.BackColor = System.Drawing.Color.Transparent;
            this.ScanPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScanPicture.Image = ((System.Drawing.Image)(resources.GetObject("ScanPicture.Image")));
            this.ScanPicture.Location = new System.Drawing.Point(0, 0);
            this.ScanPicture.Margin = new System.Windows.Forms.Padding(0);
            this.ScanPicture.Name = "ScanPicture";
            this.ScanPicture.Padding = new System.Windows.Forms.Padding(1);
            this.ScanPicture.Size = new System.Drawing.Size(40, 40);
            this.ScanPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScanPicture.TabIndex = 0;
            this.ScanPicture.TabStop = false;
            this.ScanPicture.Click += new System.EventHandler(this.ScanPicture_Click);
            // 
            // StartStopBTN
            // 
            this.StartStopBTN.AutoSize = true;
            this.StartStopBTN.BackColor = System.Drawing.Color.Transparent;
            this.StartStopBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartStopBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartStopBTN.Location = new System.Drawing.Point(40, 0);
            this.StartStopBTN.Margin = new System.Windows.Forms.Padding(0);
            this.StartStopBTN.Name = "StartStopBTN";
            this.StartStopBTN.Size = new System.Drawing.Size(127, 40);
            this.StartStopBTN.TabIndex = 1;
            this.StartStopBTN.Text = "Сканирование";
            this.StartStopBTN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.StartStopBTN.Click += new System.EventHandler(this.StartStopBTN_Click);
            // 
            // MapPicture
            // 
            this.MapPicture.BackColor = System.Drawing.Color.Transparent;
            this.MapPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapPicture.Image = ((System.Drawing.Image)(resources.GetObject("MapPicture.Image")));
            this.MapPicture.Location = new System.Drawing.Point(0, 40);
            this.MapPicture.Margin = new System.Windows.Forms.Padding(0);
            this.MapPicture.Name = "MapPicture";
            this.MapPicture.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.MapPicture.Size = new System.Drawing.Size(40, 40);
            this.MapPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MapPicture.TabIndex = 2;
            this.MapPicture.TabStop = false;
            this.MapPicture.Click += new System.EventHandler(this.MapPicture_Click);
            // 
            // MapBTN
            // 
            this.MapBTN.AutoSize = true;
            this.MapBTN.BackColor = System.Drawing.Color.Transparent;
            this.MapBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MapBTN.Location = new System.Drawing.Point(40, 40);
            this.MapBTN.Margin = new System.Windows.Forms.Padding(0);
            this.MapBTN.Name = "MapBTN";
            this.MapBTN.Size = new System.Drawing.Size(127, 40);
            this.MapBTN.TabIndex = 3;
            this.MapBTN.Text = "Карта";
            this.MapBTN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MapBTN.Click += new System.EventHandler(this.MapBTN_Click);
            // 
            // SettingsPicture
            // 
            this.SettingsPicture.BackColor = System.Drawing.Color.Transparent;
            this.SettingsPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsPicture.Image = ((System.Drawing.Image)(resources.GetObject("SettingsPicture.Image")));
            this.SettingsPicture.Location = new System.Drawing.Point(0, 120);
            this.SettingsPicture.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsPicture.Name = "SettingsPicture";
            this.SettingsPicture.Padding = new System.Windows.Forms.Padding(2);
            this.SettingsPicture.Size = new System.Drawing.Size(40, 40);
            this.SettingsPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SettingsPicture.TabIndex = 4;
            this.SettingsPicture.TabStop = false;
            this.SettingsPicture.Click += new System.EventHandler(this.SettingsPicture_Click);
            // 
            // SettingsBTN
            // 
            this.SettingsBTN.AutoSize = true;
            this.SettingsBTN.BackColor = System.Drawing.Color.Transparent;
            this.SettingsBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SettingsBTN.Location = new System.Drawing.Point(40, 120);
            this.SettingsBTN.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsBTN.Name = "SettingsBTN";
            this.SettingsBTN.Size = new System.Drawing.Size(127, 40);
            this.SettingsBTN.TabIndex = 5;
            this.SettingsBTN.Text = "Настройки";
            this.SettingsBTN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SettingsBTN.Click += new System.EventHandler(this.SettingsBTN_Click);
            // 
            // ColorPanel
            // 
            this.ColorPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ColorPanel.Location = new System.Drawing.Point(167, 0);
            this.ColorPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ColorPanel.Name = "ColorPanel";
            this.ColorPanel.Size = new System.Drawing.Size(2, 562);
            this.ColorPanel.TabIndex = 3;
            // 
            // pagePanel
            // 
            this.pagePanel.BackColor = System.Drawing.Color.Transparent;
            this.pagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagePanel.Location = new System.Drawing.Point(169, 0);
            this.pagePanel.Margin = new System.Windows.Forms.Padding(0);
            this.pagePanel.Name = "pagePanel";
            this.pagePanel.Size = new System.Drawing.Size(1115, 562);
            this.pagePanel.TabIndex = 4;
            // 
            // GUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1284, 562);
            this.Controls.Add(this.pagePanel);
            this.Controls.Add(this.ColorPanel);
            this.Controls.Add(this.tabPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1300, 600);
            this.Name = "GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flight Radar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GUI_FormClosed);
            this.LocationChanged += new System.EventHandler(this.GUI_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.GUI_SizeChanged);
            this.tabPanel.ResumeLayout(false);
            this.tabTable.ResumeLayout(false);
            this.tabTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AircraftPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScanPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Panel tabPanel;
        private System.Windows.Forms.TableLayoutPanel tabTable;
        private System.Windows.Forms.PictureBox ScanPicture;
        private System.Windows.Forms.Label StartStopBTN;
        private System.Windows.Forms.Label AircraftBTN;
        private System.Windows.Forms.PictureBox AircraftPicture;
        private System.Windows.Forms.PictureBox MapPicture;
        private System.Windows.Forms.Label MapBTN;
        private System.Windows.Forms.PictureBox SettingsPicture;
        private System.Windows.Forms.Label SettingsBTN;
        private System.Windows.Forms.Panel ColorPanel;
        private System.Windows.Forms.Panel pagePanel;
    }
}

