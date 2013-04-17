using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoneyAndSecurities.Wealth;
using MoneyAndSecurities.Mortgage;
using MoneyAndSecurities.Handlers;
using MoneyAndSecurities.Exceptions;
using MoneyAndSecurities.Institution;

namespace MoneyAndSecurities
{
    public class Program
    {

        /*
         * Ketfele "vagyon" letezik a modellben. Az egyik valamilyen valutaban ertendo penzmennyiseg, a masik pedig valamilyen ingosag (haz, auto, belyeg, stb.).
         * Mindegyikbol valamennyi egesz darabbal rendelkezhetunk, es van lehetosegunk ezen mennyiseget novelni, illetve csokkenteni.
         * A penzvagyon tud negativ lenni, viszont az ingosag nem (nem tudunk -3 belyeggel rendelkezni, de tudunk -3000 Forinttal).
         */

        // Exceptions and Events via interface
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

        /*
         * Felmerult az igeny arra, hogy a "vagyon" entitasokat a zaloghaz szamara becsomagoljuk. Minden zaloghazi vagyontargyhoz tartozik
         * egy szamlaszam, mely a zaloghaz szempontjabol egyedi. A wrapper osztalyt ha generikusan keszitjuk el, akkor nincs szukseg ket wrapper osztalyt
         * keszitenunk, eleg egy template-et!
         * Amennyiben egy ingosag negativ lenne outcome soran, a wrapper nullazza ki (ne egyszeruen nullaza, mivel fel kell tudni keszulni arra, hogy
         * "valaki" esetleg figyeli egy esemenyen keresztul a vagyontargy valtozasat, ezert a csokkenst pontosan kell vegrehajtani (kivetel lekezelese, melybol
         * kiderul hogy mennyivel kell az outcome-ot hivni ahhoz, hogy pont nulla legyen a vagyontargy darabszama).
         */

        // generic class
        private static void testAccount()
        {
            Console.WriteLine("----[ Test Account ]----");
            Account<Money> moneyAccount = new Account<Money>("MON001", new Money(Currency.CHF, 500));
            Console.WriteLine(moneyAccount);
            moneyAccount.income(100);
            moneyAccount.outcome(50);
            Console.WriteLine(moneyAccount);

            Account<Chattel> chattelAccount = new Account<Chattel>("CHA001", new Chattel("Stamp", 1500, 4));
            Console.WriteLine(chattelAccount);
            chattelAccount.outcome(6);
            Console.WriteLine(chattelAccount);
        }

        /*
         * A zaloghaz az egy szemely tulajdonaban levo szamlakat egyuttesen szeretne kezelni, foleg azert pl. hogy lassa egyben hogy mekkora ertekkel
         * rendelkezik az adott szemely (value), valamint ha behoz/kivesz valamilyen valutat, elzalogosit/kivalt valamilyen ingosagot, akkor ezt
         * egysegesen tudja megtenni (fontos az atlathatosag vegett, hogy adott szemelynek pontosan ugyanolyan belyegebol, 
         * pontosan ugyanolyan valutajabol ne legyen tobb szamlaja).
         * A generic osztalyokat nehezen tudjuk kozos listaba szervezni, viszont a redundanciat minden aron el kell kerulnunk.
         * Ket modszer kombinacioja legtobbszor eleg: generikus metodusok, es overload metodusok, valamint termeszetesen az mar nem generic osztaly,
         * melyen kereszul ezeket mozgatjuk.
         */

        // generic methods, generic wrapper
        private static void testPersonAccounts()
        {
            Console.WriteLine("----[ Test PersonAccounts ]----");
            PersonAccounts personAccounts = new PersonAccounts(new Person("Nemecsek"));
            personAccounts.addAccount("MON001", Currency.EUR, 100);
            personAccounts.addAccount("CHA001", "Stamp", 1500, 4);
            personAccounts.addAccount("MON002", Currency.HUF, 3000);
            Console.WriteLine(personAccounts);
            personAccounts.income(Currency.HUF, 500);
            personAccounts.outcome("Stamp", 1);
            Console.WriteLine(personAccounts);
        }

        /*
         * A zaloghaz mar egy egyszeru, ujdonsagot nem tartalmazo osztaly, hiszen immaron egy nem generikus PersonAccounts listat kezel (ami bar generikus).
         * Az osztalyhoz miutan ugyfeleket rendelunk (addPerson()), mar erkeztethetjuk is a beveteleket, kiadasokat. Amennyiben olyan tetel kerul
         * kezbe, amit az adott szemely egyetlen szamlajahoz sem tudunk csatolni, akkor a szemelynek letrehozunk egy ilyen szamlat. Ehhez ismet kivetelkezelest fogunk hasznalni.
         */

        private static void testPawnshop()
        {
            Console.WriteLine("----[ Test Pawnshop ]----");
            Pawnshop shop = new Pawnshop();
            shop.addPerson("Nemecsek");
            shop.addPerson("TesztElek");
            shop.income("Nemecsek", Currency.EUR, 100);
            shop.income("TesztElek", "Stamp", 1500, 4);
            shop.income("Nemecsek", "Stamp", 2000, 2);
            Console.WriteLine(shop);
        }

        private static void Main(string[] args)
        {
            Program.testWealth();
            Program.testAccount();
            Program.testPersonAccounts();
            Program.testPawnshop();
        }
    }
}
