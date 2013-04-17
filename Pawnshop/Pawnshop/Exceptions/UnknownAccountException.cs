using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyAndSecurities.Exceptions
{
    public class UnknownAccountException : ApplicationException
    {

        public UnknownAccountException() : this(null) { }

        public UnknownAccountException(string message) : this(message, null) { }

        public UnknownAccountException(string message, System.Exception inner)
            : base(message, inner) { }

    }
}
