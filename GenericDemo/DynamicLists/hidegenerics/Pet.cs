using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists.hidegenerics
{
    public class Pet
    {

        private readonly String name;

        private String owner;

        public String Name
        {
            get { return this.name; }
        }

        public String Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        public Pet(String name)
        {
            this.name = name;
        }

        public override String ToString()
        {
            return " " + this.name + (this.owner != null ? " (owner: " + this.owner + ")" : "");
        }

    }
}
