using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwedishStore.Demo
{
    public class Animal
    {

        private readonly String name;

        public String Name
        {
            get { return this.name; }
        }

        public Animal(String name)
        {
            this.name = name;
        }

        public virtual String eat()
        {
            return this + " is eating.";
        }

        public override string ToString()
        {
            return "Animal (name: " + this.name + ")";
        }

    }
}
