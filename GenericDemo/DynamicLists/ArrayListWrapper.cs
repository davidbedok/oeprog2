using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists
{
    public class ArrayListWrapper
    {

        private ArrayList list;

        public ArrayListWrapper(int capacity)
        {
            this.list = new ArrayList(capacity);
        }

        public void Add(String value)
        {
            this.list.Add(value);
        }

        public int IndexOf(String value)
        {
            return this.list.IndexOf(value);
        }

    }
}
