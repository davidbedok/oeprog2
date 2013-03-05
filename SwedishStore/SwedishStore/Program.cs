using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwedishStore.Common;
using System.Threading;
using System.Globalization;
using SwedishStore.Furniture;
using SwedishStore.Api;
using SwedishStore.Engine;
using SwedishStore.Demo;

namespace SwedishStore
{
    public class Program
    {

        private static void testDemoAnimal()
        {
            Console.WriteLine("# testDemoAnimal()");
            Animal animal = new Animal("Bubosvocsok");
            Console.WriteLine(animal);
            Console.WriteLine(animal.eat());
        }

        private static void testCat()
        {
            Console.WriteLine("# testCat()");
            Cat cat = new Cat("Cirmos", "Cirmi");
            cat.NumberOfMilk = 3;
            Console.WriteLine(cat);
            Console.WriteLine(cat.eat());
        }

        private static void testCatAlter()
        {
            Console.WriteLine("# testCatAlter()");
            Animal animal = new Cat("Cirmos", "Cirmi");
            Console.WriteLine(animal);
            Console.WriteLine(animal.eat());
        }


        private static void testSize()
        {
            Console.WriteLine("# testSize()");
            Size size = new Size(120.4323, 100.3543, 45);
            Console.WriteLine(size);
            size = Size.fromString("120.4323", "100.3543", "45");
            Console.WriteLine(size);
        }

        private static void testFurniture()
        {
            Console.WriteLine("\n# testFurniture()");
            Table table = new Table("Tango", Room.Kitchen, Material.Oak, new Size(80, 90, 100), 120, 4, false, true);
            Console.WriteLine(table);
            Wardrobe wardrobe = new Wardrobe("John", Room.Bedroom, Material.CherryTree, new Size(50, 160, 90), 180, 3, DoorType.Sliding, true, false);
            Console.WriteLine(wardrobe);
            Bed bed = new Bed("Foxtrot", Room.LivingRoom, Material.Pine, new Size(100, 45, 210), 230, Mattress.Healthy, false, true, false);
            Console.WriteLine(bed);

            Console.WriteLine(table.sell(1));
            Console.WriteLine(((AbstractFurniture)wardrobe).sell(2));
            Program.sellFurniture(bed, 1);
        }

        private static void testAbstractFurniture()
        {
            Console.WriteLine("\n# testAbstractFurniture()");
            AbstractFurniture table = new Table("Tango", Room.Kitchen, Material.Oak, new Size(80, 90, 100), 120, 4, false, true);
            Console.WriteLine(table);
            AbstractFurniture wardrobe = new Wardrobe("John", Room.Bedroom, Material.CherryTree, new Size(50, 160, 90), 180, 3, DoorType.Sliding, true, false);
            Console.WriteLine(wardrobe);
            AbstractFurniture bed = new Bed("Foxtrot", Room.LivingRoom, Material.Pine, new Size(100, 45, 210), 230, Mattress.Healthy, false, true, false);
            Console.WriteLine(bed);

            Program.sellFurniture(table, 1);
            Program.sellFurniture(wardrobe, 2);
            Program.sellFurniture(bed, 1);
        }

        private static void sellFurniture(AbstractFurniture furniture, int pieces )
        {
            Console.WriteLine(furniture.sell(pieces));
        }

        private static void testStore()
        {
            Console.WriteLine("\n# testStore()");
            Store store = new Store();
            store.addBed("Foxtrot", Room.LivingRoom, Material.Pine, new Size(100, 45, 210), 230, Mattress.Healthy, false, true, false, 4);
            store.addTable("Tango", Room.Kitchen, Material.Oak, new Size(80, 90, 100), 120, 4, false, true, 6);
            store.addWardrobe("John", Room.Bedroom, Material.CherryTree, new Size(50, 160, 90), 180, 3, DoorType.Sliding, true, false, 2);

            Console.WriteLine(store);
            Console.WriteLine(store.addFurniture("Foxtrot", 1) + "\n");
            Console.WriteLine(store);
            Console.WriteLine(store.sell("Tango", 2) + "\n");
            Console.WriteLine(store);
        }

        private static void Main(string[] args)
        {
            Program.testDemoAnimal();
            Program.testCat();
            Program.testCatAlter();
           
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Program.testSize();
            Program.testFurniture();
            Program.testAbstractFurniture();
            Program.testStore();
             
        }
    }
}
