using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ASTERIX
{
    public partial class UComboBox : UserControl
    {
        private bool droppedDown = false;
        private int displayItems = 15;
        private string masktext;
        private string text;
        public event EventHandler ControlSelectedIndexChanged;
        public List<string> Items = new List<string>();
        private listForm lstForm = new listForm();
        
        public int DisplayItems
        {
            get
            {
                return displayItems;
            }
            set
            {
                displayItems = value;
            }
        }
        public string MaskText
        {
            get
            {
                return masktext;
            }
            set
            {
                masktext = value;
                uTextBox.MaskField = masktext;
            }
        }
        public bool DroppedDown
        {
            get
            {
                return droppedDown;
            }
            set
            {
                droppedDown = value;

                if (value)
                {
                    lstForm.StartPosition = FormStartPosition.Manual;

                    Point r = this.PointToScreen(this.ClientRectangle.Location);

                    lstForm.Location = new Point(r.X, r.Y + this.Height);
                    lstForm.Width = this.Width;

                    if (lstForm.listBox.Items.Count <= displayItems)
                    {
                        lstForm.Height = lstForm.listBox.ItemHeight * (lstForm.listBox.Items.Count + 1);
                    }
                    else
                    {
                        lstForm.Height = lstForm.listBox.ItemHeight * (displayItems + 1);
                    }

                    foreach (object item in Items)
                    {
                        if ((uTextBox.TextField != null) && (Convert.ToString(item).ToUpper().StartsWith(uTextBox.TextField)))
                        {
                            lstForm.listBox.SelectedItem = item;
                            break;
                        }
                    }

                    lstForm.Show();
                    uTextBox.Focus();
                }
                else
                {
                    if (uTextBox.TextField != Convert.ToString(lstForm.listBox.SelectedItem).ToUpper())
                    {
                        uTextBox.TextField = "";
                        uTextBox.TextField = null;
                    }
                    this.ControlSelectedIndexChanged?.Invoke(this, null);
                    lstForm.Hide();
                }
            }

        }
        public List<string> DataSource
        {
            get
            {
                return Items;
            }
            set
            {
                Items = value;
                lstForm.listBox.DataSource = Items;
            }

        }
        public string TextField
        {
            get
            {
                return uTextBox.TextField;
            }
            set
            {
                text = value;
                uTextBox.TextField = text;
            }
        }

        private void uTextBox_ControlTextChanged(object sender, EventArgs e)
        {
            if (TextField != null)
            {
                DroppedDown = true;
            }
        }
        private void uTextBox_ControlKeyDown(object sender, EventArgs e)
        {
            switch (((KeyEventArgs)(e)).KeyCode)
            {
                case Keys.Enter:
                    {
                        uTextBox.TextField = Convert.ToString(lstForm.listBox.SelectedItem);
                        DroppedDown = false;
                        break;
                    }
                case Keys.Down:
                    {
                        if (DroppedDown)
                        {
                            lstForm.Focus();
                        }
                        else
                        {
                            if (lstForm.listBox.SelectedIndex == lstForm.listBox.Items.Count - 1)
                            {
                                lstForm.listBox.SelectedIndex = 0;
                            }
                            else
                            {
                                lstForm.listBox.SelectedIndex += 1;
                            }
                            TextField = (string)lstForm.listBox.SelectedItem;
                            DroppedDown = false;
                        }
                        break;
                    }
                case Keys.Up:
                    {
                        if (DroppedDown)
                        {
                            lstForm.Focus();
                        }
                        else
                        {
                            if (lstForm.listBox.SelectedIndex == 0)
                            {
                                lstForm.listBox.SelectedIndex = lstForm.listBox.Items.Count - 1;
                            }
                            else
                            {
                                lstForm.listBox.SelectedIndex -= 1;
                            }
                            TextField = (string)lstForm.listBox.SelectedItem;
                            DroppedDown = false;
                        }
                        break;
                    }
            }
        }


        public UComboBox()
        {
            InitializeComponent();
            lstForm.Init(this, this.uTextBox);
        }

        public void Add(string item)
        {
            Items.Add(item);

            lstForm.listBox.DataSource = null;
            lstForm.listBox.DataSource = Items;
        }

        private void UComboBox_Enter(object sender, EventArgs e)
        {
            DroppedDown = true;
        }
        private void UComboBox_Leave(object sender, EventArgs e)
        {
            DroppedDown = false;
        }
        private void uTextBox_ControlMouseDown(object sender, EventArgs e)
        {
            DroppedDown = true;
        }

    }

    public partial class listForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public System.Windows.Forms.ListBox listBox;
        public UComboBox ucombobox;
        public UTextBox utextbox;

        public listForm()
        {
            this.listBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();

            this.listBox.BackColor = System.Drawing.SystemColors.Window;
            this.listBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(0, 0);
            this.listBox.Margin = new System.Windows.Forms.Padding(0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(0, 0);
            this.listBox.TabIndex = 3;
            this.listBox.Click += new EventHandler(listBox__Click);
            this.listBox.KeyDown += new KeyEventHandler(listBox__KeyDown);

            this.AutoScaleDimensions = new System.Drawing.SizeF(0, 0);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.ControlBox = false;
            this.Controls.Add(this.listBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "listForm";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ResumeLayout(false);
        }

        private void listBox__Click(object sender, EventArgs e)
        {
            utextbox.TextField = Convert.ToString(listBox.SelectedItem).ToUpper();
            ucombobox.DroppedDown = false;
        }

        private void listBox__KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    {
                        utextbox.TextField = Convert.ToString(listBox.SelectedItem);
                        ucombobox.DroppedDown = false;
                        break;
                    }
                default:
                    {
                        if ((e.KeyCode != Keys.Down) & ((e.KeyCode != Keys.Up)))
                        {
                            utextbox.Focus();
                        }
                        break;
                    }
            }
        }

        public void Init(UComboBox uC, UTextBox uT)
        {
            ucombobox = uC;
            utextbox = uT;
        }
    }
}
