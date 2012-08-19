using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountEvent.Base
{
    public class TransferEvent : Event
    {
        private Account target;
        private double value;

        public Account TargetAccount
        {
            get
            {
                return this.target;
            }
        }

        public double TransferValue
        {
            get
            {
                return this.value;
            }
        }

        public TransferEvent(Account target, double value, Account account, DateTime date)
            : base(account,date)
        {
            this.target = target;
            this.value = value;
        }

        public override string print()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            return "[Trans] " + base.ToString() + " " + this.target + " --> "+this.value;
        }


    }
}
