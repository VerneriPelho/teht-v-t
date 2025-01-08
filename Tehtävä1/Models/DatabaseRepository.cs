public List<Book> GetRecentBooks(int years)
{
    using var connection = new SqlConnection(_connectionString);
    connection.Open();

    using var command = new SqlCommand($"SELECT * FROM Book WHERE PublicationYear >= {DateTime.Now.Year - years}", connection);
    using var reader = command.ExecuteReader();

    List<Book> books = new();
    while (reader.Read())
    {
        books.Add(new Book
        {
            BookId = (int)reader["BookId"],
            Title = reader["Title"].ToString(),
            ISBN = reader["ISBN"].ToString(),
            PublicationYear = (int)reader["PublicationYear"],
            AvailableCopies = (int)reader["AvailableCopies"]
        });
    }

    return books;
}
