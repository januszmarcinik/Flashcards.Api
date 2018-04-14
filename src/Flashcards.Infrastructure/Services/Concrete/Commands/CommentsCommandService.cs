using Flashcards.Core.Exceptions;
using Flashcards.Domain.Data.Abstract;
using Flashcards.Domain.Entities;
using Flashcards.Domain.Extensions;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services.Concrete.Commands
{
    internal class CommentsCommandService : ICommentsCommandService
    {
        private readonly IDbContext _dbContext;

        public CommentsCommandService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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
