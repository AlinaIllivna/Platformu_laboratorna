using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryMvcApp.Data;
using LibraryRazorApp.Models;

namespace LibraryRazorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly LibraryContext _context;

        public LoansController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Loan>>> GetLoans()
        {
            var loans = await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Reader)
                .AsNoTracking()
                .Select(l => new Loan
                {
                    ID = l.ID,
                    BookID = l.BookID,
                    ReaderID = l.ReaderID,
                    IssueDate = l.IssueDate,
                    ReturnDate = l.ReturnDate,
                    Book = l.Book != null ? new Book { ID = l.Book.ID, Title = l.Book.Title, Author = l.Book.Author, Year = l.Book.Year } : null,
                    Reader = l.Reader != null ? new Reader { ID = l.Reader.ID, FullName = l.Reader.FullName, TicketNumber = l.Reader.TicketNumber } : null
                })
                .ToListAsync();

            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Loan>> GetLoan(int id)
        {
            var loan = await _context.Loans
                .Include(l => l.Book)
                .Include(l => l.Reader)
                .FirstOrDefaultAsync(l => l.ID == id);

            if (loan == null) return NotFound();
            return Ok(loan);
        }

        [HttpPost]
        public async Task<ActionResult<Loan>> PostLoan(Loan loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLoan), new { id = loan.ID }, loan);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(int id, Loan loan)
        {
            if (id != loan.ID) return BadRequest();
            _context.Entry(loan).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            var loan = await _context.Loans.FindAsync(id);
            if (loan == null) return NotFound();
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}