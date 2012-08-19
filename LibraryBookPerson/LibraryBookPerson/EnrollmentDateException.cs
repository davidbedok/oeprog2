using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryBookPerson
{
    public class EnrollmentDateException : System.ApplicationException
    {
        public EnrollmentDateException() : base() { }
        public EnrollmentDateException(string message) : base(message) { }
        public EnrollmentDateException(string message, System.Exception inner) : base(message, inner) { }
    }
}
