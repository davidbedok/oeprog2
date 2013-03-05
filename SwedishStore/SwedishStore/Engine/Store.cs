using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwedishStore.Api;
using SwedishStore.Common;
using SwedishStore.Furniture;

namespace SwedishStore.Engine
{
    public class Store
    {
        public const String CURRENCY = "EUR";

        private readonly Dictionary<AbstractFurniture, Int32> items;

        public Store()
        {
            this.items = new Dictionary<AbstractFurniture, Int32>();
        }

        private void addFurniture(AbstractFurniture furniture, Int32 count)
        {
            Int32 newCount = count;
            if (this.items.ContainsKey(furniture))
            {
                newCount += this.items[furniture];
                this.items[furniture] = newCount;
            }
            else
            {
                this.items.Add(furniture, newCount);
            }
        }

        public void addBed(String fancyName, Room room, Material material, Size size, double price, Mattress mattress, bool doubleSize, bool compactSize,
                bool builtInLamp, int count)
        {
            this.addFurniture(new Bed(fancyName, room, material, size, price, mattress, doubleSize, compactSize, builtInLamp), count);
        }


        public void addTable(String fancyName, Room room, Material material, Size size, double price, int numberOfChairs, bool scratchResistant,
                bool compactSize, int count)
        {
            this.addFurniture(new Table(fancyName, room, material, size, price, numberOfChairs, scratchResistant, compactSize), count);
        }

        public void addWardrobe(String fancyName, Room room, Material material, Size size, double price, int numberOfShelves, DoorType typeOfDoor, bool mirror,
                bool builtInLamp, int count)
        {
            this.addFurniture(new Wardrobe(fancyName, room, material, size, price, numberOfShelves, typeOfDoor, mirror, builtInLamp), count);
        }

        public AbstractFurniture find(String fancyName)
        {
            AbstractFurniture ret = null;
            foreach (AbstractFurniture furniture in this.items.Keys)
            {
                if (fancyName.Equals(furniture.getFancyName()))
                {
                    ret = furniture;
                    break;
                }
            }
            return ret;
        }

        public String addFurniture(String fancyName, Int32 count)
        {
            String ret = null;
            AbstractFurniture furniture = this.find(fancyName);
            if (furniture != null)
            {
                this.addFurniture(furniture, count);
                ret = count + " piece(s) " + furniture.getFancyName() + " was arrived.";
            }
            return ret;
        }

        public String sell(String fancyName, int pieces)
        {
            String ret = null;
            AbstractFurniture furniture = this.find(fancyName);
            if (furniture != null)
            {
                Int32 currentCount = this.items[furniture];
                if (currentCount - pieces > 0)
                {
                    ret = furniture.sell(pieces);
                    this.items[furniture] = currentCount - pieces;
                }
            }
            return ret;
        }

        public List<AbstractFurniture> listAllCompactSizeCapableFurniture()
        {
            List<AbstractFurniture> list = new List<AbstractFurniture>();
            foreach (AbstractFurniture furniture in this.items.Keys)
            {
                if (furniture is CompactSizeCapable)
                {
                    list.Add(furniture);
                }
            }
            return list;
        }

        public override String ToString()
        {
            StringBuilder info = new StringBuilder(100);
            foreach (AbstractFurniture furniture in this.items.Keys)
            {
                Int32 count = this.items[furniture];
                info.Append(String.Format("{0} piece(s) - ", count)).AppendLine(furniture.ToString());
            }
            return info.ToString();
        }

    }
}
