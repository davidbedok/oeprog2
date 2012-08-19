using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryBookPerson
{
    public class Book : IBook
    {

        private readonly String isbn; // International Standard Book Number
        private readonly String author;
        private readonly String title;
        private readonly BookCategory category;
        private Int32 availableCount;

        public String ISBN
        {
            get { return this.isbn; }
        }

        public String Author
        {
            get { return this.author; }
        }

        public String Title
        {
            get { return this.title; }
        }

        public BookCategory Category
        {
            get { return this.category; }
        }

        public Int32 AvailableCount
        {
            get { return this.availableCount; }
        }

        public Book(String isbn, String author, String title, BookCategory category, Int32 count)
        {
            this.isbn = isbn;
            this.title = title;
            this.author = author;
            this.category = category;
            this.availableCount = count;
        }

        public void incrementCounter()
        {
            this.availableCount++;
        }

        public void decrementCounter()
        {
            if (this.availableCount > 0)
            {
                this.availableCount--;
            }
            else
            {
                throw new NotEnoughBookException("Book is not available.");
            }
        }

        public override string ToString()
        {
            return this.author + ": " + this.title + " [" + this.isbn + "] " + this.category + " (available: " + this.availableCount + ")";
        }

    }
}
