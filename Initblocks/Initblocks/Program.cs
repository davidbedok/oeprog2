using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Initblocks
{
    public class Program
    {

        private static void testInitAfterCtor()
        {
            // ha nem hozunk letre olyan ctort, mely minden (szukseges) mezot be tud allitani
            // akkor letrehozas utan kell settereket hivnunk --> de ezt nem tudjuk eloirni! (code smell)
            Child childItem = new Child(42, 'A');
            childItem.Dummy = "hello world";
            childItem.Flag = true;
            System.Console.WriteLine(childItem);

            // a C# ctor utani init blockja akkor nyer ertelmet, ha van ososztaly
            // ugyanis itt castolas nelkul nem tudnank settert hivni
            Parent parentItem = new Child(42, 'A') {
                Dummy = "hello world", 
                Flag = true
            };
            // ((Child)parentItem).Dummy = "hello world"; // not recommended
            System.Console.WriteLine(parentItem);
        }

        private static void recommendedWay()
        {
            // az egesz mokat kikerulhetjuk, hogyha letrehozunk egy megfelelo overload konstruktort
            Child childItem = new Child(42, 'A', "hello world", true);
            System.Console.WriteLine(childItem);

            Parent parentItem = new Child(42, 'A', "hello world", true);
            System.Console.WriteLine(parentItem);

            // hatranynak ez esetben azt tudom elkepzelni, mikor van 10 opcionalis mezonk, melyek kapcsan
            // mindenféle kombináció előállhat. Ilyenkor rengeteg felesleges ctor-unk lehet, azonban ezek egymast
            // eleg jol fogjuk tudni hivni (redundancia gyakorlatilag teljesen kiszurheto)
            // Teny, hogy ilyenkor jol jon a C# szintaktikai cukorkaja, azonban biztos hogy jo az az osztaly ahol
            // ennyi opcionalis mezo letezik?
        }

        private static void Main(string[] args)
        {
            Program.testInitAfterCtor();
            Program.recommendedWay();
        }
    }
}
