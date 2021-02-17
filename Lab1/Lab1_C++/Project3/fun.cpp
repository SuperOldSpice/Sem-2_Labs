#include "head.h"

void log1(int& a) // do minus one
{
	bool bit1 = false;

	for (int i = 0; i < 32 && !bit1; i++) {
		bit1 = a & (1 << i);
		if (!bit1) {
			a = a | (1 << i);
		} else {
			a = a ^ (1 << i);
		}
	}

}

int log2(int a, int b)
{
	int bit1, bit2, i, key = -1;

	bit1 = a & (1 << 31); //first bit check (positive or ngative number)
	bit2 = b & (1 << 31);
	if (!bit1 && bit2) {
		return 1;
	}
	else if (bit1 && !bit2) {
		return 0;
	}

	for (i = 31; i > -1; i--) {  //all other bits cheack
		bit1 = a & (1 << i);
		bit2 = b & (1 << i);
		if (bit1 && !bit2) {
			key = 1;
			break;
		} else if (!bit1 && bit2) {
			key = 0;
			break;
		}
	}

	if (i == -1 && key == -1) {
		key = 3;
	}

	return key;
}