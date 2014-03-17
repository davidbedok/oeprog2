using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class VHS : AbstractItem
    {
        private VHSType casetteType;

        public VHSType PCasetteType
        {
            get { return casetteType; }
            set { casetteType = value; }
        }

        public VHS(string name, int grid, double price, VHSType casetteType)
            : base(name, grid, price)
        {
            this.casetteType = casetteType;
        }
        
        public override string play()
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            return "Play VHS (" + Grid + ") " + Name + " price: " + Price + " casetteType:" + casetteType.ToString();
        }

    }
}
