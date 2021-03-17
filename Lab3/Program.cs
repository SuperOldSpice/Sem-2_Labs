using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayLibrary;

namespace Lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            int number_of_strings; //number of strings
            string[] strings = Input(out number_of_strings);  //strings array

            MyArray myStrings = new MyArray(strings, number_of_strings); //new class object

            Console.WriteLine("Input the number of string you wanna get:");
            int string_number = Convert.ToInt32(Console.ReadLine());
            string s = myStrings[string_number];
            Console.WriteLine("Your string:");
            Console.WriteLine(s);
            Console.Write("\n");

            int number_of_consonants = myStrings.GetConsonantsNumber;  // number of consonants

            Console.WriteLine("Number of consonants in array: {0}", number_of_consonants); //output
            Console.ReadKey();
        }

        static string[] Input(out int n)  //strings input
        {
            Console.WriteLine("Input number of strings:");
            n = Convert.ToInt32(Console.ReadLine());
            string[] strings = new string[n];
            Console.Write("\n");
            Console.WriteLine("Input your strings:");
            for (int i = 0; i < n; i++)
            {
                strings[i] = Console.ReadLine();
            }
            Console.Write("\n");
            return strings;
        }
    }
}
