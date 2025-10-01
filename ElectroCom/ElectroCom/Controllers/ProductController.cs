using AutoMapper;
using ElectroCom.Data;
using ElectroCom.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ElectroCom.Controllers
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
    }
}

