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
            this.AircraftGridView = new System.Windows.Forms.DataGridView();
            this.AircraftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AircraftContainer)).BeginInit();
            this.AircraftContainer.Panel1.SuspendLayout();
            this.AircraftContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AircraftGridView)).BeginInit();
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
            // 
            // AircraftContainer
            // 
            this.AircraftContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AircraftContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.AircraftContainer.Location = new System.Drawing.Point(0, 0);
            this.AircraftContainer.Name = "AircraftContainer";
            this.AircraftContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // AircraftContainer.Panel1
            // 
            this.AircraftContainer.Panel1.Controls.Add(this.AircraftGridView);
            this.AircraftContainer.Size = new System.Drawing.Size(1200, 600);
            this.AircraftContainer.SplitterDistance = 341;
            this.AircraftContainer.TabIndex = 0;
            // 
            // AircraftGridView
            // 
            this.AircraftGridView.AllowUserToAddRows = false;
            this.AircraftGridView.AllowUserToOrderColumns = true;
            this.AircraftGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AircraftGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.AircraftGridView.Location = new System.Drawing.Point(215, 29);
            this.AircraftGridView.Name = "AircraftGridView";
            this.AircraftGridView.ReadOnly = true;
            this.AircraftGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AircraftGridView.Size = new System.Drawing.Size(766, 247);
            this.AircraftGridView.TabIndex = 0;
            // 
            // Aircraft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.AircraftPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Aircraft";
            this.Text = "Aircraft";
            this.AircraftPanel.ResumeLayout(false);
            this.AircraftContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AircraftContainer)).EndInit();
            this.AircraftContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AircraftGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel AircraftPanel;
        private System.Windows.Forms.SplitContainer AircraftContainer;
        private System.Windows.Forms.DataGridView AircraftGridView;
    }
}