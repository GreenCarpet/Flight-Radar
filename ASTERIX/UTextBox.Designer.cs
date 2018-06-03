namespace ASTERIX
{
    partial class UTextBox
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.UTextBoxPanel = new System.Windows.Forms.TableLayoutPanel();
            this.textBox = new System.Windows.Forms.TextBox();
            this.ClearBTN = new System.Windows.Forms.Button();
            this.UTextBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UTextBoxPanel
            // 
            this.UTextBoxPanel.ColumnCount = 1;
            this.UTextBoxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.UTextBoxPanel.Controls.Add(this.textBox, 0, 1);
            this.UTextBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UTextBoxPanel.Location = new System.Drawing.Point(0, 0);
            this.UTextBoxPanel.Name = "UTextBoxPanel";
            this.UTextBoxPanel.RowCount = 4;
            this.UTextBoxPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.UTextBoxPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.UTextBoxPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.UTextBoxPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.UTextBoxPanel.Size = new System.Drawing.Size(172, 20);
            this.UTextBoxPanel.TabIndex = 4;
            // 
            // textBox
            // 
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox.Location = new System.Drawing.Point(0, 3);
            this.textBox.Margin = new System.Windows.Forms.Padding(0);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(172, 13);
            this.textBox.TabIndex = 1;
            this.textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.textBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_MouseDown);
            // 
            // ClearBTN
            // 
            this.ClearBTN.BackColor = System.Drawing.Color.LightGray;
            this.ClearBTN.Cursor = System.Windows.Forms.Cursors.Default;
            this.ClearBTN.Dock = System.Windows.Forms.DockStyle.Right;
            this.ClearBTN.FlatAppearance.BorderSize = 0;
            this.ClearBTN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.ClearBTN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.ClearBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearBTN.Location = new System.Drawing.Point(172, 0);
            this.ClearBTN.Margin = new System.Windows.Forms.Padding(0);
            this.ClearBTN.Name = "ClearBTN";
            this.ClearBTN.Size = new System.Drawing.Size(28, 20);
            this.ClearBTN.TabIndex = 3;
            this.ClearBTN.TabStop = false;
            this.ClearBTN.Text = "X";
            this.ClearBTN.UseVisualStyleBackColor = false;
            this.ClearBTN.Visible = false;
            this.ClearBTN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ClearBTN_MouseDown);
            this.ClearBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ClearBTN_MouseUp);
            // 
            // UTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UTextBoxPanel);
            this.Controls.Add(this.ClearBTN);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(1000, 20);
            this.MinimumSize = new System.Drawing.Size(30, 20);
            this.Name = "UTextBox";
            this.Size = new System.Drawing.Size(200, 20);
            this.UTextBoxPanel.ResumeLayout(false);
            this.UTextBoxPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel UTextBoxPanel;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button ClearBTN;
    }
}
