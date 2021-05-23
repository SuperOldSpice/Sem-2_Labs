using System;
using NodesLibrary;
namespace Lab08sharp
{
    class Program
    {
        static void Main(string[] args)
        {
               
            MyNodes list = new MyNodes(11);
            list.AddLast(10);
            list.AddLast(1);
            list.AddLast(20);
            list.AddLast(1);
            list.AddLast(1);
            list.AddLast(11);
            PrintNodes(list);
            int count = list.FindPairFive();
            Console.WriteLine($"Number of pair elements, that multiplies five: {count}");
            Console.WriteLine($"Avereage: {list.DeleteBiggerElements()}");
            PrintNodes(list);
        }

        public static void PrintNodes(MyNodes list)
        {
            long[] arr = list.GetList();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"N{i+1}: {arr[i]}");
            }
        }
    }
}
