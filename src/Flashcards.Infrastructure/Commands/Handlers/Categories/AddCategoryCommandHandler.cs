using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Categories;
using Flashcards.Domain.Repositories;

namespace Flashcards.Infrastructure.Commands.Handlers.Categories
{
    internal class AddCategoryCommandHandler : ICommandHandler<AddCategoryCommandModel>
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public AddCategoryCommandHandler(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public void Handle(AddCategoryCommandModel command)
            => _categoriesRepository.Add(command.Name, command.Topic.Value, command.Description);
    }
}
