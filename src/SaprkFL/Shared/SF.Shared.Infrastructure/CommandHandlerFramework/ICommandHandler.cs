using System.Threading.Tasks;

namespace SF.Shared.Infrastructure.CommandHandlerFramework
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
}