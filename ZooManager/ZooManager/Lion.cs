using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZooManager
{
    public class Lion : Carnivorous
    {

        public Lion(String name, DateTime dateOfBirth)
            : base(name, dateOfBirth)
        {
           
        }

        protected override int getAmount()
        {
            return 50;
        }

        protected override String getFoodName()
        {
            return "zebra";
        }

        public override string ToString()
        {
            return "Lion " + base.ToString();
        }

    }
}
