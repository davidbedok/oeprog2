using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionBasics
{
    // emberek pénzei
    public class PeopleMoney : AbstractHolder
    {
        // instance holds people's money
        // if money is positive: wealth
        // money can be negative : debt
        // money can be zero

        protected override void checkWhileAdd(int content) { }

        protected override void checkWhileRead()
        {
            if (this.readIndex >= this.index)
            {
                throw new EndOfDataException("End of data.");
            }
        }

    }
}
