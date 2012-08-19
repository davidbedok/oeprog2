using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountEvent.Base
{
    public class Account
    {
        protected static string SIGN = "Ft";

        private readonly string ownerName;
        private readonly string accountNumber;
        private double balance;

        public string OwnerName
        {
            get
            {
                return this.ownerName;
            }
        }

        public string AccountNumber
        {
            get
            {
                return this.accountNumber;
            }
        }

        public double Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }

        public Account(string ownerName, string accountNumber )
        {
            this.ownerName = ownerName;
            this.accountNumber = accountNumber;
            this.balance = 0;
        }

        public override string ToString()
        {
            return this.ownerName + ":" + this.accountNumber + " [" + this.balance + " "+Account.SIGN+"]";
        }

    }
}
