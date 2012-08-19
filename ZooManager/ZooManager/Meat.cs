using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZooManager
{
    public class Meat : Food
    {

        public Meat(String name)
            : base(name)
        {

        }

        public override string ToString()
        {
            return "Meat " + base.ToString();
        }

    }
}
