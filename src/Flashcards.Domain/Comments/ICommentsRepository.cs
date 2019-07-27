using System;
using System.Collections.Generic;

namespace Flashcards.Domain.Comments
{
    public interface ICommentsRepository
    {
        List<CommentDto> GetByCard(Guid cardId);
        CommentDto GetById(Guid id);

        void Add(Guid cardId, Guid userId, string text);
    }
}
