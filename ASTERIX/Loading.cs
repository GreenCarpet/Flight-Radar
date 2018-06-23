using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ASTERIX
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        public void On()
        {
            if (LoadPictureBox.InvokeRequired)
            {
                LoadPictureBox.BeginInvoke(new Action(On));
                return;
            }
            new Thread(() =>
            {
                ShowDialog();
            }).Start();
        }
        public void Off()
        {
            if (LoadPictureBox.InvokeRequired)
            {
                LoadPictureBox.BeginInvoke(new Action(Off));
                return;
            }
            Close();
        }
    }
}
