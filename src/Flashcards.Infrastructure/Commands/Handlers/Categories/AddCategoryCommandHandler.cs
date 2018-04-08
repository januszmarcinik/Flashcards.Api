using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Categories;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Commands.Handlers.Categories
{
    internal class AddCategoryCommandHandler : ICommandHandler<AddCategoryCommandModel>
    {
        private readonly ICategoriesCommandService _categoriesCommandService;

        public AddCategoryCommandHandler(ICategoriesCommandService categoriesCommandService)
        {
            _categoriesCommandService = categoriesCommandService;
        }

        public async Task HandleAsync(AddCategoryCommandModel command)
            => await _categoriesCommandService.AddAsync(command.Name, command.Topic.Value);
    }
}
