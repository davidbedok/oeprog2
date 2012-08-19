using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZooManager
{
    public abstract class ZooAnimal : Object
    {
        private readonly String name;
        private readonly DateTime dateOfBirth;
        public event HungerHandler hunger;

        public String Name
        {
            get { return this.name; }
        }

        public ZooAnimal(String name, DateTime dateOfBirth)
        {
            this.name = name;
            this.dateOfBirth = dateOfBirth;
        }

        public void iAmHungry()
        {
            if (this.hunger != null)
            {
                this.hunger(this.name, this.getFood(), this.getAmount());
            }
        }

        protected abstract Food getFood();

        protected abstract int getAmount();

        protected abstract String getFoodName(); 

        public override string ToString()
        {
            return "(name: " + this.name + " dateOfBirth: " + this.dateOfBirth + ")";
        }

    }
}
