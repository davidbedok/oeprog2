using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

// Mi a kimenete az alábbi programnak?

// IOException
// Finally
// -1

// IOException
// Finally
// 0

// IOException 
// -1

// Finally 
// 0

// Fordítási hiba - OK

// Futás idejű hiba

// Control cannot leave the body of a finally clause.

namespace ExceptionTest.Task03
{

    public class Test {
        public static void test() {
            throw new IOException();
        }
        public static int method() {
            try {
                Test.test();
            } catch (IOException e) {
                System.Console.WriteLine("IOException");
                return -1;
            } finally {
                System.Console.WriteLine("Finally");
                // return 0;
            }
            return 1;
        }
    }

    public class Task {
        public static void process() {
            System.Console.WriteLine(Test.method());
        }
    }
}
