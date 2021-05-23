using System;

namespace NodesLibrary
{
    

    public class MyNodes
    {
        private Node head = null;
        private int count;
        private static int length = 0;
        unsafe public MyNodes(long value)
        {
            Node NewNode = new Node();
            NewNode.value = value;
            NewNode.previous = null;
            NewNode.next = null;
            head = NewNode;
            head.count = 1;
            length += 1;
        }

        public void AddLast(long value)
        {

            Node q = head;
            while (q.next != null)
            {
                q = q.next;
                //Console.WriteLine(q.value);
            }
            Node NewNode = new Node();
            NewNode.next = null;
            NewNode.previous = q;
            NewNode.value = value;
            NewNode.count = q.count + 1;
            q.next = NewNode;
            length += 1;
        }

        public long[] GetList()
        {
            long[] list = new long[length];
            Node q = head;
            list[0] = q.value;
            int i = 1;
            while (q.next != null) 
            {
                q = q.next;
                list[i] = q.value;
                i++;
            }
            return list;
        }

        public int FindPairFive()
        {
            int counter = 0;
            Node q = head;
            if (q.count % 2 == 0 && q.value % 5 == 0) counter++;
            while (q.next != null)
            {
                q = q.next;
                if (q.count % 2 == 0 && q.value % 5 == 0) counter++;
            }
            return counter;
        }

        public long DeleteBiggerElements()
        {
            Node q = head;
            long avereage;
            int counter = 0;
            avereage = q.value;
            counter++;
            while (q.next != null)
            {
                q = q.next;
                avereage += q.value;
                counter++;
            }
            avereage /= counter;

            q = head;
            while (head.value > avereage)
            {
                head = q.next;
                
                q = head;
                q.count--;
                q.previous = null;
                while (q.next != null)
                {
                    q = q.next;
                    q.count--;
                }
                q = head;
                length--;
            }

            while (q.next != null)
            {
                q = q.next;
                if (q.value > avereage)
                {
                    if (q.next != null)
                    {
                        Node left = q.previous;
                        Node right = q.next;
                        left.next = right;
                        right.previous = left;
                        Node p = q;
                        q = right;
                        q.count--;
                        while (q.next != null)
                        {
                            q = q.next;
                            q.count--;
                        }
                        q = right;
                        length--;
                    }
                    else
                    {
                        Node left = q.previous;
                        left.next = null;
                        
                        q = left;
                        length--;
                    }

                }
            }
            return avereage;


        }

    }
}
