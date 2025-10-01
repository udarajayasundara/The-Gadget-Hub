using AutoMapper;
using GadgetCentral.DTO;
using GadgetCentral.Models;

namespace GadgetCentral.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerReadDTO>();
            CreateMap<CustomerWriteDTO, Customer>();
        }
    }
}
