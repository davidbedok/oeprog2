using System;
using System.Linq;
using System.Text;
using System.Collections;
using DynamicLists.entity;

namespace DynamicLists
{
    public class DemoArray : IDemoList
    {
        private TestEntity[] items;
        private int index;

        public DemoArray(int capacity)
        {
            this.items = new TestEntity[capacity];
            this.index = 0;
        }

        private void addItem( TestEntity item ){
            if ( this.index < items.Length ){
                this.items[this.index++] = item;
            }
        }

        public void addItem(int id, string name)
        {
            this.addItem(new TestEntity(id,name));
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
            sb.AppendLine("# DemoArray");
            for (int i = 0; i < this.index; i++)
            {
                sb.AppendLine(this.items[i].ToString());
            }
            return sb.ToString();
        }

    }
}
