using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransactionTrunk
{
    public class CreditTransaction : Transaction
    {

        public CreditTransaction(Account account, double balance, int day)
            : base(account,balance,day)
        {

        }

        public override double getValue()
        {
            return this.balance;
        }

        public override string ToString()
        {
            return "CreditTransaction " + base.ToString();
        }

    }
}
