using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountEvent.Complex
{
    public class TransferEvent : AccountEvent.Alter.Event
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

        public TransferEvent(Account target, double value, DateTime date)
            : base(date)
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
            return "[Trans] " + base.ToString() + " " + this.target + " --> " + this.value;
        }

    }
}
