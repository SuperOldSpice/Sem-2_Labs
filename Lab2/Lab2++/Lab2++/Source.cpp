#include "Library.h"

int main()
{
    cout << ("Input your first line:\n");
    char* line = LineInput();                       //first line create
    Line _line = Line(line);
    delete[] line;
    LineCollection lines = LineCollection(_line);   //container create
    bool skip = false;
    cout << ("To finish the running press 0\n");             //menu
    cout << ("To add new string press 1\n");
    cout << ("To delete the string press 2\n");
    cout << ("To delete all strings press 3\n");
    cout << ("To find how much lines with some length the text has press 4\n");
    cout << ("To get the first letter to upper register press 5\n");
    cout << ("To make the key-words press 6\n");
    cout << ("To stop the program press Enter\n");
    cout << ("Select the operation:\n");
    while (!skip)                                           //operation choice
    {
        char key;
        cin >> key;
        cin.get();
        int n = key - 48;
            if (n == 0)             //stop the running
            {
                skip = true;
                break;
            }
            else if (n == 1)            //add the line
            {
                cout << ("Write your line:\n");
                char* line = LineInput();
                _line = Line(line);
                delete[] line;
                lines.AddLine(_line);
                cout << ("\nYour lines:\n");
                PrintLines(lines);
                cout << ("\nSelect the operation:\n");
            }
            else if (n == 2)            //delete some line
            {
                int number;
                cout << ("Select the Line:\n");
                cin >> number;
                bool check = lines.DeleteLine(number);
                if (!check) cout << ("The Line is Missing\n");
                else
                {
                    cout << ("\nYour lines:\n");
                    PrintLines(lines);
                }
                cout << ("\nSelect the operation:\n");
            }
            else if (n == 3)            //deletes all lines
            { 
                lines.DeleteAll();
                cout << ("\nYour lines:\n");
                PrintLines(lines);
                cout << ("\nSelect the operation:\n");
            }   
            else if (n == 4)            //searching lines with some length
            {   
                cout << ("Write the length of searching lines\n");
                int number;
                cin >> number;
                number = lines.HowMuch(number);
                cout << ("\nThe number of lines with that length: ") << number;
                cout << ("\nSelect the operation:\n");
            }
            else if (n == 5)        //gets first letters to upper register
            {
                lines.ToUpRegister();
                cout << ("\nYour lines:\n");
                PrintLines(lines);
                cout << ("\nSelect the operation:\n");
            }
            else if (n == 6)            //make key - words
            {
                cout << ("\nKey-words:\n");
                PrintLines(lines, "keys");
                cout << ("\nSelect the operation:\n");
            }  
    }
}