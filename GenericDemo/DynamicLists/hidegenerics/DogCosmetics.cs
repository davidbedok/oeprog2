using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists.hidegenerics
{
    public class DogCosmetics : PetHolder<Dog>
    {

        public void Haircut(String dogName, int length)
        {
            this.Find(dogName).CutHair(length);
        }

    }
}
