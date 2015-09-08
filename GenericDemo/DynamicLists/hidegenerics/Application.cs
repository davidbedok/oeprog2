using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists.hidegenerics
{
    public class Application
    {

        public static void TestShop()
        {
            PetShop<Cat> shop = new PetShop<Cat>();
            shop.Add(new Cat("Cirmos"));
            shop.Add(new Cat("Filemon"));
            shop.Buy("Filemon", "Gyongyver");
            Console.WriteLine(shop.Find("Filemon"));
        }

        public static void TestCosmetics()
        {
            DogCosmetics cosmetics = new DogCosmetics();
            cosmetics.Add(new Dog("Bodri"));
            cosmetics.Add(new Dog("Puli"));
            cosmetics.Haircut("Puli", 5);
            Console.WriteLine(cosmetics.Find("Puli"));
        }

    }
}
