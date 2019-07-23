using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flashcards.Domain.Dto;

namespace Flashcards.Domain.Repositories
{
    public interface ICommentsRepository
    {
        Task<List<CommentDto>> GetByCardAsync(Guid cardId);
        Task<CommentDto> GetByIdAsync(Guid id);

        Task AddAsync(Guid cardId, Guid userId, string text);
    }
}
