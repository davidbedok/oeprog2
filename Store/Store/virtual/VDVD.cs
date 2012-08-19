using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class VDVD : VirtualItem
    {
        private DVDType diskType;

        public DVDType PDiskType
        {
            get { return diskType; }
            set { diskType = value; }
        }

        public VDVD(string name, int grid, double price, DVDType diskType)
            : base(name, grid, price)
        {
            this.diskType = diskType;
        }      

        // ha nics override a virtual parjaban, akkor warning lesz, es a hatas olyan, mint a Nem virtualis esetben
        // vagyis: csak parban van hatasa a virtual - override -nak
        public override string play()
        {
            return "Play VDVD (" + Grid + ") " + Name + " price: " + Price + " disktype:" + diskType.ToString();
        }


    }
}
