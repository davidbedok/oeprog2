using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceStore.helper
{
    public interface IMultiUserFurniture
    {
        int getNumberOfUser();
        void setNumberOfUser(int numberOfUser);
    }
}
