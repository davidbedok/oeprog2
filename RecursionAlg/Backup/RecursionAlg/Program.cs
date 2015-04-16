using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecursionAlg
{
    public class Program
    {

        public static void testFactorial()
        {
            System.Console.WriteLine("# Factorial");
            for (int i = 1; i < 10; i++)
            {
                System.Console.Write(Factorial.process(i) + " ");
            }
            System.Console.WriteLine();
        }

        public static void testPower()
        {
            System.Console.WriteLine("# Power");
            for (int i = 0; i < 10; i++)
            {
                System.Console.Write(Power.process(3, i) + " ");
            }
            System.Console.WriteLine();

            System.Console.WriteLine("# Fast Power");
            for (int i = 0; i < 10; i++)
            {
                System.Console.Write(Power.fastProcess(3, i) + " ");
            }
            System.Console.WriteLine();
        }

        public static void testPrime()
        {
            System.Console.WriteLine("# Prime");
            for (int i = 1; i < 100; i++)
            {
                if (Prime.process(i))
                {
                    System.Console.Write(i + " ");
                }
            }
            System.Console.WriteLine();
            for (int i = 1; i < 100; i++)
            {
                if (Prime.fastProcess(i))
                {
                    System.Console.Write(i + " ");
                }
            }
            System.Console.WriteLine();
        }

        public static void testFibonacci()
        {
            System.Console.WriteLine("# Fibonacci");
            for (int i = 1; i < 15; i++)
            {
                System.Console.Write(Fibonacci.process(i) + " ");
            }
            System.Console.WriteLine();
        }

        public static void testSequentialSearch()
        {
            System.Console.WriteLine("# Sequential search");
            int[] arr = { 5, 9, 3, 7, 4, 1 };
            System.Console.Write("5 (index 0) --> " + SequentialSearch.process(arr, 5) + "  ");
            System.Console.Write("2 (no) --> " + SequentialSearch.process(arr, 2) + "  ");
            System.Console.Write("7 (index 3) --> " + SequentialSearch.process(arr, 7) + "  ");
            System.Console.Write("1 (index 5) --> " + SequentialSearch.process(arr, 1) + "  ");
            System.Console.WriteLine();
        }

        public static void testStringTransform()
        {
            System.Console.WriteLine("# StringTransform");

            string str = "011214489";
            // 02214489
            // 0414489
            // 041889
            // 041169
            // 04269
            System.Console.WriteLine(str + " - " + StringTransform.process(str));
        }

        public static void testHanoi()
        {
            System.Console.WriteLine("# Hanoi");
            Hanoi.process(3, 1, 2, 3);
        }

        public static void Main(string[] args)
        {
            Program.testFactorial();
            Program.testPower();
            Program.testPrime();
            Program.testFibonacci();
            Program.testSequentialSearch();
            Program.testStringTransform();
            Program.testHanoi();
        }
    }
}
