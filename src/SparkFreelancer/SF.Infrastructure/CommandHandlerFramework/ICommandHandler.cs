using System.Threading.Tasks;

namespace SF.Infrastructure.CommandHandlerFramework
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task ExecuteAsync(TCommand command);
    }
}