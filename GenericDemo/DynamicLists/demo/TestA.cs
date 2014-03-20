using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists.demo
{
    public class TestA : AbstractTest
    {

        public TestA(){
		
	    }

	    public override string toPrint() {
		    return "TestA";
	    }

        public override string ToString()
        {
            return "This is TestA";
        }

    }
}
