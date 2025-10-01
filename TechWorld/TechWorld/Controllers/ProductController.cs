using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechWorld.Data;
using TechWorld.DTO;
using TechWorld.Models;

namespace TechWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMapper mapper;
        private ProductRepo repo;

        public ProductController(IMapper _mapper, ProductRepo _repo)
        {
            mapper = _mapper;
            repo = _repo;
        }
        [HttpGet("{id}")]
        public ActionResult GetProductByID(int id)
        {
            var product = repo.GetProduct(id);
            if (product != null)
                return Ok(mapper.Map<ProductReadDTO>(product));
            return BadRequest();
        }
        [HttpGet]
        public ActionResult GetAllProducts()
        {
            var products = repo.GetAllProducts();
            if (products != null && products.Any())
                return Ok(mapper.Map<IEnumerable<ProductReadDTO>>(products));
            return NotFound();
        }
    }
}
