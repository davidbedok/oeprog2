using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryBookPerson
{
    public interface IBook
    {
        String ISBN { get; }
        String Author { get; }
        String Title { get; }
        BookCategory Category { get; }
        Int32 AvailableCount { get; }

        void incrementCounter();
        void decrementCounter();
    }
}
