using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class LibraryContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Loan> Loans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("\"Server=(localdb)\\\\MSSQLLocalDB;Database=MyLibrary;Trusted_Connection=True;\"\r\n");
    }
}
