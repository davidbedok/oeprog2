using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceStore.helper;

namespace InterfaceStore.market
{
    public class TableLamp : AbstractMarketGoods
    {
        private Efficiency efficiency;

        public TableLamp(GoodsType type, Efficiency efficiency)
            : base(type)
        {
            this.efficiency = efficiency;
        }

        public override string description()
        {
            return "TableLamp";
        }

        public override string ToString()
        {
            return this.efficiency + " " + base.ToString();
        }

    }
}
