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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Map));
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
            this.HideSearchBTN = new System.Windows.Forms.Button();
            this.LoadGridView = new System.Windows.Forms.DataGridView();
            this.RouteContainer = new System.Windows.Forms.SplitContainer();
            this.RouteControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.HideRouteBTN = new System.Windows.Forms.Button();
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.EmitterCategoryComboBox = new ASTERIX.UComboBox();
            this.CountryComboBox = new ASTERIX.UComboBox();
            this.CATcomboBox = new ASTERIX.UComboBox();
            this.ClassComboBox = new ASTERIX.UComboBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.LoadGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RouteContainer)).BeginInit();
            this.RouteContainer.Panel1.SuspendLayout();
            this.RouteContainer.Panel2.SuspendLayout();
            this.RouteContainer.SuspendLayout();
            this.RouteControl.SuspendLayout();
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
            this.MapContainer.SplitterDistance = 236;
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
            this.SearchContainer.Panel2.Controls.Add(this.LoadGridView);
            this.SearchContainer.Size = new System.Drawing.Size(1200, 236);
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
            this.SearchTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
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
            // LoadGridView
            // 
            this.LoadGridView.AllowUserToAddRows = false;
            this.LoadGridView.AllowUserToResizeColumns = false;
            this.LoadGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.LoadGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.LoadGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.LoadGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.LoadGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoadGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LoadGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.LoadGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LoadGridView.DefaultCellStyle = dataGridViewCellStyle15;
            this.LoadGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadGridView.GridColor = System.Drawing.Color.SeaGreen;
            this.LoadGridView.Location = new System.Drawing.Point(0, 0);
            this.LoadGridView.Margin = new System.Windows.Forms.Padding(0);
            this.LoadGridView.Name = "LoadGridView";
            this.LoadGridView.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LoadGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.LoadGridView.RowHeadersWidth = 40;
            this.LoadGridView.RowTemplate.Height = 25;
            this.LoadGridView.RowTemplate.ReadOnly = true;
            this.LoadGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LoadGridView.Size = new System.Drawing.Size(1200, 81);
            this.LoadGridView.TabIndex = 0;
            this.LoadGridView.TabStop = false;
            this.LoadGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.LoadGridView_CellMouseDoubleClick);
            this.LoadGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.LoadGridView_UserDeletingRow);
            this.LoadGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoadGridView_KeyDown);
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
            this.RouteContainer.Size = new System.Drawing.Size(1200, 360);
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
            this.RouteControl.Size = new System.Drawing.Size(259, 360);
            this.RouteControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(251, 334);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Маршруты";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(251, 334);
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
            this.HideRouteBTN.Size = new System.Drawing.Size(22, 360);
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
            this.gMapControl.Size = new System.Drawing.Size(915, 360);
            this.gMapControl.TabIndex = 0;
            this.gMapControl.Zoom = 0D;
            this.gMapControl.Load += new System.EventHandler(this.gMapControl_Load);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
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
            ((System.ComponentModel.ISupportInitialize)(this.LoadGridView)).EndInit();
            this.RouteContainer.Panel1.ResumeLayout(false);
            this.RouteContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RouteContainer)).EndInit();
            this.RouteContainer.ResumeLayout(false);
            this.RouteControl.ResumeLayout(false);
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
    }
}