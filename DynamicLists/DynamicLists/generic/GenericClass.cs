using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicLists.entity;

namespace DynamicLists.generic
{
    public class GenericClass<E>
    {
        private E variable;
	
	    public GenericClass( E variable ){
		    this.variable = variable;
	    }

	    public E getVariable() {
		    return this.variable;
	    }

	    public void setVariable(E variable) {
		    this.variable = variable;
	    }
	
	    public string say() {
            string ret = null;
		    if (this.variable is TestEntity){
			    TestEntity te = this.variable as TestEntity;
                ret = te.sayTest();
		    }
		    if (this.variable is DemoEntity){
                DemoEntity de = this.variable as DemoEntity;
                ret = de.sayDemo();
		    }
            if (this.variable is DummyEntity)
            {
                DummyEntity de = this.variable as DummyEntity;
                ret = de.sayDummy();
            }
            return ret;
	    }

        public override string ToString() {
		    return variable.ToString();
	    }

    }
}
