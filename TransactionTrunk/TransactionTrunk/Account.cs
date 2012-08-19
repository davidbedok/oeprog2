using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransactionTrunk
{
    public class Account : System.Object
    {
        private readonly string ownerName;
        private readonly string accountNumber;

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

        public Account(string ownerName, string accountNumber)
        {
            this.ownerName = ownerName;
            this.accountNumber = accountNumber;
        }

        public override string ToString()
        {
            return "(" + this.ownerName + ":" + this.accountNumber + ")";
        }


    }
}
