using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoneyAndSecurities.Helper;

namespace MoneyAndSecurities.Wealth
{
    public class Money : Property
    {

        private Currency currency;

        public Currency Currency
        {
            get { return this.currency; }
        }

        public Money(Currency currency, int count)
            : base(count)
        {
            this.currency = currency;
        }

        public override int value()
        {
            return Calculator.getInstance().exchangeRate(this.currency) * this.count;
        }

        protected override void validateOutcome(int count)
        {
        }

        public override string ToString()
        {
            return "[Money] currency: " + this.currency + base.ToString();
        }

    }
}
