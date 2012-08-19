using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZooManager
{
    public class Herb: Food
    {

        public Herb(String name)
            : base(name)
        {

        }

        public override string ToString()
        {
            return "Herb " + base.ToString();
        }

    }
}
