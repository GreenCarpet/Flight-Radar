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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.LoadGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.EndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.BeginTimePicker = new System.Windows.Forms.DateTimePicker();
            this.AirportArrivalTextBox = new System.Windows.Forms.TextBox();
            this.AirportDepatureTextBox = new System.Windows.Forms.TextBox();
            this.EmitterCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.TargetAddressTextBox = new System.Windows.Forms.TextBox();
            this.AircraftIdetificationTextBox = new System.Windows.Forms.TextBox();
            this.StartStopBTN = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LoadGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StartStopBTN)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadGridView1
            // 
            this.LoadGridView1.AllowUserToAddRows = false;
            this.LoadGridView1.AllowUserToResizeColumns = false;
            this.LoadGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.LoadGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.LoadGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.LoadGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.LoadGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoadGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LoadGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.LoadGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSeaGreen;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.LoadGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.LoadGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadGridView1.GridColor = System.Drawing.Color.SeaGreen;
            this.LoadGridView1.Location = new System.Drawing.Point(0, 0);
            this.LoadGridView1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.LoadGridView1.Name = "LoadGridView1";
            this.LoadGridView1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LoadGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.LoadGridView1.RowHeadersWidth = 40;
            this.LoadGridView1.RowTemplate.Height = 25;
            this.LoadGridView1.RowTemplate.ReadOnly = true;
            this.LoadGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LoadGridView1.Size = new System.Drawing.Size(1214, 721);
            this.LoadGridView1.TabIndex = 0;
            this.LoadGridView1.TabStop = false;
            this.LoadGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.LoadGridView1_CellMouseDoubleClick);
            this.LoadGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.LoadGridView1_UserDeletingRow);
            this.LoadGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LoadGridView1_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel1.Controls.Add(this.EndTimePicker);
            this.splitContainer1.Panel1.Controls.Add(this.BeginTimePicker);
            this.splitContainer1.Panel1.Controls.Add(this.AirportArrivalTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.AirportDepatureTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.EmitterCategoryComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.TargetAddressTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.AircraftIdetificationTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.StartStopBTN);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LoadGridView1);
            this.splitContainer1.Panel2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitContainer1.Size = new System.Drawing.Size(1214, 762);
            this.splitContainer1.SplitterDistance = 37;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(934, 14);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(260, 20);
            this.progressBar1.TabIndex = 1;
            // 
            // EndTimePicker
            // 
            this.EndTimePicker.Checked = false;
            this.EndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndTimePicker.Location = new System.Drawing.Point(804, 14);
            this.EndTimePicker.Name = "EndTimePicker";
            this.EndTimePicker.ShowCheckBox = true;
            this.EndTimePicker.Size = new System.Drawing.Size(120, 20);
            this.EndTimePicker.TabIndex = 6;
            this.EndTimePicker.ValueChanged += new System.EventHandler(this.EndTimePicker_ValueChanged);
            this.EndTimePicker.DropDown += new System.EventHandler(this.EndTimePicker_DropDown);
            this.EndTimePicker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EndTimePicker_MouseDown);
            // 
            // BeginTimePicker
            // 
            this.BeginTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.BeginTimePicker.Location = new System.Drawing.Point(674, 14);
            this.BeginTimePicker.Name = "BeginTimePicker";
            this.BeginTimePicker.ShowCheckBox = true;
            this.BeginTimePicker.Size = new System.Drawing.Size(120, 20);
            this.BeginTimePicker.TabIndex = 5;
            this.BeginTimePicker.ValueChanged += new System.EventHandler(this.BeginTimePicker_ValueChanged);
            this.BeginTimePicker.DropDown += new System.EventHandler(this.BeginTimePicker_DropDown);
            this.BeginTimePicker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BeginTimePicker_MouseDown);
            // 
            // AirportArrivalTextBox
            // 
            this.AirportArrivalTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.AirportArrivalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AirportArrivalTextBox.Location = new System.Drawing.Point(544, 14);
            this.AirportArrivalTextBox.Name = "AirportArrivalTextBox";
            this.AirportArrivalTextBox.Size = new System.Drawing.Size(120, 20);
            this.AirportArrivalTextBox.TabIndex = 4;
            this.AirportArrivalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AirportArrivalTextBox.TextChanged += new System.EventHandler(this.AirportArrivalTextBox_TextChanged);
            // 
            // AirportDepatureTextBox
            // 
            this.AirportDepatureTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.AirportDepatureTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AirportDepatureTextBox.Location = new System.Drawing.Point(414, 14);
            this.AirportDepatureTextBox.Name = "AirportDepatureTextBox";
            this.AirportDepatureTextBox.Size = new System.Drawing.Size(120, 20);
            this.AirportDepatureTextBox.TabIndex = 3;
            this.AirportDepatureTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AirportDepatureTextBox.TextChanged += new System.EventHandler(this.AirportDepatureTextBox_TextChanged);
            // 
            // EmitterCategoryComboBox
            // 
            this.EmitterCategoryComboBox.FormattingEnabled = true;
            this.EmitterCategoryComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EmitterCategoryComboBox.Location = new System.Drawing.Point(264, 14);
            this.EmitterCategoryComboBox.MaxDropDownItems = 50;
            this.EmitterCategoryComboBox.Name = "EmitterCategoryComboBox";
            this.EmitterCategoryComboBox.Size = new System.Drawing.Size(140, 21);
            this.EmitterCategoryComboBox.TabIndex = 2;
            this.EmitterCategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.EmitterCategoryComboBox_SelectedIndexChanged);
            this.EmitterCategoryComboBox.Click += new System.EventHandler(this.EmitterCategoryComboBox_Click);
            // 
            // TargetAddressTextBox
            // 
            this.TargetAddressTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TargetAddressTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TargetAddressTextBox.Location = new System.Drawing.Point(45, 14);
            this.TargetAddressTextBox.Name = "TargetAddressTextBox";
            this.TargetAddressTextBox.Size = new System.Drawing.Size(80, 20);
            this.TargetAddressTextBox.TabIndex = 1;
            this.TargetAddressTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TargetAddressTextBox.TextChanged += new System.EventHandler(this.TargetAddressTextBox_TextChanged);
            // 
            // AircraftIdetificationTextBox
            // 
            this.AircraftIdetificationTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.AircraftIdetificationTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.AircraftIdetificationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AircraftIdetificationTextBox.Location = new System.Drawing.Point(134, 14);
            this.AircraftIdetificationTextBox.Name = "AircraftIdetificationTextBox";
            this.AircraftIdetificationTextBox.Size = new System.Drawing.Size(120, 20);
            this.AircraftIdetificationTextBox.TabIndex = 0;
            this.AircraftIdetificationTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AircraftIdetificationTextBox.TextChanged += new System.EventHandler(this.AircraftIdetificationTextBox_TextChanged);
            // 
            // StartStopBTN
            // 
            this.StartStopBTN.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StartStopBTN.BackgroundImage")));
            this.StartStopBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StartStopBTN.Location = new System.Drawing.Point(-2, -4);
            this.StartStopBTN.Name = "StartStopBTN";
            this.StartStopBTN.Size = new System.Drawing.Size(53, 53);
            this.StartStopBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StartStopBTN.TabIndex = 8;
            this.StartStopBTN.TabStop = false;
            this.StartStopBTN.Click += new System.EventHandler(this.StartStopBTN_Click);
            this.StartStopBTN.MouseEnter += new System.EventHandler(this.StartStopBTN_MouseEnter);
            this.StartStopBTN.MouseLeave += new System.EventHandler(this.StartStopBTN_MouseLeave);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(504, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1214, 762);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1230, 800);
            this.Name = "GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flight Radar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.LoadGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StartStopBTN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView LoadGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox AircraftIdetificationTextBox;
        private System.Windows.Forms.TextBox TargetAddressTextBox;
        private System.Windows.Forms.ComboBox EmitterCategoryComboBox;
        private System.Windows.Forms.TextBox AirportDepatureTextBox;
        private System.Windows.Forms.TextBox AirportArrivalTextBox;
        private System.Windows.Forms.DateTimePicker BeginTimePicker;
        private System.Windows.Forms.DateTimePicker EndTimePicker;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox StartStopBTN;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.Button button1;
    }
}

