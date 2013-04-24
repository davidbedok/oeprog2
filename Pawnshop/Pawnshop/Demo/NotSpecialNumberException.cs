using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyAndSecurities.Demo
{
    public class NotSpecialNumberException : ApplicationException
    {

        private int invalidSpecialNumber;

        public int InvalidSpecialNumber
        {
            get { return this.invalidSpecialNumber; }
        }

        public NotSpecialNumberException(int invalidSpecialNumber) : this(null, invalidSpecialNumber) {
        }

        public NotSpecialNumberException(String message, int invalidSpecialNumber) : this(message, null, invalidSpecialNumber) {
        }

        public NotSpecialNumberException(String message, Exception cause, int invalidSpecialNumber) : base(message, cause) {
            this.invalidSpecialNumber = invalidSpecialNumber;
        }

    }
}
