using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;

namespace ASTERIX
{
    public partial class Graphics : Form
    {
        public Graphics(string Id)
        {
            InitializeComponent();

            DataTable trek = SQL.query("SELECT TargetAddress, GPX FROM [LOAD] WHERE ID = '" + Id + "'");
            string TargetAddress = Convert.ToString(trek.Rows[0]["TargetAddress"]);
            string xml = Convert.ToString(trek.Rows[0]["GPX"]);

            Text = TargetAddress;

            gpxType gpx = GMaps.Instance.DeserializeGPX(xml);
            rteType[] rte = gpx.rte;

            for (int route = 0; route < rte.Length; route++)
            {
                List<int> X = new List<int>();
                List<decimal> Y = new List<decimal>();

                for (int i = 0; i < rte[route].rtept.Length; i++)
                {
                    decimal ele = rte[route].rtept[i].ele;
                    if (ele != -1)
                    {
                        // X.Add(new PointLatLng(Convert.ToDouble(rte[route].rtept[i].lat), Convert.ToDouble(rte[route].rtept[i].lon)).ToString());
                        X.Add(i);
                        Y.Add(rte[route].rtept[i].ele);
                    }
                }
                chart.Series["Ele"].Points.DataBindXY(X, Y);
                if (Y.Count > 0)
                {
                    chart.ChartAreas["EleAreas"].AxisY.Minimum = Convert.ToDouble(Y.Min()) - 1000;
                    chart.ChartAreas["EleAreas"].AxisY.Maximum = Convert.ToDouble(Y.Max()) + 1000;
                }
            }
        }
    }
}
