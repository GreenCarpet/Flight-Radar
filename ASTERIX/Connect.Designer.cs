namespace ASTERIX
{
    partial class Connect
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
            this.PasswordLBL = new System.Windows.Forms.Label();
            this.NameTextBox = new ASTERIX.UTextBox();
            this.NameLBL = new System.Windows.Forms.Label();
            this.ServerNameTextBox = new ASTERIX.UTextBox();
            this.ServerNameLBL = new System.Windows.Forms.Label();
            this.SaveBTN = new System.Windows.Forms.Button();
            this.PasswordTextBox = new ASTERIX.UTextBox();
            this.SuspendLayout();
            // 
            // PasswordLBL
            // 
            this.PasswordLBL.AutoSize = true;
            this.PasswordLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordLBL.Location = new System.Drawing.Point(264, 54);
            this.PasswordLBL.Name = "PasswordLBL";
            this.PasswordLBL.Size = new System.Drawing.Size(57, 16);
            this.PasswordLBL.TabIndex = 10;
            this.PasswordLBL.Text = "Пароль";
            // 
            // NameTextBox
            // 
            this.NameTextBox.BackColoField = System.Drawing.Color.White;
            this.NameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Normal;
            this.NameTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.NameTextBox.Location = new System.Drawing.Point(126, 54);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.NameTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.NameTextBox.MaskField = null;
            this.NameTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.NameTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.NameTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.PasswordChar = '\0';
            this.NameTextBox.Size = new System.Drawing.Size(117, 20);
            this.NameTextBox.TabIndex = 9;
            this.NameTextBox.TextColorField = System.Drawing.Color.Black;
            this.NameTextBox.TextField = null;
            // 
            // NameLBL
            // 
            this.NameLBL.AutoSize = true;
            this.NameLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLBL.Location = new System.Drawing.Point(30, 54);
            this.NameLBL.Name = "NameLBL";
            this.NameLBL.Size = new System.Drawing.Size(75, 16);
            this.NameLBL.TabIndex = 8;
            this.NameLBL.Text = "Имя входа";
            // 
            // ServerNameTextBox
            // 
            this.ServerNameTextBox.BackColoField = System.Drawing.Color.White;
            this.ServerNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServerNameTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Normal;
            this.ServerNameTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.ServerNameTextBox.Location = new System.Drawing.Point(126, 18);
            this.ServerNameTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.ServerNameTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.ServerNameTextBox.MaskField = "НАПРИМЕР: SERVER-OTO\\SQLEXPRESS";
            this.ServerNameTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.ServerNameTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.ServerNameTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.ServerNameTextBox.Name = "ServerNameTextBox";
            this.ServerNameTextBox.PasswordChar = '\0';
            this.ServerNameTextBox.Size = new System.Drawing.Size(328, 20);
            this.ServerNameTextBox.TabIndex = 7;
            this.ServerNameTextBox.TextColorField = System.Drawing.Color.Black;
            this.ServerNameTextBox.TextField = null;
            // 
            // ServerNameLBL
            // 
            this.ServerNameLBL.AutoSize = true;
            this.ServerNameLBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ServerNameLBL.Location = new System.Drawing.Point(13, 18);
            this.ServerNameLBL.Name = "ServerNameLBL";
            this.ServerNameLBL.Size = new System.Drawing.Size(92, 16);
            this.ServerNameLBL.TabIndex = 6;
            this.ServerNameLBL.Text = "Имя сервера";
            // 
            // SaveBTN
            // 
            this.SaveBTN.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.SaveBTN.BackColor = System.Drawing.Color.LightSlateGray;
            this.SaveBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveBTN.Location = new System.Drawing.Point(137, 106);
            this.SaveBTN.Name = "SaveBTN";
            this.SaveBTN.Size = new System.Drawing.Size(220, 29);
            this.SaveBTN.TabIndex = 12;
            this.SaveBTN.TabStop = false;
            this.SaveBTN.Text = "СОЕДИНИТЬ";
            this.SaveBTN.UseVisualStyleBackColor = false;
            this.SaveBTN.Click += new System.EventHandler(this.SaveBTN_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColoField = System.Drawing.Color.White;
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.CharacterCasingField = System.Windows.Forms.CharacterCasing.Normal;
            this.PasswordTextBox.ClearBTNBackColorField = System.Drawing.Color.LightGray;
            this.PasswordTextBox.Location = new System.Drawing.Point(337, 54);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.PasswordTextBox.MaskColoField = System.Drawing.Color.Gray;
            this.PasswordTextBox.MaskField = null;
            this.PasswordTextBox.MaximumSize = new System.Drawing.Size(1000, 20);
            this.PasswordTextBox.MinimumSize = new System.Drawing.Size(30, 20);
            this.PasswordTextBox.MouseBackColorField = System.Drawing.Color.Gray;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(117, 20);
            this.PasswordTextBox.TabIndex = 13;
            this.PasswordTextBox.TextColorField = System.Drawing.Color.Black;
            this.PasswordTextBox.TextField = null;
            // 
            // Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(476, 147);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.SaveBTN);
            this.Controls.Add(this.PasswordLBL);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameLBL);
            this.Controls.Add(this.ServerNameTextBox);
            this.Controls.Add(this.ServerNameLBL);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Connect";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Connect_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label PasswordLBL;
        private UTextBox NameTextBox;
        private System.Windows.Forms.Label NameLBL;
        private UTextBox ServerNameTextBox;
        private System.Windows.Forms.Label ServerNameLBL;
        private System.Windows.Forms.Button SaveBTN;
        private UTextBox PasswordTextBox;
    }
}