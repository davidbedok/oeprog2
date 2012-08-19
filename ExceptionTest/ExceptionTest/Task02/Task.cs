using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

// Mi a kimenete az alábbi programnak?

// OK:
// IOException
// Finally
// -1

// IOException 
// -1

// Finally 
// 1

// IOException
// 1

// Fordítási hiba

// Futás idejű hiba

namespace ExceptionTest.Task02
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
