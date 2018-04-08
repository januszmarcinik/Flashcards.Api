using AutoMapper;
using Flashcards.Core.Extensions;
using Flashcards.Domain.Entities;
using Flashcards.Infrastructure.Dto.Categories;

namespace Flashcards.Infrastructure.Mappers.Profiles
{
    internal class CategoryProfile : Profile
    {
        public CategoryProfile() : base("Categories")
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(m => m.TopicName, p => p.MapFrom(c => c.Topic.GetDescription()));
        }
    }
}
