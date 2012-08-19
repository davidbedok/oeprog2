using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountEvent.Alter
{
    public abstract class Event
    {

        private static int SEQ_ORDER = 0;

        private DateTime date;
        private int order;

        public Event( DateTime date )
        {
            this.date = date;
            this.order = Event.SEQ_ORDER;
            Event.SEQ_ORDER++;
        }

        public abstract string print();

        public override string ToString()
        {
            // return "["+this.order+"] (date:" + this.date.ToShortDateString()+ ")";
            return "<" + this.order + ">";
        }

    }
}
