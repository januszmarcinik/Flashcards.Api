using AutoMapper;
using Flashcards.Domain.Dto;
using Flashcards.Domain.Entities;

namespace Flashcards.Infrastructure.Mappers.Profiles
{
    public class CardsProfile : Profile
    {
        public CardsProfile() : base("Cards")
        {
            CreateMap<Card, CardDto>();
        }
    }
}
