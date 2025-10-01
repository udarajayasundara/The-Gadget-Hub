using AutoMapper;
using TechWorld.DTO;
using TechWorld.Models;

namespace TechWorld.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDTO>();
            CreateMap<ProductWriteDTO, Product>();
        }
    }
}
