using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceStore.helper;

namespace InterfaceStore.furniture
{
    public class Wardrobe : AbstractFurniture
    {
        private int numberOfShelves;
        private bool builtIn;

        public Wardrobe(RoomType roomType, Material baseMaterial, Size size, int numberOfShelves, bool builtIn)
            : base(roomType, baseMaterial,size)
        {
            this.numberOfShelves = numberOfShelves;
            this.builtIn = builtIn;
        }

        public override string ToString()
        {
            return (this.builtIn ? "Built-in " : "") + "Wardrobe with " + this.numberOfShelves + " shelves. " + base.ToString();
        }

    }
}
