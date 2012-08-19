using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapImplementation
{
    public class Mark
    {
        private int percent;
        private string comment;

        public int Percent
        {
            get { return this.percent; }
        }

        public string Comment 
        {
            get { return this.comment; }    
        }

        public Mark(int percent, string comment)
        {
            this.percent = percent;
            this.comment = comment;
        }

        public override string ToString()
        {
            return this.percent + " % ("+this.comment+")";
        }

    }
}
