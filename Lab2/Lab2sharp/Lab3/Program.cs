using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextLibrary;
namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input your first line:");
            char[] line = LineInput();      //input first line
            Line _line = new Line(line);        //creating of the first line class instance
            LineCollection lines = new LineCollection(_line);       //out container
            bool skip = false;                      
            Console.WriteLine("To finish the running press 0");         //menu
            Console.WriteLine("To add new string press 1");
            Console.WriteLine("To delete the string press 2");
            Console.WriteLine("To delete all strings press 3");
            Console.WriteLine("To find how much lines with some length the text has press 4");
            Console.WriteLine("To get the first letter to upper register press 5");
            Console.WriteLine("To make the key-words press 6");
            Console.WriteLine("To stop the program press Enter");
            Console.ReadLine();
            while (!skip)           //operation choice
            {
                string key;
                Console.WriteLine("Select the operation:");
                key = Console.ReadLine();
                switch (key)
                {
                    case "0":       //finish the running press
                        skip = true;
                        break;

                    case "1":
                        Console.WriteLine("Write your line:");      //add new string
                        line = LineInput();
                        _line = new Line(line);
                        lines.AddLine(_line);
                        Console.WriteLine("Your lines:");
                        PrintLines(lines);
                        Console.WriteLine();
                        Console.ReadLine();
                        break;

                    case "2":
                        int n;
                        Console.WriteLine("Select the Line:");      //delete the string
                        n = Convert.ToInt32(Console.ReadLine());
                        bool check = lines.DeleteLine(n);
                        if (!check) Console.WriteLine("The Line is Missing");
                        else
                        {
                            Console.WriteLine("Your lines:");
                            PrintLines(lines);
                        }
                        Console.WriteLine();
                        break;

                    case "3":                   //delete all strings
                        lines.DeleteAll();
                        Console.WriteLine("Your lines:");
                        PrintLines(lines);
                        Console.WriteLine();
                        break;

                    case "4":                   //finds how much lines with some length the text has
                        Console.WriteLine("Write the length of searching lines");
                        n = Convert.ToInt32(Console.ReadLine());
                        n = lines.HowMuch(n);
                        Console.WriteLine("The text has {0} lines with that length", n);
                        Console.WriteLine(); 
                        break;

                    case "5":
                        lines.ToUpRegister();       //gets first letters to upper register
                        Console.WriteLine("Your lines:");
                        PrintLines(lines);
                        Console.WriteLine();
                        break;

                    case "6":           //make key - words
                        Console.WriteLine("Key-words:");
                        PrintLines(lines, "keys");
                        Console.WriteLine();
                        break;

                    default:            //defauls (stop)
                        skip = true;
                        break;
                }
            }
        }

        static public char[] LineInput() //string input
        {
            char[] line = new char[1];
            char[] copy = new char[1];
            char a;
            a = Convert.ToChar(Console.Read());
            int i = 0;
            while (a != '\r')
            {
                line = new char[i + 2];
                for (int j = 0; j < i; j++)
                {
                    line[j] = copy[j];
                }
                line[i] = a;
                copy = new char[i+1];
                for(int j = 0; j < (i+1); j++)
                {
                    copy[j] = line[j];
                }
                i++;
                a = Convert.ToChar(Console.Read());
            }
            line[i] = '\0';
            return line;
        }

        static public void PrintLines(LineCollection lines)     //print lines
        {
            char[][] text = lines.GetLines();
            int linesNumber = lines.GetLinesNumber();
            for(int i = 0; i < linesNumber; i++)
            {
                int j = 0;
                while(text[i][j] != '\0')
                {
                    Console.Write(text[i][j]);
                    j++;
                }
                Console.WriteLine();
            }
        }

        static public void PrintLines(LineCollection lines, string h)       //print key-words
        {
            char[][] text = lines.KeyWords();
            int linesNumber = lines.GetLinesNumber();
            for (int i = 0; i < linesNumber; i++)
            {
                int j = 0;
                while (text[i][j] != '\0')
                {
                    Console.Write(text[i][j]);
                    j++;
                }
                Console.WriteLine();
            }
        }
    }
}
