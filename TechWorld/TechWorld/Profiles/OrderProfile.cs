using AutoMapper;
using TechWorld.DTO;
using TechWorld.Models;

namespace TechWorld.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderReadDTO>();
            CreateMap<OrderWriteDTO, Order>();
        }
    }
}
