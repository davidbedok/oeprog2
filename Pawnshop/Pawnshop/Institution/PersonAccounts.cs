using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoneyAndSecurities.Mortgage;
using MoneyAndSecurities.Wealth;
using MoneyAndSecurities.Exceptions;

namespace MoneyAndSecurities.Institution
{
    public class PersonAccounts
    {
        private Person person;
        private List<Account<Money>> moneyAccounts;
        private List<Account<Chattel>> chattelAccounts;

        public Person Person
        {
            get { return this.person; }
        }

        public PersonAccounts(Person person)
        {
            this.person = person;
            this.moneyAccounts = new List<Account<Money>>();
            this.chattelAccounts = new List<Account<Chattel>>();
        }

        public void addAccount(String accountNumber, Currency currency, int count)
        {
            this.moneyAccounts.Add(new Account<Money>(accountNumber, new Money(currency, count)));
        }

        public void addAccount(String accountNumber, String name, int marketPrice, int count)
        {
            this.chattelAccounts.Add(new Account<Chattel>(accountNumber, new Chattel(name, marketPrice, count)));
        }

        public void income(Currency currency, int count)
        {
            // Account<Money> account = this.findAccount(currency);
            Account<Money> account = PersonAccounts.findAccount(currency, this.moneyAccounts);
            PersonAccounts.income(account, count);
        }

        public void income(String name, int count)
        {
            // Account<Chattel> account = this.findAccount(name);
            Account<Chattel> account = PersonAccounts.findAccount(name, this.chattelAccounts);
            PersonAccounts.income(account, count);
        }

        public void outcome(Currency currency, int count)
        {
            PersonAccounts.outcome(PersonAccounts.findAccount(currency, this.moneyAccounts), count);
        }

        public void outcome(String name, int count)
        {
            PersonAccounts.outcome(PersonAccounts.findAccount(name, this.chattelAccounts), count);
        }

        private static void income<T>(Account<T> account, int count) where T : Property
        {
            if (account != null)
            {
                account.income(count);
            }
            else
            {
                throw new UnknownAccountException("Account is not exists (count: " + count + ")");
            }
        }

        private static void outcome<T>(Account<T> account, int count) where T: Property
        {
            if (account != null)
            {
                account.outcome(count);
            }
            else
            {
                throw new UnknownAccountException("Account is not exists (count: " + count + ")");
            }
        }

        #region Find non-generic methods

        private Account<Money> findAccount(Currency currency)
        {
            Account<Money> ret = null;
            foreach (Account<Money> moneyAccount in this.moneyAccounts)
            {
                if (moneyAccount.check(currency))
                {
                    ret = moneyAccount;
                    break;
                }
            }
            return ret;
        }

        private Account<Chattel> findAccount(String name)
        {
            Account<Chattel> ret = null;
            foreach (Account<Chattel> chattelAccount in this.chattelAccounts)
            {
                if (chattelAccount.check(name))
                {
                    ret = chattelAccount;
                    break;
                }
            }
            return ret;
        }

        #endregion

        private static Account<T> findAccount<T, S>(S currency, List<Account<T>> accounts) where T : Property
        {
            Account<T> ret = null;
            foreach (Account<T> account in accounts)
            {
                if (account.check(currency))
                {
                    ret = account;
                    break;
                }
            }
            return ret;
        }

        public int value()
        {
            return PersonAccounts.valueSum(this.moneyAccounts) + PersonAccounts.valueSum(this.chattelAccounts);
        }

        private static int valueSum<T>(List<Account<T>> accounts) where T : Property
        {
            int value = 0;
            StringBuilder info = new StringBuilder(100);
            foreach (Account<T> account in accounts)
            {
                value += account.value();
            }
            return value;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder(100);
            info.AppendLine("[PersonAccount] Person: " + person + " total value: " + this.value());
            info.AppendLine("Money accounts: ");
            info.AppendLine(PersonAccounts.printAccounts(this.moneyAccounts));
            info.AppendLine("Chattel accounts: ");
            info.AppendLine(PersonAccounts.printAccounts(this.chattelAccounts));
            return info.ToString();
        }

        private static String printAccounts<T>(List<Account<T>> accounts) where T : Property
        {
            StringBuilder info = new StringBuilder(100);
            foreach (Account<T> account in accounts)
            {
                info.AppendLine(account.ToString());
            }
            return info.ToString();
        }

    }
}
