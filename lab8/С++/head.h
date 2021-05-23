#pragma once
#include <iostream>
using namespace std;


struct Node
{
public:
    Node* previous;
    Node* next;
    long value;
    int count;
};