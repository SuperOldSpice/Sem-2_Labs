#include "head.h"
#include <iostream>

    //constructor
    Segment :: Segment(double x1, double y1, double x2, double y2) : Lines(x1, y1, x2, y2)
    {
    }

    //decrease five 
    void Segment :: MinusFive()
    {
        if (_x2 - 5 >= _x1 && _y2 - 5 >= _y1)
        {
            _x2 -= 5;
            _y2 -= 5;
        }
        else
        {
            _x1 = 0;
            _x2 = 0;
            _y1 = 0;
            _y2 = 0;
        }
    }

    //returns array with coordinates
    double* Segment :: GetCoordsArray()
    {
        static double arr[4];
        arr[0] = _x1;
        arr[1] = _y1;
        arr[2] = _x2;
        arr[3] = _y2;
        return arr;
    }
