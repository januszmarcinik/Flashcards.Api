namespace Flashcards.Core
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Result Handle(TCommand command);
    }
}
