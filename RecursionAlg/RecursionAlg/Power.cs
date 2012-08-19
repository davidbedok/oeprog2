using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecursionAlg
{
    public class Power
    {
        public static int process(int x, int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return x * Power.process(x,n-1);
        }

        // paratlan
        private static bool odd(int n)
        {
            return (n % 2) == 1;
        }

        private static int square(int x)
        {
            return x * x;
        }

        // ha paros a kitevo, tudunk gyorsabb szamolast
        // x^2 ki tudjuk szamolni gyorsan x^4-t, ha negyzetre emeljuk.
        // 3^2 = 9 3^4 = 81  = 9 * 9 = (3^2)^2
        // ha paratlan, akkor meg visszavezetjuk paros kitevore:
        // 3^5 = 3^4 * 3 3^4-en pedig 3^[(4 / 2)^2]
        public static int fastProcess(int x, int n)
        {
            
            if (n == 0)
            {
                return 1;
            } else if (Power.odd(n)){
                return x * Power.square(Power.fastProcess(x, n / 2));
            }
            return Power.square(Power.fastProcess(x, n / 2));    
        }

    }
}
