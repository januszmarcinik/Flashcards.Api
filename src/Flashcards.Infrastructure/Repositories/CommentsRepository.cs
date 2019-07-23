using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Core.Exceptions;
using Flashcards.Domain.Dto;
using Flashcards.Domain.Entities;
using Flashcards.Domain.Repositories;
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

        public async Task<List<CommentDto>> GetByCardAsync(Guid cardId)
        {
            var card = await _dbContext.Cards.FindAndEnsureExistsAsync(cardId, ErrorCode.CardDoesNotExist);
            var comments = card.Comments
                .OrderByDescending(x => x.Date)
                .Select(x => x.ToDto())
                .ToList();
            return comments;
        }

        public async Task<CommentDto> GetByIdAsync(Guid id)
            => (await _dbContext.Comments.FindAndEnsureExistsAsync(id, ErrorCode.InvalidCommentText)).ToDto();

        public async Task AddAsync(Guid cardId, Guid userId, string text)
        {
            var user = await _dbContext.Users.FindAndEnsureExistsAsync(userId, ErrorCode.UserDoesNotExist);
            var card = await _dbContext.Cards.FindAndEnsureExistsAsync(cardId, ErrorCode.CardDoesNotExist);

            var comment = new Comment(text);
            user.AddComment(comment);
            card.AddComment(comment);

            _dbContext.Cards.Update(card);
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
