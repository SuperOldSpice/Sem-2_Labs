
#include "head.h";


int main()
{
    //input
    cout << "Enter the line:\n";
    string new_line;
    cin >> new_line;
    Line line_1 = Line(new_line);

    cout << "Enter the digits:\n";
    cin >> new_line;
    Digits digits_1 = Digits(new_line);

    cout << "Enter the small letters:\n";
    cin >> new_line;
    SmallLetters small_1 = SmallLetters(new_line);

    //move the line
    line_1.Move();
    digits_1.Move();
    small_1.Move();

    //output
    cout << "\nline_1 length: " << line_1.Length();
    cout << "\ndigits_1 length: " << digits_1.Length();
    cout << "\nsmall_1 length: " << small_1.Length();

    cout << "\nline_1: " << line_1.line();
    cout << "\ndigits_1: " << digits_1.line();
    cout << "\nsmall_1: " << small_1.line();
}