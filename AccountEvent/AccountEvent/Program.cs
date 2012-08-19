using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountEvent
{
    public class Program
    {

        public static void processEventDemo( IAccountTrunk trunk )
        {
            trunk.addAccount("T.Elek", "00-00", 1000);
            trunk.addAccount("N.Erno", "11-11", 5000);
            trunk.addAccount("D.Vader", "22-22", 3000);
            trunk.addAccount("K.Bela", "33-33", 4500);

            trunk.addEvent("Egyenleglekerdezes", "11-11", new DateTime(2010, 5, 10));
            trunk.addEvent("Egyenleglekerdezes", "22-22", new DateTime(2010, 9, 14));
            trunk.addEvent("Bankszamlakivonat", "33-33", new DateTime(2010, 1, 5));

            System.Console.WriteLine(trunk);

            trunk.addEvent("00-00", 500, "11-11", new DateTime(2010, 8, 8));
            trunk.addEvent("33-33", 2000, "22-22", new DateTime(2010, 1, 8));

            System.Console.WriteLine(trunk);
        }

        public static void eventDemo()
        {
            System.Console.WriteLine("#### EventDemo\n");
            Base.AccountTrunk trunk = new Base.AccountTrunk(50);
            Program.processEventDemo(trunk);
        }

        public static void eventDemoAlter()
        {
            System.Console.WriteLine("#### EventDemoAlter\n");
            Alter.AccountTrunk trunk = new Alter.AccountTrunk();
            Program.processEventDemo(trunk);

        }

        public static void accountDemo()
        {
            System.Console.WriteLine("#### AccountDemo\n");
            
            Base.AccountTrunk trunk = new Base.AccountTrunk(50);
            
            trunk.addInstrument("OTP Optima", 34.3343);
            trunk.addInstrument("Rafi Perspektiva", 43.4354);

            trunk.addAccount(5000, "T.Elek", "00-00");
            trunk.addAccount(5000, "N.Erno", "11-11");
            trunk.addAccount(1000, "D.Vader", "22-22");
            trunk.addAccount(1000, "K.Bela", "33-33");
            trunk.addAccount("OTP Optima", 10, "N.Erno", "44-44");
            trunk.addAccount("Rafi Perspektiva", 2, "K.Bela", "55-55");

            System.Console.WriteLine(trunk);
            System.Console.WriteLine(trunk.getPeopleValue());
        }

        public static void complexDemo()
        {
            System.Console.WriteLine("#### ComplexDemo\n");

            Complex.AccountTrunk trunk = new Complex.AccountTrunk();

            trunk.addInstrument("OTP Optima", 34.3343);
            trunk.addInstrument("Rafi Perspektiva", 43.4354);

            trunk.addAccount("T.Elek", "00-00", 1000);
            trunk.addAccount("N.Erno", "11-11", 2000);
            trunk.addAccount("D.Vader", "22-22", 5000);

            trunk.addAccount("T.Elek", "33-33", "OTP Optima", 10);
            trunk.addAccount("N.Erno", "44-44", "Rafi Perspektiva", 2);
            trunk.addAccount("N.Erno", "55-55", "OTP Optima", 5);

            trunk.addEvent("Egyenleglekerdezes", "11-11", new DateTime(2010, 5, 10));
            trunk.addEvent("Egyenleglekerdezes", "22-22", new DateTime(2010, 9, 14));
            trunk.addEvent("Bankszamlakivonat", "33-33", new DateTime(2010, 1, 5));

            trunk.addEvent("00-00", 500, "11-11", new DateTime(2010, 8, 8));

            System.Console.WriteLine(trunk);
            System.Console.WriteLine(trunk.getPeopleValue());
        }

        public static void Main(string[] args)
        {
            Program.eventDemo();
            Program.eventDemoAlter();
            Program.accountDemo();
            Program.complexDemo();
            System.Console.ReadKey();
        }
    }
}
