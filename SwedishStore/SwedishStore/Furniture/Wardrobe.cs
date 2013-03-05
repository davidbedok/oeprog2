using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwedishStore.Api;
using SwedishStore.Common;

namespace SwedishStore.Furniture
{
    public class Wardrobe : AbstractFurniture, BuiltInLampCapable
    {

        private readonly int numberOfShelves;
        private readonly DoorType typeOfDoor;
        private readonly bool mirror;

        private readonly bool builtInLamp;

        public Wardrobe(String fancyName, Room room, Material material, Size size, double price, int numberOfShelves, DoorType typeOfDoor, bool mirror,
                bool builtInLamp)
            : base(fancyName, room, material, size, price)
        {
            this.numberOfShelves = numberOfShelves;
            this.typeOfDoor = typeOfDoor;
            this.mirror = mirror;
            this.builtInLamp = builtInLamp;
        }

        public bool isBuiltInLamp()
        {
            return this.builtInLamp;
        }

        public int getNumberOfShelves()
        {
            return this.numberOfShelves;
        }

        public DoorType getTypeOfDoor()
        {
            return this.typeOfDoor;
        }

        public bool isMirror()
        {
            return this.mirror;
        }

        public override String ToString()
        {
            return base.ToString() + ", " + this.numberOfShelves + " shel(f/ves) " + this.typeOfDoor + " " + (this.mirror ? "[Mirror] " : "")
                    + (this.builtInLamp ? "[BuiltInLamp]" : "");
        }

        protected override String printType()
        {
            return CsvFurnitureType.WARDROBE.ToString();
        }

        protected override String sellDetails()
        {
            return "Frame is obtained from warehouse by customer, but the " + this.typeOfDoor + " door is obtained by fellow worker of store.";
        }

        public override bool Equals(Object othat)
        {
            // OR override == operator
            if (this == othat)
            {
                return true;
            }

            if (othat == null)
            {
                return false;
            }
            if (othat is Bed)
            {
                Bed that = othat as Bed;
                return this.Equals(that);
            }
            return false;
        }

        public bool Equals(Wardrobe that)
        {
            if ((object)that == null)
            {
                return false;
            }
            if (base.Equals(that))
            {
                if (that.numberOfShelves == this.numberOfShelves && that.typeOfDoor == this.typeOfDoor && that.mirror == this.mirror && that.builtInLamp == this.builtInLamp)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + numberOfShelves;
        }

    }
}
