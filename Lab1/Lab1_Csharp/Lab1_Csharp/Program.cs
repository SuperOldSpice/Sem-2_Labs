using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int first, second;
            char c;
            Console.WriteLine("Operation is 'minus one'?(y/n): ");
            c = Convert.ToChar(Console.ReadLine());
            if(c == 'y')                                        // go to minus one
            {
                Console.WriteLine("Input your number: ");
                first = Convert.ToInt32(Console.ReadLine());
                log1(ref first);
                Console.WriteLine($"Your number minus one: {first}");
            }
            else                                                // go to compare numbers
            {
                Console.WriteLine("Input your first number: ");
                first = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input your second number: ");
                second = Convert.ToInt32(Console.ReadLine());
                int key = log2(first, second);
                if (key == 3)
                {
                    Console.WriteLine("a == b");
                }
                else if (key > 0)
                {
                    Console.WriteLine("a > b");
                }
                else
                {
                    Console.WriteLine("a < b");
                }
            }
            Console.ReadKey();

            
        }


        static void log1(ref int a) // do minus one
        {
            bool bit1 = false;

            for (int i = 0; i < 32 && !bit1; i++) 
            {
                bit1 = Convert.ToBoolean(a & (1 << i));
                if (!bit1)
                {
                    a = a | (1 << i);
                }
                else
                {
                    a = a ^ (1 << i);
                }
            }

        }



        static int log2(int a, int b) // compares two numbers
        {
            int  i, key = -1;
            bool bit1, bit2;

            bit1 = Convert.ToBoolean(a & (1 << 31)); //first bit check (positive or ngative number)
            bit2 = Convert.ToBoolean(b & (1 << 31));
            if (!bit1 && bit2)
            {
                return 1;
            }
            else if (bit1 && !bit2)
            {
                return 0;
            }

            for (i = 31; i > -1; i--) //all other bits check
            {                               
                bit1 = Convert.ToBoolean(a & (1 << i));
                bit2 = Convert.ToBoolean(b & (1 << i));
                if (bit1 && !bit2)
                {
                    key = 1;
                    break;
                }
                else if (!bit1 && bit2)
                {
                    key = 0;
                    break;
                }
            }

            if (i == -1 && key == -1) // same numbers check
            {
                key = 3;
            }

            return key;
        }
    }
}
