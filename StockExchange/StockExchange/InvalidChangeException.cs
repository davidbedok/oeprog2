using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExchange
{
    public class InvalidChangeException : ApplicationException
    {

        public InvalidChangeException(String message) : base(message) { }

    }
}
