using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecursionAlg
{
    public class Hanoi
    {
        /*
         * 3 rud, elso rudon az osszes korong
         * minden lepesben egy korong teheto mashova
         * nagyobb korong nem teheto kisebbre
         */


        private static int i;

        public static void process( int num, int from, int to, int manko)
        {
            Hanoi.i = 1;
            if (num == 1)
            {
                System.Console.WriteLine(from+"->"+to);
            }
            else
            {
                Hanoi.process(num-1,from,manko,to);
                System.Console.WriteLine(from + "->" + to);
                Hanoi.process(num - 1, manko, to, from);
            }


        }


    }
}
