using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountManager
{
    public class Account
    {
        private string accountNumber;
        private Currency currency;

        public string AccountNumber
        {
            get { return this.accountNumber; }
        }

        public Currency CurrencyType
        {
            get { return this.currency; }
        }

        public Account(string accountNumber, Currency currency)
        {
            this.accountNumber = accountNumber;
            this.currency = currency;
        }

        public override string ToString()
        {
            return this.AccountNumber + " ("+this.CurrencyType+")";
        }

    }
}
