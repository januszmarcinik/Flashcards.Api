using Flashcards.Core;
using Flashcards.Infrastructure.Commands.Models.Categories;
using Flashcards.Domain.Repositories;

namespace Flashcards.Infrastructure.Commands.Handlers.Categories
{
    internal class RemoveCategoryCommandHandler : ICommandHandler<RemoveCategoryCommand>
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public RemoveCategoryCommandHandler(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public Result Handle(RemoveCategoryCommand command)
        {
            _categoriesRepository.Delete(command.Id);
            return Result.Ok();
        }
    }
}
