using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceStore.furniture;
using InterfaceStore.market;
using InterfaceStore.helper;

namespace InterfaceStore.core
{
    public class Store : System.Object
    {
        private readonly int maxItem;

        private AbstractFurniture[] furniture;
        private int numberOfFurniture;

        private AbstractMarketGoods[] marketGoods;
        private int numberOfMarketGoods;

        private ISalable[] items;
        private int numberOfItems;

        public Store(int maxItem)
        {
            this.maxItem = maxItem;

            this.furniture = new AbstractFurniture[maxItem];
            this.numberOfFurniture = 0;

            this.marketGoods = new AbstractMarketGoods[maxItem];
            this.numberOfMarketGoods = 0;

            this.items = new ISalable[maxItem];
            this.numberOfItems = 0;
        }

        public void addItem(ISalable salable)
        {
            if (this.numberOfItems < this.maxItem)
            {
                this.items[this.numberOfItems++] = salable;
            }
        }

        public void addFurniture(AbstractFurniture abstractFurniture)
        {
            if (this.numberOfFurniture < this.maxItem)
            {
                this.furniture[this.numberOfFurniture++] = abstractFurniture;
            }
            this.addItem(abstractFurniture);
        }

        public void addMarketGoods(AbstractMarketGoods abstractMarketGoods)
        {
            if (this.numberOfFurniture < this.maxItem)
            {
                this.marketGoods[this.numberOfMarketGoods++] = abstractMarketGoods;
            }
            this.addItem(abstractMarketGoods);
        }

        public string simulationSalable()
        {
            Random rand = new Random();
            StringBuilder sb = new StringBuilder(200);
            sb.Append("< Salable items >\n");
            for (int i = 0; i < this.numberOfItems; i++)
            {
                // arazas
                this.items[i].Price = rand.Next(100, 500);
                // elerhetoseg
                this.items[i].Available = Convert.ToBoolean(rand.Next(0, 2));
                sb.Append(this.items[i]).Append("\n");
                // eladas
                sb.Append(this.items[i].sell()).Append("\n\n");
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(200);
            sb.Append("< Furniture >\n");
            for (int i = 0; i < this.numberOfFurniture; i++){
                sb.Append(this.furniture[i]).Append("\n");
            }
            sb.Append("< MarketGoods >\n");
            for (int i = 0; i < this.numberOfMarketGoods; i++)
            {
                sb.Append(this.marketGoods[i]).Append("\n");
            }
            return sb.ToString();
        }

    }
}
