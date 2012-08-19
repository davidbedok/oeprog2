using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionBasics
{
    public class Program
    {

        private static void basics()
        {
            System.Console.WriteLine("\n# basics");

            string testStr = "test";
            int indexOfe = testStr.IndexOf('e');
            System.Console.WriteLine(indexOfe); // 1
            int indexOfk = testStr.IndexOf('k');
            System.Console.WriteLine(indexOfk); // -1

            try
            {
                int indexOfe2 = testStr.IndexOf('e', 5);
                System.Console.WriteLine(indexOfe2);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        private static void testPeopleGravels()
        {
            System.Console.WriteLine("\n# testPeopleGravels");

            AbstractHolder holder = new PeopleGravels();
            try
            {
                holder.addContent(5);
                holder.addContent(0);
                holder.addContent(8);
                holder.addContent(2);
                holder.addContent(-1);
            }
            catch (ArgumentException e)
            {
                System.Console.WriteLine(e.Message);
            }

            holder.initReading();
            int numberOfGravels = 0;
            while ((numberOfGravels = holder.read()) != -1)
            {
                System.Console.Write(numberOfGravels + " ");
            }
        }

        private static void testPeopleMoney()
        {
            System.Console.WriteLine("\n# testPeopleMoney");

            AbstractHolder holder = new PeopleMoney();
            holder.addContent(50);
            holder.addContent(-1);
            holder.addContent(0);
            holder.addContent(-70);
            holder.addContent(42);

            holder.initReading();
            try
            {
                while (true)
                {
                    System.Console.Write(holder.read() + " ");
                }
            }
            catch (EndOfDataException e)
            {
                System.Console.WriteLine("\n" + e.Message);
            }

        }

        private static void Main(string[] args)
        {
            // Program.basics();
            Program.testPeopleGravels();
            // Program.testPeopleMoney();
            System.Console.ReadKey();
        }
    }
}
