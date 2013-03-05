using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwedishStore.Api;

namespace SwedishStore.Engine
{
    public class StoreUpgrade
    {

       private readonly Dictionary<Salable, Int32> items;

       public StoreUpgrade()
        {
            this.items = new Dictionary<Salable, Int32>();
        }

       public void addItem(Salable item, Int32 count)
        {
            Int32 newCount = count;
            if (this.items.ContainsKey(item))
            {
                newCount += this.items[item];
                this.items[item] = newCount;
            }
            else
            {
                this.items.Add(item, newCount);
            }
        }



       public Salable find(String fancyName)
        {
            Salable ret = null;
            foreach (Salable item in this.items.Keys)
            {
                if (fancyName.Equals(item.getFancyName()))
                {
                    ret = item;
                    break;
                }
            }
            return ret;
        }

       public String addItem(String fancyName, Int32 count)
        {
            String ret = null;
            Salable item = this.find(fancyName);
            if (item != null)
            {
                this.addItem(item, count);
                ret = count + " piece(s) " + item.getFancyName() + " was arrived.";
            }
            return ret;
        }

        public String sell(String fancyName, int pieces)
        {
            String ret = null;
            Salable item = this.find(fancyName);
            if (item != null)
            {
                Int32 currentCount = this.items[item];
                if (currentCount - pieces > 0)
                {
                    ret = item.sell(pieces);
                    this.items[item] = currentCount - pieces;
                }
            }
            return ret;
        }

        public override String ToString()
        {
            StringBuilder info = new StringBuilder(100);
            foreach (Salable item in this.items.Keys)
            {
                Int32 count = this.items[item];
                info.Append(String.Format("{0} piece(s) - ", count)).AppendLine(item.ToString());
            }
            return info.ToString();
        }


    }
}
