using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryRazorApp.Models;

namespace LibraryRazorApp.Pages_Books
{
    public class DetailsModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public DetailsModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = _clientFactory.CreateClient("LibraryApi");
            var book = await client.GetFromJsonAsync<Book>($"api/books/{id}");

            if (book == null)
            {
                return NotFound();
            }

            Book = book;
            return Page();
        }
    }
}