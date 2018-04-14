using AutoMapper;
using Flashcards.Domain.Entities;
using Flashcards.Infrastructure.Dto.Comments;

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
