using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoneyAndSecurities.Mortgage;
using MoneyAndSecurities.Wealth;

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

        public void addMoneyAccount(Currency currency, int count)
        {
            this.moneyAccounts.Add(new Account<Money>(this.person, new Money(currency, count)));
        }

        public void addChattelAccount(String name, int marketPrice, int count)
        {
            this.chattelAccounts.Add(new Account<Chattel>(this.person, new Chattel(name, marketPrice, count)));
        }

        public void income(Currency currency, int count)
        {
            this.findMoneyAccount(currency).income(count);
        }

        public Account<Money> findMoneyAccount(Currency currency)
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

        public override string ToString()
        {
            StringBuilder info = new StringBuilder(100);
            info.AppendLine("[PersonAccount] Person: " + person);
            info.AppendLine("Money accounts: ");
            foreach ( Account<Money> moneyAccount in this.moneyAccounts ) {
                info.AppendLine(moneyAccount.ToString());
            }
            info.AppendLine("Chattel accounts: ");
            foreach (Account<Chattel> chattelAccount in this.chattelAccounts)
            {
                info.AppendLine(chattelAccount.ToString());
            }
            return info.ToString();
        }


    }
}
