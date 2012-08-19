using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecursionAlg
{
    public class Fibonacci
    {

        public static int process( int num )
        {
            if (num < 3)
            {
                return 1;
            }
            else
            {
                return Fibonacci.process(num - 2) + Fibonacci.process(num - 1);
            }
        }

    }
}
