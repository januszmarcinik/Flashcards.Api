using System;
using System.Collections.Generic;
using System.Linq;
using Flashcards.Domain.Comments;
using Flashcards.Infrastructure.DataAccess;

namespace Flashcards.Infrastructure.Repositories
{
    internal class CommentsRepository : ICommentsRepository
    {
        private readonly EFContext _dbContext;

        public CommentsRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Comment> GetByCard(Guid cardId)
            => _dbContext.Comments
                .Where(x => x.CardId == cardId)
                .OrderByDescending(x => x.Date)
                .ToList();

        public void Add(Comment comment)
        { 
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
        }
    }
}
