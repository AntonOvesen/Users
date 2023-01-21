using AutoMapper;
using Users.Models.DTOs;
using Users.Models.Entities;

namespace Users.AutoMapper
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
