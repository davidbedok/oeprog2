using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists.generic
{
    public class GenericPrintArray
    {
        public static void printArray<E>(E[] inputArray) {
	        foreach ( E element in inputArray ) {
	            System.Console.WriteLine(element);
	        }
	    } 
    }
}
