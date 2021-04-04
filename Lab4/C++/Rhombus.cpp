#include "head.h"


    

    //default creation
    Rhombus::Rhombus()
    {
        _coordsX[1] = 0; _coordsY[1] = 0;
        _coordsX[2] = 0; _coordsY[2] = 1;
        _coordsX[3] = 1; _coordsY[3] = 1;
        _coordsX[4] = 1; _coordsY[4] = 0;
    }

    //parametric creation
    Rhombus::Rhombus(double* coordX, double* coordY)
    {
        for (int i = 1; i <= 4; i++)
        {
            _coordsX[i] = coordX[i];
            _coordsY[i] = coordY[i];
        }
    }

    //overloaded multiply operator
    Rhombus  Rhombus::operator * (int number)
    {
        double* coordsX = new double[5];
        double* coordsY = new double[5];

        for (int i = 1; i <= 4; i++)
        {
            coordsX[i] = this->_coordsX[i] * number;
            coordsY[i] = this->_coordsY[i] * number;
        }

        Rhombus new_rhomb =  Rhombus(coordsX, coordsY);
        return new_rhomb;
    }

    //overloaded minus operator
    Rhombus Rhombus::operator - (Rhombus right_rhomb)
    {
        double* coordsX = new double[5];
        double* coordsY = new double[5];

        for (int i = 1; i <= 4; i++)
        {
            double X = this->_coordsX[i];
            double Y = this->_coordsY[i];
           
            {
                coordsX[i] = X - right_rhomb._coordsX[i];
                coordsY[i] = Y - right_rhomb._coordsY[i];
            }
            
        }

        return  Rhombus(coordsX, coordsY);
    }

    //rhombus copying
    Rhombus Rhombus::  CopyRhomb (Rhombus rhomb)
    {
        double* coordsX = new double[5];
        double* coordsY = new double[5];

        for (int i = 1; i <= 4; i++)
        {
            coordsX[i] = rhomb._coordsX[i];
            coordsY[i] = rhomb._coordsY[i];
        }

        return  Rhombus(coordsX, coordsY);
    }

    //copyes x coordinates
    double* Rhombus:: GetCoordsX()
    {
        double* coordsX = new double[5];

        for (int i = 1; i <= 4; i++)
        {
            coordsX[i] = _coordsX[i];
        }

        return coordsX;
    }

    //copyes y coordinates
    double*  Rhombus:: GetCoordsY()
    {
        double* coordsY = new double[5];

        for (int i = 1; i <= 4; i++)
        {
            coordsY[i] = _coordsY[i];
        }

        return coordsY;
    }

