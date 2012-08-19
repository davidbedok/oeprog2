using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapImplementation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Map Implementation Demo");
            StudentCatalog catalog = new StudentCatalog();
            catalog.addNewPerson("Anakin Skywalker","DVADER",new DateTime(2000,01,07));
            catalog.addNewPerson("Boba Fett", "BF3746", new DateTime(1999, 05, 25));
            catalog.addNewPerson("Chewbacca", "7GH3JH", new DateTime(2003, 07, 17));
            catalog.addNewPerson("Darth Maul", "U56JH2", new DateTime(2007, 03, 08));
            catalog.addNewPerson("Palpatine", "DSIDIO", new DateTime(1978, 09, 11));
            catalog.addNewPerson("Han Solo", "HS78JK", new DateTime(1988, 10, 15));
            catalog.addNewPerson("Jar Jar Binks", "JJB432", new DateTime(2002, 11, 19));
            catalog.addNewPerson("Luke Skywalker", "GLUCAS", new DateTime(2009, 03, 22));
            catalog.addNewPerson("Luke Skywalker2", "GLUCAS", new DateTime(2009, 03, 22));

            catalog.addNewMark("DVADER", 34, "fefwefefe");
            catalog.addNewMark("DVADER", 20, "htrhtrr");
            catalog.addNewMark("BF3746", 65, "htrhf");
            catalog.addNewMark("BF3746", 45, "dfhtht");
            catalog.addNewMark("BF3746", 34, "ffgrtrg");
            catalog.addNewMark("7GH3JH", 51, "fbfdbdfsb");
            catalog.addNewMark("7GH3JH", 55, "trztrht");
            catalog.addNewMark("U56JH2", 14, "bvcbvrr");
            catalog.addNewMark("DSIDIO", 13, "zhergg");
            catalog.addNewMark("DSIDIO", 12, "nbfbntr");
            catalog.addNewMark("DSIDIO", 11, "feferer");
            catalog.addNewMark("HS78JK", 98, "bvcbrher");
            catalog.addNewMark("HS78JK", 92, "htwss");
            catalog.addNewMark("JJB432", 70, "jzukrujr");
            catalog.addNewMark("GLUCAS", 88, "kzujktzjtr");
            catalog.addNewMark("GLUCAS", 92, "wfergtr");

            System.Console.WriteLine(catalog);

        }
    }
}
