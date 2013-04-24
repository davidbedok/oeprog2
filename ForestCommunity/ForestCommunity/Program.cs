using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ForestCommunity.Forest;
using ForestCommunity.Api;

namespace ForestCommunity
{
    class Program
    {
        private static void Main(string[] args)
        {

            Plantation plantation = new Plantation(3, 1);
            try
            {
                while (true)
                {
                    plantation.tick();
                    Console.WriteLine(plantation.ToString());
                    Console.ReadKey();
                }
            }
            catch (NoMoreWorkSeedBedException e)
            {

            }

        }
    }
}
