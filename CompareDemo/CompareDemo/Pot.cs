using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompareDemo
{
    public class Pot : IComparable
    {
        private readonly int numberOfGravel; // kavics

        public int NumberOfGravel
        {
            get { return this.numberOfGravel; }
        }

        public Pot(int numberOfGravel)
        {
            this.numberOfGravel = numberOfGravel;
        }

        public int CompareTo(object other)
        {
            if (other == null) return 1;
            int ret = 0;
            if (this.numberOfGravel > ((Pot)other).numberOfGravel)
            {
                ret = 1;
            }
            else if (this.numberOfGravel < ((Pot)other).numberOfGravel)
            {
                ret = -1;
            }
            return ret;
        }

        public override string ToString()
        {
            return "[Pot] " + this.numberOfGravel;
        }

        public static Pot[] generatePots(Random rand, int number)
        {
            Pot[] pots = new Pot[number];
            for (int i = 0; i < 10; i++)
            {
                pots[i] = new Pot(rand.Next(100));
            }
            return pots;
        }

        public static string printArray(Pot[] data)
        {
            StringBuilder sb = new StringBuilder(50);
            sb.Append("Pot Array: ");
            foreach (Pot item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

    }
}
