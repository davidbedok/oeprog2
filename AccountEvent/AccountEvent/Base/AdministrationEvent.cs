using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountEvent.Base
{
    public class AdministrationEvent : Event
    {
        private string message;

        public AdministrationEvent(string message, Account account, DateTime date)
            : base(account,date)
        {
            this.message = message;
        }

        public override string print()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            return "[Admin]" + base.ToString() + " " + this.message;
        }

    }
}
