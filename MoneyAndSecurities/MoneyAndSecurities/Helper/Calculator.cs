using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoneyAndSecurities.Wealth;

namespace MoneyAndSecurities.Helper
{
    public class Calculator
    {

        // Int32 --> simplicity
        private Dictionary<Currency, Int32> exchangeRates;

        public Int32 exchangeRate( Currency currency )
        {
            return this.exchangeRates[currency];
        }

        // -------------------------------------------------

        private static Calculator instance = null;

        private Calculator()
        {
            this.exchangeRates = new Dictionary<Currency, Int32>();
            this.exchangeRates.Add(Currency.HUF, 1);
            this.exchangeRates.Add(Currency.CHF, 242);
            this.exchangeRates.Add(Currency.EUR, 296);
        }

        public static Calculator getInstance()
        {
            if (Calculator.instance == null)
            {
                Calculator.instance = new Calculator();
            }
            return Calculator.instance;
        }

    }
}
