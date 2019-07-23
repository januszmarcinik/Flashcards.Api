namespace Flashcards.Infrastructure.Commands.Abstract
{
    public interface ICommandHandler<T> where T : ICommandModel
    {
        void Handle(T command);
    }
}
