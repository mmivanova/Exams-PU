using System;
using System.Collections.Generic;
using System.Linq;

namespace _8_July_2012
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = ValidateIntArgument(0, 2000, "Enter the number of books: ");

            List<Book> books = new List<Book>();

            Input(number, books);

            List<Book> sortedListByTitle = SortByTitle(books);
            Output(sortedListByTitle);

            List<Book> publisherInquiry = PublisherInquiry(books);
            Output(publisherInquiry);

            List<Book> inquiry = Inquiry(books);
            Output(inquiry);
        }

        private static void Input(int number, List<Book> books)
        {
            for (int i = 0; i < number; i++)
            {
                string title = ValidateArgument(0, 40, "Title: ");
                string author = ValidateArgument(0, 40, "Author: ");
                string publisher = ValidateArgument(0, 20, "Publisher: ");
                int year = ValidateIntArgument(1899, 2012, "Year of publication: ");
                double price = ValidateDoubleArgument(0, "Price: ") ;
                int numberOfBooks = ValidateIntArgument(0, "Number of books: ");

                Book book = new Book(title, author, publisher, year, price, numberOfBooks);
                books.Add(book);
            }
        }

        public static int ValidateIntArgument(int from, int to, string text)
        {
            int number;
            do
            {
                Console.Write(text);
                number = int.Parse(Console.ReadLine());
            } while (number <= from || number > to);

            return number;
        }

        public static int ValidateIntArgument(int from, string text)
        {
            int number;
            do
            {
                Console.Write(text);
                number = int.Parse(Console.ReadLine());
            } while (number <= from);

            return number;
        }

        public static double ValidateDoubleArgument(int from, string text)
        {
            double number;
            do
            {
                Console.Write(text);
                number = double.Parse(Console.ReadLine());
            } while (number <= from);

            return number;
        }

        public static string ValidateArgument(int from, int to, string text)
        {
            string argument;
            do
            {
                Console.Write(text);
                argument = Console.ReadLine();
            } while (argument.Length <= from || argument.Length > to);

            return argument;
        }

        private static void Output(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        public static List<Book> SortByTitle(List<Book> books)
        {
            Book temp;

            for (int i = 0; i < books.Count - 1; i++)
            {
                for (int j = 0; j < books.Count-1-i; j++)
                {
                    if (books[j].Title.CompareTo(books[j+1].Title) > 0)
                    {
                        temp = books[j];
                        books[j] = books[j + 1];
                        books[j + 1] = temp;
                    }
                }
            }
            return books;
        }

        public static List<Book> SortByAuthor(List<Book> books)
        {
            Book temp;

            for (int i = 0; i < books.Count-1; i++)
            {
                for (int j = 0; j < books.Count-1-i; j++)
                {
                    if (books[j].Author.CompareTo(books[j+1].Author) > 0 || (
                        books[j].Author.CompareTo(books[j + 1].Author) == 0 &&
                        books[j].Price.CompareTo(books[j + 1].Price) < 0))
                    {
                        temp = books[j];
                        books[j] = books[j + 1];
                        books[j + 1] = temp;
                    }
                }
            }
            return books;
        }

        public static double GetAverageNumberOfBooks(List<Book> books)
        {
            int totalNumber = 0;
            int count = 0;
            foreach (var book in books)
            {
                totalNumber += book.NumberOfBooks;
                count++;
            }

            double averageNumber = totalNumber / count;
            return averageNumber;
        }

        public static List<Book> PublisherInquiry(List<Book> books)
        {
            string publisher;
            do
            {
                Console.Write("Pubisher: ");
                publisher = Console.ReadLine();
            } while (publisher.Length <= 0 || publisher.Length > 20);

            List<Book> booksByPublisher
                = new List<Book>();

            foreach (var book in books.Where(p => p.Publisher.Equals(publisher)))
            {
                booksByPublisher.Add(book);
            }

            return SortByAuthor(booksByPublisher);
        }

        public static List<Book> Inquiry(List<Book> books)
        {
            List<Book> inquiry = new List<Book>();

            foreach (var book in books)
            {
                if (book.YearOfRelease % 5 == 0 && book.NumberOfBooks > GetAverageNumberOfBooks(books))
                {
                    inquiry.Add(book);
                }
            }

            return inquiry;
        }
    }
}
