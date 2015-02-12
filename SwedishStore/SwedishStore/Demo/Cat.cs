using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwedishStore.Demo
{
    public class Cat : Animal
    {

        private String nick;
        private int numberOfMilkCartons;

        public int NumberOfMilk
        {
            get { return this.numberOfMilkCartons; }
            set { this.numberOfMilkCartons = value; }
        }

        public Cat(String name, String nick)
            : base(name)
        {
            this.nick = nick;
            this.numberOfMilkCartons = 1;
        }

        public override String eat()
        {
            return this + " is eating " + this.numberOfMilkCartons + " milk carton(s).";
        }

        public override string ToString()
        {
            return "Cat (name: " + this.Name + ")";
        }

    }
}
