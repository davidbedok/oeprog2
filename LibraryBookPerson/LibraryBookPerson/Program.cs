using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryBookPerson
{
    public class Program
    {

        // 1 point
        private static void testBook()
        {
            Console.WriteLine("########################## Test Book");
            IBook book = new Book("978-0450011849", "Frank Herbert", "Dune", BookCategory.SCIENCE_FICTION, 5);
            Console.WriteLine(book);
            // output: Frank Herbert: Dune [978-0450011849] SCIENCE_FICTION (available: 5)
        }

        // 2 point
        private static void testLibrary()
        {
            Console.WriteLine("\n\n########################## Test Library");
            ILibrary library = Program.createLibrary();
            try
            {
                library.addBook("978-0450011849", "Noname Author", "Exception", BookCategory.SCHOOL_BOOK, 5);
            } catch (BookAlreadyExistsException e) {
                Console.WriteLine(e.Message);
                // output: The ISBN number is already exists (978-0450011849).
            }
            Console.WriteLine(library);
        }

        private static ILibrary createLibrary()
        {
            ILibrary library = new Library();
            library.addBook("978-0450011849", "Frank Herbert", "Dune", BookCategory.SCIENCE_FICTION, 3);
            library.addBook("978-0441104024", "Frank Herbert", "Children of Dune", BookCategory.SCIENCE_FICTION, 1);
            return library;
        }

        // 1 point
        public static void testPerson()
        {
            Console.WriteLine("\n\n########################## Test Person");
            IPerson person = new Person(42, "Teszt Elek", new DateTime(2012, 2, 20));
            Console.WriteLine(person);
            // output: Teszt Elek [42] 2012.02.20. 0:00:00
        }

        // 3 point
        public static void testEnrollment()
        {
            Console.WriteLine("\n\n########################## Test Enrollment");
            ILibrary library = Program.createLibrary();
            library.enrollment(42, "Teszt Elek", new DateTime(2012, 2, 20));
            library.enrollment(30, "Nemecsek Erno", new DateTime(2011, 10, 7));
            Console.WriteLine(library);
            library.enrollment(42, "Teszt Elek", new DateTime(2012, 3, 20));
            Console.WriteLine(library);
            try
            {
                library.enrollment(42, "Teszt Elek", new DateTime(2012, 1, 20));
            }
            catch (EnrollmentException e)
            {
                Console.WriteLine(e.Message);
                // output: The new enrollment date (2012.01.20. 0:00:00) is former than the original enrollment date (2012.03.20. 0:00:00).
            }
            try
            {
                library.enrollment(30, "Noname", new DateTime(2010, 1, 1));
            }
            catch (EnrollmentException e)
            {
                Console.WriteLine(e.Message);
                // output: This ID is belongs to that person: Nemecsek Erno [30] 2011.10.07. 0:00:00
            }
        }

        // 4 point
        private static void testBorrow()
        {
            Console.WriteLine("\n\n########################## Test Borrow");
            ILibrary library = Program.createFullLibrary();
            Console.WriteLine(library);
            library.borrow(42, "978-0441104024");
            Console.WriteLine(library);
            try
            {
                library.borrow(30, "978-0441104024");
            }
            catch (BorrowException e)
            {
                Console.WriteLine(e.Message);
                // output: Book is not available.
            }
            try
            {
                library.borrow(10, "978-0450011849");
            }
            catch (BorrowException e)
            {
                Console.WriteLine(e.Message);
                // output: The person ID (10) is not valid.
            }
            try
            {
                library.borrow(30, "978-xxx");
            }
            catch (BorrowException e)
            {
                Console.WriteLine(e.Message);
                // output: The ISBN number (978-xxx) is not valid.
            }
        }

        private static ILibrary createFullLibrary()
        {
            ILibrary library = new Library();
            library.addBook("978-0450011849", "Frank Herbert", "Dune", BookCategory.SCIENCE_FICTION, 2);
            library.addBook("978-0441104024", "Frank Herbert", "Children of Dune", BookCategory.SCIENCE_FICTION, 1);
            library.enrollment(42, "Teszt Elek", new DateTime(2012, 2, 20));
            library.enrollment(30, "Nemecsek Erno", new DateTime(2011, 10, 7));
            return library;
        }

        // 2 point
        private static void testBringBack() 
        {
            Console.WriteLine("\n\n########################## Test Bring Back");
            ILibrary library = Program.createFullLibrary();
            library.borrow(42, "978-0441104024");
            Console.WriteLine(library);
            library.bringBack(42, "978-0441104024");
            Console.WriteLine(library);
            try
            {
                library.bringBack(30, "978-0441104024");
            }
            catch (BorrowException e)
            {
                Console.WriteLine(e.Message);
                // This person (30) doesn't borrow any book.
            }
            try
            {
                library.bringBack(10, "978-0450011849");
            }
            catch (BorrowException e)
            {
                Console.WriteLine(e.Message);
                // output: The person ID (10) is not valid.
            }
            try
            {
                library.bringBack(30, "978-xxx");
            }
            catch (BorrowException e)
            {
                Console.WriteLine(e.Message);
                // output: The ISBN number (978-xxx) is not valid.
            }
            try
            {
                library.bringBack(42, "978-0441104024");
            }
            catch (BorrowException e)
            {
                Console.WriteLine(e.Message);
                // output: This person (42) doesn't borrow this book (978-0441104024).
            }
        }

        private static void Main(string[] args)
        {
            Program.testBook();
            Program.testLibrary();
            Program.testPerson();
            Program.testEnrollment();
            Program.testBorrow();
            Program.testBringBack();
        }
    }
}
