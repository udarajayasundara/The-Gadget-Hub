using AutoMapper;
using TechWorld.DTO;
using TechWorld.Models;

namespace TechWorld.Profiles
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile() 
        {
            CreateMap<Customer, CustomerReadDTO>();
            CreateMap<CustomerWriteDTO, Customer>();
        }
    }
}
