using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoneyAndSecurities.Wealth;
using MoneyAndSecurities.Exceptions;

namespace MoneyAndSecurities.Mortgage
{
    // institution wrapper..
    public class Account<T> where T: Property
    {

        private String accountNumber;
        private T wealth;

        public Account(String accountNumber, T wealth)
        {
            this.accountNumber = accountNumber;
            this.wealth = wealth;
        }

        public int value()
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

        public bool check(Object condition)
        {
            bool ret = false;
            if ( (wealth is Money) && ( condition is Currency ) )
            {
                Money money = wealth as Money;
                Currency currency = (Currency)Enum.Parse(typeof(Currency), condition.ToString());
                ret = money.Currency == currency;
            }
            else if ((wealth is Chattel) && (condition is String))
            {
                Chattel chattel = wealth as Chattel;
                String name = condition as String;
                ret = chattel.Name == name;
            }
            return ret;
        }

        public override string ToString()
        {
            return "AccountNumber: " + accountNumber + " - " + wealth;
        }

    }
}
