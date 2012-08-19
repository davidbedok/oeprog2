using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransactionTrunk
{
    public abstract class Transaction : System.Object
    {
        protected Account baseAccount;
        protected double balance;
        protected int day;

        public Account BaseAccount
        {
            get
            {
                return this.baseAccount;
            }
        }

        public double Balance
        {
            get
            {
                return this.balance;
            }
        }

        public int Day
        {
            get
            {
                return this.day;
            }
        }

        public Transaction(Account baseAccount, double balance, int day)
        {
            this.baseAccount = baseAccount;
            this.balance = balance;
            this.day = day;
        }

        public abstract double getValue();

        public override string ToString()
        {
            return this.baseAccount.ToString() + " Balance: " + this.balance + " Day: " + this.day;
        }

    }
}
