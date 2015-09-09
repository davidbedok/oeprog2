using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        private static void Main(string[] args)
        {

            Bank bank = new Bank();
            bank.Add("123-123", Currency.EUR, 100);
            bank.Add("456-456", Currency.HUF, 2500);
            bank.Add("789-789", Currency.CHF, 500);

            Console.WriteLine(bank);

            Console.WriteLine("Transfer 10 EUR from 123-123 to 456-456.");
            bank.Transfer("123-123", "456-456", 10);

            Console.WriteLine(bank);

            Console.WriteLine("Transfer 20 CHF from 789-789 to 123-123.");
            bank.Transfer("789-789", "123-123", 20);

            Console.WriteLine(bank);

            Console.WriteLine("Transfer 3000 HUF from 456-456 to 789-789.");
            bank.Transfer("456-456", "789-789", 3000);

            Console.WriteLine(bank);

            ExchangeRateHolder exchangeRates = ExchangeRateHolder.GetInstance();
            exchangeRates[Currency.EUR] = 200;
            exchangeRates[Currency.CHF] = 100;

            Console.WriteLine("Transfer 2000 HUF from 456-456 to 123-123.");
            bank.Transfer("456-456", "123-123", 2000);

            Console.WriteLine(bank);
        }
    }
}
