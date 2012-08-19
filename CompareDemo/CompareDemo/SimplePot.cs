using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompareDemo
{
    public class SimplePot
    {
        private readonly int numberOfGravel; // kavics

        public int NumberOfGravel
        {
            get { return this.numberOfGravel; }
        }

        public SimplePot(int numberOfGravel)
        {
            this.numberOfGravel = numberOfGravel;
        }

        public override string ToString()
        {
            return "[SimplePot] " + this.numberOfGravel;
        }

        public static SimplePot[] generatePots(Random rand, int number)
        {
            SimplePot[] pots = new SimplePot[number];
            for (int i = 0; i < 10; i++)
            {
                pots[i] = new SimplePot(rand.Next(100));
            }
            return pots;
        }

        public static string printArray(SimplePot[] data)
        {
            StringBuilder sb = new StringBuilder(50);
            sb.Append("SimplePot Array: ");
            foreach (SimplePot item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

    }
}
