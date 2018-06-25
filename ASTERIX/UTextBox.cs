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
    public partial class UTextBox : UserControl
    {
        private string text;
        private string Masktext;
        private char passChar;
        private bool Readonly = false;
        private CharacterCasing ChCasing = CharacterCasing.Upper;
        private Color maskColor = Color.Gray;
        private Color textColor = Color.Black;
        private Color ClearBTNBackColor = Color.LightGray;
        private Color mouseBackColor = Color.Gray;
        private Color textBoxBackColor = Color.White;
        public event EventHandler ControlTextChanged;
        public event EventHandler ControlKeyDown;
        public event EventHandler ControlMouseDown;

        public CharacterCasing CharacterCasingField
        {
            get
            {
                return ChCasing;
            }
            set
            {
                ChCasing = value;
                textBox.CharacterCasing = ChCasing;
            }
        }
        public string MaskField
        {
            get
            {
                return Masktext;
            }
            set
            {
                Masktext = value;
                if (Masktext != null)
                {
                    switch (ChCasing)
                    {
                        case CharacterCasing.Upper:
                            {
                                Masktext = Masktext.ToUpper();
                                break;
                            }
                        case CharacterCasing.Lower:
                            {
                                Masktext = Masktext.ToLower();
                                break;
                            }
                    }
                    textBox.ForeColor = maskColor;
                    textBox.Text = Masktext;
                }
                else
                {
                    if (text != null)
                    {
                        textBox.Text = text;
                        textBox.ForeColor = textColor;
                    }
                    else
                    {
                        textBox.Text = "";
                        textBox.ForeColor = textColor;
                    }
                }
            }
        }
        public string TextField
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                if (text != null)
                {
                    switch (ChCasing)
                    {
                        case CharacterCasing.Upper:
                            {
                                text = text.ToUpper();
                                break;
                            }
                        case CharacterCasing.Lower:
                            {
                                text = text.ToLower();
                                break;
                            }
                    }
                    textBox.Text = text;
                    textBox.ForeColor = textColor;
                }
                else
                {
                    if (Masktext != null)
                    {
                        textBox.Text = Masktext;
                        textBox.ForeColor = maskColor;
                    }
                    else
                    {
                        textBox.Text = "";
                        textBox.ForeColor = textColor;
                    }
                }
            }
        }

        public Color BackColoField
        {
            get
            {
                return textBoxBackColor;
            }
            set
            {
                textBoxBackColor = value;
                UTextBoxPanel.BackColor = textBoxBackColor;
                textBox.BackColor = textBoxBackColor;
            }
        }
        public Color MaskColoField
        {
            get
            {
                return maskColor;
            }
            set
            {
                maskColor = value;
                textBox.ForeColor = maskColor;
            }
        }
        public Color TextColorField
        {
            get
            {
                return textColor;
            }
            set
            {
                textColor = value;
                textBox.ForeColor = textColor;
            }
        }
        public Color ClearBTNBackColorField
        {
            get
            {
                return ClearBTNBackColor;
            }
            set
            {
                ClearBTNBackColor = value;
                ClearBTN.BackColor = ClearBTNBackColor;
            }
        }
        public Color MouseBackColorField
        {
            get
            {
                return mouseBackColor;
            }
            set
            {
                mouseBackColor = value;
                ClearBTN.FlatAppearance.MouseDownBackColor = mouseBackColor;
                ClearBTN.FlatAppearance.MouseOverBackColor = mouseBackColor;
            }
        }
        public char PasswordChar
        {
            get
            {
                return passChar;
            }
            set
            {
                passChar = value;
                textBox.PasswordChar = passChar;
            }
        }

        public bool ReadOnly
        {
            get
            {
                return Readonly;
            }
            set
            {
                Readonly = value;
                textBox.ReadOnly = Readonly;
                if (Readonly)
                {
                    ClearBTN.Visible = false;
                }
            }
        }

        public void Clear()
        {
            ClearBTN_MouseUp(null, null);
        }

        public UTextBox()
        {
            InitializeComponent();

            ClearBTN.BackColor = ClearBTNBackColor;
            ClearBTN.FlatAppearance.MouseDownBackColor = mouseBackColor;
            ClearBTN.FlatAppearance.MouseOverBackColor = mouseBackColor;
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if ((textBox.Text == "") && (text != null))
            {
                ClearBTN_MouseUp(null, null);
            }
            if ((textBox.Text != MaskField) && (textBox.ForeColor == maskColor) && (textBox.Text != ""))
            {
                if ((MaskField != "") && (MaskField != null))
                {
                    textBox.Text = textBox.Text.Replace(MaskField, "");
                }
                textBox.SelectionStart = textBox.TextLength;
                textBox.ForeColor = textColor;
            }
            if (textBox.ForeColor == textColor)
            {
                text = textBox.Text;
                if (!Readonly)
                {
                    ClearBTN.Visible = true;
                }
                this.ControlTextChanged?.Invoke(this, e);
            }
        }
        private void textBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox.ForeColor == maskColor)
            {
                textBox.SelectionStart = 0;
                textBox.SelectionLength = 0;
            }
            this.ControlMouseDown?.Invoke(this, e);
        }
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox.ForeColor == maskColor)
            {
                textBox.SelectionStart = 0;
                if ((e.KeyCode == Keys.Delete) || (e.KeyCode == Keys.Back) || (e.KeyCode == Keys.End) || (e.KeyCode == Keys.Right) || (e.KeyCode == Keys.Down))
                {
                    e.SuppressKeyPress = true;
                }
            }
            this.ControlKeyDown?.Invoke(this, e);
        }

        private void ClearBTN_MouseDown(object sender, MouseEventArgs e)
        {
            textBox.Focus();
        }
        private void ClearBTN_MouseUp(object sender, MouseEventArgs e)
        {
            if (!Readonly)
            {
                text = null;
                textBox.Text = null;
                ClearBTN.Visible = false;
                this.ControlTextChanged?.Invoke(this, e);

                textBox.ForeColor = maskColor;
                textBox.Text = MaskField;
            }
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            textBox.SelectionStart = 0;
            textBox.SelectionLength = 0;
        }
    }
}
