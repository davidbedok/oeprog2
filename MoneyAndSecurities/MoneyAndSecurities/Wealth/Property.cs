using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoneyAndSecurities.Events;

namespace MoneyAndSecurities.Wealth
{
    public abstract class Property
    {

        private const Currency BASE_CURRENCY = Currency.HUF;

        // double.. (simplicity)
        protected int count;

        private CountOnChangeEvent onChange;

        public CountOnChangeEvent OnChangeHandler
        {
            set { this.onChange = value; }
        }

        public Property(int count)
        {
            this.count = count;
        }

        public abstract int value();

        public void income( int count )
        {
            int originalCount = this.count;
            this.count += count;
            this.handler(originalCount);
        }

        public void outcome(int count)
        {
            int originalCount = this.count;
            this.validateOutcome(count);
            this.count -= count;
            this.handler(originalCount);
        }

        private void handler(int originalCount)
        {
            if (originalCount != this.count)
            {
                if (this.onChange != null)
                {
                    this.onChange.onChange(this, originalCount, this.count);
                }
            }
        }

        protected abstract void validateOutcome(int count);

        public override string ToString()
        {
            return " count: " + this.count + " (VALUE: " + this.value() + " " + BASE_CURRENCY + ")";
        }

    }
}
