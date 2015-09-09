using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class ExchangeRateHolder
    {

        private static ExchangeRateHolder INSTANCE;

        private readonly Dictionary<Currency, Double> rates;

        public double this[Currency key]
        {
            get
            {
                return this.rates[key];
            }
            set
            {
                this.rates[key] = value;
            }
        }

        private ExchangeRateHolder()
        {
            this.rates = new Dictionary<Currency, Double>();
            foreach (Currency currency in Currency.Values)
            {
                this.rates.Add(currency, currency.InitialExchangeRate);
            }
        }

        public double Convert(Currency from, Currency to, double value)
        {
            double fromExchangeRate = this[from];
            double toExchangeRate = this[to];
            return value * fromExchangeRate / toExchangeRate;
        }

        public static ExchangeRateHolder GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new ExchangeRateHolder();
            }
            return INSTANCE;
        }

    }
}
