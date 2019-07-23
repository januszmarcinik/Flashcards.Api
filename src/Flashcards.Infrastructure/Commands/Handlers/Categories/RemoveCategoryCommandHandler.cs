using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Categories;
using System.Threading.Tasks;
using Flashcards.Domain.Repositories;

namespace Flashcards.Infrastructure.Commands.Handlers.Categories
{
    internal class RemoveCategoryCommandHandler : ICommandHandler<RemoveCategoryCommandModel>
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public RemoveCategoryCommandHandler(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task HandleAsync(RemoveCategoryCommandModel command)
            => await _categoriesRepository.RemoveAsync(command.Id);
    }
}
