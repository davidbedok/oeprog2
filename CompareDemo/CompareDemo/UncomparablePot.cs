using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompareDemo
{
    public class UncomparablePot
    {
        private readonly int numberOfGravels; // kavics

        public int NumberOfGravels
        {
            get { return this.numberOfGravels; }
        }

        public UncomparablePot(int numberOfGravels)
        {
            this.numberOfGravels = numberOfGravels;
        }

        public override string ToString()
        {
            return "[UncomparablePot] " + this.numberOfGravels;
        }

        public static UncomparablePot[] generatePots(Random rand, int number)
        {
            UncomparablePot[] pots = new UncomparablePot[number];
            for (int i = 0; i < 10; i++)
            {
                pots[i] = new UncomparablePot(rand.Next(100));
            }
            return pots;
        }

    }
}
