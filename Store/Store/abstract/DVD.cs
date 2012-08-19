using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class DVD : AbstractItem
    {
        private DVDType diskType;

        public DVDType PDiskType
        {
            get { return diskType; }
            set { diskType = value; }
        }

        public DVD(string name, int grid, double price, DVDType diskType)
            : base(name, grid, price)
        {
            this.diskType = diskType;
        }
      
        public override string play()
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            return "Play DVD (" + Grid + ") " + Name + " price: " + Price + " disktype:" + diskType.ToString();
        }


    }
}
