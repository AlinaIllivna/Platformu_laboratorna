namespace LibraryBlazorApp.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; } = null!;
        public string? Author { get; set; }
        public int? Year { get; set; }

        public List<Loan> Loans { get; set; } = new();
    }
}
