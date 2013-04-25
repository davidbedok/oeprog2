using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockExchange
{
    public interface ValueChangeEvent
    {

        void change( int newValue );

    }
}
