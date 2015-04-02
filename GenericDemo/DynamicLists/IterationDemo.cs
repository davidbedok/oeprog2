using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists
{
    public class IterationDemo
    {

        public static void dictionaryIteration()
        {
            Console.WriteLine("# Dictionary Iteration Sample");

            Dictionary<Int32, String> map = new Dictionary<Int32, String>();
            map[10] = "Hello";
            map[20] = "Lorem";
            map[30] = "Ipsum";

            Dictionary<Int32, String>.Enumerator iterator = map.GetEnumerator();
            while (iterator.MoveNext())
            {
                KeyValuePair<Int32, String> pair = iterator.Current;
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }

            IEnumerator<KeyValuePair<Int32, String>> iterator2 = map.GetEnumerator();
            while (iterator2.MoveNext())
            {
                KeyValuePair<Int32, String> pair = iterator2.Current;
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }

            foreach (KeyValuePair<Int32, String> pair in map)
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }
        }

        public static void listIteration()
        {
            Console.WriteLine("# List Iteration Sample");

            List<String> list = new List<String>();
            list.Add("Hello");
            list.Add("Lorem");
            list.Add("Ipsum");

            List<String>.Enumerator iterator = list.GetEnumerator();
            while (iterator.MoveNext())
            {
                String current = iterator.Current;
                Console.WriteLine(current);
            }

            IEnumerator<String> iterator2 = list.GetEnumerator();
            while (iterator2.MoveNext())
            {
                String current = iterator2.Current;
                Console.WriteLine(current);
            }

            foreach (String current in list)
            {
                Console.WriteLine(current);
            }

        }

    }
}
