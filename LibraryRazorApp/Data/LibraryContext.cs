using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using LibraryRazorApp.Models; // Додайте цей рядок

namespace LibraryMvcApp.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Reader> Readers { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Loan> Loans { get; set; } = null!;
    }

    public class LibraryContextFactory : IDesignTimeDbContextFactory<LibraryContext>
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            
            var connectionString = "Server=localhost;Database=library_db;User=root;Password=;";

            // Для MySql.EntityFrameworkCore використовується UseMySQL без вказування версії сервера
            optionsBuilder.UseMySQL(connectionString);

            return new LibraryContext(optionsBuilder.Options);
        }
    }
}