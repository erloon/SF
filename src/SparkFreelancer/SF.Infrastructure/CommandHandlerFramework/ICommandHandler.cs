using System.Threading.Tasks;

namespace SF.Infrastructure.CommandHandlerFramework
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task ExecuteAsync(T command);
    }
}