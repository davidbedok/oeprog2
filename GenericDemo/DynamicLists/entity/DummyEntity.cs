using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists.entity
{
    public class DummyEntity
    {
        private string id;
        private string name;

        public DummyEntity(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public string Id
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

        public string sayDummy()
        {
            return "DUMMY";
        }

    }
}
