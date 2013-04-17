using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoneyAndSecurities.Events;
using MoneyAndSecurities.Wealth;

namespace MoneyAndSecurities.Handlers
{
    public class CountChangeEventHandler : CountOnChangeEvent
    {

        public void onChange(Property property, int originalCount, int newCount)
        {
            Console.WriteLine( property + " change from " + originalCount + " to " + newCount);    
        }

    }
}
