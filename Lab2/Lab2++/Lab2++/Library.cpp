#include "Library.h"

//////////////
/////Line
/////////////

Line::Line()           //default constructor
{
    _arr = new char[1];
    _length = 0;
    _arr[0] = '\n';
}

Line::Line(char* line) //own constructor
{
    _length = FindLength(line);
    _arr = new char[_length + 1];
    for (int j = 0; j <= _length; j++)
    {
        _arr[j] = line[j];
    }
    _arr[_length] = '\n';
}

char* Line::GetLine()  //get line
{
    return _arr;
}

int Line::GetLength() //get length
{
    return _length;
}

int Line::FindLength(char* line) //search the length
{
    int i = 0;
    while (line[i] != '\n')
    {
        i++;
    }
    return i;
}

///////////
///LinesCollection
///////////

LineCollection::LineCollection(Line line)  //container construct
{
    _linesNumber = 1;
    _myLines = new Line[1];
    _myLines[0] = line;
}

void LineCollection::AddLine(Line line)  //add line to container
{
    Line* copy = new Line[_linesNumber];
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
    delete[] copy;
}

char** LineCollection::GetLines()   //to print lines
{
    char** text = new char* [_linesNumber];
    for (int i = 0; i < _linesNumber; i++)
    {
        int length = _myLines[i].GetLength();
        char* str = _myLines[i].GetLine();
        text[i] = new char[length + 1];
        for (int j = 0; j <= length; j++)
        {
            text[i][j] = str[j];
        }
    }
    return text;
}

int LineCollection::GetLinesNumber()   //lines number
{
    return _linesNumber;
}

bool LineCollection::DeleteLine(int n) //delete some line 
{
    if (n >= _linesNumber)
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
        Line* copy = CopyArray(_myLines, _linesNumber, _linesNumber);
        delete[] _myLines;
        _myLines = new Line[_linesNumber];
        _myLines = CopyArray(copy, _linesNumber, _linesNumber);
        delete[] copy;
        return true;
    }
}

void LineCollection::DeleteAll() //clear the container
{
    delete[] _myLines;
    _myLines = new Line[1];
    _linesNumber = 0;
}

int LineCollection::HowMuch(int size)  //searhs how much lines with some size do we have
{
    int k = 0;
    for (int i = 0; i < _linesNumber; i++)
    {
        if (size == _myLines[i].GetLength()) k++;
    }
    return k;
}

void LineCollection::ToUpRegister() //changes first letter to upper register
{
    for (int i = 0; i < _linesNumber; i++)
    {
        int length = _myLines[i].GetLength();
        char* str = _myLines[i].GetLine();
        for (int j = 0; j < length; j++)
        {
            int k = (str[j]);
            if (j == 0 && k != ' ' && k > 96 && k < 123)
            {
                str[j] = (k - 32);
            }
            else if (j > 0 && (str[j - 1]) == ' ' && k != ' ' && k > 96 && k < 123)
            {
                str[j] = (k - 32);
            }
        }
    }
}

char** LineCollection::KeyWords()   //make the key - words
{
    char** _keyWords = new char* [_linesNumber];
    for (int i = 0; i < _linesNumber; i++)
    {
        int length = _myLines[i].GetLength();
        char* str = _myLines[i].GetLine();
        int index = 0, size = 0;
        for (int j = 0; j < length; j++)
        {
            int k = (str[j]);
            if (j == 0 && k != ' ')
            {
                size++;
            }
            else if (j > 0 && (str[j - 1]) == ' ' && k != ' ')
            {
                size++;
            }
        }

        _keyWords[i] = new char[size + 1];

        for (int j = 0; j < length; j++)
        {
            int k = (str[j]);
            if (j == 0 && k != ' ')
            {
                _keyWords[i][index] = str[j];
                index++;
            }
            else if (j > 0 && (str[j - 1]) == ' ' && k != ' ')
            {
                _keyWords[i][index] = str[j];
                index++;
            }
        }

        _keyWords[i][size] = '\n';
    }
    return _keyWords;
}

Line* LineCollection::CopyArray(Line* lines, int oldSize, int newSize) // makes a copy of array
{
    Line* copy = new Line[newSize];
    for (int n = 0; n < oldSize; n++)
    {
        copy[n] = lines[n];
    }
    return copy;
}

///////////
///functions
///////////

char* LineInput()   //string input 
{
    char* line = new char[1];
    char* copy = new char[1];
    char a;
    a = cin.get();
    int i = 0;
    while (a != '\n')
    {
        line = new char[i + 2];
        for (int j = 0; j < i; j++)
        {
            line[j] = copy[j];
        }
        line[i] = a;
        copy = new char[i + 1];
        for (int j = 0; j < (i + 1); j++)
        {
            copy[j] = line[j];
        }
        i++;
        a = cin.get();
    }
    line[i] = '\n';
    return line;
}

void PrintLines(LineCollection lines) //lines print
{
    char** text = lines.GetLines();
    int linesNumber = lines.GetLinesNumber();
    for (int i = 0; i < linesNumber; i++)
    {
        int j = 0;
        while (text[i][j] != '\n')
        {
            cout << (text[i][j]);
            j++;
        }
        cout << endl;
    }
}

void PrintLines(LineCollection lines, string h)  //keywords print
{
    char** text = lines.KeyWords();
    int linesNumber = lines.GetLinesNumber();
    for (int i = 0; i < linesNumber; i++)
    {
        int j = 0;
        while (text[i][j] != '\n')
        {
            cout << (text[i][j]);
            j++;
        }
        cout << endl;
    }
}