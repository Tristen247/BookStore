using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using CsvHelper;
using BookStore.Models;

namespace BookStoreConsole
{
    public class OutputHelper
    {
        public void WriteToConsole(List<Book> books)
        {
            foreach (var b in books)
            {
                Console.WriteLine($"Book ID: {b.BookId} Title: {b.BookTitle} Release Year: {b.YearOfRelease}");
            }
        }

        public void WriteToCSV(List<Book> books)
        {
            using (var writer = new StreamWriter(@"..\file.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(books);
            }
        }

        // Overloaded method to accept a string message
        public void WriteToConsole(string message)
        {
            Console.WriteLine(message);
        }
    }
}
