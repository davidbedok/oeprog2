using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwedishStore.Api;
using SwedishStore.Common;

namespace SwedishStore.Market
{
    public class DinnerwareSet : AbstractMarketGood
    {

        private readonly bool colored;

        public DinnerwareSet(String fancyName, SupplementaryType supplementaryType, double price, bool colored)
            : base(fancyName, supplementaryType, price)
        {
            this.colored = colored;
        }

        public bool isColored()
        {
            return this.colored;
        }

        public override String ToString()
        {
            return base.ToString() + (this.colored ? "[Colored] " : "");
        }

    }
}
