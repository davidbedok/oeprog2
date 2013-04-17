using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyAndSecurities.Mortgage
{
    public class Person
    {

        private String name;

        public String Name
        {
            get { return this.name; }
        }

        public Person(String name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }

    }
}
