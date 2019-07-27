using Flashcards.Core;
using Flashcards.Infrastructure.Commands.Models.Categories;
using Flashcards.Domain.Repositories;

namespace Flashcards.Infrastructure.Commands.Handlers.Categories
{
    internal class AddCategoryCommandHandler : ICommandHandler<AddCategoryCommand>
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public AddCategoryCommandHandler(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public Result Handle(AddCategoryCommand command)
        {
            _categoriesRepository.Add(command.Name, command.Topic.Value, command.Description);
            return Result.Ok();
        }
    }
}
