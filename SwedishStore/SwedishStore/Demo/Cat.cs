using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwedishStore.Demo
{
    public class Cat : Animal
    {

        private String nick;
        private int numberOfMilk;

        public int NumberOfMilk
        {
            get { return this.numberOfMilk; }
            set { this.numberOfMilk = value; }
        }

        public Cat( String name, String nick )
            : base(name)
        {
            this.nick = nick;
            this.numberOfMilk = 1;
        }

        public override String eat()
        {
            return this + " is eating " + this.numberOfMilk + " milk(s)";
        }

        public override string ToString()
        {
            return "Cat (name: "+this.Name + ")";
        }

    }
}
