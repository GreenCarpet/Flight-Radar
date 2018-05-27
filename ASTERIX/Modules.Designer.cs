namespace ASTERIX
{
    partial class Modules
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
            this.ModulesGridView = new System.Windows.Forms.DataGridView();
            this.AddModuleButton = new System.Windows.Forms.Button();
            this.DeleteModuleButton = new System.Windows.Forms.Button();
            this.ImportModuleDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ModulesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ModulesGridView
            // 
            this.ModulesGridView.AllowUserToAddRows = false;
            this.ModulesGridView.AllowUserToResizeColumns = false;
            this.ModulesGridView.AllowUserToResizeRows = false;
            this.ModulesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ModulesGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ModulesGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ModulesGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ModulesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ModulesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ModulesGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.ModulesGridView.Location = new System.Drawing.Point(12, 12);
            this.ModulesGridView.MultiSelect = false;
            this.ModulesGridView.Name = "ModulesGridView";
            this.ModulesGridView.ReadOnly = true;
            this.ModulesGridView.RowHeadersVisible = false;
            this.ModulesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ModulesGridView.Size = new System.Drawing.Size(479, 199);
            this.ModulesGridView.TabIndex = 0;
            this.ModulesGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ModulesGridView_CellMouseDoubleClick);
            this.ModulesGridView.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.ModulesGridView_UserDeletedRow);
            this.ModulesGridView.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.ModulesGridView_UserDeletingRow);
            // 
            // AddModuleButton
            // 
            this.AddModuleButton.Location = new System.Drawing.Point(81, 228);
            this.AddModuleButton.Name = "AddModuleButton";
            this.AddModuleButton.Size = new System.Drawing.Size(119, 40);
            this.AddModuleButton.TabIndex = 1;
            this.AddModuleButton.Text = "Добавить";
            this.AddModuleButton.UseVisualStyleBackColor = true;
            this.AddModuleButton.Click += new System.EventHandler(this.AddModuleButton_Click);
            // 
            // DeleteModuleButton
            // 
            this.DeleteModuleButton.Location = new System.Drawing.Point(301, 228);
            this.DeleteModuleButton.Name = "DeleteModuleButton";
            this.DeleteModuleButton.Size = new System.Drawing.Size(119, 40);
            this.DeleteModuleButton.TabIndex = 2;
            this.DeleteModuleButton.Text = "Удалить";
            this.DeleteModuleButton.UseVisualStyleBackColor = true;
            this.DeleteModuleButton.Click += new System.EventHandler(this.DeleteModuleButton_Click);
            // 
            // Modules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 286);
            this.Controls.Add(this.DeleteModuleButton);
            this.Controls.Add(this.AddModuleButton);
            this.Controls.Add(this.ModulesGridView);
            this.Name = "Modules";
            this.Text = "Modules";
            this.Load += new System.EventHandler(this.Modules_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ModulesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ModulesGridView;
        private System.Windows.Forms.Button AddModuleButton;
        private System.Windows.Forms.Button DeleteModuleButton;
        private System.Windows.Forms.OpenFileDialog ImportModuleDialog;
    }
}