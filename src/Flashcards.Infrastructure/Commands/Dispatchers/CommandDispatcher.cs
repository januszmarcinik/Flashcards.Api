using Autofac;
using Flashcards.Core.Exceptions;
using Flashcards.Infrastructure.Commands.Abstract;
using NLog;

namespace Flashcards.Infrastructure.Commands.Dispatchers
{
    internal class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;
        private readonly ILogger _logger;

        public CommandDispatcher(IComponentContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Dispatch<T>(T command) where T : ICommandModel
        {
            _logger.Trace($"Command has been run: '{typeof(T)}'");

            if (command == null)
            {
                throw new FlashcardsException(ErrorCode.EmptyCommand, typeof(T).Name);
            }

            var handler = _context.Resolve<ICommandHandler<T>>();
            handler.Handle(command);
        }
    }
}
