using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists.entity
{
    public class TestEntity
    {
        private int id;
        private string name;

        public TestEntity(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id
        {
            get { return this.id; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public override string ToString()
        {
            return this.Name + " (" + this.Id + ")";
        }

        public string sayTest()
        {
            return "TEST";
        }

    }
}
