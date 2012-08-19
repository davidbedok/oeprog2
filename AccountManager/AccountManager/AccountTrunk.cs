using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountManager
{
    public class AccountTrunk : ITrunk
    {
 
        private List<Account> accounts;
        private List<Transfer> transfers;
        private Dictionary<Currency,double> holder;

        public AccountTrunk()
        {
            this.accounts = new List<Account>();
            this.transfers = new List<Transfer>();
            this.holder = new Dictionary<Currency,double>();
        }

        public void addCurrency(Currency currency, double value)
        {
            if (!this.holder.ContainsKey(currency))
            {
                this.holder.Add(currency, value);
            }
        }

        protected void addAccount(Account account)
        {
            if (!this.accounts.Contains(account))
            {
                this.accounts.Add(account);
            }
        }

        public void addAccount(string accountNumber, Currency currency)
        {
            Account account = this.getAccountByNumber(accountNumber);
            if (account == null)
            {
                this.addAccount(new Account(accountNumber, currency));
            }
            else
            {
                this.accounts.Remove(account);
                this.addAccount(new Account(accountNumber, currency));
            }
        }

        protected void addTransfer(Transfer transfer)
        {
            this.transfers.Add(transfer);
        }

        protected void addTransfer(Account account, Currency currency, double value)
        {

            this.addTransfer(new Transfer(account, currency, value));
        }

        public void addTransfer(string accountNumber, Currency currency, double value)
        {
            Account account = this.getAccountByNumber(accountNumber);
            if (account != null)
            {
                this.addTransfer(account, currency, value);
            }
        }

        protected Account getAccountByNumber( string accountNumber )
        {
            foreach (Account a in this.accounts)
            {
                if (a.AccountNumber.Equals(accountNumber))
                {
                    return a;
                }
            }
            return null;
        }

        public double convertCurrency(Currency from, Currency to, double value)
        {
            return this.holder[from] / this.holder[to] * value;
        }

        public double getAccountValue(string accountNumber)
        {
            double ret = 0;
            Account account = this.getAccountByNumber(accountNumber);
            if (account != null)
            {
                foreach (Transfer t in this.transfers)
                {
                    if (t.Account.Equals(account))
                    {
                        ret += this.convertCurrency(t.CurrencyType, account.CurrencyType, t.Value);
                    }
                }
            }
            return ret;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Accounts");
            foreach (Account a in this.accounts)
            {
                sb.AppendLine(a.ToString());
            }
            sb.AppendLine("Transfers");
            foreach (Transfer t in this.transfers)
            {
                sb.AppendLine(t.ToString());
            }
            return sb.ToString();
        }

    }
}
