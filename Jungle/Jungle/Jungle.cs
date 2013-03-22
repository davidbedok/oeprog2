using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jungle
{
    public class Jungle
    {
        private List<Animal> animals;

        public Jungle()
        {
            this.animals = new List<Animal>();
        }

        public void addAnimal(Animal animal)
        {
            this.animals.Add(animal);
        }

        public List<Dangerous> findDangerousByType(AnimalType type)
        {
            List<Dangerous> dangerouses = new List<Dangerous>();
            foreach (Animal animal in this.animals)
            {
                if ( (animal is Dangerous) && ( animal.Type == type) )
                {
                    dangerouses.Add((Dangerous)animal);
                }
            }
            return dangerouses;
        }

        public List<Toxicant> attackAllToxicant(List<Dangerous> dangerouses)
        {
            List<Animal> toxicantsAnimal = new List<Animal>();

            foreach (Animal animal in this.animals)
            {
                if (animal is Toxicant)
                {
                    toxicantsAnimal.Add(animal);
                }
            }

            List<Toxicant> toxicants = new List<Toxicant>();

            int i = 0;
            foreach (Dangerous animal in dangerouses) {
                if (toxicantsAnimal.Count > i)
                {
                    if (!animal.Equals(toxicantsAnimal[i])) {
                        animal.attack(toxicantsAnimal[i]);
                        toxicants.Add((Toxicant)toxicantsAnimal[i]);
                        i++;
                    }
                }
            }
            return toxicants;
        }

        public void toxicAllPlayful(List<Toxicant> toxicants)
        {
            List<Animal> playfulAnimals = new List<Animal>();

            foreach (Animal animal in this.animals)
            {
                if (animal is Playful)
                {
                    playfulAnimals.Add(animal);
                }
            }

            int i = 0;
            foreach (Toxicant animal in toxicants)
            {
                if (playfulAnimals.Count > i)
                {
                    animal.toxic(playfulAnimals[i]);
                    i++;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder(50);
            foreach (Animal animal in this.animals)
            {
                info.AppendLine(animal.ToString());
            }
            return info.ToString();
        }


    }
}
