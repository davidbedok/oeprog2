using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InterfaceStore.helper;

namespace InterfaceStore.furniture
{
    public class KitchenTable : AbstractFurniture, IMultiUserFurniture
    {
        private int numberOfUser; // felhasznalok szama
        private bool scratchResistant; // karcallo

        public KitchenTable(RoomType roomType, Material baseMaterial, Size size, int numberOfUser, bool scratchResistant)
            : base(roomType, baseMaterial,size)
        {
            this.numberOfUser = numberOfUser;
            this.scratchResistant = scratchResistant;
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
            return (this.scratchResistant ? "Scratch-resistant " : "") + "KitchenTable. " + base.ToString();
        }


    }
}
