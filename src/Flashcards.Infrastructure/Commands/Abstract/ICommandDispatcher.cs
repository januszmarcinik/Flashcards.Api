using System.Threading.Tasks;

namespace Flashcards.Infrastructure.Commands.Abstract
{
    public interface ICommandDispatcher
    {
        void Dispatch<T>(T command) where T : ICommandModel;
    }
}
