using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountEvent
{
    public class Instrument
    {
        private readonly string name;
        private double value;

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public double Value
        {
            get
            {
                return this.value;
            }
        }

        public Instrument(string name, double value)
        {
            this.name = name;
            this.value = value;
        }

        public void changeValue( int percent ){
            this.value += (percent / 100 * this.value);
        }

        public override string ToString()
        {
            return this.name+ " ("+this.value+")";
        }

    }
}
