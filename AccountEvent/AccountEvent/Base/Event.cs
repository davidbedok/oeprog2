using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountEvent.Base
{
    public abstract class Event
    {
        private static int SEQ_ORDER = 0;

        private Account account;
        private DateTime date;
        private int order;

        public Account BaseAccount
        {
            get
            {
                return this.account;
            }
        }

        public Event( Account account, DateTime date )
        {
            this.account = account;
            this.date = date;
            this.order = Event.SEQ_ORDER;
            Event.SEQ_ORDER++;
        }

        public abstract string print();

        public override string ToString()
        {
            // return "<" + this.account.ToString() + "> ["+this.order+"] (date:" + this.date.ToShortDateString()+ ")";
            return "<" + this.order + "." + this.account.ToString() + ">";
        }

    }
}
