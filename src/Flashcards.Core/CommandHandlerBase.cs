namespace Flashcards.Core
{
    public abstract class CommandHandlerBase<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        public abstract Result Handle(TCommand command);

        protected Result Ok()
        {
            return Result.Ok();
        }

        protected Result Fail(string message)
        {
            return Result.Fail(message);
        }
    }
}
