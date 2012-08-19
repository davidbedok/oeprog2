using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapImplementation
{
    public class Person
    {
        private string name;
        private string neptunCode;
        private DateTime birthDate;

        public string Name
        {
            get { return this.name; }
        }

        public string NeptunCode
        {
            get { return this.neptunCode; }
        }

        public DateTime BirthDate
        {
            get { return this.birthDate; }
        }

        public Person(string name, string neptunCode, DateTime birthDate)
        {
            this.name = name;
            this.neptunCode = neptunCode;
            this.birthDate = birthDate;
        }

        public override string ToString()
        {
            return "["+this.neptunCode+"] " + this.name;
        }

        public override bool Equals(object obj)
        {
            return this.GetHashCode().Equals(obj.GetHashCode());
        }

        public override int GetHashCode()
        {
            return this.neptunCode.GetHashCode();
        }

    }
}
