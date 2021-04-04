#include "head.h"

    int main()
    {


        //P1 P2 creation
        Rhombus P1 =  Rhombus();
        Rhombus P2 =  Rhombus();

        //P3 input and creation
        cout << ("Create P3:\n");
        //example: 0 0 / 2 2 / 5 2 / 3 0 /
        double* coordsX = new double[5];
        double* coordsY = new double[5];
        for (int i = 1; i <= 4; i++)
        {
            cout << "Input X" << i << " coordinate:\n";
            cin >> coordsX[i];
            cout << "Input Y" << i << " coordinate:\n";
            cin >> coordsY[i];
            cout << "\n";
        }
        Rhombus P3 = Rhombus(coordsX, coordsY);

        //coordinates print
        RhombsPrint(P1, P2, P3);

        //P3 by 3 multiply
        P3 = P3 * 3;

        //P3 minus P2 copy to P1
        P1 = P1.CopyRhomb(P3 - P2);

        //coordinates print
        RhombsPrint(P1, P2, P3);

    }

    //coordinates print
    void RhombsPrint(Rhombus P1, Rhombus P2, Rhombus P3)
    {
        cout << "Rhomb P1:\n";
        double* coordsX = P1.GetCoordsX();
        double* coordsY = P1.GetCoordsY();
        for (int i = 1; i <= 4; i++)
        {
            cout << "X" << i << " == " << coordsX[i] <<  "  Y" << i << " == " << coordsY[i] << "\n";
        }
        cout << "\n";

        cout << "Rhomb P2:\n";
        coordsX = P2.GetCoordsX();
        coordsY = P2.GetCoordsY();
        for (int i = 1; i <= 4; i++)
        {
            cout << "X" << i << " == " << coordsX[i] << "  Y" << i << " == " << coordsY[i] << "\n";
        }
        cout << "\n";

        cout << "Rhomb P3:\n";
        coordsX = P3.GetCoordsX();
        coordsY = P3.GetCoordsY();
        for (int i = 1; i <= 4; i++)
        {
            cout << "X" << i << " == " << coordsX[i] << "  Y" << i << " == " << coordsY[i] << "\n";
        }

        cout << "\n";
        for (int j = 0; j <= 2; j++)
        cout << "////////////////////////////////////////\n";
        cout << "\n";
    }

