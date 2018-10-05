using System;
using System.Threading.Tasks;
using Autofac;

namespace SF.Shared.Infrastructure.CommandHandlerFramework
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var handler = _context.Resolve<ICommandHandler<TCommand>>();

            await handler.ExecuteAsync(command);
        }
    }
}