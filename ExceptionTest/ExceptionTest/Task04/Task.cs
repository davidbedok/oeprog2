using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

// Mi a kimenete az alábbi programnak?

// OK:
// IOException
// Finally
// Exception Out

// IOException
// Exception In
// 1

// IOException
// Exception In
// Finally
// 1

// IOException
// Exception In
// Finally
// 0

// IOException
// Exception In
// Finally
// 1
// Exception Out

// IOException
// Exception In
// Finally
// Exception Out

// Fordítási hiba

// Futás idejű hiba

namespace ExceptionTest.Task04
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
                throw new Exception();
            } catch (Exception e) {
                System.Console.WriteLine("Exception In");
                return 1;
            } finally {
                System.Console.WriteLine("Finally");
            }
            return 0;
        }
    }

    public class Task
    {
        public static void process() {
            try {
                System.Console.WriteLine(Test.method());
            } catch (Exception e) {
                System.Console.WriteLine("Exception Out");
            }
        }
    }
}
