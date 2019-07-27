using System;
using System.Collections.Generic;
using System.Linq;
using Flashcards.Core.Exceptions;
using Flashcards.Domain.Comments;
using Flashcards.Infrastructure.DataAccess;
using Flashcards.Infrastructure.Extensions;

namespace Flashcards.Infrastructure.Repositories
{
    internal class CommentsRepository : ICommentsRepository
    {
        private readonly EFContext _dbContext;

        public CommentsRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CommentDto> GetByCard(Guid cardId)
        {
            var card = _dbContext.Cards.FindAndEnsureExists(cardId, ErrorCode.CardDoesNotExist);
            var comments = card.Comments
                .OrderByDescending(x => x.Date)
                .Select(x => x.ToDto())
                .ToList();

            return comments;
        }

        public CommentDto GetById(Guid id)
            => _dbContext.Comments
                .FindAndEnsureExists(id, ErrorCode.InvalidCommentText)
                .ToDto();

        public void Add(Guid cardId, Guid userId, string text)
        {
            var user = _dbContext.Users.FindAndEnsureExists(userId, ErrorCode.UserDoesNotExist);
            var card = _dbContext.Cards.FindAndEnsureExists(cardId, ErrorCode.CardDoesNotExist);

            var comment = new Comment(text);
            user.AddComment(comment);
            card.AddComment(comment);

            _dbContext.Cards.Update(card);
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }
    }
}
