using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentReg
{
    public class Node
    {
        private object data;
        private Node next;

        public Node(object data, Node next)
        {
            this.data = data;
            this.next = next;
        }
        public object Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
        public Node Next
        {
            get { return this.next; }
            set { this.next = value; }
        }
    }
    public class LinkedList
    {

        private Node head;
        private int count;

        public LinkedList()
        {
            this.head = null;
            this.count = 0;

        }

        public bool Empty
        {
            get { return this.count == 0; }
        }
        public int Count
        {
            get { return this.count; }
        }

        public object Add(int index, object o)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("index: " + index);

            if (index > count)
                index = count;

            Node current = this.head;

            if (this.Empty || index == 0)
            {
                this.head = new Node(o, this.head);
            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                    current = current.Next;

                current.Next = new Node(o, current.Next);

            }

            count++;

            return o;
        }

        public object Add(object o)
        {
            return this.Add(count, o);
        }

        public object Remove(int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("index: "+index);

            if (this.Empty)
                return null;

            if (index > this.count)
                index = count - 1;

            Node current = this.head;
            object result = null;

            if (index == 0)
            {
                result = current.Data;
                this.head = current.Next;

            }
            else
            {
                for (int i = 0; i < index - 1; i++)
                    current = current.Next;

                result = current.Next.Data;

                current.Next = current.Next.Next;      //skips the reference to "deleted" node



            }
            count++;

            return result;
        }
        public void Clear()
        {
            this.head = null;
            this.count = 0;

        }

        public override string ToString()
        {
            return head.ToString();
         
        }
    }
}


    

