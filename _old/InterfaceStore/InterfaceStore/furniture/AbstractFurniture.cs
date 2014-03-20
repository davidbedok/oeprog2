using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceStore.core;
using InterfaceStore.helper;

namespace InterfaceStore.furniture
{
    public abstract class AbstractFurniture : System.Object, ISalable
    {
        private RoomType roomType;
        private Material baseMaterial;
        private Size size;
        private int price;
        private bool available;

        public AbstractFurniture(RoomType roomType, Material baseMaterial, Size size)
        {
            this.roomType = roomType;
            this.baseMaterial = baseMaterial;
            this.size = size;
        }

        public string sell()
        {
            if (this.Available)
            {
                return this + " is sold (" + this.Price + " huf).";
            }
            else
            {
                return this + " is not available.";
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

        public override string ToString()
        {
            string addon = "";
            if (this is IMultiUserFurniture)
            {
                addon = (this as IMultiUserFurniture).getNumberOfUser() + "-users ";
            }
            return addon + this.roomType + " furniture of " + this.baseMaterial + " ["+this.size+"]";
        }

    }
}
