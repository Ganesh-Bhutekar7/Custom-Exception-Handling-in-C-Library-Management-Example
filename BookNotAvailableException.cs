using System;
using System.Collections.Generic;

//================ Custom Exception in C# ====================
public class BookNotAvailableException : Exception
{
    public BookNotAvailableException() { }

    public BookNotAvailableException(string message) : base(message) { }

    public BookNotAvailableException(string message, Exception inner) : base(message, inner) { }
}

//================ Library Class ====================
class Library
{
    private Dictionary<string, int> books = new Dictionary<string, int>();

    public Library()
    {
        // Initialize library stock
        books.Add("C# Programming", 10);
        books.Add("Data Structures", 13);
        books.Add(".NET Core", 16);
        books.Add(".NET Framework", 0);
    }

    // Borrow book method
    public void BorrowBook(string bookName)
    {
        if (!books.ContainsKey(bookName) || books[bookName] <= 0)
        {
            throw new BookNotAvailableException($"The book '{bookName}' is not available.");
        }

        books[bookName]--;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✔ Successfully borrowed '{bookName}'. Remaining copies: {books[bookName]}");
        Console.ResetColor();
    }

    // Display current stock
    public void DisplayStock()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n--- Current Library Stock ---");
        foreach (var book in books)
        {
            Console.WriteLine($"{book.Key} : {book.Value} copies");
        }
        Console.WriteLine("-----------------------------\n");
        Console.ResetColor();
    }
}

//================ Main Program ====================
class Program
{
    static void Main()
    {
        Library library = new Library();
        library.DisplayStock();

        // List of books to borrow
        string[] borrowRequests = { "asp", "C# Programming", ".NET Framework", "Data Structures" };

        foreach (var book in borrowRequests)
        {
            try
            {
                library.BorrowBook(book);
            }
            catch (BookNotAvailableException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"✖ Custom Exception Caught: {ex.Message}");
                Console.ResetColor();
            }
        }

        library.DisplayStock();
    }
}
