using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class NotEnoughMoneyException : ApplicationException
    {

        public NotEnoughMoneyException(Account account, double value)
            : base(account.Number + " hasn't got enough money to transfer " + value + " " + account.Currency + ".")
        {
        }

    }
}
