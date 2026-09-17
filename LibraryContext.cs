using Microsoft.EntityFrameworkCore;
using System;
public class LibraryContext : DbContext
{
    public DbSet<Reader> Readers { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Loan> Loans { get; set; } = null!;


  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    var connectionString = "Server=localhost;Database=library_db;Uid=root;Pw=;";
    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
}
    
}