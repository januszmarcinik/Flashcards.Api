using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Commands.Abstract
{
    public interface ICommandHandler<T> where T : ICommandModel
    {
        Task HandleAsync(T command);
    }
}
