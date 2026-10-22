public class Book
{
    public int ID { get; set; }
    public string Title { get; set; } = null!;

    public List<Loan> Loans { get; set; } = new();
}