using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExchange
{
    public class Commission
    {

        private readonly SecuritiesName securitiesName;
        private readonly int count;
        private readonly int expectedValue;
        private readonly CommissionType type;
        private bool done;

        public CommissionType Type {
            get { return this.type; }
        }

        public int ExpectedValue {
            get { return this.expectedValue; }
        }

        public int Count
        {
            get { return this.count; }
        }

        public bool Done
        {
            get { return this.done; }
            set { this.done = value; }
        }

        public Commission(SecuritiesName securitiesName, int count, int expectedValue, CommissionType type)
        {
            this.securitiesName = securitiesName;
            this.count = count;
            this.expectedValue = expectedValue;
            this.type = type;
            this.done = false;
        }

        public int value() {
            return this.count * this.expectedValue;
        }

        public override string ToString()
        {
            return "["+type+" Commission] " + securitiesName + " count: " + count + " expectedValue: " + expectedValue + " DONE: " + this.done;
        }

    }
}
