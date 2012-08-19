using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionBasics
{
    public class EndOfDataException : System.ApplicationException
    {
        public EndOfDataException() : base() { }
        public EndOfDataException(string message) : base(message) { }
        public EndOfDataException(string message, System.Exception inner) : base(message, inner) { }

        protected EndOfDataException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

    }
}
