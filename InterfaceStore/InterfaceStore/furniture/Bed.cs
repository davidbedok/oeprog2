using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceStore.helper;

namespace InterfaceStore.furniture
{
    public class Bed : AbstractFurniture, IMultiUserFurniture
    {

        private int numberOfUser;
        private Mattress mattress; // matrac

        public Bed(RoomType roomType, Material baseMaterial, Size size, int numberOfUser, Mattress mattress)
            : base(roomType, baseMaterial,size)
        {
            this.numberOfUser = numberOfUser;
            this.mattress = mattress;
        }

        public int getNumberOfUser()
        {
            return this.numberOfUser;
        }

        public void setNumberOfUser(int numberOfUser)
        {
            this.numberOfUser = numberOfUser;
        }

        public override string ToString()
        {
            return "Bed with "+this.mattress+" mattress. " + base.ToString();
        }

    }
}
