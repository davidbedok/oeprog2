using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwedishStore.Api;
using SwedishStore.Common;

namespace SwedishStore.Furniture
{
    public class Table : AbstractFurniture, CompactSizeCapable
    {

        private readonly int numberOfChairs;
        private readonly bool scratchResistant;

        private readonly bool compactSize;

        public Table(String fancyName, Room room, Material material, Size size, double price, int numberOfChairs, bool scratchResistant, bool compactSize)
            : base(fancyName, room, material, size, price)
        {
            this.numberOfChairs = numberOfChairs;
            this.scratchResistant = scratchResistant;
            this.compactSize = compactSize;
        }

        public bool isCompactSizeMode()
        {
            return this.compactSize;
        }

        public int getNumberOfChairs()
        {
            return this.numberOfChairs;
        }

        public bool isScratchResistant()
        {
            return this.scratchResistant;
        }

        public override String ToString()
        {
            return base.ToString() + ", " + this.numberOfChairs + " chair(s) " + (this.scratchResistant ? "[ScratchResistant] " : "")
                    + (this.compactSize ? "[CompactSize] " : "");
        }


        protected override String printType()
        {
            return CsvFurnitureType.TABLE.ToString();
        }


        protected override String sellDetails()
        {
            return "The table and the attached " + this.numberOfChairs + " chair(s) are obtained from warehouse by customer.";
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
            if (othat is Table)
            {
                Table that = othat as Table;
                return this.Equals(that);
            }
            return false;
        }

        public bool Equals(Table that)
        {
            if ((object)that == null)
            {
                return false;
            }
            if (base.Equals(that))
            {
                if (that.numberOfChairs == this.numberOfChairs && that.scratchResistant == this.scratchResistant && that.compactSize == this.compactSize)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + numberOfChairs;
        }

    }
}
