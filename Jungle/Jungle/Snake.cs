using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jungle
{
    public class Snake : Animal, Dangerous, Toxicant
    {

        public Snake(String petName, AnimalType type, Random rand)
            : base(petName, type, rand)
        {
        
        }

        public void attack(Animal target)
        {
            this.moodDown();
            target.injured();
        }

        public void toxic(Animal target)
        {
            this.moodUp();
            target.injured();
            target.moodDown();
        }

        public override string ToString()
        {
            return "[Snake] " + base.ToString();
        }

    }
}
