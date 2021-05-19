using System;
using FormulaLibrary;
namespace Lab07sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Formula[] arr = new Formula[3];
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = new  Formula(20, 5, 5, 5);
            }
            arr[0] = new Formula(5, 5, 5, 5);
            //arr[1] = new Formula(5, 0, 5, 5);
            arr[2] = new Formula(5, 5, 100, 5);
            for (int i = 0; i < arr.Length; i ++)
            {
                Console.WriteLine($"{i}. The result is: {String.Format("{0:0.0000}", arr[i].FindValue())}");
                /*try
                {
                    Console.WriteLine($"{i}. The result is: {String.Format("{0:0.0000}", arr[i].FindValue())}");                  
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    Console.WriteLine("\nThe value was found successfully\n");
                }*/
            }
            
        }
   
    }
}
