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
    class Ball
    {
        public Position position, velocity;
        private double r;
        public Ball() {
            position = Configures.InitPosition;
            velocity = Configures.InitVelocity;
            r = Configures.InitRadius;
        }
        public Ball(Position _Position, Position _Velocity) { position = _Position; velocity = _Velocity; }
        public double GetR() { return r; }
        public void SetR(double _r) { r = _r; }
        /// <summary>
        /// Check if over range and move the ball
        /// </summary>
        /// <param name="WindowRange">
        /// A Position-type variable which is usually got by GetWindowRange() 
        /// and it records thr range of the Form
        /// </param>
        public void Update(Position WindowRange)
        {
            velocity = velocity * Configures.AirResistance;
            if (velocity.Distance(new Position()) <= Configures.MaxSpeed)
                velocity = velocity + Configures.VectorG * Configures.GCoefficient;
            // Update velocity
            int impact = (velocity + position).overRange(WindowRange, GetR());
            if (impact > 0)
                velocity = velocity * Configures.Impact_Speed_Reduce;
            // Check if over range
            if ((impact & (Position.overRangeType.Left | Position.overRangeType.Right)) > 0)
                velocity.SetX(-velocity.GetX());
            // If left or right, reverse X
            if ((impact & (Position.overRangeType.Up | Position.overRangeType.Down)) > 0)
                velocity.SetY(-velocity.GetY());
            // If up or down, reverse Y
            position = velocity + position;
        }
    }
}