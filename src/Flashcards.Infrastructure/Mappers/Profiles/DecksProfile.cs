using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Flashcards.Domain.Dto;
using Flashcards.Domain.Entities;

namespace Flashcards.Infrastructure.Mappers.Profiles
{
    public class DecksProfile : Profile
    {
        public DecksProfile() : base("Decks")
        {
            CreateMap<Deck, DeckDto>();
        }
    }
}
