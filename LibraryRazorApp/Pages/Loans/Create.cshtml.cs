using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryRazorApp.Models;

namespace LibraryRazorApp.Pages_Loans
{
    public class CreateModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public CreateModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [BindProperty]
        public Loan Loan { get; set; } = new Loan { IssueDate = System.DateTime.Now };

        public SelectList ReadersList { get; set; } = default!;
        public SelectList BooksList { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            await PopulateSelectListsAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await PopulateSelectListsAsync();
                return Page();
            }

            var client = _clientFactory.CreateClient("LibraryApi");
            var response = await client.PostAsJsonAsync("api/loans", Loan);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }

            await PopulateSelectListsAsync();
            return Page();
        }

        private async Task PopulateSelectListsAsync()
        {
            var client = _clientFactory.CreateClient("LibraryApi");
            var readers = await client.GetFromJsonAsync<List<Reader>>("api/readers") ?? new List<Reader>();
            var books = await client.GetFromJsonAsync<List<Book>>("api/books") ?? new List<Book>();

            ReadersList = new SelectList(readers, "ID", "FullName");
            BooksList = new SelectList(books, "ID", "Title");
        }
    }
}