using System;
using System.Collections.Generic;

namespace Flashcards.Domain.Comments
{
    public interface ISqlCommentsRepository
    {
        IEnumerable<Comment> GetByCard(Guid cardId);
        
        void Add(Comment comment);
    }
}
