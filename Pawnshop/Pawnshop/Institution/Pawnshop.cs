using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoneyAndSecurities.Wealth;
using MoneyAndSecurities.Institution;
using MoneyAndSecurities.Exceptions;

namespace MoneyAndSecurities.Mortgage
{
    public class Pawnshop
    {
        private int accountNumberSequence;
        private List<PersonAccounts> accounts = new List<PersonAccounts>();

        public Pawnshop()
        {
            this.accounts = new List<PersonAccounts>();
            this.accountNumberSequence = 0;
        }

        public void addPerson( String name )
        {
            this.accounts.Add(new PersonAccounts(new Person(name)));
        }

        public void income(String personName, Currency currency, int count)
        {
            PersonAccounts personAccounts = this.findPersonAccounts(personName);
            if (personAccounts != null)
            {
                try
                {
                    personAccounts.income(currency, count);
                }
                catch (UnknownAccountException e)
                {
                    personAccounts.addAccount("MON" + ++this.accountNumberSequence, currency, count);
                }
            }
        }

        public void income(String personName, String name, int marketPrice, int count)
        {
            PersonAccounts personAccounts = this.findPersonAccounts(personName);
            if (personAccounts != null)
            {
                try
                {
                    personAccounts.income(name, count);
                }
                catch (UnknownAccountException e)
                {
                    personAccounts.addAccount("CHA" + ++this.accountNumberSequence, name, marketPrice, count);
                }
            }
        }

        public void outcome(String personName, Currency currency, int count)
        {
            PersonAccounts personAccounts = this.findPersonAccounts(personName);
            if (personAccounts != null)
            {
                try
                {
                    personAccounts.outcome(currency, count);
                }
                catch (UnknownAccountException e)
                {
                    personAccounts.addAccount("MON" + ++this.accountNumberSequence, currency, count);
                }
            }
        }

        public void outcome(String personName, String name, int marketPrice, int count)
        {
            PersonAccounts personAccounts = this.findPersonAccounts(personName);
            if (personAccounts != null)
            {
                try
                {
                    personAccounts.outcome(name, count);
                }
                catch (UnknownAccountException e)
                {
                    // log warning, etc.
                }
            }
        }

        private PersonAccounts findPersonAccounts(String name)
        {
            PersonAccounts ret = null;
            foreach (PersonAccounts personAccount in this.accounts)
            {
                if (personAccount.Person.Name.Equals(name))
                {
                    ret = personAccount;
                    break;
                }
            }
            return ret;
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder(100);
            foreach (PersonAccounts personAccount in this.accounts)
            {
                info.AppendLine(personAccount.ToString());
            }
            return info.ToString();
        }

    }
}
