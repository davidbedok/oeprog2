using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryBookPerson
{
    public class Library: ILibrary
    {

        private Dictionary<String, IBook> books;
        private Dictionary<Int32, IPerson> people;
        private Dictionary<IPerson, List<IBook>> transactions;

        public Library()
        {
            this.books = new Dictionary<String, IBook>();
            this.people = new Dictionary<Int32, IPerson>();
            this.transactions = new Dictionary<IPerson, List<IBook>>();
        }

        public void addBook(String isbn, String author, String title, BookCategory category, Int32 count)
        {
            if (!this.books.ContainsKey(isbn))
            {
                this.addBook(new Book(isbn, author, title, category, count));
            }
            else
            {
                throw new BookAlreadyExistsException("The ISBN number is already exists (" + isbn + ").");
            }
        }

        private void addBook( IBook book )
        {
            this.books.Add(book.ISBN, book);
        }

        private void enrollment(IPerson person)
        {
            this.people.Add(person.ID, person);
        }

        public void enrollment(Int32 id, String name, DateTime enrollmentDate)
        {
            if (!this.people.ContainsKey(id))
            {
                this.enrollment(new Person(id, name, enrollmentDate));
            }
            else
            {
                if (this.people[id].Name.Equals(name))
                {
                    try
                    {
                        this.people[id].regenerateEnrollment(enrollmentDate);
                    }
                    catch (EnrollmentDateException e)
                    {
                        throw new EnrollmentException(e.Message, e);
                    }
                }
                else
                {
                    throw new EnrollmentException("This ID is belongs to that person: " + this.people[id]);
                }
            }
        }

        public void borrow(Int32 id, String isbn)
        {
            this.checkArguments(id, isbn);
            try
            {
                this.addTransaction(this.people[id], this.books[isbn]);
            }
            catch (NotEnoughBookException e)
            {
                throw new BorrowException(e.Message, e);
            }
        }

        private void addTransaction(IPerson person, IBook book)
        {
            if (!this.transactions.ContainsKey(person))
            {
                this.transactions.Add(person, new List<IBook>());
            }
            book.decrementCounter();
            this.transactions[person].Add(book);
        }

        private void checkArguments(Int32 id, String isbn)
        {
            if (!this.people.ContainsKey(id))
            {
                throw new BorrowException("The person ID (" + id + ") is not valid.");
            }
            if (!this.books.ContainsKey(isbn))
            {
                throw new BorrowException("The ISBN number (" + isbn + ") is not valid.");
            }
        }

        public void bringBack(Int32 id, String isbn)
        {
            this.checkArguments(id, isbn);
            this.removeTransaction(this.people[id], this.books[isbn]);
        }

        private void removeTransaction(IPerson person, IBook book)
        {
            if (!this.transactions.ContainsKey(person))
            {
                throw new BorrowException("This person (" + person.ID + ") doesn't borrow any book.");
            }
            else
            {
                if (this.transactions[person].Contains(book))
                {
                    book.incrementCounter();
                    this.transactions[person].Remove(book);
                }
                else
                {
                    throw new BorrowException("This person (" + person.ID + ") doesn't borrow this book (" + book.ISBN + ").");
                }
            }
        }

        public override string ToString()
        {
            StringBuilder info = new StringBuilder(100);
            info.AppendLine(">>> Library - books <<<");
            foreach (IBook book in this.books.Values)
            {
                info.AppendLine(book.ToString());
            }
            info.AppendLine(">>> Library - people <<<");
            foreach (IPerson person in this.people.Values)
            {
                info.AppendLine(person.ToString());
            }
            info.AppendLine(">>> Library - transactions <<<");
            foreach (KeyValuePair<IPerson, List<IBook>> transaction in this.transactions)
            {
                info.AppendLine(">>> " + transaction.Key + " transactions: ");
                if (transaction.Value != null)
                {
                    foreach (IBook book in transaction.Value)
                    {
                        info.AppendLine(book.ToString());
                    }
                }
            }
            return info.ToString();
        }

    }
}
