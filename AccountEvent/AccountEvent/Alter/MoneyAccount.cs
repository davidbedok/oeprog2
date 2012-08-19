using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountEvent.Alter
{
    public class MoneyAccount : Account
    {

        private double moneyBalance;

        public double Money
        {
            get
            {
                return this.moneyBalance;
            }
            set
            {
                this.moneyBalance = value;
            }
        }

        public MoneyAccount(double moneyBalance, string ownerName, string accountNumber)
            : base(ownerName, accountNumber)
        {
            this.moneyBalance = moneyBalance;
        }

        public override string ToString()
        {
            return this.OwnerName + ":" + this.AccountNumber + "["+this.moneyBalance+" "+Account.SIGN+"]";
        }


    }
}
