using System;
using System.Collections.Generic;
using System.Text;

namespace LinesLibrary
{
    public class SmallLetters : Line
    {
        //constructor
        public SmallLetters(string line) : base(line)
        {
           _line = line.ToLower(); 
        }
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
            for (int i = 0; i < _line.Length - 1; i++)
            {

                new_line[i] = _line[i + 1];
            }
            new_line[n - 1] = _line[0];
            _line = new string(new_line); 
        }
    }
}
