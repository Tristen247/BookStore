using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class BookStoreBasicFunctions
    {

        // Return all books
        public static List<Book> GetAllBooks()
        {
            using (var dbContext = new Se407BookstoreContext())
            {
                return dbContext.Books.ToList();
            }
        }

        // Return book by title
        public static List<Book> GetBookByTitle(string title)
        {
            using (var dbContext = new Se407BookstoreContext())
            {
                return dbContext.Books
                    .Where(b => b.BookTitle == title)
                    .ToList();
            }
        }

        //Get by author last
        public static List<Book> GetBookByAuthorLastName(string authorLastName)
        {
            using (var dbContext = new Se407BookstoreContext())
            {
                return dbContext.Books
                    .Where(b => b.Author.AuthorLast == authorLastName)
                    .ToList();
            }
        }

    }
}
