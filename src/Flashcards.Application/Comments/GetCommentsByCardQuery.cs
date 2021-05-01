using System;
using System.Collections.Generic;
using Flashcards.Core;

namespace Flashcards.Application.Comments
{
    public class GetCommentsByCardQuery : IQuery<IEnumerable<CommentDto>>
    {
        public GetCommentsByCardQuery(Guid cardId)
        {
            CardId = cardId;
        }

        public Guid CardId { get; }
    }
}
