using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Categories;
using System.Threading.Tasks;
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

        public async Task HandleAsync(EditCategoryCommandModel command)
            => await _categoriesRepository.EditAsync(command.Id, command.Name, command.Topic.Value, command.Description);
    }
}
