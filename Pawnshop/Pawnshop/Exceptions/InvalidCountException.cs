using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyAndSecurities.Exceptions
{
    public class InvalidCountException : ApplicationException
    {
        private int wrongCount;

        public int WrongCount
        {
            get { return this.wrongCount; }
        }

        public InvalidCountException(int wrongCount) : this(null, wrongCount) { }

        public InvalidCountException(string message, int wrongCount) : this(message, null, wrongCount) { }

        public InvalidCountException(string message, System.Exception inner, int wrongCount)
            : base(message, inner)
        {
            this.wrongCount = wrongCount;
        }

    }
}
