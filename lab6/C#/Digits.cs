using System;
using System.Collections.Generic;
using System.Text;

namespace LinesLibrary
{
    public class Digits : Line
    {
        //constructor
        public Digits(string line) : base(line) { }
        //length
        public override int Length()
        {
            return base.Length();
        }
        //move
        public override void Move()
        {
            int n = _line.Length;
            char[] new_line = new char[n];
            new_line[0] = _line[_line.Length - 1];
            for (int i = 1 ; i < _line.Length; i++)
            {
                
                new_line[i] = _line[i - 1];
            }
            _line = new string(new_line);
        }
        //integer 

        public int Number()
        {
            return Convert.ToInt32(_line);
        }
    }
}
