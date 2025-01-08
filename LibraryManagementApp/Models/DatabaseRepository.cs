public List<Book> GetRecentBooks()
{
    List<Book> books = new();
    using var connection = new SqlConnection(_connectionString);
    connection.Open();

    using var command = new SqlCommand("SELECT * FROM Book WHERE PublicationYear >= @year", connection);
    command.Parameters.AddWithValue("@year", DateTime.Now.Year - 5);
    using var reader = command.ExecuteReader();

    while (reader.Read())
    {
        books.Add(new Book
        {
            BookId = Convert.ToInt32(reader["BookId"]),
            Title = reader["Title"].ToString(),
            ISBN = reader["ISBN"].ToString(),
            PublicationYear = Convert.ToInt32(reader["PublicationYear"]),
            AvailableCopies = Convert.ToInt32(reader["AvailableCopies"])
        });
    }
    return books;
}
