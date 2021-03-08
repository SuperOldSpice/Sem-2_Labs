using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextLibrary
{
    public class LineCollection         //class container for lines
    {
        private int _linesNumber = 0;       //number of lines
        private Line[] _myLines;            //container

        public LineCollection(Line line)        //container
        {
            _linesNumber = 1;
            _myLines = new Line[1];
            _myLines[0] = line;
        }

        public void AddLine(Line line)          //adds line in container
        {
            Line[] copy = new Line[_linesNumber];
            for (int i = 0; i < _linesNumber; i++)
            {
                copy[i] = _myLines[i];
            }
            _linesNumber++;
            _myLines = new Line[_linesNumber];
            for (int i = 0; i < (_linesNumber - 1); i++)
            {
                _myLines[i] = copy[i];
            }
            _myLines[_linesNumber - 1] = line;
        }

        public char[][] GetLines()          //get lines from container
        {
            char[][] text = new char[_linesNumber][];
            for (int i = 0; i < _linesNumber; i++)
            {
                int length = _myLines[i].GetLength();
                char[] str = _myLines[i].GetLine();
                text[i] = new char[length + 1];
                for (int j = 0; j <= length; j++)
                {
                    text[i][j] = str[j];
                }
            }
            return text;
        }

        public int GetLinesNumber()     //gets number of lines
        {
            return _linesNumber;
        }

        public bool DeleteLine(int n)       //delete some line
        {
            if(n >= _linesNumber)
            {
                return false;
            }
            else
            {
                _linesNumber--;
                for (int i = n; i < _linesNumber; i++)
                {
                    _myLines[i] = _myLines[i + 1];
                }
                Line[] copy = CopyArray(_myLines, _linesNumber, _linesNumber);
                _myLines = new Line[_linesNumber];
                _myLines = CopyArray(copy, _linesNumber, _linesNumber);
                return true;
            }
        }

        public void DeleteAll()         //delets all lines
        {
            _myLines = new Line[1];
            _linesNumber = 0;
        }

        public int HowMuch(int size)
        {
            int k = 0;
            for(int i = 0; i < _linesNumber; i++)
            {
                if (size == _myLines[i].GetLength()) k++;
            }
            return k;
        }

        public void ToUpRegister()      //get first letters to upper register
        {
            for (int i = 0; i < _linesNumber; i++)
            {
                int length = _myLines[i].GetLength();
                char[] str = _myLines[i].GetLine();
                for(int j = 0; j < length; j++)
                {
                    int k = Convert.ToInt32(str[j]);
                    if (j == 0 && k != ' ' && k > 96 && k < 123)
                    {
                        str[j] = Convert.ToChar(k - 32);
                    }
                    else if(j > 0 && Convert.ToInt32(str[j-1]) == ' ' && k != ' ' && k > 96 && k < 123)
                    {
                        str[j] = Convert.ToChar(k - 32);
                    }
                }
            }
        }

        public char[][] KeyWords()      //make key-words
        {
            char[][] _keyWords = new char[_linesNumber][];
            for (int i = 0; i < _linesNumber; i++)
            {
                int length = _myLines[i].GetLength();
                char[] str = _myLines[i].GetLine();
                int index = 0, size = 0;
                for (int j = 0; j < length; j++)
                {
                    int k = Convert.ToInt32(str[j]);
                    if (j == 0 && k != ' ')
                    {
                        size++;
                    }
                    else if (j > 0 && Convert.ToInt32(str[j - 1]) == ' ' && k != ' ')
                    {
                        size++;
                    }
                }

                _keyWords[i] = new char[size + 1];

                for (int j = 0; j < length; j++)
                {
                    int k = Convert.ToInt32(str[j]);
                    if (j == 0 && k != ' ')
                    {
                        _keyWords[i][index] = str[j];
                        index++;
                    }
                    else if (j > 0 && Convert.ToInt32(str[j - 1]) == ' ' && k != ' ')
                    {
                        _keyWords[i][index] = str[j];
                        index++;
                    }
                }

                _keyWords[i][size] = '\0';
            }
            return _keyWords;
        }

        private Line[] CopyArray(Line[] lines, int oldSize, int newSize)        //make the copy
        {
            Line[] copy = new Line[newSize];
            for(int n = 0; n < oldSize; n++)
            {
                copy[n] = lines[n];
            }
            return copy;
        }

    }
}
