using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jungle
{
    public class Platypus : Animal, Toxicant, Playful
    {

        public Platypus(String petName, AnimalType type, Random rand)
            : base(petName, type, rand)
        {
        
        }

        public void toxic(Animal target)
        {
            this.moodUp();
            target.injured();
            target.moodDown();
        }

        public void play()
        {
            this.healing();
            this.moodUp();
        }

        public override string ToString()
        {
            return "[Platypus] " + base.ToString();
        }

    }
}
