using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransactionTrunk
{
    public class Program : System.Object
    {
        public static void Main(string[] args)
        {

            TransactionTrunk trunk = new TransactionTrunk();
            trunk.addAccount("Teszt Elek","1234-1234");
            trunk.addAccount("Nemecserk Erno", "9876-9876");
            trunk.addAccount("Han Solo", "5555-5555");
            trunk.addCreditTransaction("5555-5555",3000,70);
            trunk.addCreditTransaction("1234-1234", 5000, 67);
            trunk.addCreditTransaction("1234-1234", 2000, 72);
            trunk.addCreditTransaction("9876-9876", 7000, 80);
            trunk.addDebitTransaction("9876-9876", 1500, 75);
            trunk.addDebitTransaction("9876-9876", 4000, 68);
            trunk.addDebitTransaction("5555-5555", 500, 66);

            System.Console.WriteLine(trunk);

            System.Console.WriteLine("Last transaction (1234-1234): " + trunk.getBalance("1234-1234") );
            System.Console.WriteLine("Last transaction (9876-9876): " + trunk.getBalance("9876-9876"));
            System.Console.WriteLine("Last transaction (5555-5555): " + trunk.getBalance("5555-5555"));

            System.Console.WriteLine("Last transaction (1234-1234, 65, 75): " + trunk.getBalance("1234-1234", 65, 75));
            System.Console.WriteLine("Last transaction (9876-9876, 65, 76): " + trunk.getBalance("9876-9876", 65, 76));
            System.Console.WriteLine("Last transaction (9876-9876, 72, 82): " + trunk.getBalance("9876-9876", 72, 82));
            System.Console.WriteLine("Last transaction (5555-5555, 65, 66): " + trunk.getBalance("5555-5555", 65, 66));



            System.Console.ReadKey();
        }
    }
}
