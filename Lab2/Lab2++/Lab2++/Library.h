#pragma once
#include <iostream>
#include <string>
using namespace std;

class Line		//lines class
{
	public:
		Line();             //default constructor
		Line(char* line);   //own constructor
		char* GetLine();    //get the line
		int GetLength();		//get lien length
		
	private:
		int _length;       //length
		char* _arr;			//line
		int FindLength(char* line);     //search the length
};

class LineCollection		//lines class - container
{
	public:
		LineCollection(Line line);  //container 
		void AddLine(Line line);	//add line to container
		char** GetLines();			//to print the container lines
		int GetLinesNumber();		//return the number of lines
		bool DeleteLine(int n);		//deletes some of lines
		void DeleteAll();			//deletes all lines
		int HowMuch(int size);		//number of the lines with some size
		void ToUpRegister();		//gets first letters to upper register
		char** KeyWords();			//make key-words

	private:
		Line* CopyArray(Line* lines, int oldSize, int newSize);  //copy array
		int _linesNumber = 0;		//number of lines
		Line* _myLines;			//container of lines
};	

char* LineInput();			//string input
void PrintLines(LineCollection lines, string h);		//print key -words
void PrintLines(LineCollection lines);		//print lines