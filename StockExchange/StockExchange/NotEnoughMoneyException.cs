using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExchange
{
    public class NotEnoughMoneyException : ApplicationException
    {

        public NotEnoughMoneyException(String message) : base(message) { } 

    }
}
