using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwedishStore.Common;

namespace SwedishStore.Api
{
    public abstract class AbstractFurniture : Object, Salable
    {

        private const String CURRENCY = "EUR";

        protected readonly String fancyName;
        protected readonly Room room;
        protected readonly Material material;
        protected readonly Size size;

        protected readonly double price;

        public AbstractFurniture(String fancyName, Room room, Material material, Size size, double price)
        {
            this.fancyName = fancyName;
            this.room = room;
            this.material = material;
            this.size = size;
            this.price = price;
        }

        public Material getMaterial()
        {
            return this.material;
        }

        public Room getRoom()
        {
            return this.room;
        }

        public Size getSize()
        {
            return this.size;
        }

        public String getFancyName()
        {
            return this.fancyName;
        }

        public double getPrice()
        {
            return this.price;
        }

        public String sell(int pieces)
        {
            return pieces + " piece(s) " + this.printInfo() + " was sold. " + this.sellDetails();
        }

        protected abstract String printType();

        protected abstract String sellDetails();

        public override String ToString()
        {
            return String.Format("{0,-9}", this.printType()) + this.printFancyName() + " Room-" + this.room + " Material-" + this.material + " " + this.size + " "
                    + String.Format("{0,8:0.00}", this.price) + " " + AbstractFurniture.CURRENCY;
        }

        private String printFancyName()
        {
            return String.Format("{0,7}", this.fancyName.ToUpper());
        }

        public String printInfo()
        {
            return this.printFancyName() + " " + this.printType();
        }
        
        public override bool Equals(Object othat)
        {
            if (othat == null)
            {
                return false;
            }
            if (othat is AbstractFurniture)
            {
                AbstractFurniture that = othat as AbstractFurniture;
                return this.Equals(that);
            }
            return false;
        }

        public bool Equals(AbstractFurniture that)
        {
            if ((object)that == null)
            {
                return false;
            }
            bool a = that.fancyName.Equals(this.fancyName);
            bool b = that.room == this.room;
            bool c = that.material == this.material;
            bool d = that.size.Equals(this.size);
            bool e = that.price == this.price;
            if (that.fancyName.Equals(this.fancyName) && that.room == this.room && that.material == this.material && that.size.Equals(this.size) && that.price == this.price)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 7 * fancyName.GetHashCode();
        }

    }
}
