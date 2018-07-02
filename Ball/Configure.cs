using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ball
{
    public partial class Configure : Form
    {
        public Configure()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Configures.AirResistance = Convert.ToDouble(trackBar1.Value) / 100;
            label1.Text = Convert.ToString(Configures.AirResistance);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            Configures.GCoefficient = Convert.ToDouble(trackBar2.Value) / 10;
            label2.Text = Convert.ToString(Configures.GCoefficient);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            Configures.Impact_Speed_Reduce = Convert.ToDouble(trackBar3.Value) / 100;
            label3.Text = Convert.ToString(Configures.Impact_Speed_Reduce);
        }
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            Configures.MaxSpeed = Convert.ToDouble(trackBar4.Value) *10;
            label4.Text = Convert.ToString(Configures.MaxSpeed);
        }
        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            Configures.GRotateSpeed = Convert.ToDouble(trackBar5.Value);
            label5.Text = Convert.ToString(Configures.GRotateSpeed);
        }
    }
}
