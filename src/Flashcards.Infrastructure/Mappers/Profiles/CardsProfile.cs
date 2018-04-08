using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Flashcards.Domain.Entities;
using Flashcards.Infrastructure.Dto.Cards;

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
