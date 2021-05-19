using System;

namespace FormulaLibrary
{
    public class Formula
    {
        private int _a, _b, _c, _d;
        public Formula(int a, int b, int c, int d)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
        }

        public double FindValue()
        {
            double val;
            try
            {
                if(24 + _d - _c < 0)
                    throw new Exception("You cant get a square root from negative number");
                val = 1 + _a - _b / 2;
                val = val / (Math.Sqrt(24 + _d - _c) + _a / _b);
            }
            catch(DivideByZeroException)
            {
                throw new Exception("You cant divide by null!");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return val;
        }
    }
}
