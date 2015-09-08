using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists
{
    public class Domino
    {

        private readonly int value;

        private Domino next;

        public Domino Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public Domino(int value)
        {
            this.value = value;
        }

        public Domino Add(int value)
        {
            this.Next = new Domino(value);
            return this.Next;
        }

        public void Insert(int value)
        {
            Domino tmp = this.next;
            this.next = new Domino(value);
            this.next.next = tmp;
        }

        public void DeleteNext()
        {
            this.next = this.next.next;
        }

        public void DeleteByIndex(int relativeIndex)
        {
            Domino tmp = this;
            for (int i = 0; i < relativeIndex - 1; i++)
            {
                tmp = tmp.Next;
            }
            tmp.Next = tmp.Next.Next;
        }

        public Domino RelativeFind(int value)
        {
            Domino tmp = this;
            while (tmp.value != value)
            {
                tmp = tmp.Next;
            }
            return tmp;
        }

        public Domino Find(int value)
        {
            return this.value == value ? this : this.next.Find(value);
        }

        public override string ToString()
        {
            return this.value + " -> " + (this.next != null ? this.next.ToString() : "NIL");
        }

    }
}
