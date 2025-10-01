using AutoMapper;
using TheGadgetHub.DTO;
using TheGadgetHub.Models;

namespace TheGadgetHub.Profiles
{
    public class UserProfiles :Profile
    {
        public UserProfiles() {

            CreateMap<User, UserReadDTO>();
            CreateMap<User, UserLoginDTO>();
            CreateMap<UserWriteDTO, User>();
        }
    }
}
