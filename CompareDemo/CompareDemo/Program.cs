using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompareDemo
{
    public class Program
    {

        private static void sortUncomparablePotWithArraySort(Random rand)
        {
            UncomparablePot[] pots = UncomparablePot.generatePots(rand, 10);
            System.Console.WriteLine(Arrays.toString("UncomparablePot after generation", pots));
            Array.Sort(pots); // ArgumentException ! 
            System.Console.WriteLine(Arrays.toString("UncomparablePot after sort", pots));
        }

        private static void sortPotWithArraySort(Random rand)
        {
            ComparablePot[] pots = ComparablePot.generatePots(rand, 10);
            System.Console.WriteLine(Arrays.toString("ComparablePot after generation", pots));
            Array.Sort(pots);
            System.Console.WriteLine(Arrays.toString("ComparablePot after sort", pots));
        }

        private static void sortPotWithCustomAlg(Random rand)
        {
            ComparablePot[] pots = ComparablePot.generatePots(rand, 10);
            System.Console.WriteLine(Arrays.toString("ComparablePot after generation", pots));
            SortUtil.minimumSelectionSort(pots);
            System.Console.WriteLine(Arrays.toString("ComparablePot after sort", pots));
        }

        private static void sortGenericComparablePotWithArraySort(Random rand)
        {
            GenericComparablePot[] pots = GenericComparablePot.generatePots(rand, 10);
            System.Console.WriteLine(Arrays.toString("GenericComparablePot after generation", pots));
            Array.Sort(pots);
            System.Console.WriteLine(Arrays.toString("GenericComparablePot after sort", pots));
        }

        private static void sortGenericComparablePotWithCustomAlg(Random rand){
            GenericComparablePot[] pots = GenericComparablePot.generatePots(rand, 10);
            System.Console.WriteLine(Arrays.toString("GenericComparablePot after generation", pots));
            GenericComparablePot.minimumSelectionSort(pots);
            System.Console.WriteLine(Arrays.toString("GenericComparablePot after sort", pots));
        }

        private static void Main(string[] args)
        {
            Random rand = new Random();

            // Program.sortUncomparablePotWithArraySort(rand);
            // Program.sortPotWithArraySort(rand);
            // Program.sortPotWithCustomAlg(rand);
            // Program.sortGenericComparablePotWithArraySort(rand);
            // Program.sortGenericComparablePotWithCustomAlg(rand);
        }
    }
}
