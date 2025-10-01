using AutoMapper;
using ElectroCom.DTO;
using ElectroCom.Models;

namespace ElectroCom.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDTO>();
            CreateMap<ProductWriteDTO, Product>();
        }
    }
}
