using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfaceStore.core
{
    // eladhato
    public interface ISalable : IAvailable
    {
        string sell();
        
        int Price
        {
            get;
            set;
        }
    }
}
