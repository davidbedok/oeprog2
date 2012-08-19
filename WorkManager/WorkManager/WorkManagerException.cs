using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkManager
{
    public class WorkManagerException : System.ApplicationException
    {
        public WorkManagerException() : base() { }
        public WorkManagerException(string message) : base(message) { }
        public WorkManagerException(string message, System.Exception inner) : base(message, inner) { }

        protected WorkManagerException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
