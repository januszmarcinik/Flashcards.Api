using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Categories;
using Flashcards.Infrastructure.Services.Abstract.Commands;
using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Commands.Handlers.Categories
{
    internal class EditCategoryCommandHandler : ICommandHandler<EditCategoryCommandModel>
    {
        private readonly ICategoriesCommandService _categoriesCommandService;

        public EditCategoryCommandHandler(ICategoriesCommandService categoriesCommandService)
        {
            _categoriesCommandService = categoriesCommandService;
        }

        public async Task HandleAsync(EditCategoryCommandModel command)
            => await _categoriesCommandService.EditAsync(command.Id, command.Name, command.Topic.Value);
    }
}
