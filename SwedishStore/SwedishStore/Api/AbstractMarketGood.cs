using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwedishStore.Common;
using SwedishStore.Engine;

namespace SwedishStore.Api
{
    public abstract class AbstractMarketGood : Object, Salable
    {

        protected readonly SupplementaryType supplementaryType;

        protected readonly String fancyName;
        protected readonly double price;

        public AbstractMarketGood(String fancyName, SupplementaryType supplementaryType, double price)
        {
            this.fancyName = fancyName;
            this.supplementaryType = supplementaryType;
            this.price = price;
        }


        public String getFancyName()
        {
            return this.fancyName;
        }

        public SupplementaryType getSupplementaryType()
        {
            return this.supplementaryType;
        }


        public double getPrice()
        {
            return this.price;
        }


        public String sell(int pieces)
        {
            return pieces + " piece(s) " + this.getFancyName() + " was sold (total: " + String.Format("{0,8:0.00}", pieces * this.price) + " " + Store.CURRENCY + ").";
        }


        public override String ToString()
        {
            return this.fancyName + " " + this.supplementaryType + String.Format("{0,8:0.00}", this.price);
        }


    }
}
