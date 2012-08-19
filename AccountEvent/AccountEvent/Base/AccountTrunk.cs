using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountEvent.Base
{
    public class AccountTrunk : IAccountTrunk
    {

        private readonly int MAX_EVENT;
        private static int MAX_ACCOUNT = 100;
        private Account[] accounts;
        private Event[] events;
        private Securities securities;
        private int actAccount;
        private int actEvent;

        public AccountTrunk( int maxEvent )
        {
            this.MAX_EVENT = maxEvent;
            this.events = new Event[this.MAX_EVENT];
            this.accounts = new Account[AccountTrunk.MAX_ACCOUNT];
            this.securities = new Securities();
            this.actAccount = 0;
            this.actEvent = 0;
        }

        #region Search functions

        /// <summary>
        /// Szamlaszam alapjan visszaadja a Szamlat
        /// </summary>
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

        /// <summary>
        /// Esemeny felvitele 0. szint (mindenkeppen private)
        /// </summary>
        private void addEvent(Event pevent){
            if (this.actEvent < this.MAX_EVENT)
            {
                this.events[this.actEvent] = pevent;
                System.Console.WriteLine(this.events[this.actEvent]);
                if (pevent is TransferEvent)
                {
                    TransferEvent te = (TransferEvent)pevent;
                    Account baseAccount = te.BaseAccount;
                    Account targetAccount = te.TargetAccount;
                    if (baseAccount.Balance >= te.TransferValue)
                    {
                        baseAccount.Balance -= te.TransferValue;
                        targetAccount.Balance += te.TransferValue;
                    }
                }
                actEvent++;
            }
        }

        /// <summary>
        /// Szamla felvitele 0. szint (mindenkeppen private)
        /// </summary>
        private void addAccount(Account account)
        {
            if (this.actAccount < AccountTrunk.MAX_ACCOUNT)
            {
                this.accounts[this.actAccount++] = account;
            }
        }

        /// <summary>
        /// Ertekpapir felvitele 1. szint (nyilvanos, mert a felvitel a Securities osztalyban van!)
        /// </summary>
        public void addInstrument(string name, double value)
        {
            this.securities.addInstrument(name, value);
        }

        #endregion

        #region Add Event functions

        /// <summary>
        /// Esemeny felvitele 1. szint - leszarmazott konstruktorok csomagolasa - AdministrationEvent (mindenkeppen private)
        /// </summary>
        private void addEvent(string message, Account account, DateTime date)
        {
            // 0. szintet hiv
            this.addEvent(new AdministrationEvent(message,account,date));
        }

        /// <summary>
        /// Esemeny felvitele 1. szint - leszarmazott konstruktorok csomagolasa - TransferEvent (mindenkeppen private)
        /// </summary>
        private void addEvent(Account target, double value, Account account, DateTime date)
        {
            // 0. szintet hiv
            this.addEvent(new TransferEvent(target, value, account, date));
        }

        /// <summary>
        /// Esemeny felvitele 2. szint - Account csomagolasa keresessel (AdministrationEvent)
        /// </summary>
        public void addEvent(string message, string accountNumber, DateTime date)
        {
            // 1. szintet hiv
            this.addEvent(message, this.findAccountByAccountNumber(accountNumber), date);
        }

        /// <summary>
        /// Esemeny felvitele 2. szint - Account csomagolasa keresessel (TransferEvent)
        /// </summary>
        public void addEvent(String targetAccountNumber, double value, String accountNumber, DateTime date)
        {
            this.addEvent(this.findAccountByAccountNumber(targetAccountNumber), value, this.findAccountByAccountNumber(accountNumber), date);
        }

        #endregion

        #region Add Account functions

        /// <summary>
        /// Szamla felvitele 1. szint - konstruktorok csomagolasa - Account
        /// </summary>
        public void addAccount(string ownerName, string accountNumber)
        {
            // 0. szintet hiv
            this.addAccount(new Account(ownerName, accountNumber));
        }

        /// <summary>
        /// Szamla felvitele 1. szint - konstruktorok csomagolasa + egyenleg beallitas - Account
        /// </summary>
        public void addAccount(string ownerName, string accountNumber, double balance)
        {
            // 0. szintet hiv
            Account account = new Account(ownerName, accountNumber);
            account.Balance = balance;
            this.addAccount(account);
        }

        /// <summary>
        /// Szamla felvitele 1. szint - konstruktorok csomagolasa - MoneyAccount
        /// </summary>
        public void addAccount(double moneyBalance, string ownerName, string accountNumber)
        {
            // 0. szintet hiv
            this.addAccount(new MoneyAccount(moneyBalance, ownerName, accountNumber));
        }

        /// <summary>
        /// Szamla felvitele 1. szint - konstruktorok csomagolasa - StockAccount (Instrument miatt private)
        /// </summary>
        private void addAccount(Instrument instrument, int number, string ownerName, string accountNumber)
        {
            // 0. szintet hiv
            this.addAccount(new StockAccount(instrument, number, ownerName, accountNumber));
        }

        /// <summary>
        /// Szamla felvitele 2. szint - Instrument csomagolasa keresessel - StockAccount
        /// </summary>
        public void addAccount(string instrumentName, int number, string ownerName, string accountNumber)
        {
            // 1. szintet hiv
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
            for (int i = 0; i < this.actAccount; i++){
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
                ret += this.accounts[i].Balance;
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
                ret += "[" + i + "] " + this.accounts[i]+"\n";
            }
            ret += "TrunkValue: "+this.getTrunkValue()+"\n";
            ret += "AllTrunkValue: " + this.getAllTrunkValue() + "\n";
            return ret;
        }

    }
}
