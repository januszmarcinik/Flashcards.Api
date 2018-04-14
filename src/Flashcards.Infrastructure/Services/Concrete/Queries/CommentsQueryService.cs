using AutoMapper;
using Flashcards.Core.Exceptions;
using Flashcards.Domain.Data.Abstract;
using Flashcards.Domain.Extensions;
using Flashcards.Infrastructure.Dto.Comments;
using Flashcards.Infrastructure.Services.Abstract.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Services.Concrete.Queries
{
    internal class CommentsQueryService : ICommentsQueryService
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public CommentsQueryService(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> GetByCardAsync(Guid cardId)
        {
            var card = await _dbContext.Cards.FindAndEnsureExistsAsync(cardId, ErrorCode.CardDoesNotExist);
            var comments = card.Comments.OrderByDescending(x => x.Date);
            return _mapper.Map<List<CommentDto>>(comments);
        }

        public async Task<CommentDto> GetByIdAsync(Guid id)
            => _mapper.Map<CommentDto>(await _dbContext.Comments.FindAndEnsureExistsAsync(id, ErrorCode.InvalidCommentText));
    }
}
