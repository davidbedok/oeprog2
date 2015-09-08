using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists.hidegenerics
{
    public class Dog : Pet
    {

        private int lengthOfHairs;

        public Dog(String name)
            : base(name)
        {
            this.lengthOfHairs = 10;
        }

        public void CutHair(int length)
        {
            this.lengthOfHairs -= length;
        }

        public override string ToString()
        {
            return "Dog" + base.ToString() + " length of hairs: " + this.lengthOfHairs;
        }

    }
}
