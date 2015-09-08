using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists.hidegenerics
{
    public class PetShop<T> : PetHolder<T> where T : Pet
    {

        public void Buy(String name, String owner)
        {
            this.Find(name).Owner = owner;
        }

    }
}
