#include <iostream>
#include "head.h";
using namespace std;

int main()
{
    //coordinates
    double x1, y1, x2, y2;

    //input
    cout << "Input your coordinates (x1, y1, x2, y2)\n";
    cin >> x1 >> y1 >> x2 >> y2;

    //new section
    Segment sec_1 = Segment(x1, y1, x2, y2);

    //corodinates and length print
    thePrint(sec_1);
    
    //minus five
    sec_1.MinusFive();

    //corodinates and length print
    thePrint(sec_1);
}

//corodinates and length print
void thePrint(Segment sec_1)
{
    double* arr_sec_1 = sec_1.GetCoordsArray();
    cout << "\ncoord x1 == " << arr_sec_1[0] << "\n";
    cout << "coord y1 == " << arr_sec_1[1] << "\n";
    cout << "coord x2 == " << arr_sec_1[2] << "\n";
    cout << "coord y2 == " << arr_sec_1[3] << "\n";

    double len = sec_1.GetLength();
    printf("Your segment length is %.3f", len);
    cout << "\n";
}