using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jungle
{
    public abstract class Animal
    {
        private readonly String petName;
        private readonly AnimalType type;
        private Mood mood;
        private int vitality;

        public AnimalType Type
        {
            get { return this.type; }
        }

        public Animal(String petName, AnimalType type, Random rand)
        {
            this.petName = petName;
            this.type = type;
            this.vitality = rand.Next(10) + 1;
            this.mood = Mood.Calm;
        }

        public void injured()
        {
            if (this.isAlive())
            {
                this.vitality--;
            }
        }

        public void healing()
        {
            this.vitality++;
        }

        public void moodUp()
        {
            if (this.mood != Mood.Cheerful)
            {
                this.mood = (Mood)(((int)this.mood)+1);
            }
        }

        public void moodDown()
        {
            if (this.mood != Mood.Furious)
            {
                this.mood = (Mood)(((int)this.mood) - 1);
            }
        }

        public bool isAlive()
        {
            return this.vitality > 0;
        }

        public override bool Equals(Object othat)
        {
            if (this == othat)
            {
                return true;
            }

            if (othat == null)
            {
                return false;
            }
            if (othat is Animal)
            {
                Animal that = othat as Animal;
                return this.Equals(that);
            }
            return false;
        }

        public bool Equals(Animal that)
        {
            if ((object)that == null)
            {
                return false;
            }
            if (that.petName.Equals(this.petName) && that.type == this.type && that.mood == this.mood && that.vitality == this.vitality)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return this.petName + " (type: " + this.type + ", vitality: [" + this.vitality + "], mood: "+this.mood+")";
        }

    }
}
