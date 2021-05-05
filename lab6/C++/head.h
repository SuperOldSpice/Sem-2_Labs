#pragma once
#include <iostream>
#include <string>
#include <cctype>
#include <algorithm>
using namespace std;

class Line 
{
    //line
protected:
    string _line;

public:
    //line getter
    string line()
    {
        return _line;
    }
    //constructor
    Line(string line)
    {
        _line = line;
    }
    //length
    virtual int Length()
    {
        return _line.length();
    }
    //move the line 
    virtual  void Move()
    {
        int n = _line.length() - 1;
        string new_line;
        for (int i = 0; i < _line.length() - 1; i++)
        {
            _line[i] = _line[i + 1];
        }
        _line[n] = '\0';

    }
};

class Digits : public Line
{

public:

    //constructor
    Digits(string line) : Line(line) { }
    //length
    int Length() override
    {
        return Line::Length();
    }
    //move
    void Move() override
    {
        int n = _line.length();
        char a = _line[n - 1];
        for (int i = _line.length() - 1; i > 0 ; i--)
        {
            _line[i] = _line[i - 1];
        }
        _line[0] = a;
    }
    //integer number from digits

    int Number()
    {
        return stoi(_line);
    }
};

class SmallLetters : public Line
{

public:
    //constructor
    SmallLetters(string line) : Line(line)
    {
        _line = line;
        transform(_line.begin(), _line.end(), _line.begin(), 
            [](unsigned char c)
            { return tolower(c); });
    }
    //length
    int Length() override
    {
        return Line::Length();
    }
    //move
    void Move() override
    {
        int n = _line.length();
        char a = _line[0];
        for (int i = 0; i < _line.length() - 1; i++)
        {

            _line[i] = _line[i + 1];
        }
        _line[n - 1] = a;
    }
};