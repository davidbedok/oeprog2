using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZooManager
{
    public class Koala : Herbivorous
    {

        public Koala(String name, DateTime dateOfBirth)
            : base(name, dateOfBirth)
        {
           
        }

        protected override int getAmount()
        {
            return 10;
        }

        protected override String getFoodName()
        {
            return "eucalyptus";
        }

        public override string ToString()
        {
            return "Koala " + base.ToString();
        }

    }
}
