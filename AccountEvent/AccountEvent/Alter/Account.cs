using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountEvent.Alter
{
    public class Account
    {
        private static int MAX_EVENT = 100;

        protected static string SIGN = "Ft";

        private readonly string ownerName;
        private readonly string accountNumber;
        private double balance;
        private Event[] events;
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

        public double Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }

        public Account(string ownerName, string accountNumber )
        {
            this.ownerName = ownerName;
            this.accountNumber = accountNumber;
            this.balance = 0;

            this.events = new Event[Account.MAX_EVENT];
        }

        public void addEvent(Event pevent)
        {
            if (this.actEvent < Account.MAX_EVENT)
            {
                this.events[this.actEvent] = pevent;
                System.Console.WriteLine(this.events[this.actEvent]);
                if (pevent is TransferEvent)
                {
                    TransferEvent te = (TransferEvent)pevent;
                    Account targetAccount = te.TargetAccount;
                    if (this.balance >= te.TransferValue)
                    {
                        this.balance -= te.TransferValue;
                        targetAccount.Balance += te.TransferValue;
                    }
                }
                actEvent++;
            }
        }

        public void addEvent(string message, DateTime date)
        {
            this.addEvent(new AdministrationEvent(message,date));
        }

        public void addEvent(Account target, double value, DateTime date)
        {
            this.addEvent(new TransferEvent(target,value,date));
        }

        public override string ToString()
        {
            return this.ownerName + ":" + this.accountNumber + " [" + this.balance + " "+Account.SIGN+"]";
        }

    }
}
