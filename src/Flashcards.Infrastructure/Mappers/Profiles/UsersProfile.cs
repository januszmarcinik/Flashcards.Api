using AutoMapper;
using Flashcards.Domain.Dto;
using Flashcards.Domain.Entities;

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
