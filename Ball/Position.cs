using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball
{
    public class Position
    {
        public Position() { x = y = 0; }
        public Position(double _x, double _y) { x = _x; y = _y; }
        public Position(Position b) { x = b.x; y = b.y; }
        public double GetX() { return x; }
        public double GetY() { return y; }
        public void SetX(double _x) { x = _x; }
        public void SetY(double _y) { y = _y; }
        //public Position DToWindow(Position WindowRange)
        //{
        //    Position result = new Position();
        //    result.SetX(this.GetX() * WindowRange.GetX());
        //    result.SetY((1 - this.GetY()) * WindowRange.GetY());
        //    return result;
        //}
        //public Position WindowToD(Position WindowRange)
        //{
        //    Position result = new Position();
        //    result.SetX(this.GetX() / WindowRange.GetX());
        //    result.SetY(WindowRange.GetY() - this.GetY());
        //    return new Position(this.GetX());
        //}


        /// <summary>
        /// Get distance of two points
        /// </summary>
        /// <param name="position1">Point X</param>
        /// <param name="position2">Point Y</param>
        /// <returns>A double-type variable which is considered as the distance of two points</returns>
        public static double Distance(Position position1, Position position2)
        {
            return Math.Sqrt(
                Math.Pow(position1.GetX() - position2.GetX(), 2)
                +
                Math.Pow(position1.GetY() - position2.GetY(), 2)
            );
        }
        public double Distance(Position position)
        {
            return Distance(this, position);
        }
        public static Position operator +(Position position1, Position position2)
        {
            // Position result = new Position();
            // result.SetX(position1.GetX() + position2.GetX());
            // result.SetY(position1.GetY() + position2.GetY());
            return new Position(position1.GetX() + position2.GetX(), position1.GetY() + position2.GetY());
        }
        public static Position operator -(Position position)
        {
            // Position result = new Position();
            // result.SetX(-position.GetX());
            // result.SetY(-position.GetY());
            return new Position(-position.GetX(), -position.GetY());
        }
        public static Position operator -(Position position1, Position position2)
        {
            return position1 + -position2;
        }
        public static Position operator *(Position position, double k)
        {
            return new Position(position.GetX() * k, position.GetY() * k);
        }
        public static Position operator /(Position position, double k)
        {
            return new Position(position.GetX() / k, position.GetY() / k);
        }
        public Position rotate(double alpha)
        {
            double cA = Math.Cos(alpha), sA = Math.Sin(alpha);
            return new Position(this.GetX() * cA - this.GetY() * sA, this.GetX() * sA + this.GetY() * cA);
        }
        public static Position rotate(Position position, double alpha)
        {
            return position.rotate(alpha);
        }
        /// <summary>
        /// Check if the ball is over range
        /// </summary>
        /// <param name="WindowRange">
        /// A Position-type variable which is usually got by GetWindowRange() 
        /// and it records thr range of the Form
        /// </param>
        /// <param name="Radius">The radius of the ball</param>
        /// <returns></returns>
        public int overRange(Position WindowRange, double Radius = 0)
        {
            int result = overRangeType.None;
            Radius = Radius * 2;
            if (this.GetX()          <                  0) { result |= overRangeType.Left; }
            if (this.GetX() + Radius > WindowRange.GetX()) { result |= overRangeType.Right; }
            if (this.GetY()          <                  0) { result |= overRangeType.Up; }
            if (this.GetY() + Radius > WindowRange.GetY()) { result |= overRangeType.Down; }
            return result;
        }
        public override string ToString()
        {
            return this.GetX().ToString() + " " + this.GetY().ToString();
        }
        static public class overRangeType{
            static public int Up    = 0x0001;
            static public int Left  = 0x0010;
            static public int Down  = 0x0100;
            static public int Right = 0x1000;
            static public int None  = 0x0000;
        }
        private double x, y;
    }
}
