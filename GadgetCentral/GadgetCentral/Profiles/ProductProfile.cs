using AutoMapper;
using GadgetCentral.DTO;
using GadgetCentral.Models;

namespace GadgetCentral.Profiles
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
