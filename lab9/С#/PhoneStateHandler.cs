using System;
using System.Collections.Generic;
using System.Text;

namespace Lab09Library
{
    public delegate void PhoneStateHandler(object sender, PhoneEventArgs e);
    public class PhoneEventArgs
    {
        public string Message { get; private set; }
        public decimal Sum { get; private set; }
        public PhoneEventArgs(string mes, decimal sum)
        {
            Message = mes;
            Sum = sum;
        }
    }
}
