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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.TargetAddressTextBox = new System.Windows.Forms.TextBox();
            this.EndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.AircraftIdetificationTextBox = new System.Windows.Forms.TextBox();
            this.BeginTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EmitterCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.AirportArrivalTextBox = new System.Windows.Forms.TextBox();
            this.AirportDepatureTextBox = new System.Windows.Forms.TextBox();
            this.LoadGridView1 = new System.Windows.Forms.DataGridView();
            this.RouteContainer = new System.Windows.Forms.SplitContainer();
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
            ((System.ComponentModel.ISupportInitialize)(this.LoadGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RouteContainer)).BeginInit();
            this.RouteContainer.SuspendLayout();
            this.AircraftPage.SuspendLayout();
            this.SettingsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.tabTable.SetColumnSpan(this.progressBar1, 2);
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 45);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(167, 24);
            this.progressBar1.TabIndex = 1;
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
            this.tabTable.RowCount = 5;
            this.tabTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tabTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tabTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tabTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tabTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tabTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tabTable.Size = new System.Drawing.Size(167, 208);
            this.tabTable.TabIndex = 0;
            // 
            // AircraftBTN
            // 
            this.AircraftBTN.AutoSize = true;
            this.AircraftBTN.BackColor = System.Drawing.Color.Transparent;
            this.AircraftBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AircraftBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AircraftBTN.Location = new System.Drawing.Point(33, 114);
            this.AircraftBTN.Margin = new System.Windows.Forms.Padding(0);
            this.AircraftBTN.Name = "AircraftBTN";
            this.AircraftBTN.Size = new System.Drawing.Size(134, 45);
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
            this.AircraftPicture.Location = new System.Drawing.Point(0, 114);
            this.AircraftPicture.Margin = new System.Windows.Forms.Padding(0);
            this.AircraftPicture.Name = "AircraftPicture";
            this.AircraftPicture.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.AircraftPicture.Size = new System.Drawing.Size(33, 45);
            this.AircraftPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.AircraftPicture.TabIndex = 5;
            this.AircraftPicture.TabStop = false;
            // 
            // ScanPicture
            // 
            this.ScanPicture.BackColor = System.Drawing.Color.Transparent;
            this.ScanPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScanPicture.Image = ((System.Drawing.Image)(resources.GetObject("ScanPicture.Image")));
            this.ScanPicture.Location = new System.Drawing.Point(0, 0);
            this.ScanPicture.Margin = new System.Windows.Forms.Padding(0);
            this.ScanPicture.Name = "ScanPicture";
            this.ScanPicture.Size = new System.Drawing.Size(33, 45);
            this.ScanPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScanPicture.TabIndex = 0;
            this.ScanPicture.TabStop = false;
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
            this.StartStopBTN.Size = new System.Drawing.Size(134, 45);
            this.StartStopBTN.TabIndex = 1;
            this.StartStopBTN.Text = "Сканирование";
            this.StartStopBTN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MapPicture
            // 
            this.MapPicture.BackColor = System.Drawing.Color.Transparent;
            this.MapPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapPicture.Image = ((System.Drawing.Image)(resources.GetObject("MapPicture.Image")));
            this.MapPicture.Location = new System.Drawing.Point(0, 69);
            this.MapPicture.Margin = new System.Windows.Forms.Padding(0);
            this.MapPicture.Name = "MapPicture";
            this.MapPicture.Size = new System.Drawing.Size(33, 45);
            this.MapPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MapPicture.TabIndex = 2;
            this.MapPicture.TabStop = false;
            // 
            // MapBTN
            // 
            this.MapBTN.AutoSize = true;
            this.MapBTN.BackColor = System.Drawing.Color.Transparent;
            this.MapBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MapBTN.Location = new System.Drawing.Point(33, 69);
            this.MapBTN.Margin = new System.Windows.Forms.Padding(0);
            this.MapBTN.Name = "MapBTN";
            this.MapBTN.Size = new System.Drawing.Size(134, 45);
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
            this.SettingsPicture.Location = new System.Drawing.Point(0, 159);
            this.SettingsPicture.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsPicture.Name = "SettingsPicture";
            this.SettingsPicture.Size = new System.Drawing.Size(33, 49);
            this.SettingsPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SettingsPicture.TabIndex = 4;
            this.SettingsPicture.TabStop = false;
            // 
            // SettingsBTN
            // 
            this.SettingsBTN.AutoSize = true;
            this.SettingsBTN.BackColor = System.Drawing.Color.Transparent;
            this.SettingsBTN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SettingsBTN.Location = new System.Drawing.Point(33, 159);
            this.SettingsBTN.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsBTN.Name = "SettingsBTN";
            this.SettingsBTN.Size = new System.Drawing.Size(134, 49);
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
            this.pagePanel.Size = new System.Drawing.Size(1045, 762);
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
            this.tabControl.Size = new System.Drawing.Size(1045, 762);
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
            this.MapPage.Size = new System.Drawing.Size(1037, 736);
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
            this.MapPanel.Size = new System.Drawing.Size(1031, 730);
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
            this.MapContainer.Size = new System.Drawing.Size(1031, 730);
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
            this.SearchContainer.Panel1.Controls.Add(this.TargetAddressTextBox);
            this.SearchContainer.Panel1.Controls.Add(this.EndTimePicker);
            this.SearchContainer.Panel1.Controls.Add(this.AircraftIdetificationTextBox);
            this.SearchContainer.Panel1.Controls.Add(this.BeginTimePicker);
            this.SearchContainer.Panel1.Controls.Add(this.EmitterCategoryComboBox);
            this.SearchContainer.Panel1.Controls.Add(this.AirportArrivalTextBox);
            this.SearchContainer.Panel1.Controls.Add(this.AirportDepatureTextBox);
            // 
            // SearchContainer.Panel2
            // 
            this.SearchContainer.Panel2.Controls.Add(this.LoadGridView1);
            this.SearchContainer.Size = new System.Drawing.Size(1031, 290);
            this.SearchContainer.SplitterDistance = 127;
            this.SearchContainer.TabIndex = 0;
            // 
            // TargetAddressTextBox
            // 
            this.TargetAddressTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TargetAddressTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TargetAddressTextBox.Location = new System.Drawing.Point(57, 20);
            this.TargetAddressTextBox.Name = "TargetAddressTextBox";
            this.TargetAddressTextBox.Size = new System.Drawing.Size(80, 20);
            this.TargetAddressTextBox.TabIndex = 1;
            this.TargetAddressTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EndTimePicker
            // 
            this.EndTimePicker.Checked = false;
            this.EndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndTimePicker.Location = new System.Drawing.Point(424, 46);
            this.EndTimePicker.Name = "EndTimePicker";
            this.EndTimePicker.ShowCheckBox = true;
            this.EndTimePicker.Size = new System.Drawing.Size(120, 20);
            this.EndTimePicker.TabIndex = 6;
            // 
            // AircraftIdetificationTextBox
            // 
            this.AircraftIdetificationTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.AircraftIdetificationTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.AircraftIdetificationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AircraftIdetificationTextBox.Location = new System.Drawing.Point(57, 46);
            this.AircraftIdetificationTextBox.Name = "AircraftIdetificationTextBox";
            this.AircraftIdetificationTextBox.Size = new System.Drawing.Size(120, 20);
            this.AircraftIdetificationTextBox.TabIndex = 0;
            this.AircraftIdetificationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BeginTimePicker
            // 
            this.BeginTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BeginTimePicker.Location = new System.Drawing.Point(424, 20);
            this.BeginTimePicker.Name = "BeginTimePicker";
            this.BeginTimePicker.ShowCheckBox = true;
            this.BeginTimePicker.Size = new System.Drawing.Size(120, 20);
            this.BeginTimePicker.TabIndex = 5;
            // 
            // EmitterCategoryComboBox
            // 
            this.EmitterCategoryComboBox.FormattingEnabled = true;
            this.EmitterCategoryComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EmitterCategoryComboBox.Location = new System.Drawing.Point(57, 72);
            this.EmitterCategoryComboBox.MaxDropDownItems = 50;
            this.EmitterCategoryComboBox.Name = "EmitterCategoryComboBox";
            this.EmitterCategoryComboBox.Size = new System.Drawing.Size(140, 21);
            this.EmitterCategoryComboBox.TabIndex = 2;
            // 
            // AirportArrivalTextBox
            // 
            this.AirportArrivalTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.AirportArrivalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AirportArrivalTextBox.Location = new System.Drawing.Point(247, 46);
            this.AirportArrivalTextBox.Name = "AirportArrivalTextBox";
            this.AirportArrivalTextBox.Size = new System.Drawing.Size(120, 20);
            this.AirportArrivalTextBox.TabIndex = 4;
            this.AirportArrivalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AirportDepatureTextBox
            // 
            this.AirportDepatureTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.AirportDepatureTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AirportDepatureTextBox.Location = new System.Drawing.Point(247, 20);
            this.AirportDepatureTextBox.Name = "AirportDepatureTextBox";
            this.AirportDepatureTextBox.Size = new System.Drawing.Size(120, 20);
            this.AirportDepatureTextBox.TabIndex = 3;
            this.AirportDepatureTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoadGridView1
            // 
            this.LoadGridView1.AllowUserToAddRows = false;
            this.LoadGridView1.AllowUserToResizeColumns = false;
            this.LoadGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.LoadGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.LoadGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.LoadGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.LoadGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoadGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LoadGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.LoadGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LoadGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.LoadGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadGridView1.GridColor = System.Drawing.Color.SeaGreen;
            this.LoadGridView1.Location = new System.Drawing.Point(0, 0);
            this.LoadGridView1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.LoadGridView1.Name = "LoadGridView1";
            this.LoadGridView1.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LoadGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.LoadGridView1.RowHeadersWidth = 40;
            this.LoadGridView1.RowTemplate.Height = 25;
            this.LoadGridView1.RowTemplate.ReadOnly = true;
            this.LoadGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LoadGridView1.Size = new System.Drawing.Size(1031, 159);
            this.LoadGridView1.TabIndex = 0;
            this.LoadGridView1.TabStop = false;
            // 
            // RouteContainer
            // 
            this.RouteContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RouteContainer.Location = new System.Drawing.Point(0, 0);
            this.RouteContainer.Margin = new System.Windows.Forms.Padding(0);
            this.RouteContainer.Name = "RouteContainer";
            this.RouteContainer.Size = new System.Drawing.Size(1031, 436);
            this.RouteContainer.SplitterDistance = 342;
            this.RouteContainer.TabIndex = 0;
            // 
            // AircraftPage
            // 
            this.AircraftPage.Controls.Add(this.AircraftPanel);
            this.AircraftPage.Location = new System.Drawing.Point(4, 22);
            this.AircraftPage.Margin = new System.Windows.Forms.Padding(0);
            this.AircraftPage.Name = "AircraftPage";
            this.AircraftPage.Padding = new System.Windows.Forms.Padding(3);
            this.AircraftPage.Size = new System.Drawing.Size(1037, 736);
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
            this.AircraftPanel.Size = new System.Drawing.Size(1031, 730);
            this.AircraftPanel.TabIndex = 0;
            // 
            // SettingsPage
            // 
            this.SettingsPage.Controls.Add(this.SettingsPanel);
            this.SettingsPage.Location = new System.Drawing.Point(4, 22);
            this.SettingsPage.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsPage.Size = new System.Drawing.Size(1037, 736);
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
            this.SettingsPanel.Size = new System.Drawing.Size(1031, 730);
            this.SettingsPanel.TabIndex = 1;
            // 
            // GUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1214, 762);
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
            this.SearchContainer.Panel1.PerformLayout();
            this.SearchContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SearchContainer)).EndInit();
            this.SearchContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LoadGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RouteContainer)).EndInit();
            this.RouteContainer.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox TargetAddressTextBox;
        private System.Windows.Forms.DateTimePicker EndTimePicker;
        private System.Windows.Forms.TextBox AircraftIdetificationTextBox;
        private System.Windows.Forms.DateTimePicker BeginTimePicker;
        private System.Windows.Forms.ComboBox EmitterCategoryComboBox;
        private System.Windows.Forms.TextBox AirportArrivalTextBox;
        private System.Windows.Forms.TextBox AirportDepatureTextBox;
        private System.Windows.Forms.DataGridView LoadGridView1;
        private System.Windows.Forms.SplitContainer RouteContainer;
        private System.Windows.Forms.TabPage AircraftPage;
        private System.Windows.Forms.Panel AircraftPanel;
        private System.Windows.Forms.TabPage SettingsPage;
        private System.Windows.Forms.Panel SettingsPanel;
    }
}

