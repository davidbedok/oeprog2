using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountEvent.Base
{
    public class StockAccount : Account
    {
        protected static string NUMBER = "db";

        private int number;
        private Instrument instrument;

        public double CalcValue
        {
            get
            {
                return this.number * this.instrument.Value;
            }
        }

        public StockAccount(Instrument instrument, int number, string ownerName, string accountNumber)
            : base(ownerName, accountNumber)
        {
            this.instrument = instrument;
            this.number = number;
        }

        public override string ToString()
        {
            return this.OwnerName + ":" + this.AccountNumber + "[" + this.number + " " + StockAccount.NUMBER + " " + this.instrument + " = "+this.CalcValue + " " +Account.SIGN + " ]";
        }

    }
}
