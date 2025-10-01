using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechWorld.Data;
using TechWorld.DTO;
using TechWorld.Models;

namespace TechWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly OrderRepo _repo;

        public OrderController(IMapper mapper, OrderRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost]
        public ActionResult CreateOrder(OrderWriteDTO writeDTO)
        {
            // Step 1: Get customer by email
            var customer = _repo.GetCustomerByEmail(writeDTO.CustomerEmail);
            if (customer == null)
                return BadRequest("Customer not found with provided email.");

            // Step 2: Validate products
            var products = _repo.GetProductsByIds(writeDTO.ProductIds);
            if (products.Count != writeDTO.ProductIds.Count)
                return BadRequest("One or more product IDs are invalid.");

            // Step 3: Create and save order
            var order = new Order
            {
                Date = writeDTO.Date,
                Discount = writeDTO.Discount,
                Total = writeDTO.Total,
                CustomerId = customer.Id,
                Products = products
            };

            if (_repo.Create(order))
            {
                // Optional: Return order DTO or simple message
                return CreatedAtAction(nameof(GetOrderById), new { id = order.Id }, "Order created.");
            }

            return BadRequest("Failed to create order.");
        }

        [HttpGet("{id}")]
        public ActionResult<OrderReadDTO> GetOrderById(int id)
        {
            var order = _repo.GetOrderById(id);
            if (order == null) return NotFound();

            var dto = _mapper.Map<OrderReadDTO>(order);
            return Ok(dto);
        }

    }
}