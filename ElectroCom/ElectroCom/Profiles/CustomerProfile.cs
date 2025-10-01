using AutoMapper;
using ElectroCom.DTO;
using ElectroCom.Models;

namespace ElectroCom.Profiles
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
