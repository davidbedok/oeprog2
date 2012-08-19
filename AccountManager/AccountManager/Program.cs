using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccountManager
{
    public class Program
    {
        private static Random rand = new Random();

        // out: 4
        public static double Test001(ITrunk trunk)
        {
            return trunk.convertCurrency(Currency.HUF, Currency.EUR, 1000);
        }

        // out: 5000
        public static double Test002(ITrunk trunk)
        {
            return trunk.convertCurrency(Currency.CHF, Currency.JPY, 50);
        }

        // out: 0
        public static double Test003(ITrunk trunk)
        {
            return trunk.getAccountValue("NO001");
        }

        // out: 700
        public static double Test004(ITrunk trunk)
        {
            trunk.addAccount("ABC-001", Currency.HUF);
            trunk.addTransfer("ABC-001", Currency.HUF, 1000);
            trunk.addTransfer("ABC-001", Currency.HUF, -500);
            trunk.addTransfer("ABC-001", Currency.HUF, 200);
            return trunk.getAccountValue("ABC-001");
        }

        // out: 900
        public static double Test005(ITrunk trunk)
        {
            trunk.addAccount("ABC-001", Currency.HUF);
            trunk.addAccount("QWE-002", Currency.HUF);
            trunk.addTransfer("ABC-001", Currency.HUF, 1000);
            trunk.addTransfer("QWE-002", Currency.HUF, 333);
            trunk.addTransfer("ABC-001", Currency.EUR, -2);
            trunk.addTransfer("ABC-001", Currency.CHF, 2);
            trunk.addTransfer("QWE-002", Currency.HUF, 111);
            return trunk.getAccountValue("ABC-001");
        }

        // out: 27500
        public static double Test006(ITrunk trunk)
        {
            trunk.addAccount("ASD-000", Currency.HUF);
            trunk.addAccount("ABC-001", Currency.HUF);
            trunk.addAccount("QWE-002", Currency.HUF);
            // 550 * 50 = 27500
            for (int i = 0; i < 50; i++)
            {
                trunk.addTransfer("ASD-000", Currency.EUR, rand.Next(10,1000));
                trunk.addTransfer("ASD-000", Currency.GBP, rand.Next(10, 1000));
                trunk.addTransfer("ASD-000", Currency.JPY, rand.Next(10, 1000));
                trunk.addTransfer("ABC-001", Currency.CHF, 3); // 600
                trunk.addTransfer("ASD-000", Currency.HUF, rand.Next(10, 1000));
                trunk.addTransfer("QWE-002", Currency.HUF, rand.Next(10, 1000));
                trunk.addTransfer("ABC-001", Currency.EUR, -2); // -500
                trunk.addTransfer("ABC-001", Currency.GBP, 1.5); // 450 
                trunk.addTransfer("ASD-000", Currency.HUF, rand.Next(10, 1000));
                trunk.addTransfer("QWE-002", Currency.HUF, rand.Next(10, 1000));
            }
            return trunk.getAccountValue("ABC-001");
        }

        // out: 3,6
        public static double Test007(ITrunk trunk)
        {
            trunk.addAccount("ABC-001", Currency.HUF);
            trunk.addAccount("QWE-002", Currency.HUF);
            trunk.addAccount("ABC-001", Currency.EUR);
            trunk.addTransfer("ABC-001", Currency.HUF, 1000);
            trunk.addTransfer("QWE-002", Currency.HUF, 333);
            trunk.addTransfer("ABC-001", Currency.EUR, -2);
            trunk.addTransfer("ABC-001", Currency.CHF, 2);
            trunk.addTransfer("QWE-002", Currency.HUF, 111);
            return trunk.getAccountValue("ABC-001");
        }

        // out: 18.5
        public static double Test008(ITrunk trunk)
        {
            trunk.addAccount("ABC-001", Currency.CHF);
            trunk.addAccount("QWE-002", Currency.HUF);
            trunk.addTransfer("ABC-001", Currency.HUF, 1000);
            trunk.addTransfer("QWE-002", Currency.HUF, -500);
            trunk.addTransfer("ABC-001", Currency.HUF, 3500);
            trunk.addTransfer("ABC-001", Currency.HUF, -800);
            trunk.addTransfer("QWE-002", Currency.HUF, 111);
            return trunk.getAccountValue("ABC-001");
        }

        // out: 250
        public static double Test009(ITrunk trunk)
        {
            trunk.addAccount("ASD-000", Currency.GBP);
            trunk.addAccount("ABC-001", Currency.GBP);
            trunk.addAccount("QWE-002", Currency.HUF);
            for (int i = 0; i < 50; i++)
            {
                trunk.addTransfer("ASD-000", Currency.EUR, rand.Next(10, 1000));
                trunk.addTransfer("ASD-000", Currency.GBP, rand.Next(10, 1000));
                trunk.addTransfer("ASD-000", Currency.JPY, rand.Next(10, 1000));
                trunk.addTransfer("ABC-001", Currency.CHF, 3); // 600
                trunk.addTransfer("ASD-000", Currency.HUF, rand.Next(10, 1000));
                trunk.addTransfer("QWE-002", Currency.HUF, rand.Next(10, 1000));
                trunk.addTransfer("ABC-001", Currency.EUR, -2); // -500
                trunk.addTransfer("ABC-001", Currency.GBP, 1.5); // 450 
                trunk.addTransfer("ASD-000", Currency.HUF, rand.Next(10, 1000));
                trunk.addTransfer("QWE-002", Currency.HUF, rand.Next(10, 1000));
                trunk.addTransfer("ABC-001", Currency.HUF, 950); // 950
            }
            return trunk.getAccountValue("ABC-001");
        }

        // out: -187,5
        public static double Test010(ITrunk trunk)
        {
            trunk.addAccount("ASD-000", Currency.GBP);
            trunk.addAccount("ASD-000", Currency.HUF);
            trunk.addAccount("ABC-001", Currency.GBP);
            trunk.addAccount("QWE-002", Currency.HUF);
            trunk.addAccount("QWE-002", Currency.EUR);
            trunk.addAccount("ABC-001", Currency.CHF);
            for (int i = 0; i < 50; i++)
            {
                trunk.addTransfer("ASD-000", Currency.EUR, rand.Next(10, 1000));
                trunk.addTransfer("ASD-000", Currency.GBP, rand.Next(10, 1000));
                trunk.addTransfer("ASD-000", Currency.JPY, rand.Next(10, 1000));
                trunk.addTransfer("ABC-001", Currency.CHF, -3.5); // -700
                trunk.addTransfer("ASD-000", Currency.HUF, rand.Next(10, 1000));
                trunk.addTransfer("QWE-002", Currency.HUF, rand.Next(10, 1000));
                trunk.addTransfer("ABC-001", Currency.EUR, -2); // -500
                trunk.addTransfer("ABC-001", Currency.GBP, 1.5); // 450 
                trunk.addTransfer("ASD-000", Currency.HUF, rand.Next(10, 1000));
                trunk.addTransfer("QWE-002", Currency.HUF, rand.Next(10, 1000));
            }
            return trunk.getAccountValue("ABC-001");
        }

        public static void Main(string[] args)
        {
            ITrunk trunk = new AccountTrunk();
            trunk.addCurrency(Currency.HUF, 1);
            trunk.addCurrency(Currency.EUR, 250);
            trunk.addCurrency(Currency.CHF, 200);
            trunk.addCurrency(Currency.USD, 180);
            trunk.addCurrency(Currency.GBP, 300);
            trunk.addCurrency(Currency.JPY, 2);

            System.Console.WriteLine(Program.Test010(trunk));
        }
    }
}
