using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists.generic
{
    public class GenericCreateDemo<E> : System.Object
        where E : new()
    {

        private E variable;

        public GenericCreateDemo()
        {
            this.variable = new E();
        }

        public override string  ToString()
        {
 	         return this.variable.ToString();
        }

    }
}
