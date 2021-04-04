using System;

namespace RhombusLibrary
{
    public class Rhombus 
    {
        //coordinetes
        private double []  
            _coordsY = new double[5],
            _coordsX = new double[5];

        //default creation
        public Rhombus()
        {
            _coordsX[1] = 0; _coordsY[1] = 0;
            _coordsX[2] = 0; _coordsY[2] = 1;
            _coordsX[3] = 1; _coordsY[3] = 1;
            _coordsX[4] = 1; _coordsY[4] = 0;
        }

        //parametric creation
        public Rhombus(double[] coordX, double[] coordY)
        {
            for(int i = 1; i <= 4; i++)
            {
                _coordsX[i] = coordX[i];
                _coordsY[i] = coordY[i];
            }
        }

        //overloaded multiply operator
        public static Rhombus operator *(Rhombus rhomb, int number)
        {
            double[] coordsX = new double[5];
            double[] coordsY = new double[5];

            for(int i = 1; i<= 4; i++)
            {
                coordsX[i] = rhomb._coordsX[i] * number;
                coordsY[i] = rhomb._coordsY[i] * number;
            }

            Rhombus new_rhomb = new Rhombus(coordsX, coordsY);
            return new_rhomb;
        }

        //overloaded minus operator
        public static Rhombus operator -(Rhombus left_rhomb, Rhombus right_rhomb)
        {
            double[] coordsX = new double[5];
            double[] coordsY = new double[5];

            for (int i = 1; i <= 4; i++)
            {
                double X = left_rhomb._coordsX[i];
                double Y = left_rhomb._coordsY[i];
                if (X >= right_rhomb._coordsX[i] && Y >= right_rhomb._coordsY[i])
                {
                    coordsX[i] = X - right_rhomb._coordsX[i];
                    coordsY[i] = Y - right_rhomb._coordsY[i];
                }
                else return null;
            }

            return new Rhombus(coordsX, coordsY);
        }

        //rhombus copying
        public static Rhombus CopyRhomb(Rhombus rhomb)
        {
            double[] coordsX = new double[5];
            double[] coordsY = new double[5];

            for (int i = 1; i <= 4; i++)
            {
                coordsX[i] = rhomb._coordsX[i];
                coordsY[i] = rhomb._coordsY[i];
            }

            return new Rhombus(coordsX, coordsY);
        }

        //copyes x coordinates
        public double[] GetCoordsX()
        {
            double[] coordsX = new double[5];

            for (int i = 1; i <= 4; i++)
            {
                coordsX[i] = _coordsX[i];
            }

            return coordsX;
        }

        //copyes y coordinates
        public double[] GetCoordsY()
        {
            double[] coordsY = new double[5];

            for (int i = 1; i <= 4; i++)
            {
                coordsY[i] = _coordsY[i];
            }

            return coordsY;
        }

    }
}
