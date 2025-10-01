using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using TheGadgetHub_Web.Models;
using System.Net.Http.Headers;

namespace TheGadgetHub_Web.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly HttpClient _client;

        public ProductsModel(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
        }

        public List<Product> Products { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            string url = "https://localhost:7280/api/Product";
            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                Products = await response.Content.ReadFromJsonAsync<List<Product>>() ?? new List<Product>();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostOrderAsync(int productId)
        {
            var token = HttpContext.Session.GetString("JwtToken");
            if (string.IsNullOrEmpty(token))
            {
                TempData["fail"] = "Please log in to place an order.";
                return RedirectToPage();
            }

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var orderRequest = new { GlobalProductId = productId };
            string orderUrl = "https://localhost:7239/api/GlobalProductCatlog/order";
            var content = new StringContent(JsonSerializer.Serialize(orderRequest), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(orderUrl, content);

            if (response.IsSuccessStatusCode)
            {
                TempData["success"] = "Successfully ordered the product!";
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                TempData["fail"] = $"Failed to order product. Status: {response.StatusCode}. Details: {errorContent}";
            }

            return RedirectToPage();
        }
    }
}