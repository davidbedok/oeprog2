using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompareDemo
{
    public class Program
    {

        private static void testSimplePot(Random rand)
        {
            SimplePot[] simplePots = SimplePot.generatePots(rand, 10);
            System.Console.WriteLine(SimplePot.printArray(simplePots));
            Array.Sort(simplePots); // ArgumentException ! 
            System.Console.WriteLine(SimplePot.printArray(simplePots));
        }

        private static void testPot(Random rand)
        {
            Pot[] pots = Pot.generatePots(rand, 10);
            System.Console.WriteLine(Pot.printArray(pots));
            Program.minimumSelectionSortWithNoGenericCompareTo(pots);
            // Array.Sort(pots);
            System.Console.WriteLine(Pot.printArray(pots));
        }

        private static void minimumSelectionSortWithNoGenericCompareTo(IComparable[] data)
        {
            if (data.Length > 0)
            {
                IComparable min;
                int minPos;
                for (int i = 0; i < data.Length - 1; i++)
                {
                    min = data[i];
                    minPos = i;
                    for (int j = i; j < data.Length; j++)
                    {
                        if (min.CompareTo(data[j]) > 0)
                        {
                            min = data[j];
                            minPos = j;
                        }
                    }
                    Program.switchItems(data, i, minPos);
                }
            }
        }

        private static void switchItems(IComparable[] data, int aPos, int bPos)
        {
            IComparable tmp = data[aPos];
            data[aPos] = data[bPos];
            data[bPos] = tmp;
        }

        private static void testGenericPot(Random rand){
            GenericPot[] pots = GenericPot.generatePots(rand, 10);
            System.Console.WriteLine(GenericPot.printArray(pots));
            GenericPot.minimumSelectionSort(pots);
            // GenericPot.minimumSelectionSortWithCompareTo(pots);
            // Array.Sort(pots);
            System.Console.WriteLine(GenericPot.printArray(pots));
        }

        private static void Main(string[] args)
        {
            Random rand = new Random();

            // Program.testSimplePot(rand);
            // Program.testPot(rand);
            // Program.testGenericPot(rand);
            
        }
    }
}
