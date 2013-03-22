using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jungle
{
    public class Turtle : Animal, Playful, Dangerous
    {
        public Turtle(String petName, AnimalType type, Random rand)
            : base(petName, type, rand)
        {
        
        }

        public void play()
        {
            this.healing();
            this.moodUp();
        }

        public void attack(Animal target)
        {
            this.moodDown();
            target.injured();
        }

        public override string ToString()
        {
            return "[Turtle] " + base.ToString();
        }

    }
}
