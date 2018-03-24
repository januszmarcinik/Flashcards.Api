using AutoMapper;
using Flashcards.Domain.Entities;
using Flashcards.Infrastructure.Dto.Users;

namespace Flashcards.Infrastructure.Mappers.Profiles
{
    internal class UsersProfile : Profile
    {
        public UsersProfile() : base("Users")
        {
            CreateMap<User, UserDto>();
        }
    }
}
