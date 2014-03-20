using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists.generic
{
    public class GenericMultiClass<E,K>
    {
        private E id;
        private K name;

        public GenericMultiClass(E id, K name)
        {
            this.id = id;
            this.name = name;
        }

        public E Id
        {
            get { return this.id; }
        }

        public K Name
        {
            get { return this.name; }
        }

        public override string ToString()
        {
            return this.Name + " (" + this.Id + ")";
        }


    }
}
