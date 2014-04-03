using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompareDemo
{
    public class ComparablePot : IComparable
    {
        private readonly int numberOfGravels; // kavics

        public int NumberOfGravels
        {
            get { return this.numberOfGravels; }
        }

        public ComparablePot(int numberOfGravels)
        {
            this.numberOfGravels = numberOfGravels;
        }

        public int CompareTo(object othat)
        {
            if (othat == null) return 1;
            if (othat == this) return 0;
            if (othat is ComparablePot)
            {
                ComparablePot that = (ComparablePot)othat;
                return this.numberOfGravels - that.numberOfGravels;
            }
            return 1;
        }

        public override string ToString()
        {
            return "[ComparablePot] " + this.numberOfGravels;
        }

        public static ComparablePot[] generatePots(Random rand, int number)
        {
            ComparablePot[] pots = new ComparablePot[number];
            for (int i = 0; i < 10; i++)
            {
                pots[i] = new ComparablePot(rand.Next(100));
            }
            return pots;
        }

    }
}
