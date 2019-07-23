using Flashcards.Core.Exceptions;
using Flashcards.Infrastructure.Services.Abstract.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flashcards.Domain.Dto;
using Flashcards.Infrastructure.DataAccess;
using Flashcards.Infrastructure.Extensions;

namespace Flashcards.Infrastructure.Services.Concrete.Queries
{
    internal class CommentsQueryService : ICommentsQueryService
    {
        private readonly EFContext _dbContext;

        public CommentsQueryService(EFContext dbContext)
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
    }
}
