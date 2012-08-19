using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryBookPerson
{
    public class BorrowException: System.ApplicationException
    {
        public BorrowException() : base() { }
        public BorrowException(string message) : base(message) { }
        public BorrowException(string message, System.Exception inner) : base(message, inner) { }
    }
}
