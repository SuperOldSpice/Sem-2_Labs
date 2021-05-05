using System;

namespace LinesLibrary
{
    public class Line
    {
        //line
        protected string _line;
        //line getter
        public string line
        {
            get
            {
                return _line;
            }
        }
        //constructor
        public Line(string line)
        {
            _line = line;
        }
        //length
        public virtual int Length()
        {
            return _line.Length;
        }
        //move the line 
        public virtual  void Move()
        {
            int n = _line.Length - 1;
            char[] new_line = new char[n];
            for (int i = 0; i < _line.Length  - 1; i++)
            {
                new_line[i] = _line[i + 1];
            }
            _line = new string(new_line);
        }
    }
}
