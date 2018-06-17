namespace ASTERIX
{
    partial class Map
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Map));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MapPanel = new System.Windows.Forms.Panel();
            this.MapContainer = new System.Windows.Forms.SplitContainer();
            this.SearchContainer = new System.Windows.Forms.SplitContainer();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.SearchTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SICtextBox = new ASTERIX.UTextBox();
            this.SACtextBox = new ASTERIX.UTextBox();
            this.EndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.BeginTimePicker = new System.Windows.Forms.DateTimePicker();
            this.TargetAddressTextBox = new ASTERIX.UTextBox();
            this.AircraftIdetificationTextBox = new ASTERIX.UTextBox();
            this.RegistrationTextBox = new ASTERIX.UTextBox();
            this.TypeAircraftTextBox = new ASTERIX.UTextBox();
            this.Mode3ATextBox = new ASTERIX.UTextBox();
            this.AirportDepatureTextBox = new ASTERIX.UTextBox();
            this.AirportArrivalTextBox = new ASTERIX.UTextBox();
            this.EmitterCategoryComboBox = new ASTERIX.UComboBox();
            this.CountryComboBox = new ASTERIX.UComboBox();
            this.CATcomboBox = new ASTERIX.UComboBox();
            this.ClassComboBox = new ASTERIX.UComboBox();
            this.toMapBTN = new System.Windows.Forms.Button();
            this.ClearFilterBTN = new System.Windows.Forms.Button();
            this.HideSearchBTN = new System.Windows.Forms.Button();
            this.PagePanel = new System.Windows.Forms.Panel();
            this.AllPageTextBox = new System.Windows.Forms.MaskedTextBox();
            this.PageTextBox = new System.Windows.Forms.MaskedTextBox();
            this.Back = new System.Windows.Forms.Button();
            this.Up = new System.Windows.Forms.Button();
            this.INlabel = new System.Windows.Forms.Label();
            this.LoadGridView = new System.Windows.Forms.DataGridView();
            this.RouteContainer = new System.Windows.Forms.SplitContainer();
            this.RouteControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.RouteGridView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.HideRouteBTN = new System.Windows.Forms.Button();
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
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
            this.SearchTableLayoutPanel.SuspendLayout();
            this.PagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RouteContainer)).BeginInit();
            this.RouteContainer.Panel1.SuspendLayout();
            this.RouteContainer.Panel2.SuspendLayout();
            this.RouteContainer.SuspendLayout();
            this.RouteControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RouteGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // MapPanel
            // 
            this.MapPanel.Controls.Add(this.MapContainer);
            this.MapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapPanel.Location = new System.Drawing.Point(0, 0);
            this.MapPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MapPanel.Name = "MapPanel";
            this.MapPanel.Size = new System.Drawing.Size(1200, 600);
            this.MapPanel.TabIndex = 2;
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
            this.MapContainer.Size = new System.Drawing.Size(1200, 600);
            this.MapContainer.SplitterDistance = 273;
            this.MapContainer.TabIndex = 1;
            // 
            // SearchContainer
            // 
            this.SearchContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
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
            this.SearchContainer.Panel2.Controls.Add(this.PagePanel);
            this.SearchContainer.Panel2.Controls.Add(this.LoadGridView);
            this.SearchContainer.Size = new System.Drawing.Size(1200, 273);
            this.SearchContainer.SplitterDistance = 151;
            this.SearchContainer.TabIndex = 0;
            // 
            // SearchPanel
            // 
            this.SearchPanel.BackColor = System.Drawing.Color.LightGray;
            this.SearchPanel.Controls.Add(this.SearchTableLayoutPanel);
            this.SearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchPanel.Location = new System.Drawing.Point(0, 0);
            this.SearchPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(1200, 129);
            this.SearchPanel.TabIndex = 8;
            // 
            // SearchTableLayoutPanel
            // 
            this.SearchTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.SearchTableLayoutPanel.ColumnCount = 8;
            this.SearchTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.698304F));
            this.SearchTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.42133F));
            this.SearchTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.42133F));
            this.SearchTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.42133F));
            this.SearchTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.42133F));
            this.SearchTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.42133F));
            this.SearchTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.42133F));
            this.SearchTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.773728F));
            this.SearchTableLayoutPanel.Controls.Add(this.SICtextBox, 5, 2);
            this.SearchTableLayoutPanel.Controls.Add(this.SACtextBox, 5, 1);
            this.SearchTableLayoutPanel.Controls.Add(this.EndTimePicker, 4, 1);
            this.SearchTableLayoutPanel.Controls.Add(this.BeginTimePicker, 4, 0);
            this.SearchTableLayoutPanel.Controls.Add(this.TargetAddressTextBox, 1, 0);
            this.SearchTableLayoutPanel.Controls.Add(this.AircraftIdetificationTextBox, 1, 1);
            this.SearchTableLayoutPanel.Controls.Add(this.RegistrationTextBox, 1, 2);
            this.SearchTableLayoutPanel.Controls.Add(this.TypeAircraftTextBox, 2, 1);
            this.SearchTableLayoutPanel.Controls.Add(this.Mode3ATextBox, 2, 2);
            this.SearchTableLayoutPanel.Controls.Add(this.AirportDepatureTextBox, 3, 1);
            this.SearchTableLayoutPanel.Controls.Add(this.AirportArrivalTextBox, 3, 2);
            this.SearchTableLayoutPanel.Controls.Add(this.EmitterCategoryComboBox, 2, 0);
            this.SearchTableLayoutPanel.Controls.Add(this.CountryComboBox, 3, 0);
            this.SearchTableLayoutPanel.Controls.Add(this.CATcomboBox, 5, 0);
            this.SearchTableLayoutPanel.Controls.Add(this.ClassComboBox, 6, 0);
            this.SearchTableLayoutPanel.Controls.Add(this.toMapBTN, 6, 2);
            this.SearchTableLayoutPanel.Controls.Add(this.ClearFilterBTN, 6, 1);
            this.SearchTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.SearchTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SearchTableLayoutPanel.Name = "SearchTableLayoutPanel";
            this.SearchTableLayoutPanel.RowCount = 3;
            this.SearchTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.SearchTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.SearchTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.SearchTableLayoutPanel.Size = new System.Drawing.Size(1200, 129);
            this.SearchTableLayoutPanel.TabIndex = 2;
            this.SearchTableLayoutPanel.Click += new System.EventHandler(this.SearchTableLayoutPanel_Click);
            // 
            // SICtextBox
            // 
            this.SICtextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SICtextBox.BackColoField = System.Drawing.Color.White;
            this.SICtextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SICtextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.SICtextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.SICtextBox.Location = new System.Drawing.Point(784, 97);
            this.SICtextBox.Margin = new System.Windows.Forms.Padding(0);
            this.SICtextBox.MaskColoField = System.Drawing.Color.Gray;
            this.SICtextBox.MaskField = "SIC";
            this.SICtextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.SICtextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.SICtextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.SICtextBox.Name = "SICtextBox";
            this.SICtextBox.Size = new System.Drawing.Size(148, 20);
            this.SICtextBox.TabIndex = 15;
            this.SICtextBox.TextColorField = System.Drawing.Color.Black;
            this.SICtextBox.TextField = null;
            this.SICtextBox.ControlTextChanged += new System.EventHandler(this.SICtextBox_ControlTextChanged);
            // 
            // SACtextBox
            // 
            this.SACtextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SACtextBox.BackColoField = System.Drawing.Color.White;
            this.SACtextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SACtextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.SACtextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.SACtextBox.Location = new System.Drawing.Point(784, 54);
            this.SACtextBox.Margin = new System.Windows.Forms.Padding(0);
            this.SACtextBox.MaskColoField = System.Drawing.Color.Gray;
            this.SACtextBox.MaskField = "SAC";
            this.SACtextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.SACtextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.SACtextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.SACtextBox.Name = "SACtextBox";
            this.SACtextBox.Size = new System.Drawing.Size(148, 20);
            this.SACtextBox.TabIndex = 14;
            this.SACtextBox.TextColorField = System.Drawing.Color.Black;
            this.SACtextBox.TextField = null;
            this.SACtextBox.ControlTextChanged += new System.EventHandler(this.SACtextBox_ControlTextChanged);
            // 
            // EndTimePicker
            // 
            this.EndTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EndTimePicker.Checked = false;
            this.EndTimePicker.Location = new System.Drawing.Point(611, 54);
            this.EndTimePicker.Margin = new System.Windows.Forms.Padding(0);
            this.EndTimePicker.Name = "EndTimePicker";
            this.EndTimePicker.ShowCheckBox = true;
            this.EndTimePicker.Size = new System.Drawing.Size(148, 20);
            this.EndTimePicker.TabIndex = 11;
            this.EndTimePicker.ValueChanged += new System.EventHandler(this.EndTimePicker_ValueChanged);
            this.EndTimePicker.DropDown += new System.EventHandler(this.EndTimePicker_DropDown);
            this.EndTimePicker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EndTimePicker_MouseDown);
            // 
            // BeginTimePicker
            // 
            this.BeginTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BeginTimePicker.Location = new System.Drawing.Point(611, 11);
            this.BeginTimePicker.Margin = new System.Windows.Forms.Padding(0);
            this.BeginTimePicker.Name = "BeginTimePicker";
            this.BeginTimePicker.ShowCheckBox = true;
            this.BeginTimePicker.Size = new System.Drawing.Size(148, 20);
            this.BeginTimePicker.TabIndex = 10;
            this.BeginTimePicker.ValueChanged += new System.EventHandler(this.BeginTimePicker_ValueChanged);
            this.BeginTimePicker.DropDown += new System.EventHandler(this.BeginTimePicker_DropDown);
            this.BeginTimePicker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BeginTimePicker_MouseDown);
            // 
            // TargetAddressTextBox
            // 
            this.TargetAddressTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TargetAddressTextBox.BackColoField = System.Drawing.Color.White;
            this.TargetAddressTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TargetAddressTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.TargetAddressTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.TargetAddressTextBox.Location = new System.Drawing.Point(92, 11);
            this.TargetAddressTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.TargetAddressTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.TargetAddressTextBox.MaskField = "ICAO24";
            this.TargetAddressTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.TargetAddressTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.TargetAddressTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.TargetAddressTextBox.Name = "TargetAddressTextBox";
            this.TargetAddressTextBox.Size = new System.Drawing.Size(148, 20);
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
            this.AircraftIdetificationTextBox.Location = new System.Drawing.Point(92, 54);
            this.AircraftIdetificationTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.AircraftIdetificationTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.AircraftIdetificationTextBox.MaskField = "ПОЗЫВНОЙ";
            this.AircraftIdetificationTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.AircraftIdetificationTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.AircraftIdetificationTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.AircraftIdetificationTextBox.Name = "AircraftIdetificationTextBox";
            this.AircraftIdetificationTextBox.Size = new System.Drawing.Size(148, 20);
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
            this.RegistrationTextBox.Location = new System.Drawing.Point(92, 97);
            this.RegistrationTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.RegistrationTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.RegistrationTextBox.MaskField = "БОРТОВОЙ";
            this.RegistrationTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.RegistrationTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.RegistrationTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.RegistrationTextBox.Name = "RegistrationTextBox";
            this.RegistrationTextBox.Size = new System.Drawing.Size(148, 20);
            this.RegistrationTextBox.TabIndex = 3;
            this.RegistrationTextBox.TextColorField = System.Drawing.Color.Black;
            this.RegistrationTextBox.TextField = null;
            this.RegistrationTextBox.ControlTextChanged += new System.EventHandler(this.RegistrationTextBox_ControlTextChanged);
            // 
            // TypeAircraftTextBox
            // 
            this.TypeAircraftTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TypeAircraftTextBox.BackColoField = System.Drawing.Color.White;
            this.TypeAircraftTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TypeAircraftTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.TypeAircraftTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.TypeAircraftTextBox.Location = new System.Drawing.Point(265, 54);
            this.TypeAircraftTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.TypeAircraftTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.TypeAircraftTextBox.MaskField = "ТИП";
            this.TypeAircraftTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.TypeAircraftTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.TypeAircraftTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.TypeAircraftTextBox.Name = "TypeAircraftTextBox";
            this.TypeAircraftTextBox.Size = new System.Drawing.Size(148, 20);
            this.TypeAircraftTextBox.TabIndex = 5;
            this.TypeAircraftTextBox.TextColorField = System.Drawing.Color.Black;
            this.TypeAircraftTextBox.TextField = null;
            this.TypeAircraftTextBox.ControlTextChanged += new System.EventHandler(this.TypeAircraftTextBox_ControlTextChanged);
            // 
            // Mode3ATextBox
            // 
            this.Mode3ATextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Mode3ATextBox.BackColoField = System.Drawing.Color.White;
            this.Mode3ATextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Mode3ATextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.Mode3ATextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.Mode3ATextBox.Location = new System.Drawing.Point(265, 97);
            this.Mode3ATextBox.Margin = new System.Windows.Forms.Padding(0);
            this.Mode3ATextBox.MaskColoField = System.Drawing.Color.Gray;
            this.Mode3ATextBox.MaskField = "MODE3A";
            this.Mode3ATextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.Mode3ATextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.Mode3ATextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.Mode3ATextBox.Name = "Mode3ATextBox";
            this.Mode3ATextBox.Size = new System.Drawing.Size(148, 20);
            this.Mode3ATextBox.TabIndex = 6;
            this.Mode3ATextBox.TextColorField = System.Drawing.Color.Black;
            this.Mode3ATextBox.TextField = null;
            this.Mode3ATextBox.ControlTextChanged += new System.EventHandler(this.Mode3ATextBox_ControlTextChanged);
            // 
            // AirportDepatureTextBox
            // 
            this.AirportDepatureTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AirportDepatureTextBox.BackColoField = System.Drawing.Color.White;
            this.AirportDepatureTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AirportDepatureTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.AirportDepatureTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.AirportDepatureTextBox.Location = new System.Drawing.Point(438, 54);
            this.AirportDepatureTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.AirportDepatureTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.AirportDepatureTextBox.MaskField = "АЭРОПОРТ ВЫЛЕТА";
            this.AirportDepatureTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.AirportDepatureTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.AirportDepatureTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.AirportDepatureTextBox.Name = "AirportDepatureTextBox";
            this.AirportDepatureTextBox.Size = new System.Drawing.Size(148, 20);
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
            this.AirportArrivalTextBox.Location = new System.Drawing.Point(438, 97);
            this.AirportArrivalTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.AirportArrivalTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.AirportArrivalTextBox.MaskField = "АЭРОПОРТ ПРИБЫТИЯ";
            this.AirportArrivalTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.AirportArrivalTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.AirportArrivalTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.AirportArrivalTextBox.Name = "AirportArrivalTextBox";
            this.AirportArrivalTextBox.Size = new System.Drawing.Size(148, 20);
            this.AirportArrivalTextBox.TabIndex = 9;
            this.AirportArrivalTextBox.TextColorField = System.Drawing.Color.Black;
            this.AirportArrivalTextBox.TextField = null;
            this.AirportArrivalTextBox.ControlTextChanged += new System.EventHandler(this.AirportArrivalTextBox_TextChanged);
            // 
            // EmitterCategoryComboBox
            // 
            this.EmitterCategoryComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EmitterCategoryComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.EmitterCategoryComboBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EmitterCategoryComboBox.DataSource = ((System.Collections.Generic.List<string>)(resources.GetObject("EmitterCategoryComboBox.DataSource")));
            this.EmitterCategoryComboBox.DisplayItems = 15;
            this.EmitterCategoryComboBox.DroppedDown = false;
            this.EmitterCategoryComboBox.Location = new System.Drawing.Point(265, 11);
            this.EmitterCategoryComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.EmitterCategoryComboBox.MaskText = "КАТЕГОРИЯ";
            this.EmitterCategoryComboBox.Name = "EmitterCategoryComboBox";
            this.EmitterCategoryComboBox.Size = new System.Drawing.Size(148, 20);
            this.EmitterCategoryComboBox.TabIndex = 4;
            this.EmitterCategoryComboBox.TextField = null;
            this.EmitterCategoryComboBox.ControlSelectedIndexChanged += new System.EventHandler(this.EmitterCategoryComboBox_SelectedIndexChanged);
            this.EmitterCategoryComboBox.Enter += new System.EventHandler(this.EmitterCategoryComboBox_Enter);
            // 
            // CountryComboBox
            // 
            this.CountryComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CountryComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.CountryComboBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CountryComboBox.DataSource = ((System.Collections.Generic.List<string>)(resources.GetObject("CountryComboBox.DataSource")));
            this.CountryComboBox.DisplayItems = 15;
            this.CountryComboBox.DroppedDown = false;
            this.CountryComboBox.Location = new System.Drawing.Point(438, 11);
            this.CountryComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.CountryComboBox.MaskText = "ГОСУДАРСТВО";
            this.CountryComboBox.Name = "CountryComboBox";
            this.CountryComboBox.Size = new System.Drawing.Size(148, 20);
            this.CountryComboBox.TabIndex = 7;
            this.CountryComboBox.TextField = null;
            this.CountryComboBox.ControlSelectedIndexChanged += new System.EventHandler(this.CountryComboBox_SelectedIndexChanged);
            this.CountryComboBox.Enter += new System.EventHandler(this.CountryComboBox_Enter);
            // 
            // CATcomboBox
            // 
            this.CATcomboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CATcomboBox.BackColor = System.Drawing.SystemColors.Window;
            this.CATcomboBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CATcomboBox.DataSource = ((System.Collections.Generic.List<string>)(resources.GetObject("CATcomboBox.DataSource")));
            this.CATcomboBox.DisplayItems = 15;
            this.CATcomboBox.DroppedDown = false;
            this.CATcomboBox.Location = new System.Drawing.Point(784, 11);
            this.CATcomboBox.Margin = new System.Windows.Forms.Padding(0);
            this.CATcomboBox.MaskText = "CAT";
            this.CATcomboBox.Name = "CATcomboBox";
            this.CATcomboBox.Size = new System.Drawing.Size(148, 20);
            this.CATcomboBox.TabIndex = 13;
            this.CATcomboBox.TextField = null;
            this.CATcomboBox.ControlSelectedIndexChanged += new System.EventHandler(this.CATcomboBox_SelectedIndexChanged);
            this.CATcomboBox.Enter += new System.EventHandler(this.CATcomboBox_Enter);
            // 
            // ClassComboBox
            // 
            this.ClassComboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ClassComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.ClassComboBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ClassComboBox.DataSource = ((System.Collections.Generic.List<string>)(resources.GetObject("ClassComboBox.DataSource")));
            this.ClassComboBox.DisplayItems = 15;
            this.ClassComboBox.DroppedDown = false;
            this.ClassComboBox.Location = new System.Drawing.Point(957, 11);
            this.ClassComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.ClassComboBox.MaskText = "КЛАСС";
            this.ClassComboBox.Name = "ClassComboBox";
            this.ClassComboBox.Size = new System.Drawing.Size(148, 20);
            this.ClassComboBox.TabIndex = 16;
            this.ClassComboBox.TextField = null;
            this.ClassComboBox.ControlSelectedIndexChanged += new System.EventHandler(this.CATcomboBox_SelectedIndexChanged);
            this.ClassComboBox.Enter += new System.EventHandler(this.ClassComboBox_Enter);
            // 
            // toMapBTN
            // 
            this.toMapBTN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.toMapBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.toMapBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toMapBTN.Location = new System.Drawing.Point(957, 96);
            this.toMapBTN.Margin = new System.Windows.Forms.Padding(0);
            this.toMapBTN.Name = "toMapBTN";
            this.toMapBTN.Size = new System.Drawing.Size(148, 23);
            this.toMapBTN.TabIndex = 17;
            this.toMapBTN.Text = "На карту";
            this.toMapBTN.UseVisualStyleBackColor = false;
            this.toMapBTN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toMapBTN_MouseDown);
            this.toMapBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toMapBTN_MouseUp);
            // 
            // ClearFilterBTN
            // 
            this.ClearFilterBTN.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ClearFilterBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClearFilterBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearFilterBTN.Location = new System.Drawing.Point(957, 53);
            this.ClearFilterBTN.Margin = new System.Windows.Forms.Padding(0);
            this.ClearFilterBTN.Name = "ClearFilterBTN";
            this.ClearFilterBTN.Size = new System.Drawing.Size(148, 23);
            this.ClearFilterBTN.TabIndex = 17;
            this.ClearFilterBTN.Text = "Очистить";
            this.ClearFilterBTN.UseVisualStyleBackColor = false;
            this.ClearFilterBTN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ClearFilterBTN_MouseDown);
            this.ClearFilterBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ClearFilterBTN_MouseUp);
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
            this.HideSearchBTN.Size = new System.Drawing.Size(1200, 22);
            this.HideSearchBTN.TabIndex = 7;
            this.HideSearchBTN.TabStop = false;
            this.HideSearchBTN.Text = "Нажмите для настройки фильтра";
            this.HideSearchBTN.UseVisualStyleBackColor = false;
            this.HideSearchBTN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HideSearchBTN_MouseDown);
            this.HideSearchBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HideSearchBTN_MouseUp);
            // 
            // PagePanel
            // 
            this.PagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PagePanel.BackColor = System.Drawing.Color.LightGray;
            this.PagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PagePanel.Controls.Add(this.AllPageTextBox);
            this.PagePanel.Controls.Add(this.PageTextBox);
            this.PagePanel.Controls.Add(this.Back);
            this.PagePanel.Controls.Add(this.Up);
            this.PagePanel.Controls.Add(this.INlabel);
            this.PagePanel.Location = new System.Drawing.Point(0, 91);
            this.PagePanel.Name = "PagePanel";
            this.PagePanel.Size = new System.Drawing.Size(1200, 26);
            this.PagePanel.TabIndex = 6;
            // 
            // AllPageTextBox
            // 
            this.AllPageTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AllPageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AllPageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AllPageTextBox.HidePromptOnLeave = true;
            this.AllPageTextBox.Location = new System.Drawing.Point(612, 3);
            this.AllPageTextBox.Mask = "00000000";
            this.AllPageTextBox.Name = "AllPageTextBox";
            this.AllPageTextBox.PromptChar = ' ';
            this.AllPageTextBox.ReadOnly = true;
            this.AllPageTextBox.Size = new System.Drawing.Size(56, 18);
            this.AllPageTextBox.TabIndex = 6;
            this.AllPageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PageTextBox
            // 
            this.PageTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PageTextBox.HidePromptOnLeave = true;
            this.PageTextBox.Location = new System.Drawing.Point(530, 3);
            this.PageTextBox.Mask = "00000000";
            this.PageTextBox.Name = "PageTextBox";
            this.PageTextBox.PromptChar = ' ';
            this.PageTextBox.Size = new System.Drawing.Size(56, 18);
            this.PageTextBox.TabIndex = 6;
            this.PageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Back
            // 
            this.Back.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Back.BackColor = System.Drawing.Color.LightSlateGray;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back.Location = new System.Drawing.Point(445, 2);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(75, 20);
            this.Back.TabIndex = 2;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Back_MouseDown);
            this.Back.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Back_MouseUp);
            // 
            // Up
            // 
            this.Up.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Up.BackColor = System.Drawing.Color.LightSlateGray;
            this.Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Up.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Up.Location = new System.Drawing.Point(679, 2);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(75, 20);
            this.Up.TabIndex = 1;
            this.Up.Text = "Вперед";
            this.Up.UseVisualStyleBackColor = false;
            this.Up.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Up_MouseDown);
            this.Up.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Up_MouseUp);
            // 
            // INlabel
            // 
            this.INlabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.INlabel.AutoSize = true;
            this.INlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.INlabel.Location = new System.Drawing.Point(592, 2);
            this.INlabel.Name = "INlabel";
            this.INlabel.Size = new System.Drawing.Size(14, 20);
            this.INlabel.TabIndex = 4;
            this.INlabel.Text = "-";
            // 
            // LoadGridView
            // 
            this.LoadGridView.AllowUserToAddRows = false;
            this.LoadGridView.AllowUserToOrderColumns = true;
            this.LoadGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.LoadGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.LoadGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.LoadGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.LoadGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.LoadGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LoadGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.LoadGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LoadGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.LoadGridView.GridColor = System.Drawing.Color.SeaGreen;
            this.LoadGridView.Location = new System.Drawing.Point(0, -4);
            this.LoadGridView.Margin = new System.Windows.Forms.Padding(0);
            this.LoadGridView.Name = "LoadGridView";
            this.LoadGridView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LoadGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.LoadGridView.RowHeadersVisible = false;
            this.LoadGridView.RowHeadersWidth = 40;
            this.LoadGridView.RowTemplate.ReadOnly = true;
            this.LoadGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LoadGridView.Size = new System.Drawing.Size(1200, 96);
            this.LoadGridView.TabIndex = 0;
            this.LoadGridView.TabStop = false;
            this.LoadGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.LoadGridView_CellMouseDoubleClick);
            this.LoadGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.LoadGridView_UserDeletingRow);
            this.LoadGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoadGridView_KeyDown);
            this.LoadGridView.MouseHover += new System.EventHandler(this.LoadGridView_MouseHover);
            // 
            // RouteContainer
            // 
            this.RouteContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RouteContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
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
            this.RouteContainer.Size = new System.Drawing.Size(1200, 323);
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
            this.RouteControl.Size = new System.Drawing.Size(259, 323);
            this.RouteControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.RouteGridView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(251, 297);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Маршруты";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // RouteGridView
            // 
            this.RouteGridView.AllowUserToAddRows = false;
            this.RouteGridView.AllowUserToResizeRows = false;
            this.RouteGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RouteGridView.BackgroundColor = System.Drawing.Color.White;
            this.RouteGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RouteGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RouteGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RouteGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.RouteGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RouteGridView.Location = new System.Drawing.Point(3, 3);
            this.RouteGridView.Margin = new System.Windows.Forms.Padding(0);
            this.RouteGridView.Name = "RouteGridView";
            this.RouteGridView.RowHeadersVisible = false;
            this.RouteGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RouteGridView.Size = new System.Drawing.Size(245, 291);
            this.RouteGridView.TabIndex = 0;
            this.RouteGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RouteGridView_CellDoubleClick);
            this.RouteGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RouteGridView_CellMouseClick);
            this.RouteGridView.SelectionChanged += new System.EventHandler(this.RouteGridView_SelectionChanged);
            this.RouteGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.RouteGridView_UserDeletingRow);
            this.RouteGridView.MouseEnter += new System.EventHandler(this.RouteGridView_MouseEnter);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(251, 297);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Шаблоны";
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
            this.HideRouteBTN.Size = new System.Drawing.Size(22, 323);
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
            this.gMapControl.Size = new System.Drawing.Size(915, 323);
            this.gMapControl.TabIndex = 0;
            this.gMapControl.Zoom = 0D;
            this.gMapControl.Load += new System.EventHandler(this.gMapControl_Load);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.ControlBox = false;
            this.Controls.Add(this.MapPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Map";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Map";
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
            this.SearchTableLayoutPanel.ResumeLayout(false);
            this.PagePanel.ResumeLayout(false);
            this.PagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadGridView)).EndInit();
            this.RouteContainer.Panel1.ResumeLayout(false);
            this.RouteContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RouteContainer)).EndInit();
            this.RouteContainer.ResumeLayout(false);
            this.RouteControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RouteGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel MapPanel;
        private System.Windows.Forms.SplitContainer MapContainer;
        private System.Windows.Forms.SplitContainer SearchContainer;
        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.TableLayoutPanel SearchTableLayoutPanel;
        private UTextBox SICtextBox;
        private UTextBox SACtextBox;
        private System.Windows.Forms.DateTimePicker EndTimePicker;
        private System.Windows.Forms.DateTimePicker BeginTimePicker;
        private UTextBox TargetAddressTextBox;
        private UTextBox AircraftIdetificationTextBox;
        private UTextBox RegistrationTextBox;
        private UTextBox TypeAircraftTextBox;
        private UTextBox Mode3ATextBox;
        private UTextBox AirportDepatureTextBox;
        private UTextBox AirportArrivalTextBox;
        private System.Windows.Forms.Button HideSearchBTN;
        private System.Windows.Forms.DataGridView LoadGridView;
        private System.Windows.Forms.SplitContainer RouteContainer;
        private System.Windows.Forms.TabControl RouteControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button HideRouteBTN;
        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.Timer UpdateTimer;
        private UComboBox EmitterCategoryComboBox;
        private UComboBox CountryComboBox;
        private UComboBox CATcomboBox;
        private UComboBox ClassComboBox;
        private System.Windows.Forms.DataGridView RouteGridView;
        private System.Windows.Forms.Button toMapBTN;
        private System.Windows.Forms.Button ClearFilterBTN;
        private System.Windows.Forms.Panel PagePanel;
        private System.Windows.Forms.MaskedTextBox AllPageTextBox;
        private System.Windows.Forms.MaskedTextBox PageTextBox;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Up;
        private System.Windows.Forms.Label INlabel;
    }
}