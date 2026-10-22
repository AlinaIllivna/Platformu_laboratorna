using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryRazorApp.Models;

namespace LibraryRazorApp.Pages_Loans
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IList<Loan> Loan { get; set; } = new List<Loan>();

        public async Task OnGetAsync()
        {
            var client = _clientFactory.CreateClient("LibraryApi");
            var result = await client.GetFromJsonAsync<List<Loan>>("api/loans");
            if (result != null)
            {
                Loan = result;
            }
        }
    }
}