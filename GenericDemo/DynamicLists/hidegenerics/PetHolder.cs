using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists.hidegenerics
{
    public abstract class PetHolder<T> where T : Pet
    {
        private List<T> animals;

        public PetHolder()
        {
            this.animals = new List<T>();
        }

        public void Add(T animal)
        {
            this.animals.Add(animal);
        }

        public T Find(String name)
        {
            T result = null;
            foreach (T animal in this.animals)
            {
                if (animal.Name.Equals(name))
                {
                    result = animal;
                    break;
                }
            }
            return result;
        }

    }
}
