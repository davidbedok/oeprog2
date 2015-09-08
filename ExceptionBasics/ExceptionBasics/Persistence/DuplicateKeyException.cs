using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionBasics.Persistence
{
    public class DuplicateKeyException : PersistenceException
    {
        public DuplicateKeyException(String message, String field) : base(message, field) { }
        public DuplicateKeyException(String message, String field, Exception inner) : base(message, field, inner) { }
    }
}
