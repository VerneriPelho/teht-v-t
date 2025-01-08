using System;

class Program
{
    static void Main(string[] args)
    {
        var repository = new DatabaseRepository("Server=(localdb)\\MSSQLLocalDB;Database=MyLibrary;Trusted_Connection=True;");
        Console.WriteLine(repository.TestConnection());
    }
}
