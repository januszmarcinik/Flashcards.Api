using AutoMapper;
using Flashcards.Domain.Dto;
using Flashcards.Domain.Entities;

namespace Flashcards.Infrastructure.Mappers.Profiles
{
    public class CommentsProfile : Profile
    {
        public CommentsProfile() : base("Comments")
        {
            CreateMap<Comment, CommentDto>()
                .ForMember(x => x.User, m => m.MapFrom(c => c.User.Email));
        }
    }
}
