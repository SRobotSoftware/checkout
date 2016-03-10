using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    public class Library
    {
        public List<Book> Books = new List<Book>();
        public Library()
        {

        }
        public void Checkout(Book MyBook)
        {
            MyBook.CheckedOut = true;
            MyBook.Duration = DateTime.Now;
        }

        public Book SelectBook(string str)
        {
            var OurSelection = Books[int.Parse(str) - 1];
            Checkout(OurSelection);
            return OurSelection;
        }

        public void ReturnBook()
        {
            foreach (var book in Books)
            {
                if (book.CheckedOut)
                {
                    book.CheckedOut = false;
                    var BookOut = book.Duration;
                    var BookIn = DateTime.Now;
                    //TimeSpan Result = BookIn - BookOut;
                    Console.WriteLine(book.Title + " was checked out for: " + (BookOut - BookIn).ToString(@"hh\:mm\:ss"));
                    Console.WriteLine("Press any key to Continue");
                    Console.ReadKey();
                }
                
            }
        }

        public void ListAvailable()
        {
            Console.Clear();
            for (var i = 0; i < Books.Count; i++)
            {
                if (!Books[i].CheckedOut)
                {
                    Console.WriteLine($"{i + 1}) {Books[i].Title}");
                }
            }
        }
    }
}
