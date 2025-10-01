using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TheGadgetHub.Data;
using TheGadgetHub.DTO;
using TheGadgetHub.Models;
using TheGadgetHub.Services;

namespace TheGadgetHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {   
        private IMapper mapper;
        private UserRepo repo;

        public UserController(IMapper _mapper, UserRepo _repo)
        {
            mapper = _mapper;
            repo = _repo;
        }

        [HttpPost("register")]
        public ActionResult CreateUser(UserWriteDTO writeDTO)
        {
            var user = mapper.Map<User>(writeDTO);

            // Hash the password
            user.HashedPassword = BCrypt.Net.BCrypt.HashPassword(writeDTO.HashedPassword);

            if (repo.Create(user))
                return Ok("User Account Created Successfully");
            return BadRequest("Failed to create user account");
        }

        [HttpPost("login")]
        public ActionResult Login(UserLoginDTO loginDTO, [FromServices] JwtService jwtService)
        {
            var user = repo.Authenticate(loginDTO.Email, loginDTO.HashedPassword);

            if (user == null)
                return Unauthorized("Invalid email or password");

            var token = jwtService.GenerateToken(user);

            return Ok(new { Token = token });
        }


    }
}
