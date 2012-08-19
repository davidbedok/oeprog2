using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicLists.entity;

namespace DynamicLists
{
    public class DemoGenericList : IDemoList
    {
        private List<TestEntity> items;

        public DemoGenericList()
        {
            this.items = new List<TestEntity>();
        }

        private void addItem(TestEntity item)
        {
            this.items.Add(item);
        }

        public void addItem(int id, string name)
        {
            this.addItem(new TestEntity(id, name));
        }

        public void iterate()
        {
            IEnumerator<TestEntity> iterator = this.items.GetEnumerator();
            while (iterator.MoveNext())
            {
                TestEntity te = iterator.Current;
                System.Console.WriteLine(te.sayTest());
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("# DemoGenericList");
            foreach (TestEntity item in this.items)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

    }
}
