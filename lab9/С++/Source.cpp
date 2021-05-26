#include <iostream>
using namespace std;
int* GetArray(int _elements[2][2]);
int main()
{
    int* (*operation)(int arr[2][2]);
    operation = GetArray;
    int arr[2][2] = { {1, 5, },
                      {1, 2 } };
    int* new_arr = operation(arr);

}

int* GetArray(int _elements[2][2])
{
    int arr[2] = { _elements[0][0], _elements[1][1] };
    cout << "Diagonal array: " << arr[0] << ", " << arr[1] << "\n";
    return arr;
}