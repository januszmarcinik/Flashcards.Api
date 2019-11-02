using System;
using System.Collections.Generic;

namespace Flashcards.Domain.Comments
{
    public interface ICommentsRepository
    {
        IEnumerable<Comment> GetByCard(Guid cardId);
        
        void Add(Comment comment);
    }
}
