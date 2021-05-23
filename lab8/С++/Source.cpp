#include "head.h"

Node* MakeNode(long value);
void AddLast(Node* head, long value);
int FindPairFive(Node* head);
Node* DeleteBiggerElements(Node* head);
void PrintNodes(Node* head);

int main()
{
    Node* head = MakeNode(11);
    AddLast(head, 10);
    AddLast(head, 1);
    AddLast(head, 20);
    AddLast(head, 1);
    AddLast(head, 1);
    AddLast(head, 11);
    PrintNodes(head);
    int count = FindPairFive(head);
    cout << "Number of pair elements, that multiplies five: "  << count << endl;
    head = DeleteBiggerElements(head);
    PrintNodes(head);
}

Node* MakeNode(long value)
{
   
    Node* NewNode = new Node();
    NewNode->value = value;
    NewNode->previous = nullptr;
    NewNode->next = nullptr;
    NewNode->count = 1;
    return NewNode;
}

void AddLast(Node* head, long value)
{
    
    Node * q = head;
    while (q->next != nullptr)
    {
        q = q->next;
        //cout << q->value << endl;
    }
    Node *NewNode = new Node();
    NewNode->next = nullptr;
    NewNode->previous = q;
    NewNode->value = value;
    NewNode->count = q->count + 1;
    q->next = NewNode; 
}

int FindPairFive(Node* head)
{
    int counter = 0;
    Node* q = head;
    if (q->count % 2 == 0 && q->value % 5 == 0) counter++;
    while (q->next != nullptr)
    {
        q = q->next;
        if (q->count % 2 == 0 && q->value % 5 == 0) counter++;
    }
    return counter;
}

Node* DeleteBiggerElements(Node* head)
{
    Node* q = head;
    long avereage;
    int counter = 0;
    avereage = q-> value;
    counter++;
    while (q->next != nullptr)
    {
        q = q->next;
        avereage += q->value;
        counter++;
    }
    avereage /= counter;
    cout << "Avereage: " << avereage << endl;

    q = head;
    while (head->value > avereage)
    {
        head = q->next;
        delete q;
        q = head; 
        q->count--;
        q->previous = nullptr;
        while (q->next != nullptr)
        {
            q = q->next;
            q->count--;
        }
        q = head; 
    }

    while (q->next != nullptr)
    {
        q = q->next;
        if (q->value > avereage)
        {
            if (q->next != nullptr)
            {
                Node* left = q->previous;
                Node* right = q->next;
                left->next = right;
                right->previous = left;
                Node* p = q;
                q = right;  
                q->count--;
                while (q->next != nullptr)
                {
                    q = q->next;
                    q->count--;
                }
                q = right;
                delete p;
            }
            else
            {
                Node* left = q->previous;
                left->next = nullptr;
                delete q;
                q = left;
            }
            
        }
    }
    return head;
}



void PrintNodes(Node* head)
{
    Node* q = head;
    cout << "N" << q->count << ": " << q->value << endl;
    while (q->next != nullptr)
    {
        q = q->next;
        cout << "N" << q->count << ": " << q->value << endl;
    }
}