using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicLists
{
    public interface IDemoList
    {
        void addItem(int id, string name);
        void iterate();
    }
}
