using System;
using System.Collections.Generic;
using BookStore;
using BookStoreConsole;
using BookStore.Models;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2) // 2 args required
        {
            Console.WriteLine("Usage:BookStoreConsole.exe <OutputType> <MethodName> [Parameter]");
            return;
        }

        string outputType = args[0]; // "Console" or "CSV"
        string methodName = args[1]; // Ex. GetMovieByTitle
        string parameter = args.Length > 2 ? args[2] : null; //optional

        OutputHelper oh = new OutputHelper();
        List<Book> result = new List<Book>();

        using (var db = new Se407BookstoreContext())
        {
            switch(methodName)
            {
                case "GetBookByTitle":
                    if(string.IsNullOrEmpty(parameter))
                    {
                        Console.WriteLine("Error: missing book title");
                    }
                    var book = db.Books.FirstOrDefault(b => b.BookTitle == parameter);
                    if (book != null) result.Add(book);
                    break;
                case "GetAllBooks":
                    result = db.Books.ToList();
                    break;

                default:
                    Console.WriteLine("Error: Unknown method name.");
                    return;
            }
        }

        if (outputType.Equals("CSV"))
        {
            oh.WriteToCSV(result);
            oh.WriteToConsole("Output written to: file.csv");
        }
        else if (outputType.Equals("Console"))
        {
            oh.WriteToConsole(result);
        }
        else
        {
            Console.WriteLine("Error: Invalid output type. Please type 'CSV' or 'Console.'");
        }
    }
}





