using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryRazorApp.Models;

namespace LibraryRazorApp.Pages_Loans
{
    public class DetailsModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public DetailsModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public Loan Loan { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            var client = _clientFactory.CreateClient("LibraryApi");
            var loan = await client.GetFromJsonAsync<Loan>($"api/loans/{id}");

            if (loan == null) return NotFound();

            Loan = loan;
            return Page();
        }
    }
}