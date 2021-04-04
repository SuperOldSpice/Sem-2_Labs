#pragma once
#include <iostream>
using namespace std;

class Rhombus
{
    private:
        //coordinetes
        double* _coordsY = new double[5];
        double* _coordsX = new double[5];

    public:
        //default creation
        Rhombus();


        //parametric creation
        Rhombus(double* coordX, double* coordY);


        //overloaded multiply operator
        Rhombus  operator * (int number);


        //overloaded minus operator
        Rhombus operator - (Rhombus right_rhomb);


        //rhombus copying
        static Rhombus CopyRhomb(Rhombus rhomb);


        //copyes x coordinates
        double* GetCoordsX();


        //copyes y coordinates
        double* GetCoordsY();

};

void RhombsPrint(Rhombus P1, Rhombus P2, Rhombus P3);