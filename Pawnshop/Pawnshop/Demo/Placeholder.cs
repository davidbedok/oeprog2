using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoneyAndSecurities.Demo
{
    public class Placeholder
    {

        public Placeholder()
        {

        }

        public int addSpecialNumbers( int dividableByThree, int diviableByFive )
        {
            if (dividableByThree % 3 != 0)
            {
                throw new NotSpecialNumberException("Number is not special (%3).", dividableByThree);
            }
            else if (diviableByFive % 5 != 0)
            {
                throw new NotSpecialNumberException("Number is not special (%5).", diviableByFive);
            }
            return dividableByThree + diviableByFive;
        }

    }
}
