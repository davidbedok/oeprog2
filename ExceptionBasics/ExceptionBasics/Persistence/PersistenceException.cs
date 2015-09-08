using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionBasics.Persistence
{
    public abstract class PersistenceException : ApplicationException
    {
        private readonly String field;

        public String Field
        {
            get { return this.field; }
        }

        public PersistenceException(String message, String field) : this(message, field, null) { }
        public PersistenceException(String message, String field, Exception inner)
            : base(message, inner)
        {
            this.field = field;
        }
    }
}
