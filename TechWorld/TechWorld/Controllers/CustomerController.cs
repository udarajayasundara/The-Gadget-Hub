using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TechWorld.Data;
using TechWorld.DTO;
using TechWorld.Models;

namespace TechWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IMapper mapper;
        private CustomerRepo repo;

        public CustomerController(IMapper _mapper, CustomerRepo _repo)
        {
            mapper = _mapper;
            repo = _repo;
        }
        [HttpPost]
        public ActionResult CreateCustomer(CustomerWriteDTO writeDTO)
        {
            var customer = mapper.Map<Customer>(writeDTO);
            if (repo.Create(customer))
                return Ok();
            return BadRequest();
        }
    }               
}
