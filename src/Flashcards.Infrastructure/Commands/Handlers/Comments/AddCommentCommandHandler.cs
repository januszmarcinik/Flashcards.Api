using Flashcards.Core.Extensions;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Comments;
using System;
using System.Threading.Tasks;
using Flashcards.Domain.Repositories;

namespace Flashcards.Infrastructure.Commands.Handlers.Comments
{
    internal class AddCommentCommandHandler : ICommandHandler<AddCommentCommandModel>
    {
        private readonly ICommentsRepository _commentsRepository;

        public AddCommentCommandHandler(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public async Task HandleAsync(AddCommentCommandModel command)
        {
            if (command.Id.IsEmpty())
            {
                command.Id = Guid.NewGuid();
            }

            await _commentsRepository.AddAsync(command.CardId, command.UserId, command.Text);
        }
    }
}
