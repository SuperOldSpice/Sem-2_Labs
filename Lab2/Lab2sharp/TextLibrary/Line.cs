using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLibrary
{
    public class Line       //lines class
    {
        private int _length;        //length
        private char[] _arr;        //array
        public Line()       //line default constructor
        {
            _arr = new char[1];
            _length = 0;
            _arr[0] = '\0';
        }

        public Line(char[] line)        //own line constructor
        {
            _length = FindLength(line);
            _arr = new char[_length + 1];
            for(int j = 0; j <= _length; j ++)
            {
                _arr[j] = line[j];
            }
            _arr[_length] = '\0';
        }

        public char[] GetLine()         //get the line
        {
            return _arr;
        }

        public int GetLength()      //get the length
        {
            return _length;
        }
        private int FindLength(char[] line)         //searchs the length
        {
            int i = 0;
            while (line[i] != '\0')
            {
                i++;
            }
            return i;
        }
    }
}
