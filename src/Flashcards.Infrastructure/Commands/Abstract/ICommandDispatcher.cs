using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Commands.Abstract
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommandModel;
    }
}
