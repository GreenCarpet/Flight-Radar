using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET.WindowsForms.Markers;

namespace ASTERIX
{
    public partial class Edit : Form
    {
        static Color[] colors;
        public string onClick;
        public string Tool;

        public string name = null;
        public Color color;
        public Color oldColor = Color.Red;

        public Edit(string tool, Color oldcolor, string Name)
        {
            InitializeComponent();

            Tool = tool;
            oldColor = oldcolor;
            name = Name;
        }
        private void Edit_Load(object sender, EventArgs e)
        {
            switch (Tool)
            {
                case "route":
                    {
                        colors = Map.colors;
                        NameTextBox.ReadOnly = true;

                        break;
                    }
                case "polygons":
                    {
                        colors = Map.colors;
                        NameTextBox.ReadOnly = true;

                        break;
                    }
                case "markers":
                    {
                        Color[] Markercolors = { Color.LightBlue, Color.Blue, Color.Green, Color.Orange, Color.Pink, Color.Purple, Color.Red, Color.Yellow };
                        colors = Markercolors;

                        break;
                    }
            }

            NameTextBox.TextField = name;

            foreach (Color clr in colors)
            {
                ColorComboBox.Items.Add("");
            }

            ColorComboBox.BackColor = oldColor;
        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {
            onClick = "OK";

            name = NameTextBox.TextField;
            color = ColorComboBox.BackColor;

            Close();
        }
        private void DeleteBTN_Click(object sender, EventArgs e)
        {
            onClick = "DELETE";

            Close();
        }
        private void EditDBBTN_Click(object sender, EventArgs e)
        {
            onClick = "EDITDB";

            Close();
        }

        private void ColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            using (Brush br = new SolidBrush(colors[e.Index]))
            {
                e.Graphics.FillRectangle(br, e.Bounds);
            }
        }
        private void ColorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ColorComboBox.BackColor = colors[ColorComboBox.SelectedIndex];
        }
    }
}
