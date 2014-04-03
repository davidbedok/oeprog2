using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompareDemo
{
    public class GenericComparablePot : IComparable<GenericComparablePot>
    {
        private readonly int numberOfGravels; // kavics

        public int NumberOfGravels
        {
            get { return this.numberOfGravels; }
        }

        public GenericComparablePot(int numberOfGravels)
        {
            this.numberOfGravels = numberOfGravels;
        }

        public int CompareTo(GenericComparablePot that)
        {
            if (that == null) return 1;
            if (that == this) return 0;
            return this.numberOfGravels - that.numberOfGravels;
        }

        public override string ToString()
        {
            return "[GenericComparablePot] " + this.numberOfGravels;
        }

        public static GenericComparablePot[] generatePots(Random rand, int number)
        {
            GenericComparablePot[] pots = new GenericComparablePot[number];
            for (int i = 0; i < 10; i++)
            {
                pots[i] = new GenericComparablePot(rand.Next(100));
            }
            return pots;
        }

        public static void minimumSelectionSort(GenericComparablePot[] data)
        {
            if (data.Length > 0)
            {
                GenericComparablePot min;
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
                    GenericComparablePot.switchItems(data, i, minPos);
                }
            }
        }

        private static void switchItems(GenericComparablePot[] data, int aPos, int bPos)
        {
            GenericComparablePot tmp = data[aPos];
            data[aPos] = data[bPos];
            data[bPos] = tmp;
        }
 
    }
}
