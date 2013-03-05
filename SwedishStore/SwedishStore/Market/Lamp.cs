using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwedishStore.Api;
using SwedishStore.Common;

namespace SwedishStore.Market
{
    public class Lamp : AbstractMarketGood
    {
        private static readonly String LUMEN = "lm";

        private readonly LampType lampType;
        private readonly int flux;

        public Lamp(String fancyName, SupplementaryType supplementaryType, double price, LampType lampType, int flux)
            : base(fancyName, supplementaryType, price)
        {
            this.lampType = lampType;
            this.flux = flux;
        }

        public LampType getLampType()
        {
            return this.lampType;
        }

        public int getFlux()
        {
            return this.flux;
        }

        public override String ToString()
        {
            return base.ToString() + " " + this.lampType + " " + this.flux + " " + Lamp.LUMEN;
        }

    }
}
