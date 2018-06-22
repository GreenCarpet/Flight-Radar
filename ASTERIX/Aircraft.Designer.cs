namespace ASTERIX
{
    partial class Aircraft
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AircraftPanel = new System.Windows.Forms.Panel();
            this.AircraftContainer = new System.Windows.Forms.SplitContainer();
            this.PagePanel = new System.Windows.Forms.Panel();
            this.AllPageTextBox = new System.Windows.Forms.MaskedTextBox();
            this.PageTextBox = new System.Windows.Forms.MaskedTextBox();
            this.Back = new System.Windows.Forms.Button();
            this.Up = new System.Windows.Forms.Button();
            this.INlabel = new System.Windows.Forms.Label();
            this.AircraftGridView = new System.Windows.Forms.DataGridView();
            this.ResetBTN = new System.Windows.Forms.Button();
            this.UpdateBTN = new System.Windows.Forms.Button();
            this.AddPanel = new System.Windows.Forms.Panel();
            this.AddTable = new System.Windows.Forms.TableLayoutPanel();
            this.TargetAddressTextBox = new ASTERIX.UTextBox();
            this.RegistrationTextBox = new ASTERIX.UTextBox();
            this.ICAOTypeCodeTextBox = new ASTERIX.UTextBox();
            this.TypeAircraftTextBox = new ASTERIX.UTextBox();
            this.CountryTextBox = new ASTERIX.UTextBox();
            this.ClassTextBox = new ASTERIX.UTextBox();
            this.UserTextBox = new ASTERIX.UTextBox();
            this.SearchBTN = new System.Windows.Forms.Button();
            this.AddBTN = new System.Windows.Forms.Button();
            this.DeleteBTN = new System.Windows.Forms.Button();
            this.AircraftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AircraftContainer)).BeginInit();
            this.AircraftContainer.Panel1.SuspendLayout();
            this.AircraftContainer.Panel2.SuspendLayout();
            this.AircraftContainer.SuspendLayout();
            this.PagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AircraftGridView)).BeginInit();
            this.AddPanel.SuspendLayout();
            this.AddTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // AircraftPanel
            // 
            this.AircraftPanel.Controls.Add(this.AircraftContainer);
            this.AircraftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AircraftPanel.Location = new System.Drawing.Point(0, 0);
            this.AircraftPanel.Margin = new System.Windows.Forms.Padding(0);
            this.AircraftPanel.Name = "AircraftPanel";
            this.AircraftPanel.Size = new System.Drawing.Size(1200, 600);
            this.AircraftPanel.TabIndex = 1;
            this.AircraftPanel.VisibleChanged += new System.EventHandler(this.AircraftPanel_VisibleChanged);
            // 
            // AircraftContainer
            // 
            this.AircraftContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AircraftContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.AircraftContainer.IsSplitterFixed = true;
            this.AircraftContainer.Location = new System.Drawing.Point(0, 0);
            this.AircraftContainer.Name = "AircraftContainer";
            this.AircraftContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // AircraftContainer.Panel1
            // 
            this.AircraftContainer.Panel1.Controls.Add(this.PagePanel);
            this.AircraftContainer.Panel1.Controls.Add(this.AircraftGridView);
            // 
            // AircraftContainer.Panel2
            // 
            this.AircraftContainer.Panel2.Controls.Add(this.ResetBTN);
            this.AircraftContainer.Panel2.Controls.Add(this.UpdateBTN);
            this.AircraftContainer.Panel2.Controls.Add(this.AddPanel);
            this.AircraftContainer.Panel2.Controls.Add(this.SearchBTN);
            this.AircraftContainer.Panel2.Controls.Add(this.AddBTN);
            this.AircraftContainer.Panel2.Controls.Add(this.DeleteBTN);
            this.AircraftContainer.Size = new System.Drawing.Size(1200, 600);
            this.AircraftContainer.SplitterDistance = 415;
            this.AircraftContainer.TabIndex = 0;
            this.AircraftContainer.TabStop = false;
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
            this.PagePanel.Location = new System.Drawing.Point(212, 380);
            this.PagePanel.Name = "PagePanel";
            this.PagePanel.Size = new System.Drawing.Size(766, 29);
            this.PagePanel.TabIndex = 5;
            // 
            // AllPageTextBox
            // 
            this.AllPageTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AllPageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AllPageTextBox.HidePromptOnLeave = true;
            this.AllPageTextBox.Location = new System.Drawing.Point(395, 4);
            this.AllPageTextBox.Mask = "00000000";
            this.AllPageTextBox.Name = "AllPageTextBox";
            this.AllPageTextBox.PromptChar = ' ';
            this.AllPageTextBox.ReadOnly = true;
            this.AllPageTextBox.Size = new System.Drawing.Size(56, 20);
            this.AllPageTextBox.TabIndex = 6;
            this.AllPageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PageTextBox
            // 
            this.PageTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PageTextBox.HidePromptOnLeave = true;
            this.PageTextBox.Location = new System.Drawing.Point(313, 4);
            this.PageTextBox.Mask = "00000000";
            this.PageTextBox.Name = "PageTextBox";
            this.PageTextBox.PromptChar = ' ';
            this.PageTextBox.Size = new System.Drawing.Size(56, 20);
            this.PageTextBox.TabIndex = 6;
            this.PageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Back
            // 
            this.Back.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Back.BackColor = System.Drawing.Color.LightSlateGray;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Location = new System.Drawing.Point(228, 2);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(75, 23);
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
            this.Up.Location = new System.Drawing.Point(462, 2);
            this.Up.Name = "Up";
            this.Up.Size = new System.Drawing.Size(75, 23);
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
            this.INlabel.Location = new System.Drawing.Point(375, 3);
            this.INlabel.Name = "INlabel";
            this.INlabel.Size = new System.Drawing.Size(14, 20);
            this.INlabel.TabIndex = 4;
            this.INlabel.Text = "-";
            // 
            // AircraftGridView
            // 
            this.AircraftGridView.AllowUserToAddRows = false;
            this.AircraftGridView.AllowUserToDeleteRows = false;
            this.AircraftGridView.AllowUserToOrderColumns = true;
            this.AircraftGridView.AllowUserToResizeRows = false;
            this.AircraftGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AircraftGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AircraftGridView.BackgroundColor = System.Drawing.Color.White;
            this.AircraftGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AircraftGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AircraftGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AircraftGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.AircraftGridView.Location = new System.Drawing.Point(212, 12);
            this.AircraftGridView.MultiSelect = false;
            this.AircraftGridView.Name = "AircraftGridView";
            this.AircraftGridView.ReadOnly = true;
            this.AircraftGridView.RowHeadersVisible = false;
            this.AircraftGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AircraftGridView.Size = new System.Drawing.Size(766, 366);
            this.AircraftGridView.TabIndex = 0;
            this.AircraftGridView.TabStop = false;
            // 
            // ResetBTN
            // 
            this.ResetBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ResetBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.ResetBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResetBTN.Location = new System.Drawing.Point(992, 91);
            this.ResetBTN.Name = "ResetBTN";
            this.ResetBTN.Size = new System.Drawing.Size(61, 44);
            this.ResetBTN.TabIndex = 11;
            this.ResetBTN.Text = "СБРОС";
            this.ResetBTN.UseVisualStyleBackColor = false;
            this.ResetBTN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResetBTN_MouseDown);
            this.ResetBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ResetBTN_MouseUp);
            // 
            // UpdateBTN
            // 
            this.UpdateBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.UpdateBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.UpdateBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateBTN.Location = new System.Drawing.Point(900, 68);
            this.UpdateBTN.Name = "UpdateBTN";
            this.UpdateBTN.Size = new System.Drawing.Size(76, 44);
            this.UpdateBTN.TabIndex = 10;
            this.UpdateBTN.Text = "ИЗМЕНИТЬ";
            this.UpdateBTN.UseVisualStyleBackColor = false;
            this.UpdateBTN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UpdateBTN_MouseDown);
            this.UpdateBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.UpdateBTN_MouseUp);
            // 
            // AddPanel
            // 
            this.AddPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.AddPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddPanel.Controls.Add(this.AddTable);
            this.AddPanel.ForeColor = System.Drawing.Color.Black;
            this.AddPanel.Location = new System.Drawing.Point(224, 13);
            this.AddPanel.Name = "AddPanel";
            this.AddPanel.Size = new System.Drawing.Size(653, 156);
            this.AddPanel.TabIndex = 1;
            // 
            // AddTable
            // 
            this.AddTable.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AddTable.ColumnCount = 3;
            this.AddTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.AddTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.AddTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.AddTable.Controls.Add(this.TargetAddressTextBox, 0, 0);
            this.AddTable.Controls.Add(this.RegistrationTextBox, 1, 0);
            this.AddTable.Controls.Add(this.ICAOTypeCodeTextBox, 0, 1);
            this.AddTable.Controls.Add(this.TypeAircraftTextBox, 1, 1);
            this.AddTable.Controls.Add(this.CountryTextBox, 2, 0);
            this.AddTable.Controls.Add(this.ClassTextBox, 2, 1);
            this.AddTable.Controls.Add(this.UserTextBox, 0, 2);
            this.AddTable.Location = new System.Drawing.Point(18, 0);
            this.AddTable.Name = "AddTable";
            this.AddTable.RowCount = 3;
            this.AddTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.AddTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.AddTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.AddTable.Size = new System.Drawing.Size(632, 154);
            this.AddTable.TabIndex = 0;
            // 
            // TargetAddressTextBox
            // 
            this.TargetAddressTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TargetAddressTextBox.BackColoField = System.Drawing.Color.White;
            this.TargetAddressTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TargetAddressTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.TargetAddressTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.TargetAddressTextBox.Location = new System.Drawing.Point(0, 15);
            this.TargetAddressTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.TargetAddressTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.TargetAddressTextBox.MaskField = "ICAO24";
            this.TargetAddressTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.TargetAddressTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.TargetAddressTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.TargetAddressTextBox.Name = "TargetAddressTextBox";
            this.TargetAddressTextBox.Size = new System.Drawing.Size(196, 20);
            this.TargetAddressTextBox.TabIndex = 0;
            this.TargetAddressTextBox.TextColorField = System.Drawing.Color.Black;
            this.TargetAddressTextBox.TextField = null;
            this.TargetAddressTextBox.ControlTextChanged += new System.EventHandler(this.TargetAddressTextBox_ControlTextChanged);
            // 
            // RegistrationTextBox
            // 
            this.RegistrationTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RegistrationTextBox.BackColoField = System.Drawing.Color.White;
            this.RegistrationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RegistrationTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.RegistrationTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.RegistrationTextBox.Location = new System.Drawing.Point(210, 15);
            this.RegistrationTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.RegistrationTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.RegistrationTextBox.MaskField = "БОРТОВОЙ";
            this.RegistrationTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.RegistrationTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.RegistrationTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.RegistrationTextBox.Name = "RegistrationTextBox";
            this.RegistrationTextBox.Size = new System.Drawing.Size(196, 20);
            this.RegistrationTextBox.TabIndex = 2;
            this.RegistrationTextBox.TextColorField = System.Drawing.Color.Black;
            this.RegistrationTextBox.TextField = null;
            this.RegistrationTextBox.ControlTextChanged += new System.EventHandler(this.RegistrationTextBox_ControlTextChanged);
            // 
            // ICAOTypeCodeTextBox
            // 
            this.ICAOTypeCodeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ICAOTypeCodeTextBox.BackColoField = System.Drawing.Color.White;
            this.ICAOTypeCodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ICAOTypeCodeTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.ICAOTypeCodeTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.ICAOTypeCodeTextBox.Location = new System.Drawing.Point(0, 66);
            this.ICAOTypeCodeTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.ICAOTypeCodeTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.ICAOTypeCodeTextBox.MaskField = "ICAOTYPE";
            this.ICAOTypeCodeTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.ICAOTypeCodeTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.ICAOTypeCodeTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.ICAOTypeCodeTextBox.Name = "ICAOTypeCodeTextBox";
            this.ICAOTypeCodeTextBox.Size = new System.Drawing.Size(196, 20);
            this.ICAOTypeCodeTextBox.TabIndex = 1;
            this.ICAOTypeCodeTextBox.TextColorField = System.Drawing.Color.Black;
            this.ICAOTypeCodeTextBox.TextField = null;
            this.ICAOTypeCodeTextBox.ControlTextChanged += new System.EventHandler(this.ICAOTypeCodeTextBox_ControlTextChanged);
            // 
            // TypeAircraftTextBox
            // 
            this.TypeAircraftTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TypeAircraftTextBox.BackColoField = System.Drawing.Color.White;
            this.TypeAircraftTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TypeAircraftTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.TypeAircraftTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.TypeAircraftTextBox.Location = new System.Drawing.Point(210, 66);
            this.TypeAircraftTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.TypeAircraftTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.TypeAircraftTextBox.MaskField = "ТИП";
            this.TypeAircraftTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.TypeAircraftTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.TypeAircraftTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.TypeAircraftTextBox.Name = "TypeAircraftTextBox";
            this.TypeAircraftTextBox.Size = new System.Drawing.Size(196, 20);
            this.TypeAircraftTextBox.TabIndex = 3;
            this.TypeAircraftTextBox.TextColorField = System.Drawing.Color.Black;
            this.TypeAircraftTextBox.TextField = null;
            this.TypeAircraftTextBox.ControlTextChanged += new System.EventHandler(this.TypeAircraftTextBox_ControlTextChanged);
            // 
            // CountryTextBox
            // 
            this.CountryTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CountryTextBox.BackColoField = System.Drawing.Color.White;
            this.CountryTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CountryTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.CountryTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.CountryTextBox.Location = new System.Drawing.Point(420, 15);
            this.CountryTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.CountryTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.CountryTextBox.MaskField = "ГОСУДАРСТВО";
            this.CountryTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.CountryTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.CountryTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.CountryTextBox.Name = "CountryTextBox";
            this.CountryTextBox.Size = new System.Drawing.Size(196, 20);
            this.CountryTextBox.TabIndex = 4;
            this.CountryTextBox.TextColorField = System.Drawing.Color.Black;
            this.CountryTextBox.TextField = null;
            this.CountryTextBox.ControlTextChanged += new System.EventHandler(this.CountryTextBox_ControlTextChanged);
            // 
            // ClassTextBox
            // 
            this.ClassTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ClassTextBox.BackColoField = System.Drawing.Color.White;
            this.ClassTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ClassTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.ClassTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.ClassTextBox.Location = new System.Drawing.Point(420, 66);
            this.ClassTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.ClassTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.ClassTextBox.MaskField = "КЛАСС";
            this.ClassTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.ClassTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.ClassTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.ClassTextBox.Name = "ClassTextBox";
            this.ClassTextBox.Size = new System.Drawing.Size(196, 20);
            this.ClassTextBox.TabIndex = 5;
            this.ClassTextBox.TextColorField = System.Drawing.Color.Black;
            this.ClassTextBox.TextField = null;
            this.ClassTextBox.ControlTextChanged += new System.EventHandler(this.ClassTextBox_ControlTextChanged);
            // 
            // UserTextBox
            // 
            this.UserTextBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.UserTextBox.BackColoField = System.Drawing.Color.White;
            this.UserTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.UserTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.AddTable.SetColumnSpan(this.UserTextBox, 3);
            this.UserTextBox.Location = new System.Drawing.Point(0, 118);
            this.UserTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.UserTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.UserTextBox.MaskField = "ПРИМЕЧАНИЕ";
            this.UserTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.UserTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.UserTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.UserTextBox.Name = "UserTextBox";
            this.UserTextBox.Size = new System.Drawing.Size(616, 20);
            this.UserTextBox.TabIndex = 6;
            this.UserTextBox.TextColorField = System.Drawing.Color.Black;
            this.UserTextBox.TextField = null;
            this.UserTextBox.ControlTextChanged += new System.EventHandler(this.UserTextBox_ControlTextChanged);
            // 
            // SearchBTN
            // 
            this.SearchBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.SearchBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.SearchBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SearchBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchBTN.Location = new System.Drawing.Point(992, 40);
            this.SearchBTN.Name = "SearchBTN";
            this.SearchBTN.Size = new System.Drawing.Size(61, 44);
            this.SearchBTN.TabIndex = 7;
            this.SearchBTN.TabStop = false;
            this.SearchBTN.Text = "ПОИСК";
            this.SearchBTN.UseVisualStyleBackColor = false;
            this.SearchBTN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SearchBTN_MouseDown);
            this.SearchBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SearchBTN_MouseUp);
            // 
            // AddBTN
            // 
            this.AddBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.AddBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.AddBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBTN.Location = new System.Drawing.Point(900, 17);
            this.AddBTN.Name = "AddBTN";
            this.AddBTN.Size = new System.Drawing.Size(76, 44);
            this.AddBTN.TabIndex = 8;
            this.AddBTN.TabStop = false;
            this.AddBTN.Text = "ДОБАВИТЬ";
            this.AddBTN.UseVisualStyleBackColor = false;
            this.AddBTN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddBTN_MouseDown);
            this.AddBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AddBTN_MouseUp);
            // 
            // DeleteBTN
            // 
            this.DeleteBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.DeleteBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.DeleteBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteBTN.Location = new System.Drawing.Point(900, 119);
            this.DeleteBTN.Name = "DeleteBTN";
            this.DeleteBTN.Size = new System.Drawing.Size(76, 45);
            this.DeleteBTN.TabIndex = 9;
            this.DeleteBTN.TabStop = false;
            this.DeleteBTN.Text = "УДАЛИТЬ";
            this.DeleteBTN.UseVisualStyleBackColor = false;
            this.DeleteBTN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DeleteBTN_MouseDown);
            this.DeleteBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DeleteBTN_MouseUp);
            // 
            // Aircraft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.AircraftPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Aircraft";
            this.Text = "Aircraft";
            this.AircraftPanel.ResumeLayout(false);
            this.AircraftContainer.Panel1.ResumeLayout(false);
            this.AircraftContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AircraftContainer)).EndInit();
            this.AircraftContainer.ResumeLayout(false);
            this.PagePanel.ResumeLayout(false);
            this.PagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AircraftGridView)).EndInit();
            this.AddPanel.ResumeLayout(false);
            this.AddTable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel AircraftPanel;
        private System.Windows.Forms.SplitContainer AircraftContainer;
        private System.Windows.Forms.DataGridView AircraftGridView;
        private System.Windows.Forms.TableLayoutPanel AddTable;
        private UTextBox TargetAddressTextBox;
        private UTextBox RegistrationTextBox;
        private UTextBox ICAOTypeCodeTextBox;
        private UTextBox TypeAircraftTextBox;
        private UTextBox UserTextBox;
        private System.Windows.Forms.Button SearchBTN;
        private System.Windows.Forms.Button AddBTN;
        private System.Windows.Forms.Button DeleteBTN;
        private System.Windows.Forms.Panel AddPanel;
        private UTextBox CountryTextBox;
        private UTextBox ClassTextBox;
        private System.Windows.Forms.Button UpdateBTN;
        private System.Windows.Forms.Button ResetBTN;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Up;
        private System.Windows.Forms.Label INlabel;
        private System.Windows.Forms.Panel PagePanel;
        private System.Windows.Forms.MaskedTextBox PageTextBox;
        private System.Windows.Forms.MaskedTextBox AllPageTextBox;
    }
}