using AutoMapper;
using TheGadgetHub.DTO;
using TheGadgetHub.Models;

namespace TheGadgetHub.Profiles
{
    public class CompareRequestProfiles :Profile
    {
        public CompareRequestProfiles() 
        {
            CreateMap<GlobalProductCatlog, GlobalProductCatlogReadDTO>();
            CreateMap<GlobalProductCatlogReadDTO, GlobalProductCatlog>();
        }
    }
}
