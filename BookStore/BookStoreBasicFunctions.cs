using BookStore.Models;
using Microsoft.EntityFrameworkCore;
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

        public static List<Book> GetAllBooksFull()
        {
            {
                using (var dbContext = new Se407BookstoreContext())
                {
                    var books = dbContext.Books
                        .Include(books => books.Author)
                        .Include(books => books.Genre)
                        .ToList();

                    return books;
                }
            }
        }

        public static Book GetFullBookById(int id)
        {
            {
                using (var dbContext = new Se407BookstoreContext())
                {
                    var books = dbContext.Books
                        .Include(b => b.Author)
                        .Include(b => b.Genre)
                        .Where(b => b.BookId == id)
                        .FirstOrDefault();

                    return books;
                }
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

        public static List<Genre> GetAllGenres()
        {
            using (var db = new Se407BookstoreContext())
            {
                return db.Genres.ToList();
            }
        }
    }
}