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
using System.Diagnostics;
using SwedishStore.Market;
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
            store.addFurniture(new Bed("Foxtrot", Room.LivingRoom, Material.Pine, new Size(100, 45, 210), 230, Mattress.Healthy, false, true, false), 4);
            // store.addBed("Foxtrot", Room.LivingRoom, Material.Pine, new Size(100, 45, 210), 230, Mattress.Healthy, false, true, false, 4);
            store.addTable("Tango", Room.Kitchen, Material.Oak, new Size(80, 90, 100), 120, 4, false, true, 6);
            store.addWardrobe("John", Room.Bedroom, Material.CherryTree, new Size(50, 160, 90), 180, 3, DoorType.Sliding, true, false, 2);

            Console.WriteLine(store);
            Console.WriteLine(store.addFurniture("Foxtrot", 1) + "\n");
            Console.WriteLine(store);
            Console.WriteLine(store.sell("Tango", 2) + "\n");
            Console.WriteLine(store);
        }

        private static void testEqualsSize()
        {
            Console.WriteLine("\n# testEqualsSize()");
            Size one = new Size(100, 30, 60);
            Size two = new Size(100, 30, 60);
            Size three = new Size(100, 30, 60);

            Size four = new Size(101, 30, 60);
            Size five = new Size(100, 31, 60);

            Debug.Assert(!one.Equals(null), "error (implementation bug)");
            Debug.Assert(!one.Equals(new Random()), "error (implementation bug)");

            Debug.Assert(one.Equals(two), "error (implementation bug)");
            Debug.Assert(two.Equals(one), "error (implementation bug)");
            Debug.Assert(two.Equals(three), "error (implementation bug)");
            Debug.Assert(one.Equals(three), "error (implementation bug)");

            Debug.Assert(one.Equals(four) == four.Equals(one), "error (implementation bug)");

            Debug.Assert(!one.Equals(four), "error (implementation bug)");
            Debug.Assert(!one.Equals(five), "error (implementation bug)");
            Debug.Assert(!two.Equals(four), "error (implementation bug)");
            Debug.Assert(!three.Equals(five), "error (implementation bug)");

            Debug.Assert(one == two, "error (implementation bug)");
            Debug.Assert(two == one, "error (implementation bug)");
            Debug.Assert(one != four, "error (implementation bug)");
            Debug.Assert(four != one, "error (implementation bug)");
        }

        private static void testEqualsBed()
        {
            Console.WriteLine("\n# testEqualsBed()");
            // one, two and five are equal
            // three differs one base field
            // four differs one not-base field
            Bed one = new Bed("Foxtrot", Room.LivingRoom, Material.Pine, new Size(100, 45, 210), 230, Mattress.Healthy, false, true, false);
            Bed two = new Bed("Foxtrot", Room.LivingRoom, Material.Pine, new Size(100, 45, 210), 230, Mattress.Healthy, false, true, false);

            Bed three = new Bed("Foxtrot", Room.LivingRoom, Material.CherryTree, new Size(100, 45, 210), 230, Mattress.Healthy, false, true, false);
            Bed four = new Bed("Foxtrot", Room.LivingRoom, Material.Pine, new Size(100, 45, 210), 230, Mattress.Comfortable, false, true, false);

            Bed five = new Bed("Foxtrot", Room.LivingRoom, Material.Pine, new Size(100, 45, 210), 230, Mattress.Healthy, false, true, false);

            Debug.Assert(!one.Equals(null), "error (implementation bug)");
            Debug.Assert(!one.Equals(new Random()), "error (implementation bug)");

            Debug.Assert(one.Equals(two), "error (implementation bug)");
            Debug.Assert(two.Equals(one), "error (implementation bug)");
            Debug.Assert(two.Equals(five), "error (implementation bug)");
            Debug.Assert(one.Equals(five), "error (implementation bug)");

            Debug.Assert(one.Equals(three) == three.Equals(one), "error (implementation bug)");

            Debug.Assert(!one.Equals(three), "error (implementation bug)");
            Debug.Assert(!one.Equals(four), "error (implementation bug)");
            Debug.Assert(!three.Equals(one), "error (implementation bug)");
            Debug.Assert(!two.Equals(four), "error (implementation bug)");
        }

        private static void testEqualsViaDictionary()
        {
            Console.WriteLine("\n# testEqualsViaDictionary()");
            Dictionary<Size, Int32> items = new Dictionary<Size, Int32>();
            items.Add(new Size(100, 30, 60), 2);
            Console.WriteLine(Program.printDictionary(items));
            // items.Add(new Size(100, 30, 60), 1); // ArgumentException if overload Equals 
            // Console.WriteLine(Program.printDictionary(items));
        }

        private static String printDictionary(Dictionary<Size, Int32> items )
        {
            StringBuilder info = new StringBuilder(100);
            foreach (Size size in items.Keys)
            {
                Int32 count = items[size];
                info.Append(count).Append(" - ").AppendLine(size.ToString());
            }
            return info.ToString();
        }

        private static void testStoreWithEquals()
        {
            Console.WriteLine("\n# testStoreWithEquals()");
            Store store = new Store();
            store.addBed("Foxtrot", Room.LivingRoom, Material.Pine, new Size(100, 45, 210), 230, Mattress.Healthy, false, true, false, 4);
            store.addTable("Tango", Room.Kitchen, Material.Oak, new Size(80, 90, 100), 120, 4, false, true, 6);
            store.addWardrobe("John", Room.Bedroom, Material.CherryTree, new Size(50, 160, 90), 180, 3, DoorType.Sliding, true, false, 2);
            Console.WriteLine(store);
            store.addBed("Foxtrot", Room.LivingRoom, Material.Pine, new Size(100, 45, 210), 230, Mattress.Healthy, false, true, false, 1);
            store.addTable("Tango", Room.Kitchen, Material.Oak, new Size(80, 90, 100), 120, 4, false, true, 1);
            store.addWardrobe("John", Room.Bedroom, Material.CherryTree, new Size(50, 160, 90), 180, 3, DoorType.Sliding, true, false, 1);
            
            // With Equals: 5 Foxtrot, 7 Tango, 3 John
            // Without Equals: 4 Foxtrot, 6 Tango, 2 John, 1 Foxtrot, 1 Tango, 1 John !!!

            Console.WriteLine(store);
        }

        private static void testStoreListCompactSize()
        {
            Console.WriteLine("\n# testStore()");
            Store store = new Store();
            store.addBed("Foxtrot", Room.LivingRoom, Material.Pine, new Size(100, 45, 210), 230, Mattress.Healthy, false, true, false, 4);
            store.addBed("BedNoCompactSize", Room.LivingRoom, Material.Pine, new Size(100, 45, 210), 230, Mattress.Healthy, false, false, false, 4);
            store.addTable("Tango", Room.Kitchen, Material.Oak, new Size(80, 90, 100), 120, 4, false, true, 6);
            store.addTable("TableNoCompactSize", Room.Kitchen, Material.Oak, new Size(80, 90, 100), 120, 4, false, false, 6);
            store.addWardrobe("John", Room.Bedroom, Material.CherryTree, new Size(50, 160, 90), 180, 3, DoorType.Sliding, true, false, 2);

            Console.WriteLine(store);

            Console.WriteLine("List CompactSizeCapable furniture");
            List<AbstractFurniture> elements = store.listAllCompactSizeCapableFurniture();
            foreach (AbstractFurniture furniture in elements)
            {
                Console.WriteLine(furniture);
            }
            // 2 item: Foxtrot and Tango --> Bed or Table, and value of CompactSize is True
        }
        private static void testStoreUpgrade()
        {
            Console.WriteLine("\n# testStoreUpgrade()");
            StoreUpgrade store = new StoreUpgrade();
            store.addItem(new Bed("Foxtrot", Room.LivingRoom, Material.Pine, new Size(100, 45, 210), 230, Mattress.Healthy, false, true, false), 4);
            store.addItem(new Table("Tango", Room.Kitchen, Material.Oak, new Size(80, 90, 100), 120, 4, false, true), 6);
            store.addItem(new Wardrobe("John", Room.Bedroom, Material.CherryTree, new Size(50, 160, 90), 180, 3, DoorType.Sliding, true, false), 2);
            store.addItem(new Lamp("Lincoln", SupplementaryType.DeskTool, 34, LampType.TableLamp, 5), 12);
            store.addItem(new DinnerwareSet("Ocean", SupplementaryType.KitchenTool, 76, false), 9);
            Console.WriteLine(store);

            Console.WriteLine(store.sell("John", 1));
            Console.WriteLine(store.sell("Lincoln", 3));

            Console.WriteLine("\n"+store);
        }

        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            // Console.SetWindowSize(150, 50);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            Program.testDemoAnimal();           
            Program.testCat();
          
            Program.testCatAlter();
          
            Program.testSize();
            Program.testFurniture();
            Program.testAbstractFurniture();
            Program.testStore();

            Program.testEqualsSize();
            Program.testEqualsBed();
            Program.testEqualsViaDictionary();
            
            Program.testStoreWithEquals();
            Program.testStoreListCompactSize();
            Program.testStoreUpgrade();
        }
    }
}
