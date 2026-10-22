using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryMvcApp.Data;

namespace LibraryRazorApp.Pages_Readers
{
    public class DeleteModel : PageModel
    {
        private readonly LibraryMvcApp.Data.LibraryContext _context;

        public DeleteModel(LibraryMvcApp.Data.LibraryContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reader Reader { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = await _context.Readers.FirstOrDefaultAsync(m => m.ID == id);

            if (reader is not null)
            {
                Reader = reader;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = await _context.Readers.FindAsync(id);
            if (reader != null)
            {
                Reader = reader;
                _context.Readers.Remove(Reader);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
