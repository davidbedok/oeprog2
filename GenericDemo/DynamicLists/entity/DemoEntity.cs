using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists.entity
{
    public class DemoEntity
    {
        private double id;
        private char name;

        public DemoEntity(double id, char name)
        {
            this.id = id;
            this.name = name;
        }

        public double Id
        {
            get { return this.id; }
        }

        public char Name
        {
            get { return this.name; }
        }

        public override string ToString()
        {
            return this.Name + " (" + this.Id + ")";
        }

        public string sayDemo()
        {
            return "DEMO";
        }

    }
}
