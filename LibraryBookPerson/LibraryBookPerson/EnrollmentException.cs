using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryBookPerson
{
    public class EnrollmentException : System.ApplicationException
    {
        public EnrollmentException() : base() { }
        public EnrollmentException(string message) : base(message) { }
        public EnrollmentException(string message, System.Exception inner) : base(message, inner) { }
    }
}
