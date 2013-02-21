using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwedishStore.Api;
using SwedishStore.Common;

namespace SwedishStore.Furniture
{
    public class Bed : AbstractFurniture
    {

        private readonly Mattress mattress;
        private readonly bool doubleSize;	// double or single
        private readonly bool compactSize;
        private readonly bool builtInLamp;

        public Bed(String fancyName, Room room, Material material, Size size, double price, Mattress mattress, bool doubleSize, bool compactSize,
                bool builtInLamp)
            : base(fancyName, room, material, size, price)
        {
            this.mattress = mattress;
            this.doubleSize = doubleSize;
            this.compactSize = compactSize;
            this.builtInLamp = builtInLamp;
        }


        public bool isCompactSizeMode()
        {
            return this.compactSize;
        }


        public bool isBuiltInLamp()
        {
            return this.builtInLamp;
        }

        public Mattress getMattress()
        {
            return this.mattress;
        }

        public bool isDoubleSize()
        {
            return this.doubleSize;
        }

        public override String ToString()
        {
            return base.ToString() + " " + this.mattress + " " + (this.doubleSize ? "[DoubleSize] " : "[SingleSize] ")
                    + (this.compactSize ? "[CompactSize] " : "") + (this.builtInLamp ? "[BuiltInLamp]" : "");
        }

        protected override String printType()
        {
            return CsvFurnitureType.BED.ToString();
        }

        protected override String sellDetails()
        {
            return "Slats are obtained from warehouse by customer, but the " + this.mattress + " mattress is obtained by fellow worker of store.";
        }

    }
}
