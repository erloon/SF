using System.Threading.Tasks;

namespace SF.Infrastructure.CommandHandlerFramework
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;

    }
}