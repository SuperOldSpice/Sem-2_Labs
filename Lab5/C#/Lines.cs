using System;

namespace LinesLibrary
{
    //lines class
    public class Lines
    {
        //coordinates
        protected double _x1, _x2, _y1, _y2;

        //parametric constructor
        public Lines(double x1, double y1, double x2, double y2)
        {
            _x1 = x1;
            _x2 = x2;
            _y1 = y1;
            _y2 = y2;
        }

        //returns line`s length 
        public double GetLength()
        {
            double length;
            length = Math.Sqrt( Math.Pow((_x2 - _x1), 2) + Math.Pow((_y2 - _y1), 2));
            return length;
        }
    }
}
