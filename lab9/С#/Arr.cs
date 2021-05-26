using System;

namespace Lab09Library
{
    public class Arr
    {
        public delegate void ArrHandler(string message);
        private event ArrHandler Notify;
        private int[,] _elements;
        public Arr(int[,] arr, ArrHandler ev)
        {
            _elements = arr;
            Notify += ev;
        }

        public int[] GetArray()
        {
            int[] arr = new int[] {_elements[0, 0], _elements[1, 1]};
            Notify?.Invoke("Your array: " + arr[0] + ", " + arr[1]);
            return arr;
        }
    }
}
