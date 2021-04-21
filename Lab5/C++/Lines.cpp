#include "head.h";
#include <Math.h>

    

    //parametric constructor
    Lines::Lines(double x1, double y1, double x2, double y2)
    {
        _x1 = x1;
        _x2 = x2;
        _y1 = y1;
        _y2 = y2;
    }

    //returns line`s length 
    double Lines::GetLength()
    {
        double length;
        length = sqrt(pow((_x2 - _x1), 2) + pow((_y2 - _y1), 2));
        return length;
    }

