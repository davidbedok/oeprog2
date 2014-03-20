using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DynamicLists.entity;

namespace DynamicLists
{
    public class DemoList : IDemoList
    {
        private ArrayList items;

        public DemoList()
        {
            this.items = new ArrayList();
        }

        private void addItem(Object item)
        {
            if (item is TestEntity)
            {
                this.items.Add(item);
            }
        }

        public void addItem(int id, string name)
        {
            this.addItem(new TestEntity(id, name));
        }

        public void iterate()
        {
            IEnumerator iterator = this.items.GetEnumerator();
            while (iterator.MoveNext())
            {
                Object item = iterator.Current;
                if (item is TestEntity)
                {
                    TestEntity te = (TestEntity)item;
                    System.Console.WriteLine(te.sayTest());
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("# DemoList");
            foreach (Object item in this.items)
            {
                sb.AppendLine(item.ToString());
                if (item is TestEntity)
                {
                    // todo..
                }
            }
            return sb.ToString();
        }

    }
}
