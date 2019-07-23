using Flashcards.Infrastructure.Commands.Abstract;
using Flashcards.Infrastructure.Commands.Models.Categories;
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

        public void Handle(RemoveCategoryCommandModel command)
            => _categoriesRepository.Delete(command.Id);
    }
}
