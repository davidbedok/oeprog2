using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecursionAlg
{
    public class Factorial
    {

        public static int process(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            return Factorial.process(n - 1) * n;
        }

    }
}
