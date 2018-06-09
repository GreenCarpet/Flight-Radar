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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ImportModuleDialog = new System.Windows.Forms.OpenFileDialog();
            this.ModulesGridView = new System.Windows.Forms.DataGridView();
            this.AddModuleButton = new System.Windows.Forms.Button();
            this.DeleteModuleButton = new System.Windows.Forms.Button();
            this.SettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModulesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SettingsPanel
            // 
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
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DeleteModuleButton);
            this.splitContainer1.Panel2.Controls.Add(this.AddModuleButton);
            this.splitContainer1.Panel2.Controls.Add(this.ModulesGridView);
            this.splitContainer1.Size = new System.Drawing.Size(1200, 600);
            this.splitContainer1.SplitterDistance = 600;
            this.splitContainer1.TabIndex = 0;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ModulesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.ModulesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ModulesGridView.DefaultCellStyle = dataGridViewCellStyle6;
            this.ModulesGridView.Location = new System.Drawing.Point(78, 34);
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
            // AddModuleButton
            // 
            this.AddModuleButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AddModuleButton.Location = new System.Drawing.Point(137, 517);
            this.AddModuleButton.Name = "AddModuleButton";
            this.AddModuleButton.Size = new System.Drawing.Size(119, 40);
            this.AddModuleButton.TabIndex = 2;
            this.AddModuleButton.Text = "Добавить";
            this.AddModuleButton.UseVisualStyleBackColor = true;
            this.AddModuleButton.Click += new System.EventHandler(this.AddModuleButton_Click);
            // 
            // DeleteModuleButton
            // 
            this.DeleteModuleButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DeleteModuleButton.Location = new System.Drawing.Point(390, 517);
            this.DeleteModuleButton.Name = "DeleteModuleButton";
            this.DeleteModuleButton.Size = new System.Drawing.Size(119, 40);
            this.DeleteModuleButton.TabIndex = 3;
            this.DeleteModuleButton.Text = "Удалить";
            this.DeleteModuleButton.UseVisualStyleBackColor = true;
            this.DeleteModuleButton.Click += new System.EventHandler(this.DeleteModuleButton_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.SettingsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Settings";
            this.Text = "Settings";
            this.SettingsPanel.ResumeLayout(false);
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
        private System.Windows.Forms.Button AddModuleButton;
        private System.Windows.Forms.Button DeleteModuleButton;
    }
}