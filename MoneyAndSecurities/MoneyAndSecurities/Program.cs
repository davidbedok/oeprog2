using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoneyAndSecurities.Wealth;
using MoneyAndSecurities.Mortgage;
using MoneyAndSecurities.Handlers;

namespace MoneyAndSecurities
{
    public class Program
    {

        private static void testWealth()
        {
            Console.WriteLine("----[ Test Wealth ]----");
            CountChangeEventHandler handler = new CountChangeEventHandler();

            Money money = new Money(Currency.CHF, 100); 
            money.OnChangeHandler = handler;

            Console.WriteLine(money);
            Chattel chattel = new Chattel("Stamp", 1500, 4);
            chattel.OnChangeHandler = handler;
            Console.WriteLine(chattel);
            money.income(50);
            chattel.outcome(1);
            Console.WriteLine(money);
            Console.WriteLine(chattel);
            try
            {
                money.outcome(200);
                chattel.outcome(7);
            }
            catch (InvalidCountException e)
            {
                Console.WriteLine("Exception: " + e.Message + " - WrongCount: " + e.WrongCount);
            }
            finally
            {
                Console.WriteLine(money);
                Console.WriteLine(chattel);
            }
        }

        private static void testMortgage()
        {
            Console.WriteLine("----[ Test Mortgage ]----");
            Person person = new Person("Nemecsek");
            Account<Money> moneyAccount = new Account<Money>(person, new Money(Currency.CHF, 100));
            Console.WriteLine(moneyAccount);
            Account<Chattel> chattelAccount = new Account<Chattel>(person, new Chattel("Stamp", 1500, 4));
            Console.WriteLine(chattelAccount);
            moneyAccount.income(50);
            chattelAccount.outcome(1);
            Console.WriteLine(moneyAccount);
            Console.WriteLine(chattelAccount);
            moneyAccount.outcome(200);
            chattelAccount.outcome(7);
            Console.WriteLine(moneyAccount);
            Console.WriteLine(chattelAccount);
        }

        private static void testPawnshop()
        {
            Console.WriteLine("----[ Test Pawnshop ]----");
            Pawnshop shop = new Pawnshop();
            shop.addPerson("Nemecsek");
            shop.addPerson("Tutajos");
            shop.addMoneyAccount("Nemecsek", Currency.EUR, 450);
            shop.addChattelAccount("Nemecsek", "Stamp", 1500, 4);
            shop.addMoneyAccount("Tutajos", Currency.CHF, 670);
            shop.addMoneyAccount("Tutajos", Currency.HUF, 4532);
            Console.WriteLine(shop);
        }

        private static void Main(string[] args)
        {
            Program.testWealth();
            /*
            Program.testWealth();
            Program.testMortgage();
            Program.testPawnshop();
             */
           // DogHelper.testProcess();
        }
    }
}
