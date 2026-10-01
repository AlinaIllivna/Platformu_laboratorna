using Microsoft.EntityFrameworkCore;
using LibraryMvcApp.Models;

namespace LibraryMvcApp.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Reader> Readers { get; set; } = null!;
        public DbSet<Loan> Loans { get; set; } = null!;
    }
}