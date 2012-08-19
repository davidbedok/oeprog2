using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceStore.helper;

namespace InterfaceStore.market
{
    // etkeszlet
    public class DinnerwareSet : AbstractMarketGoods
    {
        private bool decorated;

        public DinnerwareSet(GoodsType type, bool decorated)
            : base(type)
        {
            this.decorated = decorated;
        }

        public override string description()
        {
            return "Dinnerware set";
        }

        public override string ToString()
        {
            return (this.decorated ? "Decorated " : "") + base.ToString();
        }

    }
}
