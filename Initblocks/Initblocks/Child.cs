using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Initblocks
{
    public class Child : Parent
    {
        protected string dummy;
        protected bool flag;

        public string Dummy
        {
            get { return this.dummy; }
            set { this.dummy = value; }
        }

        public bool Flag
        {
            get { return this.flag; }
            set { this.flag = value; }
        }

        // a ctor hasznalata csak abban az esetben indokolt, 
        // ha a dummy es a flag ertekei opcionálisak, avagy van alapértelmezett értékük
        public Child(int foo, char bar)
            : base(foo, bar)
        {
            // nothing to do
            this.flag = true; // default value
            this.init();
        }

        // a Java-val valo osszehasonlitas miatt letezik a metodus (egyebkent nem lenne ra szukseg)
        // Java-ban is csak az anonymous classok kapcsan lesz felhasznalva
        protected void init()
        {
            // nothing to do
        }

        public Child(int foo, char bar, string dummy, bool flag)
            : this(foo, bar)
        {
            this.dummy = dummy;
            this.flag = flag;
        }

        public override string ToString()
        {
            return this.dummy + " " + this.flag + " " + base.ToString();
        }

    }
}
