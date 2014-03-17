using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class NoVVHS : NoVirtualItem
    {
        private VHSType casetteType;

        public VHSType CasetteType
        {
            get { return casetteType; }
            set { casetteType = value; }
        }

        public NoVVHS(string name, int grid, double price, VHSType casetteType)
            : base(name, grid, price)
        {
            this.casetteType = casetteType;
        }
      
        // new nelkul warning-ot ad
        public new string play()
        {
            return "Play NoVVHS (" + Grid + ") " + Name + " price: " + Price + " casetteType:" + casetteType.ToString();
        }

    }
}
