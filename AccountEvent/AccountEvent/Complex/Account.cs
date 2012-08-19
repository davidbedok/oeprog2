using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountEvent.Complex
{
    public abstract class Account
    {
        private static int MAX_EVENT = 100;

        protected static string SIGN = "Ft";

        private readonly string ownerName;
        private readonly string accountNumber;
        private AccountEvent.Alter.Event[] events;
        private int actEvent;

        public string OwnerName
        {
            get
            {
                return this.ownerName;
            }
        }

        public string AccountNumber
        {
            get
            {
                return this.accountNumber;
            }
        }

        public Account(string ownerName, string accountNumber)
        {
            this.ownerName = ownerName;
            this.accountNumber = accountNumber;
            this.events = new AccountEvent.Alter.Event[Account.MAX_EVENT];
        }

        public void addEvent(AccountEvent.Alter.Event pevent)
        {
            if (this.actEvent < Account.MAX_EVENT)
            {
                this.events[this.actEvent] = pevent;
                System.Console.WriteLine(this.events[this.actEvent]);
                if (pevent is TransferEvent)
                {
                    TransferEvent te = (TransferEvent)pevent;
                    Account targetAccount = te.TargetAccount;
                    if ( (targetAccount is MoneyAccount) && (this is MoneyAccount) ){
                        MoneyAccount baseAccount = (MoneyAccount)this;
                        MoneyAccount targetMoneyAccount = (MoneyAccount)targetAccount;
                        baseAccount.Money -= te.TransferValue;
                        targetMoneyAccount.Money += te.TransferValue;
                    }
                }
                actEvent++;
            }
        }

        public void addEvent(string message, DateTime date)
        {
            this.addEvent(new AccountEvent.Alter.AdministrationEvent(message, date));
        }

        public void addEvent(Account target, double value, DateTime date)
        {
            this.addEvent(new TransferEvent(target, value, date));
        }

        public override string ToString()
        {
            return this.ownerName + ":" + this.accountNumber;
        }

    }
}
