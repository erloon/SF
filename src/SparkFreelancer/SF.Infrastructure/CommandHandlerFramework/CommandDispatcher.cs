using System;
using System.Threading.Tasks;
using Autofac;

namespace SF.Infrastructure.CommandHandlerFramework
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var handler = _context.Resolve<ICommandHandler<T>>();

            await handler.ExecuteAsync(command);
        }
    }
}