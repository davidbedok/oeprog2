using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryBookPerson
{
    public class NotEnoughBookException : System.ApplicationException
    {
        public NotEnoughBookException() : base() { }
        public NotEnoughBookException(string message) : base(message) { }
        public NotEnoughBookException(string message, System.Exception inner) : base(message, inner) { }
    }
}
