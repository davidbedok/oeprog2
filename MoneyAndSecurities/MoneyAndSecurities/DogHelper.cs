using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyAndSecurities
{
    public class DogHelper
    {

        private static String process(String name, int numberOfDogs)
        {
            if (numberOfDogs <= 0)
            {
                throw new InvalidArgumentException("Number of dogs must be positive.", numberOfDogs);
            }
            return name  + " has " + numberOfDogs + " dog(s)";
        }

        public static void testProcess()
        {
            try
            {
                Console.WriteLine(DogHelper.process("Nemecsek Erno", 5));
                Console.WriteLine(DogHelper.process("Petofi Sandor", -2));
                Console.WriteLine(DogHelper.process("Jozsef Attila", 3));
            }
            catch (InvalidArgumentException e)
            {
                Console.WriteLine(e.Message + ". NumberOfDogs: " + e.NumberOfDogs);
                // throw new InvalidArgumentException("Error: " + e.Message, e, e.NumberOfDogs);
            }
            finally
            {
                Console.WriteLine("Finally");
            }
    

        }


    }
}
