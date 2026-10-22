using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryRazorApp.Models;

namespace LibraryRazorApp.Pages_Loans
{
    public class EditModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public EditModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [BindProperty]
        public Loan Loan { get; set; } = default!;

        public SelectList ReaderList { get; set; } = default!;
        public SelectList BookList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _clientFactory.CreateClient("LibraryApi");
            var loan = await client.GetFromJsonAsync<Loan>($"api/loans/{id}");

            if (loan == null)
            {
                return NotFound();
            }

            Loan = loan;
            await PopulateSelectListsAsync(client);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var client = _clientFactory.CreateClient("LibraryApi");

            if (!ModelState.IsValid)
            {
                await PopulateSelectListsAsync(client);
                return Page();
            }

            var response = await client.PutAsJsonAsync($"api/loans/{Loan.ID}", Loan);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }

            ModelState.AddModelError(string.Empty, "Не вдалося оновити запис видачі.");
            await PopulateSelectListsAsync(client);
            return Page();
        }

        private async Task PopulateSelectListsAsync(HttpClient client)
        {
            var readers = await client.GetFromJsonAsync<List<Reader>>("api/readers") ?? new List<Reader>();
            var books = await client.GetFromJsonAsync<List<Book>>("api/books") ?? new List<Book>();

            ReaderList = new SelectList(readers, "ID", "FullName", Loan?.ReaderID);
            BookList = new SelectList(books, "ID", "Title", Loan?.BookID);
        }
    }
}