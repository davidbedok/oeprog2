using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LancoltListaEpam
{
    public class Node
    {

        private Node next;
        private int nodeValue;

        public int Value
        {
            get { return this.nodeValue; }
        }

        public Node Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public Node(int nodeValue)
        {
            this.nodeValue = nodeValue;
            this.next = null;
        }

        public bool HasNode()
        {
            return (this.next != null);
        }

        public Node(int nodeValue, Node next)
        {
            this.nodeValue = nodeValue;
            this.next = next;
        }

        public override string ToString()
        {
            if (this.next != null)
            {
                return "[" + this.Value + "]-->"+this.next.ToString();
            }
            else
            {
                return "[" + this.Value + "]-->NIL";
            }
        }

    }
}
