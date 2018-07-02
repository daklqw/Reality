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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BallPic.Visible = true;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.F1:
                        FormConfigure.ShowDialog();
                        break;
                }
            }
        }

        /// <summary>
        /// Get the position range of Form1
        /// </summary>
        /// <returns>A position which records MaxWidth as X and MaxHeight as Y</returns>
        public Position GetWindowRange()
        {
            return new Position(this.Width, this.Height);
        }

        /// <summary>
        /// Update the position of the ball and draw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            ball.velocity = ball.velocity * Configures.AirResistance;
            if (ball.velocity.Distance(new Position()) <= Configures.MaxSpeed)
                ball.velocity = ball.velocity + Configures.VectorG * Configures.GCoefficient;
            // Update velocity
            int impact = (ball.velocity + ball.position).overRange(GetWindowRange(), ball.GetR());
            if (impact > 0)
                ball.velocity = ball.velocity * Configures.Impact_Speed_Reduce;
            // Check if over range
            if ((impact & (Position.overRangeType.Left | Position.overRangeType.Right)) > 0)
                ball.velocity.SetX(-ball.velocity.GetX());
            // If left or right, reverse X
            if ((impact & (Position.overRangeType.Up | Position.overRangeType.Down)) > 0)
                ball.velocity.SetY(-ball.velocity.GetY());
            // If up or down, reverse Y
            ball.position = ball.velocity + ball.position;
            logs.Write(ball.position.ToString());
            // MessageBox.Show("run"); //WOC
            BallPic.Location = new System.Drawing.Point(
                Convert.ToInt32(ball.position.GetX()),
                Convert.ToInt32(ball.position.GetY())
            );
            if (Configures.GRotateSpeed > 0 && ++RunTimes % Configures.GRotateSpeed == 0)
            {
                Configures.VectorG = Configures.VectorG.rotate(Math.PI / 12);
            }
        }

        public void Exit()
        {
            logs.Flush();
            logs.Close();
            Utils.ExitImmidiately();
        }
    }
}
