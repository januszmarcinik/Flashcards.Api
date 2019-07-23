using Flashcards.Core.Exceptions;
using Flashcards.Domain.Entities;
using Flashcards.Domain.Extensions;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System;
using System.Threading.Tasks;
using Flashcards.Domain.Data.Concrete;

namespace Flashcards.Infrastructure.Services.Concrete.Commands
{
    internal class CommentsCommandService : ICommentsCommandService
    {
        private readonly EFContext _dbContext;

        public CommentsCommandService(EFContext dbContext)
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
