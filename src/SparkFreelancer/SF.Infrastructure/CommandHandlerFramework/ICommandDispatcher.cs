using System.Threading.Tasks;

namespace SF.Infrastructure.CommandHandlerFramework
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand;

    }
}