using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Net.Http;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WebApplication3.Pages
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;

        public Index(ILogger<Index> logger)
        {
            _logger = logger;
        }
        public List<Brewery>? DataResult { get; set; }

        public async Task<IActionResult> OnGet()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://api.openbrewerydb.org/breweries");

            if (response.IsSuccessStatusCode)
            {
                string? content = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(content))
                {
                    DataResult = JsonConvert.DeserializeObject<List<Brewery>>(content);
                }
            }
            return Page();
        }
    }

    public class Brewery
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string BreweryType { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Phone { get; set; }
        public string WebsiteUrl { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
    }
}
    
