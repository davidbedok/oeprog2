using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Account
    {

        private readonly String number;
        private readonly Currency currency;
        private double value;

        public String Number
        {
            get { return this.number; }
        }

        public Currency Currency
        {
            get { return this.currency; }
        }

        public double Value
        {
            get { return this.value; }
        }

        public Account(String number, Currency currency, double value)
        {
            this.number = number;
            this.currency = currency;
            this.value = value;
        }

        public void Transfer(double value)
        {
            this.value += value;
        }

        public override string ToString()
        {
            return this.number + ": " + this.value + " " + this.currency;
        }

    }
}
