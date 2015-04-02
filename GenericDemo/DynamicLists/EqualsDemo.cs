using DynamicLists.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists
{
    public class EqualsDemo
    {

        public static void equalsSample1()
        {
            // Int32 --> stock
            Dictionary<Identifier, Int32> items = new Dictionary<Identifier, Int32>();
            items.Add(new Identifier(1234, "AHD"), 1);
            items.Add(new Identifier(5678, "BHS"), 2);
            items.Add(new Identifier(1234, "AHD"), 3);

            foreach (KeyValuePair<Identifier, Int32> pair in items)
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }

            // how to search eq. 1234-AHD?
            Identifier searchIdentifier = new Identifier(1234, "AHD");
            foreach (KeyValuePair<Identifier, Int32> pair in items)
            {
                if ( searchIdentifier.SerialNumber == pair.Key.SerialNumber && searchIdentifier.Code.Equals(pair.Key.Code) ) {
                    Console.WriteLine("Heureka!!! --> " + pair);
                }
            }

            // how many 1234-AHD?
            Console.WriteLine("Number of " + searchIdentifier + " (stock): " + items[searchIdentifier]); // Runtime exception! 

        }

        public static void equalsSample2()
        {
            Identifier iden = new Identifier(1234, "AHD");

            Dictionary<Identifier, Int32> items = new Dictionary<Identifier, Int32>();
            items.Add(iden, 1);
            items.Add(new Identifier(5678, "BHS"), 2);
            items.Add(iden, 3); // Runtime exception!

            foreach (KeyValuePair<Identifier, Int32> pair in items)
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }
        }

        public static void equalsSample3()
        {
            Dictionary<IdentifierEquals, Int32> items = new Dictionary<IdentifierEquals, Int32>();
            items.Add(new IdentifierEquals(1234, "AHD"), 1);
            items.Add(new IdentifierEquals(5678, "BHS"), 2);

            foreach (KeyValuePair<IdentifierEquals, Int32> pair in items)
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }

            // how to search eq. 1234-AHD?
            IdentifierEquals searchIdentifier = new IdentifierEquals(1234, "AHD");
            foreach (KeyValuePair<IdentifierEquals, Int32> pair in items)
            {
                if (searchIdentifier.Equals(pair.Key))
                {
                    Console.WriteLine("Heureka!!! --> " + pair);
                }
            }

            // how many 1234-AHD?
            Console.WriteLine("Number of " + searchIdentifier + " (stock): " + items[searchIdentifier]); 

            // modify!
            items[searchIdentifier] += 3;
            Console.WriteLine("Number of " + searchIdentifier + " after increase (stock): " + items[searchIdentifier]); 
        }

    }
}
