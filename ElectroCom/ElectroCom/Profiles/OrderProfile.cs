using AutoMapper;
using ElectroCom.DTO;
using ElectroCom.Models;

namespace ElectroCom.Profiles
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
