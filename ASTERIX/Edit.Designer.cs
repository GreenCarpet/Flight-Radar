namespace ASTERIX
{
    partial class Edit
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
            this.ColorComboBox = new System.Windows.Forms.ComboBox();
            this.ColorLBL = new System.Windows.Forms.Label();
            this.SaveBTN = new System.Windows.Forms.Button();
            this.DeleteBTN = new System.Windows.Forms.Button();
            this.MultiBTN = new System.Windows.Forms.Button();
            this.NameTextBox = new ASTERIX.UTextBox();
            this.SuspendLayout();
            // 
            // ColorComboBox
            // 
            this.ColorComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ColorComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ColorComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColorComboBox.FormattingEnabled = true;
            this.ColorComboBox.Location = new System.Drawing.Point(69, 60);
            this.ColorComboBox.Name = "ColorComboBox";
            this.ColorComboBox.Size = new System.Drawing.Size(47, 21);
            this.ColorComboBox.TabIndex = 15;
            this.ColorComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ColorComboBox_DrawItem);
            this.ColorComboBox.SelectedIndexChanged += new System.EventHandler(this.ColorComboBox_SelectedIndexChanged);
            // 
            // ColorLBL
            // 
            this.ColorLBL.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ColorLBL.AutoSize = true;
            this.ColorLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ColorLBL.Location = new System.Drawing.Point(13, 61);
            this.ColorLBL.Name = "ColorLBL";
            this.ColorLBL.Size = new System.Drawing.Size(40, 16);
            this.ColorLBL.TabIndex = 14;
            this.ColorLBL.Text = "Цвет";
            // 
            // SaveBTN
            // 
            this.SaveBTN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SaveBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.SaveBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveBTN.Location = new System.Drawing.Point(16, 140);
            this.SaveBTN.Name = "SaveBTN";
            this.SaveBTN.Size = new System.Drawing.Size(220, 29);
            this.SaveBTN.TabIndex = 16;
            this.SaveBTN.TabStop = false;
            this.SaveBTN.Text = "ОК";
            this.SaveBTN.UseVisualStyleBackColor = false;
            this.SaveBTN.Click += new System.EventHandler(this.SaveBTN_Click);
            // 
            // DeleteBTN
            // 
            this.DeleteBTN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DeleteBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.DeleteBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteBTN.Location = new System.Drawing.Point(16, 105);
            this.DeleteBTN.Name = "DeleteBTN";
            this.DeleteBTN.Size = new System.Drawing.Size(102, 29);
            this.DeleteBTN.TabIndex = 17;
            this.DeleteBTN.TabStop = false;
            this.DeleteBTN.Text = "УДАЛИТЬ";
            this.DeleteBTN.UseVisualStyleBackColor = false;
            this.DeleteBTN.Click += new System.EventHandler(this.DeleteBTN_Click);
            // 
            // MultiBTN
            // 
            this.MultiBTN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.MultiBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.MultiBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MultiBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MultiBTN.Location = new System.Drawing.Point(132, 105);
            this.MultiBTN.Name = "MultiBTN";
            this.MultiBTN.Size = new System.Drawing.Size(102, 29);
            this.MultiBTN.TabIndex = 17;
            this.MultiBTN.TabStop = false;
            this.MultiBTN.Text = "ДОБАВИТЬ В БД";
            this.MultiBTN.UseVisualStyleBackColor = false;
            this.MultiBTN.Click += new System.EventHandler(this.MultiBTN_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.BackColoField = System.Drawing.Color.White;
            this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Normal;
            this.NameTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.NameTextBox.Location = new System.Drawing.Point(14, 19);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.NameTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.NameTextBox.MaskField = "НАЗВАНИЕ";
            this.NameTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.NameTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.NameTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.PasswordChar = '\0';
            this.NameTextBox.ReadOnly = false;
            this.NameTextBox.Size = new System.Drawing.Size(220, 20);
            this.NameTextBox.TabIndex = 1;
            this.NameTextBox.TextColorField = System.Drawing.Color.Black;
            this.NameTextBox.TextField = null;
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(246, 181);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.MultiBTN);
            this.Controls.Add(this.DeleteBTN);
            this.Controls.Add(this.SaveBTN);
            this.Controls.Add(this.ColorComboBox);
            this.Controls.Add(this.ColorLBL);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Edit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Edit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox ColorComboBox;
        private System.Windows.Forms.Label ColorLBL;
        private System.Windows.Forms.Button SaveBTN;
        private System.Windows.Forms.Button DeleteBTN;
        private System.Windows.Forms.Button MultiBTN;
        private UTextBox NameTextBox;
    }
}