using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoneyAndSecurities.Exceptions;

namespace MoneyAndSecurities.Wealth
{
    public class Chattel : Property
    {
        private String name;
        private int marketPrice; // in HUF (simplicity)

        public String Name
        {
            get { return this.name; }
        }

        public Chattel(String name, int marketPrice, int count)
            : base(count)
        {
            this.name = name;
            this.marketPrice = marketPrice;
        }

        public override int value()
        {
            return this.count * this.marketPrice;
        }

        protected override void validateOutcome( int count )
        {
            int newCount = this.count - count;
            if (newCount < 0)
            {
                throw new InvalidCountException("Count must be non-negative!", newCount);
            }
        }

        public override string ToString()
        {
            return "[Chattel] name: " + this.name + " marketPrice: " + this.marketPrice + base.ToString();
        }

    }
}
