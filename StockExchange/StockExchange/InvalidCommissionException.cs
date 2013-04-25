using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExchange
{
    public class InvalidCommissionException : ApplicationException
    {

        public InvalidCommissionException(String message) : base(message) { }

    }
}
