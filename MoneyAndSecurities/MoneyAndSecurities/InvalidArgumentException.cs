using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyAndSecurities
{
    public class InvalidArgumentException : ApplicationException
    {
        private int numberOfDogs;

        public int NumberOfDogs
        {
            get { return this.numberOfDogs; }
        }

        public InvalidArgumentException(int numberOfDogs )
            : this(null, numberOfDogs)
        {
        }

        public InvalidArgumentException(String message, int numberOfDogs)
            : this(message, null, numberOfDogs)
        {
            this.numberOfDogs = numberOfDogs;
        }

        public InvalidArgumentException(String message, Exception cause, int numberOfDogs)
            : base(message, cause)
        {
            this.numberOfDogs = numberOfDogs;
        }

    }
}
