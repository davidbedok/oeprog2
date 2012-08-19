using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Mi a kimenete az alábbi programnak?

// Jelölje be azokat a válaszokat, melyek részei a kimenetnek!
// In Question - OK
// In QuestionSub
// In Main - OK
// Fordítási hiba
// Futás idejű hiba

namespace ExceptionTest.Task01
{

    public class Question {
        public virtual void test() {
            System.Console.WriteLine("In Question");
            throw new System.IO.IOException();
        }
    }

    public class QuestionSub : Question {
        public new void test() {
            System.Console.WriteLine("In QuestionSub");
        }
    }

    public class Task {
        public static void process() {
            Question instance = new QuestionSub();
            try
            {
                instance.test();
            }
            catch (System.IO.IOException e)
            {
                System.Console.WriteLine("In Main");
            }
        }
    }
}
