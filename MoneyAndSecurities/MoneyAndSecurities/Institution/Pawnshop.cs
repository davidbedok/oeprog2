using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoneyAndSecurities.Wealth;
using MoneyAndSecurities.Institution;

namespace MoneyAndSecurities.Mortgage
{
    public class Pawnshop
    {
        List<PersonAccounts> accounts = new List<PersonAccounts>();

        public Pawnshop()
        {
            this.accounts = new List<PersonAccounts>();
        }

        public void addPerson( String name )
        {
            this.accounts.Add(new PersonAccounts(new Person(name)));
        }

        public void addMoneyAccount(String personName, Currency currency, int count)
        {
            PersonAccounts pa = this.findPersonAccounts(personName);
            pa.addMoneyAccount(currency, count);
        }

        public void addChattelAccount(String personName, String name, int marketPrice, int count)
        {
            PersonAccounts pa = this.findPersonAccounts(personName);
            pa.addChattelAccount(name, marketPrice, count);
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
