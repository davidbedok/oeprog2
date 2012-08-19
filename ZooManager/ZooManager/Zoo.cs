using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZooManager
{
    public class Zoo : Object
    {

        private Dictionary<String,ZooAnimal> animals;

        public Zoo()
        {
            this.animals = new Dictionary<String, ZooAnimal>();
        }

        private void addAnimal(ZooAnimal animal)
        {
            if (!this.animals.ContainsKey(animal.Name))
            {
                animal.hunger += new HungerHandler(animalHunger);
                this.animals.Add(animal.Name, animal);
            }
            else
            {
                throw new ArgumentException("Name of the animal (" + animal.Name + ") is already reserved.");
            }
        }

        private void animalHunger(String name, Food food, int amount)
        {
            Console.WriteLine(name + " eats " + amount + " amounts of " + food + ".");
        }

        public void addKoala(String name, DateTime dateOfBirth)
        {
            this.addAnimal(new Koala(name, dateOfBirth));
        }

        public void addLion(String name, DateTime dateOfBirth)
        {
            this.addAnimal(new Lion(name, dateOfBirth));
        }

        public void animalIsHungry(String name)
        {
            if (this.animals.ContainsKey(name))
            {
                this.animals[name].iAmHungry();
            }
        }

        public override string ToString()
        {
            StringBuilder content = new StringBuilder(100);
            foreach (KeyValuePair<String, ZooAnimal> animal in this.animals)
            {
                content.AppendLine(animal.Value.ToString());
            }
            return content.ToString();
        }

    }
}
