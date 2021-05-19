#pragma once
#include <iostream>
#include <math.h>
using namespace std;

class Formula 
{
public:
    Formula()
    {
        _a = 0;
        _b = 0;
        _c = 0;
        _d = 0;
    }
    Formula(int a, int b, int c, int d)
    {
        _a = a;
        _b = b;
        _c = c;
        _d = d;
    }

    double FindValue()
    {
        double val;
        try
        {
            if (24 + _d - _c < 0)
                throw ("You cant get a square root from negative number");
            val = 1 + _a - _b / 2;
            val = val / (sqrt(24 + _d - _c) + _a / _b);
        }
        catch (string* messeage)
        {
            cout << messeage << "\n";
        }
        

        return val;
    }

private:
    int _a, _b, _c, _d;
};
