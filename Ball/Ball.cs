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
    }
}