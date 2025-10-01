using AutoMapper;
using GadgetCentral.DTO;
using GadgetCentral.Models;

namespace GadgetCentral.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderReadDTO>();
            CreateMap<OrderWriteDTO, Order>();
        }
    }
}
