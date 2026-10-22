using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryRazorApp.Models;

namespace LibraryRazorApp.Pages_Readers
{
    public class DetailsModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public DetailsModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public Reader Reader { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var client = _clientFactory.CreateClient("LibraryApi");
            var reader = await client.GetFromJsonAsync<Reader>($"api/readers/{id}");

            if (reader == null) return NotFound();

            Reader = reader;
            return Page();
        }
    }
}