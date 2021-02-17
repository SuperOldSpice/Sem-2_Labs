#include "head.h"

int main()
{
	setlocale(LC_ALL, "ukr");
	int a, b;
	char c;
	cout << "Operation is 'minus one'?(y/n)" << endl;
	cin >> c;
	if(c == 'y') {                       // go to minus one
		cout << "Input your number: ";
		cin >> a;
		log1(a);
		cout << "Your number minus one: " << a << endl;
	} else {                            // go to compare numbers
		cout << "Input two numbers: ";
		cin >> a >> b;
		int key = log2(a, b); // a > b ?
		if (key == 3) {
			cout << "a == b";
		} else if (key) {
			cout << "a > b";
		} else {
			cout << "a < b";
		}
	}

}

