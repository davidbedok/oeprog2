using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoneyAndSecurities.Wealth;

namespace MoneyAndSecurities.Events
{
    public interface CountOnChangeEvent
    {
        void onChange(Property property, int originalCount, int newCount);
    }
}
