using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecursionAlg
{
    public class Prime
    {

        public static bool process(int n)
        {
            return Prime.process(n, 2);
        }

        public static bool fastProcess(int n)
        {
            return Prime.fastProcess(n,2);
        }

        // ha z nem osztoja n-nek, akkor prime, ha z+1 sem osztoja!
        private static bool process(int n, int z)
        {
            if (z == n)
            {
                return true;
            }
            else if ((n % z) == 0)
            {
                return false;
            }
            else if (z < n)
            {
                return Prime.process(n, z + 1);
            }
            return false;
        }

        private static bool fastProcess(int n, int z)
        {
            if (n == 1)
            {
                return false;
            }
            else if (z > Math.Sqrt(n))
            {
                return true;
            }
            else if ((n % z) == 0)
            {
                return false;
            }
            else if (z < Math.Sqrt(n))
            {
                return Prime.fastProcess(n, z + 1);
            }
            return false;
        }


    }
}
