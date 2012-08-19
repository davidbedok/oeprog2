using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountManager
{
    public interface ITrunk
    {
        void addCurrency(Currency currency, double value);
        void addAccount(string accountNumber, Currency currency);
        void addTransfer(string accountNumber, Currency currency, double value);    
        double convertCurrency(Currency from, Currency to, double value);
        double getAccountValue(string accountNumber);
    }
}
