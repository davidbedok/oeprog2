using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountEvent
{
    public class Securities
    {
        private static readonly int MAX_INSTRUMENT = 100;
        private Instrument[] instruments;
        private int actInstrument;

        public Securities()
        {
            this.instruments = new Instrument[Securities.MAX_INSTRUMENT];
            this.actInstrument = 0;
        }

        public void addInstrument(Instrument instrument)
        {
            if (this.actInstrument < Securities.MAX_INSTRUMENT)
            {
                this.instruments[actInstrument++] = instrument;
            }
        }

        public void addInstrument(string name, double value)
        {
            this.addInstrument(new Instrument(name, value));
        }

        public Instrument findInstrumentByName(string name)
        {
            Instrument ret = null;
            int i = 0;
            bool find = false;
            while ((i < actInstrument) && (!find))
            {
                if (this.instruments[i].Name.Equals(name))
                {
                    ret = this.instruments[i];
                    find = true;
                }
                i++;
            }
            return ret;
        }

        public override string ToString()
        {
            string ret = "## Securities\n";
            for (int i = 0; i < this.actInstrument; i++)
            {
                ret += "["+i+"] "+this.instruments[i];
            }
            return ret;
        }

    }
}
