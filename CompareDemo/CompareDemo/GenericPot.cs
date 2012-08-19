using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompareDemo
{
    public class GenericPot : IComparable<GenericPot>
    {
        private readonly int numberOfGravel; // kavics

        public int NumberOfGravel
        {
            get { return this.numberOfGravel; }
        }

        public GenericPot(int numberOfGravel)
        {
            this.numberOfGravel = numberOfGravel;
        }

        public int CompareTo(GenericPot other)
        {
            if (other == null) return 1;
            int ret = 0;
            if (this.numberOfGravel > other.numberOfGravel)
            {
                ret = 1;
            }
            else if (this.numberOfGravel < other.numberOfGravel)
            {
                ret = -1;
            }
            return ret;
        }

        public override string ToString()
        {
            return "[GenericPot] " + this.numberOfGravel;
        }

        public static GenericPot[] generatePots(Random rand, int number)
        {
            GenericPot[] pots = new GenericPot[number];
            for (int i = 0; i < 10; i++)
            {
                pots[i] = new GenericPot(rand.Next(100));
            }
            return pots;
        }

        public static string printArray(GenericPot[] data)
        {
            StringBuilder sb = new StringBuilder(50);
            sb.Append("GenericPot Array: ");
            foreach (GenericPot item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        private static void switchItems(GenericPot[] data, int aPos, int bPos)
        {
            GenericPot tmp = data[aPos];
            data[aPos] = data[bPos];
            data[bPos] = tmp;
        }

        public static void minimumSelectionSort(GenericPot[] data)
        {
            if (data.Length > 0)
            {
                GenericPot min;
                int minPos;
                for (int i = 0; i < data.Length - 1; i++)
                {
                    min = data[i];
                    minPos = i;
                    for (int j = i; j < data.Length; j++)
                    {
                        if (min.NumberOfGravel > data[j].NumberOfGravel)
                        {
                            min = data[j];
                            minPos = j;
                        }
                    }
                    GenericPot.switchItems(data, i, minPos);
                }
            }
        }

        public static void minimumSelectionSortWithCompareTo(GenericPot[] data)
        {
            if (data.Length > 0)
            {
                GenericPot min;
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
                    GenericPot.switchItems(data, i, minPos);
                }
            }
        }
 
    }
}
