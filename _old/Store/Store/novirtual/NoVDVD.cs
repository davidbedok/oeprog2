using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class NoVDVD : NoVirtualItem
    {
        private DVDType diskType;

        public DVDType DiskType
        {
            get { return diskType; }
            set { diskType = value; }
        }

        public NoVDVD(string name, int grid, double price, DVDType diskType)
            : base(name, grid, price)
        {
            this.diskType = diskType;
        }
       
        // new nelkul warning-ot ad
        public new string play()
        {
            return "Play NoVDVD (" + Grid + ") " + Name + " price: " + Price + " disktype:" + diskType.ToString();
        }


    }
}
