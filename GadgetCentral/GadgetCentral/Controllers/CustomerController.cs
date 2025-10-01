using AutoMapper;
using GadgetCentral.Data;
using GadgetCentral.DTO;
using GadgetCentral.Models;
using Microsoft.AspNetCore.Mvc;

namespace GadgetCentral.Controllers
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
