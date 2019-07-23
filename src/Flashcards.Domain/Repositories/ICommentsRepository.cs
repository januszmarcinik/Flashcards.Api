using System;
using System.Collections.Generic;
using Flashcards.Domain.Dto;

namespace Flashcards.Domain.Repositories
{
    public interface ICommentsRepository
    {
        List<CommentDto> GetByCard(Guid cardId);
        CommentDto GetById(Guid id);

        void Add(Guid cardId, Guid userId, string text);
    }
}
