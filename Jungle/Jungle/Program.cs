using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jungle
{
    public class Program
    {

        private static void testAnimals( Random rand)
        {
            Console.WriteLine("# testAnimals()");

            Platypus platypus = new Platypus("Plati", AnimalType.Carnivore, rand);
            Console.WriteLine(platypus);

            Console.WriteLine("Play: ");
            platypus.play();
            Console.WriteLine(platypus);
            
            Snake snake = new Snake("Snaki", AnimalType.Herbivore, rand);
            Console.WriteLine(snake);

            Console.WriteLine("Toxic Platypus: ");
            snake.toxic(platypus);
            Console.WriteLine(snake);
            Console.WriteLine(platypus);

            Turtle turtle = new Turtle("Toki", AnimalType.Omnivore, rand);
            Console.WriteLine(turtle);

            Console.WriteLine("Attack Snake: ");
            turtle.attack(snake);
            Console.WriteLine(turtle);
            Console.WriteLine(snake);
        }

        private static void testJungle(Random rand)
        {
            Console.WriteLine("\n# testJungle()");
            Jungle jungle = Program.createJungle(rand);
            Console.WriteLine(jungle);
        }

        private static Jungle createJungle(Random rand)
        {
            Jungle jungle = new Jungle();
            jungle.addAnimal(new Platypus("Plati1", AnimalType.Carnivore, rand));
            jungle.addAnimal(new Platypus("Plati2", AnimalType.Herbivore, rand));
            jungle.addAnimal(new Platypus("Plati3", AnimalType.Omnivore, rand));
            jungle.addAnimal(new Platypus("Plati4", AnimalType.Carnivore, rand));

            jungle.addAnimal(new Snake("Snaki1", AnimalType.Herbivore, rand));
            jungle.addAnimal(new Snake("Snaki2", AnimalType.Omnivore, rand));
            jungle.addAnimal(new Snake("Snaki3", AnimalType.Carnivore, rand));
            jungle.addAnimal(new Snake("Snaki4", AnimalType.Omnivore, rand));
            jungle.addAnimal(new Snake("Snaki5", AnimalType.Carnivore, rand));

            jungle.addAnimal(new Turtle("Toki1", AnimalType.Carnivore, rand));
            jungle.addAnimal(new Turtle("Toki2", AnimalType.Omnivore, rand));
            jungle.addAnimal(new Turtle("Toki3", AnimalType.Herbivore, rand));
            jungle.addAnimal(new Turtle("Toki4", AnimalType.Omnivore, rand));

            return jungle;
        }

        private static void testSimulation(Random rand)
        {
            Console.WriteLine("\n# testSimulation()");
            Jungle jungle = Program.createJungle(rand);
            Console.WriteLine(jungle);

            List<Dangerous> dangerouses = jungle.findDangerousByType(AnimalType.Carnivore);
            Console.WriteLine("findDangerousByType()");
            Console.WriteLine("dangerouses:");
            foreach (Dangerous animal in dangerouses)
            {
                Console.WriteLine(animal);
            }

            
            List<Toxicant> toxicantsAnimal = jungle.attackAllToxicant(dangerouses);
            Console.WriteLine("attackAllToxicant()");
            Console.WriteLine(jungle);
            Console.WriteLine("toxicantsAnimal:");
            foreach (Toxicant animal in toxicantsAnimal)
            {
                Console.WriteLine(animal);
            }
            
            jungle.toxicAllPlayful(toxicantsAnimal);
            Console.WriteLine("toxicAllPlayful()");
            Console.WriteLine(jungle);
        }

        private static void Main(string[] args)
        {
            Random rand = new Random();
            Program.testAnimals(rand);
            Program.testJungle(rand);
            Program.testSimulation(rand);
        }
    }
}
