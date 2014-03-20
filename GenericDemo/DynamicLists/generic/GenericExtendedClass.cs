using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicLists.demo;

namespace DynamicLists.generic
{
    public class GenericExtendedClass<E> : System.Object
        where E : AbstractTest 
    {

        private E variable;

        public GenericExtendedClass(E variable)
        {
            this.variable = variable;
        }

        public void print() {
		    System.Console.WriteLine(variable.toPrint());
	    }

    }
}
