using System;
using LinesLibrary;

namespace Lab06
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            Console.WriteLine("Enter the line:");
            string new_line = Console.ReadLine();
            Line line_1 = new Line(new_line);
            
            Console.WriteLine("Enter the digits:");
            new_line = Console.ReadLine();
            Line digits_1 = new Digits(new_line);
            
            Console.WriteLine("Enter the small letters:");
            new_line = Console.ReadLine();
            Line small_1 = new SmallLetters(new_line);

            //move the line
            line_1.Move();
            digits_1.Move();
            small_1.Move();
            
            //output
            Console.WriteLine("\nline_1 length: " + line_1.Length());
            Console.WriteLine("digits_1 length: " + digits_1.Length());
            Console.WriteLine("small_1 length: " + small_1.Length());

            Console.WriteLine("\nline_1: " + line_1.line);
            Console.WriteLine("digits_1: " + digits_1.line);
            Console.WriteLine("small_1: " + small_1.line);
        }
    }
}
