using Flashcards.Core;

namespace Flashcards.Domain.Categories
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
