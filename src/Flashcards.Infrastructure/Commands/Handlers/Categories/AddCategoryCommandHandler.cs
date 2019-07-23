using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Categories;
using System.Threading.Tasks;
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

        public async Task HandleAsync(AddCategoryCommandModel command)
            => await _categoriesRepository.AddAsync(command.Name, command.Topic.Value, command.Description);
    }
}
