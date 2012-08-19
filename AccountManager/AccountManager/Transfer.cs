using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountManager
{
    public class Transfer
    {
        private Account account;
        private double value;
        private Currency currency;

        public Account Account
        {
            get { return this.account; }
        }

        public double Value
        {
            get { return this.value; }
        }

        public Currency CurrencyType
        {
            get { return this.currency; }
        }

        public Transfer(Account account, Currency currency, double value)
        {
            this.account = account;
            this.currency = currency;
            this.value = value;
        }

        public override string ToString()
        {
            return this.Account + " >> " + this.Value + " ("+this.CurrencyType+")";
        }

    }
}
