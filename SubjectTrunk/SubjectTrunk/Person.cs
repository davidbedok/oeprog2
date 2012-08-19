using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SubjectTrunk
{
    public class Person
    {
        private string name;
        private string neptunCode;

        public string Name
        {
            get { return this.name; }
        }

        public string NeptunCode
        {
            get { return this.neptunCode; }
        }

        public Person(string name, string neptunCode)
        {
            this.name = name;
            this.neptunCode = neptunCode;
        }

        public override string ToString()
        {
            return this.name + " ["+this.neptunCode+"]";
        }

    }
}
