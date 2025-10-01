using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Net.Http.Json;
using TheGadgetHub.Data;
using TheGadgetHub.DTO;
using TheGadgetHub.Services;

namespace TheGadgetHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalProductCatlogController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly GlobalProductCatlogRepo repo;
        private readonly DistrubutorsComparing distributorsComparing;
        private readonly HttpClient _httpClient;

        public GlobalProductCatlogController(IMapper _mapper, GlobalProductCatlogRepo _repo, DistrubutorsComparing _comparing, HttpClient httpClient)
        {
            mapper = _mapper;
            repo = _repo;
            distributorsComparing = _comparing;
            _httpClient = httpClient;
        }

        [Authorize]
        [HttpPost("order")]
        public async Task<IActionResult> PlaceOrder([FromBody] CompareRequestDTO request)
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var name = User.FindFirst(ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(name))
            {
                return Unauthorized("Invalid token claims.");
            }

            var globalProduct = await repo.Compare(request.GlobalProductId);

            if (globalProduct == null)
            {
                return NotFound("Global Product ID not found.");
            }

            int techId = globalProduct.TechWorldProductId;
            int gadgetId = globalProduct.GadgetCentralProductId;
            int electroId = globalProduct.ElectroComProductId;

            var bestProduct = await distributorsComparing.CompareDistributors(techId, gadgetId, electroId);

            if (bestProduct == null)
            {
                return NotFound("No distributors have stock for this product.");
            }

            var customerDto = new CustomerWriteDTO
            {
                Name = name,
                Email = email
            };

            var orderDto = new OrderWriteDTO
            {
                Date = DateTime.UtcNow,
                Discount = 0,
                Total = bestProduct.Product.Price, // Using price as total (assuming quantity 1); adjust if needed
                CustomerEmail = email,
                ProductIds = new List<int> { bestProduct.Product.Id }
            };

            var orderUrl = $"{bestProduct.DistributorBaseUrl}/api/Order";
            var response = await _httpClient.PostAsJsonAsync(orderUrl, orderDto);

            if (response.IsSuccessStatusCode)
            {
                return Ok(new { message = "Order placed successfully." });
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                if (error.Contains("Customer not found"))
                {
                    var customerUrl = $"{bestProduct.DistributorBaseUrl}/api/Customer";
                    var custResponse = await _httpClient.PostAsJsonAsync(customerUrl, customerDto);

                    if (!custResponse.IsSuccessStatusCode)
                    {
                        return BadRequest($"Failed to create customer: {await custResponse.Content.ReadAsStringAsync()}");
                    }

                    // Retry order creation
                    response = await _httpClient.PostAsJsonAsync(orderUrl, orderDto);

                    if (response.IsSuccessStatusCode)
                    {
                        return Ok(new { message = "Order placed successfully after creating customer." });
                    }
                    else
                    {
                        return BadRequest($"Failed to place order after creating customer: {await response.Content.ReadAsStringAsync()}");
                    }
                }
                else
                {
                    return BadRequest(error);
                }
            }
        }
    }
}