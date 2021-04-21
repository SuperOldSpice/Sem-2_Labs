#pragma once

class Lines
{
public:
	//parametric constructor
	Lines(double x1, double y1, double x2, double y2);
	//returns line`s length 
	double GetLength();

protected:
	//coordinates
	double _x1, _x2, _y1, _y2;
};

class Segment : public Lines 
{
public:
	//constructor
	Segment(double x1, double y1, double x2, double y2);
	//decrease five 
	void MinusFive();
	//returns array with coordinates
	double* GetCoordsArray();
};

//corodinates and length print
void thePrint(Segment sec1);