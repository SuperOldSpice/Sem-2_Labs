using System;
using LinesLibrary;

namespace Lab05
{
    class Program
    {
        static void Main(string[] args)
        {
            //coordinates
            double x1, y1, x2, y2;
            
            //input
            Console.WriteLine("Input your coordinates (x1, y1, x2, y2)");
            string line = Console.ReadLine();
            string[] new_line = line.Split(' ');
            x1 = double.Parse(new_line[0]);
            y1 = double.Parse(new_line[1]);
            x2 = double.Parse(new_line[2]);
            y2 = double.Parse(new_line[3]);

            //new section
            Segment sec_1 = new Segment(x1, y1, x2, y2);

            //corodinates and length print
            print(sec_1);

            //minus five
            sec_1.MinusFive();

            //corodinates and length print
            print(sec_1);

        }

        static void print(Segment sec_1)
        {
            //corodinates print
            double[] arr_sec_1 = sec_1.GetCoordsArray();
            Console.WriteLine($"\ncoord x1 == {arr_sec_1[0]}");
            Console.WriteLine($"coord y1 == {arr_sec_1[1]}");
            Console.WriteLine($"coord x2 == {arr_sec_1[2]}");
            Console.WriteLine($"coord y2 == {arr_sec_1[3]}\n");

            //length print
            double len = sec_1.GetLength();
            Console.WriteLine($"Your segment length is {string.Format("{0:0.000}", len)}");
        }

    }

    
}
