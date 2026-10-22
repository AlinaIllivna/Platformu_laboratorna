using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryMvcApp.Data;
using LibraryRazorApp.Models;

namespace LibraryRazorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerBase
    {
        private readonly LibraryContext _context;

        public ReadersController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/readers
        [HttpGet]
        public async Task<IActionResult> GetReaders()
        {
            try
            {
                var readers = await _context.Readers
                    .AsNoTracking()
                    .Select(r => new Reader
                    {
                        ID = r.ID,
                        TicketNumber = r.TicketNumber ?? "",
                        FullName = r.FullName ?? "",
                        Email = r.Email ?? "",
                        Address = r.Address ?? "",
                        Phone = r.Phone ?? ""
                    })
                    .ToListAsync();

                return Ok(readers);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Помилка БД: {ex.InnerException?.Message ?? ex.Message}");
            }
        }

        // GET: api/readers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reader>> GetReader(int id)
        {
            var reader = await _context.Readers.FindAsync(id);
            if (reader == null) return NotFound();

            return Ok(new Reader
            {
                ID = reader.ID,
                TicketNumber = reader.TicketNumber ?? "",
                FullName = reader.FullName ?? "",
                Email = reader.Email ?? "",
                Address = reader.Address ?? "",
                Phone = reader.Phone ?? ""
            });
        }

        // POST: api/readers
        [HttpPost]
        public async Task<ActionResult<Reader>> PostReader([FromBody] Reader reader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Readers.Add(reader);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReader), new { id = reader.ID }, reader);
        }

        // PUT: api/readers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReader(int id, [FromBody] Reader reader)
        {
            if (id != reader.ID) return BadRequest();

            _context.Entry(reader).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/readers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReader(int id)
        {
            var reader = await _context.Readers.FindAsync(id);
            if (reader == null) return NotFound();

            _context.Readers.Remove(reader);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}