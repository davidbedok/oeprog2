using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZooManager
{
    public abstract class Carnivorous : ZooAnimal
    {

        public Carnivorous(String name, DateTime dateOfBirth)
            : base(name, dateOfBirth)
        {
           
        }

        protected override Food getFood()
        {
            return new Meat(this.getFoodName());
        }

    }
}
