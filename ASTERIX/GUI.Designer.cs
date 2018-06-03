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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.MapPage = new System.Windows.Forms.TabPage();
            this.MapPanel = new System.Windows.Forms.Panel();
            this.MapContainer = new System.Windows.Forms.SplitContainer();
            this.SearchContainer = new System.Windows.Forms.SplitContainer();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ClassComboBox = new System.Windows.Forms.ComboBox();
            this.SICtextBox = new ASTERIX.UTextBox();
            this.SACtextBox = new ASTERIX.UTextBox();
            this.EndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.BeginTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EmitterCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.TargetAddressTextBox = new ASTERIX.UTextBox();
            this.AircraftIdetificationTextBox = new ASTERIX.UTextBox();
            this.RegistrationTextBox = new ASTERIX.UTextBox();
            this.TypeAircraftTextBox = new ASTERIX.UTextBox();
            this.Mode3ATextBox = new ASTERIX.UTextBox();
            this.AirportDepatureTextBox = new ASTERIX.UTextBox();
            this.AirportArrivalTextBox = new ASTERIX.UTextBox();
            this.CountryComboBox = new System.Windows.Forms.ComboBox();
            this.CATcomboBox = new System.Windows.Forms.ComboBox();
            this.HideSearchBTN = new System.Windows.Forms.Button();
            this.LoadGridView1 = new System.Windows.Forms.DataGridView();
            this.RouteContainer = new System.Windows.Forms.SplitContainer();
            this.RouteControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.HideRouteBTN = new System.Windows.Forms.Button();
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.AircraftPage = new System.Windows.Forms.TabPage();
            this.AircraftPanel = new System.Windows.Forms.Panel();
            this.SettingsPage = new System.Windows.Forms.TabPage();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.tabPanel.SuspendLayout();
            this.tabTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AircraftPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScanPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsPicture)).BeginInit();
            this.pagePanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.MapPage.SuspendLayout();
            this.MapPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapContainer)).BeginInit();
            this.MapContainer.Panel1.SuspendLayout();
            this.MapContainer.Panel2.SuspendLayout();
            this.MapContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchContainer)).BeginInit();
            this.SearchContainer.Panel1.SuspendLayout();
            this.SearchContainer.Panel2.SuspendLayout();
            this.SearchContainer.SuspendLayout();
            this.SearchPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RouteContainer)).BeginInit();
            this.RouteContainer.Panel1.SuspendLayout();
            this.RouteContainer.Panel2.SuspendLayout();
            this.RouteContainer.SuspendLayout();
            this.RouteControl.SuspendLayout();
            this.AircraftPage.SuspendLayout();
            this.SettingsPage.SuspendLayout();
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // tabPanel
            // 
            this.tabPanel.BackColor = System.Drawing.Color.LightGray;
            this.tabPanel.Controls.Add(this.tabTable);
            this.tabPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabPanel.Location = new System.Drawing.Point(0, 0);
            this.tabPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.Size = new System.Drawing.Size(167, 762);
            this.tabPanel.TabIndex = 2;
            // 
            // tabTable
            // 
            this.tabTable.ColumnCount = 2;
            this.tabTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
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
            // 
            // AircraftBTN
            // 
            this.AircraftBTN.AutoSize = true;
            this.AircraftBTN.BackColor = System.Drawing.Color.Transparent;
            this.AircraftBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AircraftBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AircraftBTN.Location = new System.Drawing.Point(33, 80);
            this.AircraftBTN.Margin = new System.Windows.Forms.Padding(0);
            this.AircraftBTN.Name = "AircraftBTN";
            this.AircraftBTN.Size = new System.Drawing.Size(134, 40);
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
            this.AircraftPicture.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.AircraftPicture.Size = new System.Drawing.Size(33, 40);
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
            this.ScanPicture.Size = new System.Drawing.Size(33, 40);
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
            this.StartStopBTN.Location = new System.Drawing.Point(33, 0);
            this.StartStopBTN.Margin = new System.Windows.Forms.Padding(0);
            this.StartStopBTN.Name = "StartStopBTN";
            this.StartStopBTN.Size = new System.Drawing.Size(134, 40);
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
            this.MapPicture.Size = new System.Drawing.Size(33, 40);
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
            this.MapBTN.Location = new System.Drawing.Point(33, 40);
            this.MapBTN.Margin = new System.Windows.Forms.Padding(0);
            this.MapBTN.Name = "MapBTN";
            this.MapBTN.Size = new System.Drawing.Size(134, 40);
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
            this.SettingsPicture.Size = new System.Drawing.Size(33, 40);
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
            this.SettingsBTN.Location = new System.Drawing.Point(33, 120);
            this.SettingsBTN.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsBTN.Name = "SettingsBTN";
            this.SettingsBTN.Size = new System.Drawing.Size(134, 40);
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
            this.ColorPanel.Size = new System.Drawing.Size(2, 762);
            this.ColorPanel.TabIndex = 3;
            // 
            // pagePanel
            // 
            this.pagePanel.BackColor = System.Drawing.Color.Transparent;
            this.pagePanel.Controls.Add(this.tabControl);
            this.pagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagePanel.Location = new System.Drawing.Point(169, 0);
            this.pagePanel.Margin = new System.Windows.Forms.Padding(0);
            this.pagePanel.Name = "pagePanel";
            this.pagePanel.Size = new System.Drawing.Size(1345, 762);
            this.pagePanel.TabIndex = 4;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.MapPage);
            this.tabControl.Controls.Add(this.AircraftPage);
            this.tabControl.Controls.Add(this.SettingsPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1345, 762);
            this.tabControl.TabIndex = 0;
            this.tabControl.Visible = false;
            // 
            // MapPage
            // 
            this.MapPage.Controls.Add(this.MapPanel);
            this.MapPage.Location = new System.Drawing.Point(4, 22);
            this.MapPage.Margin = new System.Windows.Forms.Padding(0);
            this.MapPage.Name = "MapPage";
            this.MapPage.Padding = new System.Windows.Forms.Padding(3);
            this.MapPage.Size = new System.Drawing.Size(1337, 736);
            this.MapPage.TabIndex = 0;
            this.MapPage.Text = "Карта";
            this.MapPage.UseVisualStyleBackColor = true;
            // 
            // MapPanel
            // 
            this.MapPanel.Controls.Add(this.MapContainer);
            this.MapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapPanel.Location = new System.Drawing.Point(3, 3);
            this.MapPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MapPanel.Name = "MapPanel";
            this.MapPanel.Size = new System.Drawing.Size(1331, 730);
            this.MapPanel.TabIndex = 1;
            // 
            // MapContainer
            // 
            this.MapContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapContainer.Location = new System.Drawing.Point(0, 0);
            this.MapContainer.Margin = new System.Windows.Forms.Padding(0);
            this.MapContainer.Name = "MapContainer";
            this.MapContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MapContainer.Panel1
            // 
            this.MapContainer.Panel1.Controls.Add(this.SearchContainer);
            // 
            // MapContainer.Panel2
            // 
            this.MapContainer.Panel2.Controls.Add(this.RouteContainer);
            this.MapContainer.Size = new System.Drawing.Size(1331, 730);
            this.MapContainer.SplitterDistance = 290;
            this.MapContainer.TabIndex = 1;
            // 
            // SearchContainer
            // 
            this.SearchContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchContainer.Location = new System.Drawing.Point(0, 0);
            this.SearchContainer.Margin = new System.Windows.Forms.Padding(0);
            this.SearchContainer.Name = "SearchContainer";
            this.SearchContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SearchContainer.Panel1
            // 
            this.SearchContainer.Panel1.Controls.Add(this.SearchPanel);
            this.SearchContainer.Panel1.Controls.Add(this.HideSearchBTN);
            this.SearchContainer.Panel1MinSize = 0;
            // 
            // SearchContainer.Panel2
            // 
            this.SearchContainer.Panel2.Controls.Add(this.LoadGridView1);
            this.SearchContainer.Size = new System.Drawing.Size(1331, 290);
            this.SearchContainer.SplitterDistance = 151;
            this.SearchContainer.TabIndex = 0;
            // 
            // SearchPanel
            // 
            this.SearchPanel.BackColor = System.Drawing.Color.LightGray;
            this.SearchPanel.Controls.Add(this.tableLayoutPanel1);
            this.SearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchPanel.Location = new System.Drawing.Point(0, 0);
            this.SearchPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(1331, 129);
            this.SearchPanel.TabIndex = 8;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.698304F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.42133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.42133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.42133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.42133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.42133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.42133F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.773728F));
            this.tableLayoutPanel1.Controls.Add(this.ClassComboBox, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.SICtextBox, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.SACtextBox, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.EndTimePicker, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.BeginTimePicker, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.EmitterCategoryComboBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.TargetAddressTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.AircraftIdetificationTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.RegistrationTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TypeAircraftTextBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Mode3ATextBox, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.AirportDepatureTextBox, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.AirportArrivalTextBox, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.CountryComboBox, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.CATcomboBox, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1331, 129);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // ClassComboBox
            // 
            this.ClassComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ClassComboBox.FormattingEnabled = true;
            this.ClassComboBox.Location = new System.Drawing.Point(1060, 11);
            this.ClassComboBox.Name = "ClassComboBox";
            this.ClassComboBox.Size = new System.Drawing.Size(167, 21);
            this.ClassComboBox.TabIndex = 16;
            // 
            // SICtextBox
            // 
            this.SICtextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SICtextBox.BackColoField = System.Drawing.Color.White;
            this.SICtextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SICtextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.SICtextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.SICtextBox.Location = new System.Drawing.Point(866, 97);
            this.SICtextBox.Margin = new System.Windows.Forms.Padding(0);
            this.SICtextBox.MaskColoField = System.Drawing.Color.Gray;
            this.SICtextBox.MaskField = "SIC";
            this.SICtextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.SICtextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.SICtextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.SICtextBox.Name = "SICtextBox";
            this.SICtextBox.Size = new System.Drawing.Size(167, 20);
            this.SICtextBox.TabIndex = 15;
            this.SICtextBox.TextColorField = System.Drawing.Color.Black;
            this.SICtextBox.TextField = null;
            // 
            // SACtextBox
            // 
            this.SACtextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SACtextBox.BackColoField = System.Drawing.Color.White;
            this.SACtextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SACtextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.SACtextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.SACtextBox.Location = new System.Drawing.Point(866, 54);
            this.SACtextBox.Margin = new System.Windows.Forms.Padding(0);
            this.SACtextBox.MaskColoField = System.Drawing.Color.Gray;
            this.SACtextBox.MaskField = "SAC";
            this.SACtextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.SACtextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.SACtextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.SACtextBox.Name = "SACtextBox";
            this.SACtextBox.Size = new System.Drawing.Size(167, 20);
            this.SACtextBox.TabIndex = 14;
            this.SACtextBox.TextColorField = System.Drawing.Color.Black;
            this.SACtextBox.TextField = null;
            // 
            // EndTimePicker
            // 
            this.EndTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EndTimePicker.Checked = false;
            this.EndTimePicker.Location = new System.Drawing.Point(675, 54);
            this.EndTimePicker.Margin = new System.Windows.Forms.Padding(0);
            this.EndTimePicker.Name = "EndTimePicker";
            this.EndTimePicker.ShowCheckBox = true;
            this.EndTimePicker.Size = new System.Drawing.Size(167, 20);
            this.EndTimePicker.TabIndex = 11;
            this.EndTimePicker.ValueChanged += new System.EventHandler(this.EndTimePicker_ValueChanged);
            this.EndTimePicker.DropDown += new System.EventHandler(this.EndTimePicker_DropDown);
            this.EndTimePicker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EndTimePicker_MouseDown);
            // 
            // BeginTimePicker
            // 
            this.BeginTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BeginTimePicker.Location = new System.Drawing.Point(675, 11);
            this.BeginTimePicker.Margin = new System.Windows.Forms.Padding(0);
            this.BeginTimePicker.Name = "BeginTimePicker";
            this.BeginTimePicker.ShowCheckBox = true;
            this.BeginTimePicker.Size = new System.Drawing.Size(167, 20);
            this.BeginTimePicker.TabIndex = 10;
            this.BeginTimePicker.ValueChanged += new System.EventHandler(this.BeginTimePicker_ValueChanged);
            this.BeginTimePicker.DropDown += new System.EventHandler(this.BeginTimePicker_DropDown);
            this.BeginTimePicker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BeginTimePicker_MouseDown);
            // 
            // EmitterCategoryComboBox
            // 
            this.EmitterCategoryComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EmitterCategoryComboBox.FormattingEnabled = true;
            this.EmitterCategoryComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EmitterCategoryComboBox.Location = new System.Drawing.Point(293, 11);
            this.EmitterCategoryComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.EmitterCategoryComboBox.MaxDropDownItems = 50;
            this.EmitterCategoryComboBox.Name = "EmitterCategoryComboBox";
            this.EmitterCategoryComboBox.Size = new System.Drawing.Size(167, 21);
            this.EmitterCategoryComboBox.TabIndex = 4;
            this.EmitterCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.EmitterCategoryComboBox_SelectedIndexChanged);
            this.EmitterCategoryComboBox.Click += new System.EventHandler(this.EmitterCategoryComboBox_Click);
            // 
            // TargetAddressTextBox
            // 
            this.TargetAddressTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TargetAddressTextBox.BackColoField = System.Drawing.Color.White;
            this.TargetAddressTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TargetAddressTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.TargetAddressTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.TargetAddressTextBox.Location = new System.Drawing.Point(102, 11);
            this.TargetAddressTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.TargetAddressTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.TargetAddressTextBox.MaskField = "ICAO24";
            this.TargetAddressTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.TargetAddressTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.TargetAddressTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.TargetAddressTextBox.Name = "TargetAddressTextBox";
            this.TargetAddressTextBox.Size = new System.Drawing.Size(167, 20);
            this.TargetAddressTextBox.TabIndex = 1;
            this.TargetAddressTextBox.TextColorField = System.Drawing.Color.Black;
            this.TargetAddressTextBox.TextField = null;
            this.TargetAddressTextBox.ControlTextChanged += new System.EventHandler(this.TargetAddressTextBox_TextChanged);
            // 
            // AircraftIdetificationTextBox
            // 
            this.AircraftIdetificationTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AircraftIdetificationTextBox.BackColoField = System.Drawing.Color.White;
            this.AircraftIdetificationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AircraftIdetificationTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.AircraftIdetificationTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.AircraftIdetificationTextBox.Location = new System.Drawing.Point(102, 54);
            this.AircraftIdetificationTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.AircraftIdetificationTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.AircraftIdetificationTextBox.MaskField = "ПОЗЫВНОЙ";
            this.AircraftIdetificationTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.AircraftIdetificationTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.AircraftIdetificationTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.AircraftIdetificationTextBox.Name = "AircraftIdetificationTextBox";
            this.AircraftIdetificationTextBox.Size = new System.Drawing.Size(167, 20);
            this.AircraftIdetificationTextBox.TabIndex = 2;
            this.AircraftIdetificationTextBox.TextColorField = System.Drawing.Color.Black;
            this.AircraftIdetificationTextBox.TextField = null;
            this.AircraftIdetificationTextBox.ControlTextChanged += new System.EventHandler(this.AircraftIdetificationTextBox_TextChanged);
            // 
            // RegistrationTextBox
            // 
            this.RegistrationTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RegistrationTextBox.BackColoField = System.Drawing.Color.White;
            this.RegistrationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RegistrationTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.RegistrationTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.RegistrationTextBox.Location = new System.Drawing.Point(102, 97);
            this.RegistrationTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.RegistrationTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.RegistrationTextBox.MaskField = "БОРТОВОЙ";
            this.RegistrationTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.RegistrationTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.RegistrationTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.RegistrationTextBox.Name = "RegistrationTextBox";
            this.RegistrationTextBox.Size = new System.Drawing.Size(167, 20);
            this.RegistrationTextBox.TabIndex = 3;
            this.RegistrationTextBox.TextColorField = System.Drawing.Color.Black;
            this.RegistrationTextBox.TextField = null;
            // 
            // TypeAircraftTextBox
            // 
            this.TypeAircraftTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TypeAircraftTextBox.BackColoField = System.Drawing.Color.White;
            this.TypeAircraftTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TypeAircraftTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.TypeAircraftTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.TypeAircraftTextBox.Location = new System.Drawing.Point(293, 54);
            this.TypeAircraftTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.TypeAircraftTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.TypeAircraftTextBox.MaskField = "ТИП";
            this.TypeAircraftTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.TypeAircraftTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.TypeAircraftTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.TypeAircraftTextBox.Name = "TypeAircraftTextBox";
            this.TypeAircraftTextBox.Size = new System.Drawing.Size(167, 20);
            this.TypeAircraftTextBox.TabIndex = 5;
            this.TypeAircraftTextBox.TextColorField = System.Drawing.Color.Black;
            this.TypeAircraftTextBox.TextField = null;
            // 
            // Mode3ATextBox
            // 
            this.Mode3ATextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Mode3ATextBox.BackColoField = System.Drawing.Color.White;
            this.Mode3ATextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Mode3ATextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.Mode3ATextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.Mode3ATextBox.Location = new System.Drawing.Point(293, 97);
            this.Mode3ATextBox.Margin = new System.Windows.Forms.Padding(0);
            this.Mode3ATextBox.MaskColoField = System.Drawing.Color.Gray;
            this.Mode3ATextBox.MaskField = "MODE3A";
            this.Mode3ATextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.Mode3ATextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.Mode3ATextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.Mode3ATextBox.Name = "Mode3ATextBox";
            this.Mode3ATextBox.Size = new System.Drawing.Size(167, 20);
            this.Mode3ATextBox.TabIndex = 6;
            this.Mode3ATextBox.TextColorField = System.Drawing.Color.Black;
            this.Mode3ATextBox.TextField = null;
            // 
            // AirportDepatureTextBox
            // 
            this.AirportDepatureTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AirportDepatureTextBox.BackColoField = System.Drawing.Color.White;
            this.AirportDepatureTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AirportDepatureTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.AirportDepatureTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.AirportDepatureTextBox.Location = new System.Drawing.Point(484, 54);
            this.AirportDepatureTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.AirportDepatureTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.AirportDepatureTextBox.MaskField = "АЭРОПОРТ ВЫЛЕТА";
            this.AirportDepatureTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.AirportDepatureTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.AirportDepatureTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.AirportDepatureTextBox.Name = "AirportDepatureTextBox";
            this.AirportDepatureTextBox.Size = new System.Drawing.Size(167, 20);
            this.AirportDepatureTextBox.TabIndex = 8;
            this.AirportDepatureTextBox.TextColorField = System.Drawing.Color.Black;
            this.AirportDepatureTextBox.TextField = null;
            this.AirportDepatureTextBox.ControlTextChanged += new System.EventHandler(this.AirportDepatureTextBox_TextChanged);
            // 
            // AirportArrivalTextBox
            // 
            this.AirportArrivalTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AirportArrivalTextBox.BackColoField = System.Drawing.Color.White;
            this.AirportArrivalTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AirportArrivalTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.AirportArrivalTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.AirportArrivalTextBox.Location = new System.Drawing.Point(484, 97);
            this.AirportArrivalTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.AirportArrivalTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.AirportArrivalTextBox.MaskField = "АЭРОПОРТ ПРИБЫТИЯ";
            this.AirportArrivalTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.AirportArrivalTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.AirportArrivalTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.AirportArrivalTextBox.Name = "AirportArrivalTextBox";
            this.AirportArrivalTextBox.Size = new System.Drawing.Size(167, 20);
            this.AirportArrivalTextBox.TabIndex = 9;
            this.AirportArrivalTextBox.TextColorField = System.Drawing.Color.Black;
            this.AirportArrivalTextBox.TextField = null;
            this.AirportArrivalTextBox.ControlTextChanged += new System.EventHandler(this.AirportArrivalTextBox_TextChanged);
            // 
            // CountryComboBox
            // 
            this.CountryComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CountryComboBox.FormattingEnabled = true;
            this.CountryComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CountryComboBox.Location = new System.Drawing.Point(484, 11);
            this.CountryComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.CountryComboBox.MaxDropDownItems = 50;
            this.CountryComboBox.Name = "CountryComboBox";
            this.CountryComboBox.Size = new System.Drawing.Size(167, 21);
            this.CountryComboBox.TabIndex = 17;
            // 
            // CATcomboBox
            // 
            this.CATcomboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CATcomboBox.FormattingEnabled = true;
            this.CATcomboBox.Location = new System.Drawing.Point(866, 11);
            this.CATcomboBox.Margin = new System.Windows.Forms.Padding(0);
            this.CATcomboBox.Name = "CATcomboBox";
            this.CATcomboBox.Size = new System.Drawing.Size(167, 21);
            this.CATcomboBox.TabIndex = 13;
            // 
            // HideSearchBTN
            // 
            this.HideSearchBTN.BackColor = System.Drawing.Color.CornflowerBlue;
            this.HideSearchBTN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HideSearchBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HideSearchBTN.Location = new System.Drawing.Point(0, 129);
            this.HideSearchBTN.Margin = new System.Windows.Forms.Padding(0);
            this.HideSearchBTN.MaximumSize = new System.Drawing.Size(0, 22);
            this.HideSearchBTN.MinimumSize = new System.Drawing.Size(0, 22);
            this.HideSearchBTN.Name = "HideSearchBTN";
            this.HideSearchBTN.Size = new System.Drawing.Size(1331, 22);
            this.HideSearchBTN.TabIndex = 7;
            this.HideSearchBTN.Text = "Нажмите для настройки фильтра";
            this.HideSearchBTN.UseVisualStyleBackColor = false;
            this.HideSearchBTN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HideSearchBTN_MouseDown);
            this.HideSearchBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HideSearchBTN_MouseUp);
            // 
            // LoadGridView1
            // 
            this.LoadGridView1.AllowUserToAddRows = false;
            this.LoadGridView1.AllowUserToResizeColumns = false;
            this.LoadGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.LoadGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.LoadGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.LoadGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.LoadGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoadGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LoadGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.LoadGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LoadGridView1.DefaultCellStyle = dataGridViewCellStyle11;
            this.LoadGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadGridView1.GridColor = System.Drawing.Color.SeaGreen;
            this.LoadGridView1.Location = new System.Drawing.Point(0, 0);
            this.LoadGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.LoadGridView1.Name = "LoadGridView1";
            this.LoadGridView1.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LoadGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.LoadGridView1.RowHeadersWidth = 40;
            this.LoadGridView1.RowTemplate.Height = 25;
            this.LoadGridView1.RowTemplate.ReadOnly = true;
            this.LoadGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LoadGridView1.Size = new System.Drawing.Size(1331, 135);
            this.LoadGridView1.TabIndex = 0;
            this.LoadGridView1.TabStop = false;
            // 
            // RouteContainer
            // 
            this.RouteContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RouteContainer.Location = new System.Drawing.Point(0, 0);
            this.RouteContainer.Margin = new System.Windows.Forms.Padding(0);
            this.RouteContainer.Name = "RouteContainer";
            // 
            // RouteContainer.Panel1
            // 
            this.RouteContainer.Panel1.BackColor = System.Drawing.Color.LightGray;
            this.RouteContainer.Panel1.Controls.Add(this.RouteControl);
            this.RouteContainer.Panel1.Controls.Add(this.HideRouteBTN);
            // 
            // RouteContainer.Panel2
            // 
            this.RouteContainer.Panel2.Controls.Add(this.gMapControl);
            this.RouteContainer.Size = new System.Drawing.Size(1331, 436);
            this.RouteContainer.SplitterDistance = 281;
            this.RouteContainer.TabIndex = 0;
            // 
            // RouteControl
            // 
            this.RouteControl.Controls.Add(this.tabPage1);
            this.RouteControl.Controls.Add(this.tabPage2);
            this.RouteControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RouteControl.Location = new System.Drawing.Point(0, 0);
            this.RouteControl.Margin = new System.Windows.Forms.Padding(0);
            this.RouteControl.Name = "RouteControl";
            this.RouteControl.SelectedIndex = 0;
            this.RouteControl.Size = new System.Drawing.Size(259, 436);
            this.RouteControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(251, 410);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Маршруты";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(251, 410);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Полигоны";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // HideRouteBTN
            // 
            this.HideRouteBTN.BackColor = System.Drawing.Color.CornflowerBlue;
            this.HideRouteBTN.Dock = System.Windows.Forms.DockStyle.Right;
            this.HideRouteBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HideRouteBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HideRouteBTN.Location = new System.Drawing.Point(259, 0);
            this.HideRouteBTN.Margin = new System.Windows.Forms.Padding(0);
            this.HideRouteBTN.MaximumSize = new System.Drawing.Size(22, 0);
            this.HideRouteBTN.MinimumSize = new System.Drawing.Size(22, 0);
            this.HideRouteBTN.Name = "HideRouteBTN";
            this.HideRouteBTN.Size = new System.Drawing.Size(22, 436);
            this.HideRouteBTN.TabIndex = 0;
            this.HideRouteBTN.Text = "Маршруты";
            this.HideRouteBTN.UseVisualStyleBackColor = false;
            this.HideRouteBTN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HideRouteBTN_MouseDown);
            this.HideRouteBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HideRouteBTN_MouseUp);
            // 
            // gMapControl
            // 
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemmory = 5;
            this.gMapControl.Location = new System.Drawing.Point(0, 0);
            this.gMapControl.Margin = new System.Windows.Forms.Padding(0);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 2;
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new System.Drawing.Size(1046, 436);
            this.gMapControl.TabIndex = 0;
            this.gMapControl.Zoom = 0D;
            this.gMapControl.Load += new System.EventHandler(this.gMapControl_Load);
            // 
            // AircraftPage
            // 
            this.AircraftPage.Controls.Add(this.AircraftPanel);
            this.AircraftPage.Location = new System.Drawing.Point(4, 22);
            this.AircraftPage.Margin = new System.Windows.Forms.Padding(0);
            this.AircraftPage.Name = "AircraftPage";
            this.AircraftPage.Padding = new System.Windows.Forms.Padding(3);
            this.AircraftPage.Size = new System.Drawing.Size(1337, 736);
            this.AircraftPage.TabIndex = 1;
            this.AircraftPage.Text = "Привязки";
            this.AircraftPage.UseVisualStyleBackColor = true;
            // 
            // AircraftPanel
            // 
            this.AircraftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AircraftPanel.Location = new System.Drawing.Point(3, 3);
            this.AircraftPanel.Margin = new System.Windows.Forms.Padding(0);
            this.AircraftPanel.Name = "AircraftPanel";
            this.AircraftPanel.Size = new System.Drawing.Size(1331, 730);
            this.AircraftPanel.TabIndex = 0;
            // 
            // SettingsPage
            // 
            this.SettingsPage.Controls.Add(this.SettingsPanel);
            this.SettingsPage.Location = new System.Drawing.Point(4, 22);
            this.SettingsPage.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsPage.Size = new System.Drawing.Size(1337, 736);
            this.SettingsPage.TabIndex = 2;
            this.SettingsPage.Text = "Настройки";
            this.SettingsPage.UseVisualStyleBackColor = true;
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsPanel.Location = new System.Drawing.Point(3, 3);
            this.SettingsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(1331, 730);
            this.SettingsPanel.TabIndex = 1;
            // 
            // GUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1514, 762);
            this.Controls.Add(this.pagePanel);
            this.Controls.Add(this.ColorPanel);
            this.Controls.Add(this.tabPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1230, 800);
            this.Name = "GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flight Radar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.tabPanel.ResumeLayout(false);
            this.tabTable.ResumeLayout(false);
            this.tabTable.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AircraftPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScanPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MapPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsPicture)).EndInit();
            this.pagePanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.MapPage.ResumeLayout(false);
            this.MapPanel.ResumeLayout(false);
            this.MapContainer.Panel1.ResumeLayout(false);
            this.MapContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MapContainer)).EndInit();
            this.MapContainer.ResumeLayout(false);
            this.SearchContainer.Panel1.ResumeLayout(false);
            this.SearchContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SearchContainer)).EndInit();
            this.SearchContainer.ResumeLayout(false);
            this.SearchPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LoadGridView1)).EndInit();
            this.RouteContainer.Panel1.ResumeLayout(false);
            this.RouteContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RouteContainer)).EndInit();
            this.RouteContainer.ResumeLayout(false);
            this.RouteControl.ResumeLayout(false);
            this.AircraftPage.ResumeLayout(false);
            this.SettingsPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer UpdateTimer;
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
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage MapPage;
        private System.Windows.Forms.Panel MapPanel;
        private System.Windows.Forms.SplitContainer MapContainer;
        private System.Windows.Forms.SplitContainer SearchContainer;
        private System.Windows.Forms.DataGridView LoadGridView1;
        private System.Windows.Forms.SplitContainer RouteContainer;
        private System.Windows.Forms.TabPage AircraftPage;
        private System.Windows.Forms.Panel AircraftPanel;
        private System.Windows.Forms.TabPage SettingsPage;
        private System.Windows.Forms.Panel SettingsPanel;
        private System.Windows.Forms.Button HideSearchBTN;
        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.DateTimePicker EndTimePicker;
        private System.Windows.Forms.DateTimePicker BeginTimePicker;
        private System.Windows.Forms.ComboBox ClassComboBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UTextBox SICtextBox;
        private UTextBox SACtextBox;
        private System.Windows.Forms.ComboBox EmitterCategoryComboBox;
        private UTextBox TargetAddressTextBox;
        private UTextBox AircraftIdetificationTextBox;
        private UTextBox RegistrationTextBox;
        private UTextBox TypeAircraftTextBox;
        private UTextBox Mode3ATextBox;
        private UTextBox AirportDepatureTextBox;
        private UTextBox AirportArrivalTextBox;
        private System.Windows.Forms.ComboBox CountryComboBox;
        private System.Windows.Forms.ComboBox CATcomboBox;
        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.TabControl RouteControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button HideRouteBTN;
    }
}

