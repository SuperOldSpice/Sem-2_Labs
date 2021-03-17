using System;

namespace ArrayLibrary
{
    public class MyArray
    {
        private string[] _strings; //strings array
        private int _length;        //number of strings
        private int _consonants_number;     //number of consonants
        public MyArray(string[] str, int n)     //constructor
        {
            _length = n;
            _strings = new string[_length];
            for (int i = 0; i < _length; i++)
            {
                _strings[i] = str[i];
            }
        }

        public void PrintStrings()      //array output
        {
            for (int i = 0; i < _length; i++)
            {
                Console.WriteLine(_strings[i]);
            }
        }

        public string this[int index]      //property get string
        {
            get
            {
                return _strings[index];
            }
            set
            {
                _strings[index] = value;
            }
        }

        public int GetConsonantsNumber      //property get consonants number
        {
            get
            {
                int counter = 0;

                for(int i = 0; i < _length; i++)
                {
                    string str = _strings[i].ToLower();

                    for (int j = 0; j < str.Length; j++)
                    {
                        string letter = str[j].ToString();

                        if (!"aeouyi".Contains(letter) && letter != " ")
                        {
                            counter++;
                        }
                    }

                }

                _consonants_number = counter;

                return _consonants_number;
            }
        }
    }
}
