#include "head.h"

int main()
{
    Formula* arr = new Formula[3];
    for (int i = 0; i < sizeof(arr); i++)
    {
        arr[i] = Formula(20, 5, 5, 5);
    }
    arr[0] = Formula(5, 5, 5, 5);
    //arr[1] = Formula(5, 0, 5, 5);
    arr[2] = Formula(5, 5, 100, 5);
    cout.precision(4);
    for (int i = 0; i < sizeof(arr); i++)
    {
        try
        {
            cout << i << ". The result is:" << fixed << arr[i].FindValue() << endl;
        }
        catch (string messeage)
        {
            throw messeage;
        }  
    }
}