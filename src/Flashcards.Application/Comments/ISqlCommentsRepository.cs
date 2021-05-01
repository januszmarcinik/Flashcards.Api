using System;
using System.Collections.Generic;

namespace Flashcards.Application.Comments
{
    public interface ISqlCommentsRepository
    {
        IEnumerable<Comment> GetByCard(Guid cardId);
        
        void Add(Comment comment);
    }
}
