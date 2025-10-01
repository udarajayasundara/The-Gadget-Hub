using System.Net.Http;
using System.Net.Http.Json;
using TheGadgetHub.DTO;

namespace TheGadgetHub.Services
{
    public class DistrubutorsComparing
    {
        private readonly HttpClient _httpClient;

        public DistrubutorsComparing(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DistributorProductDTO?> CompareDistributors(int techId, int gadgetId, int electroId)
        {
            var techWorldTask = _httpClient.GetFromJsonAsync<ProductDTO>($"https://localhost:7280/api/Product/{techId}");
            var gadgetCentralTask = _httpClient.GetFromJsonAsync<ProductDTO>($"https://localhost:7128/api/Product/{gadgetId}");
            var electroComTask = _httpClient.GetFromJsonAsync<ProductDTO>($"https://localhost:7182/api/Product/{electroId}");

            await Task.WhenAll(techWorldTask, gadgetCentralTask, electroComTask);

            var techProduct = techWorldTask.Result != null ? new DistributorProductDTO
            {
                Product = techWorldTask.Result,
                DistributorBaseUrl = "https://localhost:7280"
            } : null;

            var gadgetProduct = gadgetCentralTask.Result != null ? new DistributorProductDTO
            {
                Product = gadgetCentralTask.Result,
                DistributorBaseUrl = "https://localhost:7128"
            } : null;

            var electroProduct = electroComTask.Result != null ? new DistributorProductDTO
            {
                Product = electroComTask.Result,
                DistributorBaseUrl = "https://localhost:7182"
            } : null;

            var results = new List<DistributorProductDTO?> { techProduct, gadgetProduct, electroProduct };

            var availableProducts = results.Where(p => p != null && p.Product.Stock > 0).ToList();

            if (!availableProducts.Any())
            {
                return null;
            }

            var bestProduct = availableProducts.OrderBy(p => p.Product.Price).ThenBy(p => p.Product.DeliverTime).First();

            return bestProduct;
        }
    }
}