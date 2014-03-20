using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDemo
{
    public class Program
    {
        private static void Main(string[] args)
        {

            CarStore store = new CarStore();
            store.add(Brand.SUZUKI, "Sx4", 104, 2);
            store.add(Brand.TOYOTA, "Verso", 120, 1);
            store.add(Brand.ROVER, "45", 88, 4);
            store.add(Brand.SUZUKI, "Sx4", 104, 6);

            Console.WriteLine(store);

        }
    }
}
