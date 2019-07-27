using Flashcards.Core;
using Flashcards.Domain.Repositories;

namespace Flashcards.Domain.Categories
{
    internal class EditCategoryCommandHandler : ICommandHandler<EditCategoryCommand>
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public EditCategoryCommandHandler(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public Result Handle(EditCategoryCommand command)
        {
            _categoriesRepository.Update(command.Id, command.Name, command.Topic.Value, command.Description);
            return Result.Ok();
        }
    }
}
