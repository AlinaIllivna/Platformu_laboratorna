using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryRazorApp.Models;

namespace LibraryRazorApp.Pages_Readers
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public IList<Reader> Reader { get; set; } = new List<Reader>();

        public async Task OnGetAsync()
        {
            var client = _clientFactory.CreateClient("LibraryApi");
            var response = await client.GetAsync("api/readers");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<Reader>>();
                if (result != null)
                {
                    Reader = result;
                }
            }
        }
    }
}