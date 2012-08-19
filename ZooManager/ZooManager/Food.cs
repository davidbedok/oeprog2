using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZooManager
{
    public abstract class Food : Object
    {
        private readonly String name;

        public String Name
        {
            get { return this.name; }
        }

        public Food(String name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return "[name: " + this.name + "]";
        }

    }
}
