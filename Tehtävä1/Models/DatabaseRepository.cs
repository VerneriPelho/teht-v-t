using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

public class DatabaseRepository
{
    private string _connectionString;

    public DatabaseRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public string TestConnection()
    {
        using var connection = new SqlConnection(_connectionString);

        try
        {
            connection.Open();
            return "Connection established!";
        }
        catch (SqlException ex)
        {
            return $"SQL Error: {ex.Message}";
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }

    public List<Book> GetBooksPublishedWithinLastFiveYears()
    {
        var books = new List<Book>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT * FROM Book WHERE PublicationYear >= YEAR(GETDATE()) - 5";
        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var book = new Book
            {
                BookId = Convert.ToInt32(reader["BookId"]),
                Title = reader["Title"].ToString(),
                ISBN = reader["ISBN"].ToString(),
                PublicationYear = Convert.ToInt32(reader["PublicationYear"]),
                AvailableCopies = Convert.ToInt32(reader["AvailableCopies"])
            };
            books.Add(book);
        }

        return books;
    }

    public double GetAverageAgeOfMembers()
    {
        double averageAge = 0;

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT AVG(DATEDIFF(YEAR, RegistrationDate, GETDATE())) AS AverageAge FROM Member";
        using var command = new SqlCommand(query, connection);
        var result = command.ExecuteScalar();

        if (result != DBNull.Value)
        {
            averageAge = Convert.ToDouble(result);
        }

        return averageAge;
    }

    public Book GetMostAvailableBook()
    {
        Book book = null;

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT TOP 1 * FROM Book ORDER BY AvailableCopies DESC";
        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            book = new Book
            {
                BookId = Convert.ToInt32(reader["BookId"]),
                Title = reader["Title"].ToString(),
                ISBN = reader["ISBN"].ToString(),
                PublicationYear = Convert.ToInt32(reader["PublicationYear"]),
                AvailableCopies = Convert.ToInt32(reader["AvailableCopies"])
            };
        }

        return book;
    }

    public List<(string MemberName, string ISBN)> GetMembersWithLoans()
    {
        var membersWithLoans = new List<(string, string)>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT DISTINCT m.FirstName, m.LastName, b.ISBN FROM Loan l " +
                       "JOIN Member m ON l.MemberId = m.MemberId " +
                       "JOIN Book b ON l.BookId = b.BookId";
        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var memberName = $"{reader["FirstName"]} {reader["LastName"]}";
            var isbn = reader["ISBN"].ToString();
            membersWithLoans.Add((memberName, isbn));
        }

        return membersWithLoans;
    }

    public List<Book> GetTopThreeMostLoanedBooks()
    {
        var books = new List<Book>();

        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "SELECT TOP 3 b.* FROM Loan l " +
                       "JOIN Book b ON l.BookId = b.BookId " +
                       "GROUP BY b.BookId, b.Title, b.ISBN, b.PublicationYear, b.AvailableCopies " +
                       "ORDER BY COUNT(l.LoanId) DESC";
        using var command = new SqlCommand(query, connection);
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            var book = new Book
            {
                BookId = Convert.ToInt32(reader["BookId"]),
                Title = reader["Title"].ToString(),
                ISBN = reader["ISBN"].ToString(),
                PublicationYear = Convert.ToInt32(reader["PublicationYear"]),
                AvailableCopies = Convert.ToInt32(reader["AvailableCopies"])
            };
            books.Add(book);
        }

        return books;
    }

    public List<Book> GetBooksPublishedWithinLastTenYearsLinq()
    {
        using var context = new LibraryContext();
        var books = context.Books
            .Where(book => book.PublicationYear >= DateTime.Now.Year - 10)
            .ToList();

        return books;
    }

    public (string MemberName, int Age) GetOldestMemberLinq()
    {
        using var context = new LibraryContext();
        var member = context.Members
            .OrderByDescending(m => m.RegistrationDate)
            .FirstOrDefault();
        if (member != null)
        {
            int age = DateTime.Now.Year - member.RegistrationDate.Year;
            return (member.FirstName + " " + member.LastName, age);
        }

        return (string.Empty, 0);
    }

    public Book GetLeastAvailableBookLinq()
    {
        using var context = new LibraryContext();
        var book = context.Books
            .OrderBy(book => book.AvailableCopies)
            .FirstOrDefault();

        return book;
    }

    public List<string> GetMembersWithoutLoansLinq()
    {
        using var context = new LibraryContext();
        var members = context.Members
            .Where(m => !context.Loans.Any(l => l.MemberId == m.MemberId))
            .Select(m => m.FirstName + " " + m.LastName)
            .ToList();

        return members;
    }

    public List<int> GetTopThreeMostLoanedBooksPublicationYearLinq()
    {
        using var context = new LibraryContext();
        var years = context.Loans
            .GroupBy(l => l.Book.PublicationYear)
            .OrderByDescending(g => g.Count())
            .Take(3)
            .Select(g => g.Key)
            .ToList();

        return years;
    }
}
