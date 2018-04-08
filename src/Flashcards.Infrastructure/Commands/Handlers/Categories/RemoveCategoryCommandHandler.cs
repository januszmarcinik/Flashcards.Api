using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Categories;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Commands.Handlers.Categories
{
    internal class RemoveCategoryCommandHandler : ICommandHandler<RemoveCategoryCommandModel>
    {
        private readonly ICategoriesCommandService _categoriesCommandService;

        public RemoveCategoryCommandHandler(ICategoriesCommandService categoriesCommandService)
        {
            _categoriesCommandService = categoriesCommandService;
        }

        public async Task HandleAsync(RemoveCategoryCommandModel command)
            => await _categoriesCommandService.RemoveAsync(command.Id);
    }
}
