using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryBookPerson
{
    public interface ILibrary
    {
        void addBook(String isbn, String author, String title, BookCategory category, Int32 count);
        void enrollment(Int32 id, String name, DateTime enrollmentDate);
        void borrow(Int32 id, String isbn);
        void bringBack(Int32 id, String isbn);
    }
}
