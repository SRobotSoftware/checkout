using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkout
{
    class Program
    {
        static void Main(string[] args)
        {
            var PublicLibrary = new Library();
            var book1 = new Book
            {
                Title = "HeadFirst with C#",
                Author = "Dr. Suess"
            };
            var book2 = new Book
            {
                Title = "Mastering the Console App",
                Author = "Dr. Suess"
            };
            var book3 = new Book
            {
                Title = "C# Game Programming: For Serious Game Creation",
                Author = "Dr. Suess"
            };
            var book4 = new Book
            {
                Title = "Pro C# 5.0 and the .NET 4.5 Framework",
                Author = "Dr. Suess"
            };
            PublicLibrary.Books.Add(book1);
            PublicLibrary.Books.Add(book2);
            PublicLibrary.Books.Add(book3);
            PublicLibrary.Books.Add(book4);
            while (Menu(PublicLibrary))
            {
                //Environment.Exit(0);
            }
            
        }
        public static bool Menu(Library lib)
        {
            
            var IsChecked = false;
            for (var i = 0; i < lib.Books.Count; i++) {
                if(lib.Books[i].CheckedOut)
                {
                    IsChecked = true;
                }
            }
            if (IsChecked)
            {
                Console.WriteLine("Do you want to Return your current book or view available books?");
                Console.WriteLine("1) Return");
                Console.WriteLine("2) View Available Books");
                Console.WriteLine("3) To Quit Program");
                var MenuSelection = Console.ReadLine();
                if (int.Parse(MenuSelection) == 1)
                {
                    lib.ReturnBook();
                }
                else if (int.Parse(MenuSelection) == 2)
                {
                    lib.ListAvailable();
                } else
                {
                    return false;
                }
            } else
            {
                lib.ListAvailable();
                Console.Write("Please Select a Book: ");
                var selection = Console.ReadLine();
                var OurSelection = lib.SelectBook(selection);
                Console.WriteLine("You've checked out: " + OurSelection.Title + "By: " + OurSelection.Author);
            }
            return true;
        }
    }
}
