using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RhombusLibrary;

namespace Lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            //P1 P2 creation
            Rhombus P1 = new Rhombus();
            Rhombus P2 = new Rhombus();

            //P3 input and creation
            Console.WriteLine("Create P3:\n");
            //example: 0 0 / 2 2 / 5 2 / 3 0 /
            double[] coordsX = new double[5];
            double[] coordsY = new double[5];
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine($"Input X{i} coordinate:");
                coordsX[i] = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine($"Input Y{i} coordinate:");
                coordsY[i] = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
            }
            Rhombus P3 = new Rhombus(coordsX, coordsY);

            //coordinates print
            RhombsPrint(P1, P2, P3);

            //P3 by 3 multiply
            P3 = P3 * 3;

            //P3 minus P2 copy to P1
            P1 = Rhombus.CopyRhomb(P3 - P2);

            //coordinates print
            RhombsPrint( P1,  P2,  P3);

            //wait...
            Console.ReadKey();
        }

        //coordinates print
        public static void RhombsPrint( Rhombus P1, Rhombus P2, Rhombus P3)
        {
            Console.WriteLine("Rhomb P1:");
            double [] coordsX = P1.GetCoordsX();
            double [] coordsY = P1.GetCoordsY();
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine($"X{i} == {coordsX[i]} Y{i} == {coordsY[i]}");
            }
            Console.WriteLine();

            Console.WriteLine("Rhomb P2:");
            coordsX = P2.GetCoordsX();
            coordsY = P2.GetCoordsY();
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine($"X{i} == {coordsX[i]} Y{i} == {coordsY[i]}");
            }
            Console.WriteLine();

            Console.WriteLine("Rhomb P3:");
            coordsX = P3.GetCoordsX();
            coordsY = P3.GetCoordsY();
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine($"X{i} == {coordsX[i]} Y{i} == {coordsY[i]}");
            }

            Console.WriteLine();
            for(int j = 0; j <= 2; j++)
            Console.WriteLine("////////////////////////////////////////");
            Console.WriteLine();
        }
    }
}
