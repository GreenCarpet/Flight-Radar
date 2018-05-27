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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ModulesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ModulesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ModulesGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.ModulesGridView.Location = new System.Drawing.Point(71, 12);
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
            this.AddModuleButton.Location = new System.Drawing.Point(123, 226);
            this.AddModuleButton.Name = "AddModuleButton";
            this.AddModuleButton.Size = new System.Drawing.Size(119, 40);
            this.AddModuleButton.TabIndex = 1;
            this.AddModuleButton.Text = "Добавить";
            this.AddModuleButton.UseVisualStyleBackColor = true;
            this.AddModuleButton.Click += new System.EventHandler(this.AddModuleButton_Click);
            // 
            // DeleteModuleButton
            // 
            this.DeleteModuleButton.Location = new System.Drawing.Point(366, 226);
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
            this.ClientSize = new System.Drawing.Size(643, 344);
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