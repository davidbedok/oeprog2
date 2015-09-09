using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Bank
    {

        private List<Account> accounts;

        public Bank()
        {
            this.accounts = new List<Account>();
        }

        public void Add(String number, Currency currency, double value)
        {
            this.accounts.Add(new Account(number, currency, value));
        }

        public void Transfer(String fromNumber, String toNumber, double value)
        {
            Account fromAccount = this.Find(fromNumber);
            Account toAccount = this.Find(toNumber);
            if (fromAccount.Value < value)
            {
                throw new NotEnoughMoneyException(fromAccount, value);
            }
            fromAccount.Transfer(-1 * value);
            toAccount.Transfer(ExchangeRateHolder.GetInstance().Convert(fromAccount.Currency, toAccount.Currency, value));
        }

        private Account Find(String number)
        {
            Account result = null;
            foreach (Account account in this.accounts)
            {
                if (account.Number.Equals(number))
                {
                    result = account;
                    break;
                }
            }
            return result;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(100);
            builder.AppendLine("---< Bank >---");
            foreach (Account account in this.accounts)
            {
                builder.AppendLine(account.ToString());
            }
            return builder.ToString();
        }

    }
}
