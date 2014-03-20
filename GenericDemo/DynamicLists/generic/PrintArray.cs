using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DynamicLists.entity;

namespace DynamicLists.generic
{
    public class PrintArray
    {
        public static void printArray(TestEntity[] inputArray) {
		    foreach (TestEntity element in inputArray) {
			    System.Console.WriteLine(element);
		    }
	    }

        public static void printArray(DemoEntity[] inputArray) {
            foreach (DemoEntity element in inputArray) {
			    System.Console.WriteLine(element);
		    }
	    }

        public static void printArray(DummyEntity[] inputArray) {
            foreach (DummyEntity element in inputArray) {
			    System.Console.WriteLine(element);
		    }
	    }
    }
}
