using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransactionTrunk
{
    public class DebitTransaction : Transaction
    {
        public DebitTransaction(Account account, double balance, int day)
            : base(account,balance,day)
        {

        }

        public override double getValue()
        {
            return this.balance * (-1);
        }

        public override string ToString()
        {
            return "DebitTransaction " + base.ToString();
        }
    }
}
