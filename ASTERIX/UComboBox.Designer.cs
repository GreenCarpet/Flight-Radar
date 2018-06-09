namespace ASTERIX
{
    partial class UComboBox
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
            this.uTextBox = new ASTERIX.UTextBox();
            this.SuspendLayout();
            // 
            // uTextBox
            // 
            this.uTextBox.BackColoField = System.Drawing.Color.White;
            this.uTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.uTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Upper;
            this.uTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.uTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uTextBox.Location = new System.Drawing.Point(0, 0);
            this.uTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.uTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.uTextBox.MaskField = null;
            this.uTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.uTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.uTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.uTextBox.Name = "uTextBox";
            this.uTextBox.Size = new System.Drawing.Size(200, 20);
            this.uTextBox.TabIndex = 0;
            this.uTextBox.TextColorField = System.Drawing.Color.Black;
            this.uTextBox.TextField = null;
            this.uTextBox.ControlTextChanged += new System.EventHandler(this.uTextBox_ControlTextChanged);
            this.uTextBox.ControlKeyDown += new System.EventHandler(this.uTextBox_ControlKeyDown);
            this.uTextBox.ControlMouseDown += new System.EventHandler(this.uTextBox_ControlMouseDown);
            // 
            // UComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.uTextBox);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UComboBox";
            this.Size = new System.Drawing.Size(200, 20);
            this.Enter += new System.EventHandler(this.UComboBox_Enter);
            this.Leave += new System.EventHandler(this.UComboBox_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private UTextBox uTextBox;
    }
}
