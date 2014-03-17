using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class VVHS : VirtualItem
    {
        private VHSType casetteType;

        public VHSType PCasetteType
        {
            get { return casetteType; }
            set { casetteType = value; }
        }

        public VVHS(string name, int grid, double price, VHSType casetteType)
            : base(name, grid, price)
        {
            this.casetteType = casetteType;
        }
       
        
        public override string play()
        {
            return "Play VVHS (" + Grid + ") " + Name + " price: " + Price + " casetteType:" + casetteType.ToString();
        }

    }
}
