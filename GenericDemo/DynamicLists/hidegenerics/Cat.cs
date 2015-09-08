using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists.hidegenerics
{
    public class Cat : Pet
    {

        public Cat(String name) : base(name) { }

        public override string ToString()
        {
            return "Cat" + base.ToString();
        }

    }
}
