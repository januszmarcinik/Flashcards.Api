using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Categories;
using Flashcards.Domain.Repositories;

namespace Flashcards.Infrastructure.Commands.Handlers.Categories
{
    internal class EditCategoryCommandHandler : ICommandHandler<EditCategoryCommandModel>
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public EditCategoryCommandHandler(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public void Handle(EditCategoryCommandModel command)
            => _categoriesRepository.Update(command.Id, command.Name, command.Topic.Value, command.Description);
    }
}
