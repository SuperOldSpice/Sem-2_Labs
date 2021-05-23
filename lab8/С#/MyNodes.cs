using System;
using System.Collections.Generic;
using System.Text;

namespace NodesClass
{
    public class MyNodes
    {
       private Node[] list;
       private int length;
       public MyNodes(long value)
        {
            list = new Node[1] { new Node(value)} ;
            length = 1;
        }

        public void AddLast(long value)
        {
            length++;
            Node[] NewArr = new Node[length];
            for (int i = 0; i < length - 1; i ++)
            {
                NewArr[i] = list[i];
            }
            NewArr[length - 1] = new Node(value);
            list = NewArr;
        }

        public long[] GetNodes()
        {
            long[] NewArr = new long[length];
            for(int i = 0; i < length; i ++)
            {
                NewArr[i] = list[i].value;
            }
            return NewArr;
        }

        public int FindPairFive()
        {
            int counter = 0;
            for(int i = 0; i < length; i ++)
            {
                if (list[i].value % 5 == 0 && list[i].value % 2 == 0)
                    counter++;
            }
            return counter;
        }

        public void DeleteBiggerElements()
        {
            long avereage = 0;
            for (int i = 0; i < length; i++)
            {
                avereage += list[i].value;
            }
            avereage /= length;
            int count = 1;
            while (count != 0)
            {
                count = 0;

                for (int i = 0; i < length; i++)
                {
                    if (list[i].value > avereage)
                    {
                        Node[] NewArr = new Node[length - 1];
                        for (int j = 0; j < i; j++)
                            NewArr[j] = list[j];
                        for (int j = i; j < length - 1; j++)
                            NewArr[j] = list[j + 1];
                        list = NewArr;
                        length--;
                    }
                }

                for (int i = 0; i < length; i++)
                    if (list[i].value > avereage) count++;
            }
        }

    }
}
