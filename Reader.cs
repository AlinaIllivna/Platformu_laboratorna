public class Reader
{
    public int ID { get; set; }
    public string TicketNumber { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Phone { get; set; } = null!;

    public List<Loan> Loans { get; set; } = new();
}