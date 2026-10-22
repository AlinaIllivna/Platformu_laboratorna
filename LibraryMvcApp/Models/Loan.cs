public class Loan
{
    public int ID { get; set; }
    public int ReaderID { get; set; }
    public int BookID { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public Reader Reader { get; set; } = null!;
    public Book Book { get; set; } = null!;
}