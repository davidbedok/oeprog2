using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoneyAndSecurities.Wealth;

namespace MoneyAndSecurities.Mortgage
{
    // institution wrapper..
    public class Account<T> where T: Property
    {

        private Person proprietor;
        private T wealth;

        public Account(Person proprietor, T wealth)
        {
            this.proprietor = proprietor;
            this.wealth = wealth;
        }

        public int getValue()
        {
            return wealth.value();
        }

        public void income(int count)
        {
            this.wealth.income(count);
        }

        public void outcome(int count)
        {
            try
            {
                this.wealth.outcome(count);
            }
            catch (InvalidCountException e)
            {
                this.wealth.outcome(count + e.WrongCount);  
            }
        }

        public bool check( Currency currency ) 
        {
            bool ret = false;
            if (wealth is Money)
            {
                Money money = wealth as Money;
                ret = money.Currency == currency;
            }
            return ret;
        }

        /*
        public override bool Equals(Object othat)
        {
            if (othat == null)
            {
                return false;
            }
            if (othat is Account<T>)
            {
                Account<T> that = othat as Account<T>;
                return this.Equals(that);
            }
            return false;
        }

        public bool Equals(Account<T> that)
        {
            if ((object)that == null)
            {
                return false;
            }
            if (that.c)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 13 * (int)width;
        }
        */

        public override string ToString()
        {
            return proprietor + " - " + wealth;
        }

    }
}
