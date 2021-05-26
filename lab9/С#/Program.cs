using System;
using Lab09Library;
namespace Lab09sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[,] { { 1, 5 },
                                      { 1, 2 }
            };
            Arr new_arr = new Arr(arr, DisplayMessage);
            int[] line = new_arr.GetArray();
            Console.WriteLine("\n/////////////////////////////\n");
            Phone nokia = new Phone("nokia", DisplayPhoneMessage);
            nokia.ActivatePhone();
            nokia.Put(500);
            nokia.Talk(2);
            nokia.CheckStatus();

        }

        private static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        private static void DisplayPhoneMessage(object sender, PhoneEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
