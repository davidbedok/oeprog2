using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZooManager
{
    public abstract class Herbivorous : ZooAnimal
    {

        public Herbivorous(String name, DateTime dateOfBirth)
            : base(name, dateOfBirth)
        {
           
        }

        protected override Food getFood()
        {
            return new Herb(this.getFoodName());
        }

    }
}
