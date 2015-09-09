using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Currency
    {

        public static readonly Currency EUR = new Currency("EUR", 310);
        public static readonly Currency HUF = new Currency("HUF", 1);
        public static readonly Currency CHF = new Currency("CHF", 250);

        private static List<Currency> values;

        private readonly String name;
        private readonly double initialExchangeRate;

        public static Currency[] Values
        {
            get
            {
                return values.ToArray();
            }
        }

        public String Name
        {
            get { return this.name; }
        }

        public double InitialExchangeRate
        {
            get { return this.initialExchangeRate; }
        }

        private Currency(String name, double initialExchangeRate)
        {
            this.name = name;
            this.initialExchangeRate = initialExchangeRate;
            add(this);
        }

        private static void add(Currency item)
        {
            if (values == null)
            {
                values = new List<Currency>();
            }
            values.Add(item);
        }

        public int GetOrdinal()
        {
            return values.IndexOf(this);
        }

        public override String ToString()
        {
            return this.name;
        }

    }
}
