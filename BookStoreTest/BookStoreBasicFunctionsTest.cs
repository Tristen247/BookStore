using BookStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BookStoreTest
{
    public class BookStoreBasicFunctionsTest
    {
        [Fact]
        public void GetAllBooks()
        {
            var result = BookStoreBasicFunctions.GetAllBooks();
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void GetBookByTitle()
        {
            var result = BookStoreBasicFunctions.GetBookByTitle("Canterbury Tales");
            Assert.True(result.Count == 1);
        }

        [Fact]
        public void GetBookByAuthorLast()
        {
            var result = BookStoreBasicFunctions.GetBookByAuthorLastName("Chaucer");
            Assert.True(result.Count == 2);
        }
    }
}
