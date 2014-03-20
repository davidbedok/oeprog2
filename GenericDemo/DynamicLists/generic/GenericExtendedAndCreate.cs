using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicLists.demo;

namespace DynamicLists.generic
{
    public class GenericExtendedAndCreate<E> : System.Object
        where E : AbstractTest, new()
    {

        private E variable;

        public GenericExtendedAndCreate()
        {
            this.variable = new E();
        }

        public void print() {
		    System.Console.WriteLine(variable.toPrint());
	    }


    }
}
