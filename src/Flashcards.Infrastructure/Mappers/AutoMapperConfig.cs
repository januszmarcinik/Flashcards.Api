using AutoMapper;
using Flashcards.Infrastructure.Mappers.Profiles;

namespace Flashcards.Infrastructure.Mappers
{
    internal class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CategoryProfile());
                cfg.AddProfile(new CommentsProfile());
                cfg.AddProfile(new UsersProfile());
                cfg.AddProfile(new CardsProfile());
                cfg.AddProfile(new DecksProfile());
            })
            .CreateMapper();
        }
    }
}
