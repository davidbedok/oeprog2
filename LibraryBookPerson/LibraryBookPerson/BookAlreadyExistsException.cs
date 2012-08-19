using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryBookPerson
{
    public class BookAlreadyExistsException : System.ApplicationException
    {
        public BookAlreadyExistsException() : base() { }
        public BookAlreadyExistsException(string message) : base(message) { }
        public BookAlreadyExistsException(string message, System.Exception inner) : base(message, inner) { }
    }

}
