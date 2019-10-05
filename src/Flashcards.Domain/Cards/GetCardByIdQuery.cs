using System;
using Flashcards.Core;

namespace Flashcards.Domain.Cards
{
    public class GetCardByIdQuery : IQuery<CardDto>
    {
        public GetCardByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
