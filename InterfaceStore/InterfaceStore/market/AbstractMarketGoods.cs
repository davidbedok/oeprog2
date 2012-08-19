using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceStore.core;
using InterfaceStore.helper;

namespace InterfaceStore.market
{
    public abstract class AbstractMarketGoods : System.Object, ISalable
    {
        private GoodsType type;
        private int price;
        private bool available;

        public AbstractMarketGoods(GoodsType type)
        {
            this.type = type;
        }

        public string sell()
        {
            if (this.Available)
            {
                return this.description() + " is sold (" + this.Price + " huf).";
            }
            else
            {
                return this.description() + " is not available.";
            }
        }

        public int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public bool Available
        {
            get { return this.available; }
            set { this.available = value; }
        }

        public abstract string description();

        public override string ToString()
        {
            return this.type + ": " + this.description() + " from market";
        }

    }
}
