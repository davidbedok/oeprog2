using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountEvent.Complex
{
    public class AccountTrunk
    {

        private static int MAX_ACCOUNT = 100;
        private Account[] accounts;
        private Securities securities;
        private int actAccount;

        public AccountTrunk()
        {
            this.accounts = new Account[AccountTrunk.MAX_ACCOUNT];
            this.securities = new Securities();
            this.actAccount = 0;
        }

        #region Search functions

        private Account findAccountByAccountNumber(string accountNumber)
        {
            Account ret = null;
            int i = 0;
            bool find = false;
            while ((i < actAccount) && (!find))
            {
                if (this.accounts[i].AccountNumber.Equals(accountNumber))
                {
                    ret = this.accounts[i];
                    find = true;
                }
                i++;
            }
            return ret;
        }

        #endregion

        #region Base Add functions

        private void addAccount(Account account)
        {
            if (this.actAccount < AccountTrunk.MAX_ACCOUNT)
            {
                this.accounts[this.actAccount++] = account;
            }
        }

        public void addInstrument(string name, double value)
        {
            this.securities.addInstrument(name, value);
        }

        #endregion

        #region Add Event functions

        /// <summary>
        /// Az Esemeny felvitele az Account osztalyba van csomagolva
        /// </summary>
        public void addEvent(string message, string accountNumber, DateTime date)
        {
            this.findAccountByAccountNumber(accountNumber).addEvent(message, date);
        }

        public void addEvent(string targetAccountNumber, double value, string accountNumber, DateTime date)
        {
            Account targetAccount = this.findAccountByAccountNumber(targetAccountNumber);
            this.findAccountByAccountNumber(accountNumber).addEvent(targetAccount, value, date);
        }

        #endregion

        #region Add Account functions

        public void addAccount(string ownerName, string accountNumber, double moneyBalance )
        {
            this.addAccount(new MoneyAccount(moneyBalance, ownerName, accountNumber));
        }

        private void addAccount(Instrument instrument, int number, string ownerName, string accountNumber)
        {
            this.addAccount(new StockAccount(instrument, number, ownerName, accountNumber));
        }

        public void addAccount(string ownerName, string accountNumber, string instrumentName, int number )
        {
            this.addAccount(this.securities.findInstrumentByName(instrumentName), number, ownerName, accountNumber);
        }

        #endregion

        #region Business functions

        public double getAllTrunkValue()
        {
            double ret = 0;
            for (int i = 0; i < this.actAccount; i++)
            {
                if (this.accounts[i] is MoneyAccount)
                {
                    ret += (this.accounts[i] as MoneyAccount).Money;
                }
                if (this.accounts[i] is StockAccount)
                {
                    ret += (this.accounts[i] as StockAccount).CalcValue;
                }
            }
            return ret;
        }

        public double getAllTrunkValue(string ownerName)
        {
            double ret = 0;
            for (int i = 0; i < this.actAccount; i++)
            {
                if (this.accounts[i].OwnerName.Equals(ownerName))
                {

                    if (this.accounts[i] is MoneyAccount)
                    {
                        ret += (this.accounts[i] as MoneyAccount).Money;
                    }
                    if (this.accounts[i] is StockAccount)
                    {
                        ret += (this.accounts[i] as StockAccount).CalcValue;
                    }

                }
            }
            return ret;
        }

        public string getPeopleValue()
        {
            string ret = "";
            string[] allPerson = new string[AccountTrunk.MAX_ACCOUNT];
            int allPersonCount = 0;
            for (int i = 0; i < this.actAccount; i++)
            {
                string owner = this.accounts[i].OwnerName;

                bool find = false;
                int j = 0;
                while ((j < allPersonCount) && (!find))
                {
                    if (allPerson[j].Equals(owner))
                    {
                        find = true;
                    }
                    j++;
                }
                if (!find)
                {
                    allPerson[allPersonCount++] = owner;
                }
            }
            for (int i = 0; i < allPersonCount; i++)
            {
                ret += allPerson[i] + " sum value: " + this.getAllTrunkValue(allPerson[i]) + "\n";
            }
            return ret;
        }

        public double getTrunkValue()
        {
            double ret = 0;
            for (int i = 0; i < this.actAccount; i++)
            {
                if (this.accounts[i] is MoneyAccount)
                {
                    ret += (this.accounts[i] as MoneyAccount).Money;
                }
            }
            return ret;
        }

        #endregion

        public override string ToString()
        {
            string ret = "\n### AccountTrunk\n";
            ret += "# Accounts\n";
            for (int i = 0; i < this.actAccount; i++)
            {
                ret += "[" + i + "] " + this.accounts[i] + "\n";
            }
            ret += "TrunkValue: " + this.getTrunkValue() + "\n";
            ret += "AllTrunkValue: " + this.getAllTrunkValue() + "\n";
            return ret;
        }

    }
}
