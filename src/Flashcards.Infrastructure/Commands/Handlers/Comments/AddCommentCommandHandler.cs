using Flashcards.Core.Extensions;
using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Comments;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Commands.Handlers.Comments
{
    internal class AddCommentCommandHandler : ICommandHandler<AddCommentCommandModel>
    {
        private readonly ICommentsCommandService _commentsCommandService;

        public AddCommentCommandHandler(ICommentsCommandService commentsCommandService)
        {
            _commentsCommandService = commentsCommandService;
        }

        public async Task HandleAsync(AddCommentCommandModel command)
        {
            if (command.Id.IsEmpty())
            {
                command.Id = Guid.NewGuid();
            }

            await _commentsCommandService.AddAsync(command.CardId, command.UserId, command.Text);
        }
    }
}
