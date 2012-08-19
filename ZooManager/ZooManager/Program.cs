using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZooManager
{
    public class Program
    {

        private static void testHerb()
        {
            Console.WriteLine(">>>> Test Herb <<<<");
            Herb eucalyptus = new Herb("eucalyptus");
            Console.WriteLine(eucalyptus);
        }

        private static void testMeat()
        {
            Console.WriteLine(">>>> Test Meat <<<<");
            Meat lamb = new Meat("lamb");
            Console.WriteLine(lamb);
        }

        private static void testKoala()
        {
            Console.WriteLine(">>>> Test Koala <<<<");
            Koala macilaci = new Koala("MaciLaci", new DateTime(2008, 10, 3));
            macilaci.hunger += new HungerHandler(zooAnimalHunger);
            Console.WriteLine(macilaci);
            macilaci.iAmHungry();
        }

        private static void zooAnimalHunger(String name, Food food, int amount)
        {
            Console.WriteLine(name + " eats " + amount + " amounts of " + food + ".");
        }

        private static void testLion()
        {
            Console.WriteLine(">>>> Test Lion <<<<");
            Lion alex = new Lion("Alex", new DateTime(2006, 5, 12));
            alex.hunger += new HungerHandler(zooAnimalHunger);
            Console.WriteLine(alex);
            alex.iAmHungry();
        }

        private static void testZoo()
        {
            Console.WriteLine(">>>> Test Zoo <<<<");
            Zoo zoo = new Zoo();
            zoo.addKoala("MaciLaci", new DateTime(2008, 10, 3));
            zoo.addKoala("Alice", new DateTime(2007, 7, 9));
            zoo.addLion("Alex", new DateTime(2006, 5, 12));
            zoo.addLion("Bob", new DateTime(2011, 2, 21));
            try
            {
                zoo.addLion("Alice", new DateTime(2003, 12, 4));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            zoo.animalIsHungry("MaciLaci");
            zoo.animalIsHungry("Alex");
        }

        private static void Main(string[] args)
        {
            Program.testHerb();
            Program.testMeat();
            Program.testKoala();
            Program.testLion();
            Program.testZoo();
        }
    }
}
