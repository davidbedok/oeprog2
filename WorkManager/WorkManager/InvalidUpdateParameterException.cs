using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkManager
{
    public class InvalidUpdateParameterException : System.ApplicationException
    {
        public InvalidUpdateParameterException() : base() { }
        public InvalidUpdateParameterException(string message) : base(message) { }
        public InvalidUpdateParameterException(string message, System.Exception inner) : base(message, inner) { }

        protected InvalidUpdateParameterException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

    }

}
