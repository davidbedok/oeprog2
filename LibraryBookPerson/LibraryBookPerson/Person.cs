using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryBookPerson
{
    public class Person : IPerson
    {

        private readonly Int32 id;
        private readonly String name;
        private DateTime enrollmentDate;

        public Int32 ID
        {
            get { return this.id; }
        }

        public String Name
        {
            get { return this.name; }
        }

        public DateTime EnrollmentDate
        {
            get { return this.enrollmentDate; }
        }

        public Person(Int32 id, String name, DateTime enrollmentDate)
        {
            this.id = id;
            this.name = name;
            this.enrollmentDate = enrollmentDate;
        }

        public void regenerateEnrollment(DateTime newEnrollmentDate)
        {
            if (newEnrollmentDate > enrollmentDate)
            {
                this.enrollmentDate = newEnrollmentDate;
            }
            else
            {
                throw new EnrollmentDateException("The new enrollment date (" + newEnrollmentDate + ") is former than the original enrollment date ("+this.enrollmentDate+").");
            }
        }

        public override string ToString()
        {
            return this.name + " [" + this.id + "] " + this.enrollmentDate;
        }

    }
}
