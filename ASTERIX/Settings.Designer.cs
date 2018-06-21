namespace ASTERIX
{
    partial class Settings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.BackBTN = new System.Windows.Forms.Button();
            this.ColorSelectedComboBox = new System.Windows.Forms.ComboBox();
            this.SaveBTN = new System.Windows.Forms.Button();
            this.ColorNewRouteComboBox = new System.Windows.Forms.ComboBox();
            this.ColorSelectedLBL = new System.Windows.Forms.Label();
            this.ColorNewRouteLBL = new System.Windows.Forms.Label();
            this.AircraftOfPageLBL = new System.Windows.Forms.Label();
            this.AircraftOfPageTextBox = new System.Windows.Forms.MaskedTextBox();
            this.RoutOfPageLBL = new System.Windows.Forms.Label();
            this.SecondLBL = new System.Windows.Forms.Label();
            this.RoutOfPageTextBox = new System.Windows.Forms.MaskedTextBox();
            this.UpdateTextBox = new System.Windows.Forms.MaskedTextBox();
            this.UpdageLBL = new System.Windows.Forms.Label();
            this.PasswordTextBox = new ASTERIX.UTextBox();
            this.PasswordLBL = new System.Windows.Forms.Label();
            this.NameTextBox = new ASTERIX.UTextBox();
            this.NameLBL = new System.Windows.Forms.Label();
            this.ServerNameTextBox = new ASTERIX.UTextBox();
            this.ServerNameLBL = new System.Windows.Forms.Label();
            this.DeleteModuleBTN = new System.Windows.Forms.Button();
            this.AddModuleBTN = new System.Windows.Forms.Button();
            this.ModulesGridView = new System.Windows.Forms.DataGridView();
            this.ImportModuleDialog = new System.Windows.Forms.OpenFileDialog();
            this.SettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModulesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.BackColor = System.Drawing.Color.DarkGray;
            this.SettingsPanel.Controls.Add(this.splitContainer1);
            this.SettingsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.SettingsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(1200, 600);
            this.SettingsPanel.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.BackBTN);
            this.splitContainer1.Panel1.Controls.Add(this.ColorSelectedComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.SaveBTN);
            this.splitContainer1.Panel1.Controls.Add(this.ColorNewRouteComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.ColorSelectedLBL);
            this.splitContainer1.Panel1.Controls.Add(this.ColorNewRouteLBL);
            this.splitContainer1.Panel1.Controls.Add(this.AircraftOfPageLBL);
            this.splitContainer1.Panel1.Controls.Add(this.AircraftOfPageTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.RoutOfPageLBL);
            this.splitContainer1.Panel1.Controls.Add(this.SecondLBL);
            this.splitContainer1.Panel1.Controls.Add(this.RoutOfPageTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.UpdateTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.UpdageLBL);
            this.splitContainer1.Panel1.Controls.Add(this.PasswordTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.PasswordLBL);
            this.splitContainer1.Panel1.Controls.Add(this.NameTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.NameLBL);
            this.splitContainer1.Panel1.Controls.Add(this.ServerNameTextBox);
            this.splitContainer1.Panel1.Controls.Add(this.ServerNameLBL);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.DeleteModuleBTN);
            this.splitContainer1.Panel2.Controls.Add(this.AddModuleBTN);
            this.splitContainer1.Panel2.Controls.Add(this.ModulesGridView);
            this.splitContainer1.Size = new System.Drawing.Size(1200, 600);
            this.splitContainer1.SplitterDistance = 600;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // BackBTN
            // 
            this.BackBTN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BackBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.BackBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BackBTN.Location = new System.Drawing.Point(348, 513);
            this.BackBTN.Name = "BackBTN";
            this.BackBTN.Size = new System.Drawing.Size(126, 44);
            this.BackBTN.TabIndex = 10;
            this.BackBTN.TabStop = false;
            this.BackBTN.Text = "ОТМЕНИТЬ";
            this.BackBTN.UseVisualStyleBackColor = false;
            // 
            // ColorSelectedComboBox
            // 
            this.ColorSelectedComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ColorSelectedComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColorSelectedComboBox.FormattingEnabled = true;
            this.ColorSelectedComboBox.Location = new System.Drawing.Point(293, 296);
            this.ColorSelectedComboBox.Name = "ColorSelectedComboBox";
            this.ColorSelectedComboBox.Size = new System.Drawing.Size(47, 21);
            this.ColorSelectedComboBox.TabIndex = 13;
            this.ColorSelectedComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ColorSelectedComboBox_DrawItem);
            this.ColorSelectedComboBox.SelectedIndexChanged += new System.EventHandler(this.ColorSelectedComboBox_SelectedIndexChanged);
            // 
            // SaveBTN
            // 
            this.SaveBTN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SaveBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.SaveBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveBTN.Location = new System.Drawing.Point(146, 513);
            this.SaveBTN.Name = "SaveBTN";
            this.SaveBTN.Size = new System.Drawing.Size(126, 44);
            this.SaveBTN.TabIndex = 9;
            this.SaveBTN.TabStop = false;
            this.SaveBTN.Text = "СОХРАНИТЬ";
            this.SaveBTN.UseVisualStyleBackColor = false;
            // 
            // ColorNewRouteComboBox
            // 
            this.ColorNewRouteComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ColorNewRouteComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColorNewRouteComboBox.FormattingEnabled = true;
            this.ColorNewRouteComboBox.Location = new System.Drawing.Point(293, 257);
            this.ColorNewRouteComboBox.Name = "ColorNewRouteComboBox";
            this.ColorNewRouteComboBox.Size = new System.Drawing.Size(47, 21);
            this.ColorNewRouteComboBox.TabIndex = 13;
            this.ColorNewRouteComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ColorNewRouteComboBox_DrawItem);
            this.ColorNewRouteComboBox.SelectedIndexChanged += new System.EventHandler(this.ColorNewRouteComboBox_SelectedIndexChanged);
            // 
            // ColorSelectedLBL
            // 
            this.ColorSelectedLBL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ColorSelectedLBL.AutoSize = true;
            this.ColorSelectedLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ColorSelectedLBL.Location = new System.Drawing.Point(78, 297);
            this.ColorSelectedLBL.Name = "ColorSelectedLBL";
            this.ColorSelectedLBL.Size = new System.Drawing.Size(198, 16);
            this.ColorSelectedLBL.TabIndex = 12;
            this.ColorSelectedLBL.Text = "Цвет выделенного маршрута";
            // 
            // ColorNewRouteLBL
            // 
            this.ColorNewRouteLBL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ColorNewRouteLBL.AutoSize = true;
            this.ColorNewRouteLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ColorNewRouteLBL.Location = new System.Drawing.Point(78, 258);
            this.ColorNewRouteLBL.Name = "ColorNewRouteLBL";
            this.ColorNewRouteLBL.Size = new System.Drawing.Size(157, 16);
            this.ColorNewRouteLBL.TabIndex = 12;
            this.ColorNewRouteLBL.Text = "Цвет нового маршрута";
            // 
            // AircraftOfPageLBL
            // 
            this.AircraftOfPageLBL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AircraftOfPageLBL.AutoSize = true;
            this.AircraftOfPageLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AircraftOfPageLBL.Location = new System.Drawing.Point(78, 204);
            this.AircraftOfPageLBL.Name = "AircraftOfPageLBL";
            this.AircraftOfPageLBL.Size = new System.Drawing.Size(197, 16);
            this.AircraftOfPageLBL.TabIndex = 11;
            this.AircraftOfPageLBL.Text = "Число привязок на странице";
            // 
            // AircraftOfPageTextBox
            // 
            this.AircraftOfPageTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AircraftOfPageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AircraftOfPageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AircraftOfPageTextBox.Location = new System.Drawing.Point(293, 204);
            this.AircraftOfPageTextBox.Mask = "0000";
            this.AircraftOfPageTextBox.Name = "AircraftOfPageTextBox";
            this.AircraftOfPageTextBox.PromptChar = ' ';
            this.AircraftOfPageTextBox.Size = new System.Drawing.Size(47, 20);
            this.AircraftOfPageTextBox.TabIndex = 10;
            this.AircraftOfPageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AircraftOfPageTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AircraftOfPageTextBox_MouseDown);
            // 
            // RoutOfPageLBL
            // 
            this.RoutOfPageLBL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RoutOfPageLBL.AutoSize = true;
            this.RoutOfPageLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RoutOfPageLBL.Location = new System.Drawing.Point(78, 167);
            this.RoutOfPageLBL.Name = "RoutOfPageLBL";
            this.RoutOfPageLBL.Size = new System.Drawing.Size(208, 16);
            this.RoutOfPageLBL.TabIndex = 9;
            this.RoutOfPageLBL.Text = "Число маршрутов на странице";
            // 
            // SecondLBL
            // 
            this.SecondLBL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SecondLBL.AutoSize = true;
            this.SecondLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SecondLBL.Location = new System.Drawing.Point(356, 119);
            this.SecondLBL.Name = "SecondLBL";
            this.SecondLBL.Size = new System.Drawing.Size(30, 16);
            this.SecondLBL.TabIndex = 8;
            this.SecondLBL.Text = "сек";
            // 
            // RoutOfPageTextBox
            // 
            this.RoutOfPageTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RoutOfPageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RoutOfPageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RoutOfPageTextBox.Location = new System.Drawing.Point(293, 167);
            this.RoutOfPageTextBox.Mask = "0000";
            this.RoutOfPageTextBox.Name = "RoutOfPageTextBox";
            this.RoutOfPageTextBox.PromptChar = ' ';
            this.RoutOfPageTextBox.Size = new System.Drawing.Size(47, 20);
            this.RoutOfPageTextBox.TabIndex = 7;
            this.RoutOfPageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RoutOfPageTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RoutOfPageTextBox_MouseDown);
            // 
            // UpdateTextBox
            // 
            this.UpdateTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UpdateTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UpdateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdateTextBox.Location = new System.Drawing.Point(293, 119);
            this.UpdateTextBox.Mask = "0000";
            this.UpdateTextBox.Name = "UpdateTextBox";
            this.UpdateTextBox.PromptChar = ' ';
            this.UpdateTextBox.Size = new System.Drawing.Size(47, 20);
            this.UpdateTextBox.TabIndex = 7;
            this.UpdateTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UpdateTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UpdateTextBox_MouseDown);
            // 
            // UpdageLBL
            // 
            this.UpdageLBL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UpdageLBL.AutoSize = true;
            this.UpdageLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UpdageLBL.Location = new System.Drawing.Point(78, 119);
            this.UpdageLBL.Name = "UpdageLBL";
            this.UpdageLBL.Size = new System.Drawing.Size(194, 16);
            this.UpdageLBL.TabIndex = 6;
            this.UpdageLBL.Text = "Частота обновления данных";
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PasswordTextBox.BackColoField = System.Drawing.Color.White;
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Normal;
            this.PasswordTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.PasswordTextBox.Location = new System.Drawing.Point(402, 70);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.PasswordTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.PasswordTextBox.MaskField = null;
            this.PasswordTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.PasswordTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.PasswordTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(117, 20);
            this.PasswordTextBox.TabIndex = 5;
            this.PasswordTextBox.TextColorField = System.Drawing.Color.Black;
            this.PasswordTextBox.TextField = null;
            // 
            // PasswordLBL
            // 
            this.PasswordLBL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PasswordLBL.AutoSize = true;
            this.PasswordLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordLBL.Location = new System.Drawing.Point(329, 70);
            this.PasswordLBL.Name = "PasswordLBL";
            this.PasswordLBL.Size = new System.Drawing.Size(57, 16);
            this.PasswordLBL.TabIndex = 4;
            this.PasswordLBL.Text = "Пароль";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NameTextBox.BackColoField = System.Drawing.Color.White;
            this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Normal;
            this.NameTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.NameTextBox.Location = new System.Drawing.Point(191, 70);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.NameTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.NameTextBox.MaskField = null;
            this.NameTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.NameTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.NameTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(117, 20);
            this.NameTextBox.TabIndex = 3;
            this.NameTextBox.TextColorField = System.Drawing.Color.Black;
            this.NameTextBox.TextField = null;
            // 
            // NameLBL
            // 
            this.NameLBL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.NameLBL.AutoSize = true;
            this.NameLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLBL.Location = new System.Drawing.Point(95, 70);
            this.NameLBL.Name = "NameLBL";
            this.NameLBL.Size = new System.Drawing.Size(75, 16);
            this.NameLBL.TabIndex = 2;
            this.NameLBL.Text = "Имя входа";
            // 
            // ServerNameTextBox
            // 
            this.ServerNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ServerNameTextBox.BackColoField = System.Drawing.Color.White;
            this.ServerNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServerNameTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Normal;
            this.ServerNameTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.ServerNameTextBox.Location = new System.Drawing.Point(191, 34);
            this.ServerNameTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.ServerNameTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.ServerNameTextBox.MaskField = "НАПРИМЕР: SERVER-OTO\\SQLEXPRESS";
            this.ServerNameTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.ServerNameTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.ServerNameTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.ServerNameTextBox.Name = "ServerNameTextBox";
            this.ServerNameTextBox.Size = new System.Drawing.Size(328, 20);
            this.ServerNameTextBox.TabIndex = 1;
            this.ServerNameTextBox.TextColorField = System.Drawing.Color.Black;
            this.ServerNameTextBox.TextField = null;
            // 
            // ServerNameLBL
            // 
            this.ServerNameLBL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ServerNameLBL.AutoSize = true;
            this.ServerNameLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ServerNameLBL.Location = new System.Drawing.Point(78, 34);
            this.ServerNameLBL.Name = "ServerNameLBL";
            this.ServerNameLBL.Size = new System.Drawing.Size(92, 16);
            this.ServerNameLBL.TabIndex = 0;
            this.ServerNameLBL.Text = "Имя сервера";
            // 
            // DeleteModuleBTN
            // 
            this.DeleteModuleBTN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DeleteModuleBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.DeleteModuleBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteModuleBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteModuleBTN.Location = new System.Drawing.Point(362, 513);
            this.DeleteModuleBTN.Name = "DeleteModuleBTN";
            this.DeleteModuleBTN.Size = new System.Drawing.Size(126, 44);
            this.DeleteModuleBTN.TabIndex = 10;
            this.DeleteModuleBTN.TabStop = false;
            this.DeleteModuleBTN.Text = "УДАЛИТЬ";
            this.DeleteModuleBTN.UseVisualStyleBackColor = false;
            this.DeleteModuleBTN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DeleteModuleBTN_MouseDown);
            this.DeleteModuleBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DeleteModuleBTN_MouseUp);
            // 
            // AddModuleBTN
            // 
            this.AddModuleBTN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AddModuleBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.AddModuleBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddModuleBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddModuleBTN.Location = new System.Drawing.Point(160, 513);
            this.AddModuleBTN.Name = "AddModuleBTN";
            this.AddModuleBTN.Size = new System.Drawing.Size(126, 44);
            this.AddModuleBTN.TabIndex = 9;
            this.AddModuleBTN.TabStop = false;
            this.AddModuleBTN.Text = "ДОБАВИТЬ";
            this.AddModuleBTN.UseVisualStyleBackColor = false;
            this.AddModuleBTN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddModuleBTN_MouseDown);
            this.AddModuleBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AddModuleBTN_MouseUp);
            // 
            // ModulesGridView
            // 
            this.ModulesGridView.AllowUserToAddRows = false;
            this.ModulesGridView.AllowUserToResizeColumns = false;
            this.ModulesGridView.AllowUserToResizeRows = false;
            this.ModulesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ModulesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ModulesGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ModulesGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ModulesGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ModulesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.ModulesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ModulesGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.ModulesGridView.Location = new System.Drawing.Point(82, 34);
            this.ModulesGridView.MultiSelect = false;
            this.ModulesGridView.Name = "ModulesGridView";
            this.ModulesGridView.ReadOnly = true;
            this.ModulesGridView.RowHeadersVisible = false;
            this.ModulesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ModulesGridView.Size = new System.Drawing.Size(479, 453);
            this.ModulesGridView.TabIndex = 1;
            this.ModulesGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ModulesGridView_CellMouseDoubleClick);
            this.ModulesGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.ModulesGridView_UserDeletedRow);
            this.ModulesGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.ModulesGridView_UserDeletingRow);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.SettingsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
            this.Text = "Settings";
            this.SettingsPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModulesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel SettingsPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.OpenFileDialog ImportModuleDialog;
        private System.Windows.Forms.DataGridView ModulesGridView;
        private System.Windows.Forms.Button DeleteModuleBTN;
        private System.Windows.Forms.Button AddModuleBTN;
        private System.Windows.Forms.Label ServerNameLBL;
        private UTextBox NameTextBox;
        private System.Windows.Forms.Label NameLBL;
        private UTextBox ServerNameTextBox;
        private UTextBox PasswordTextBox;
        private System.Windows.Forms.Label PasswordLBL;
        private System.Windows.Forms.Label UpdageLBL;
        private System.Windows.Forms.Label AircraftOfPageLBL;
        private System.Windows.Forms.MaskedTextBox AircraftOfPageTextBox;
        private System.Windows.Forms.Label RoutOfPageLBL;
        private System.Windows.Forms.Label SecondLBL;
        private System.Windows.Forms.MaskedTextBox RoutOfPageTextBox;
        private System.Windows.Forms.MaskedTextBox UpdateTextBox;
        private System.Windows.Forms.Button BackBTN;
        private System.Windows.Forms.ComboBox ColorSelectedComboBox;
        private System.Windows.Forms.Button SaveBTN;
        private System.Windows.Forms.ComboBox ColorNewRouteComboBox;
        private System.Windows.Forms.Label ColorSelectedLBL;
        private System.Windows.Forms.Label ColorNewRouteLBL;
    }
}