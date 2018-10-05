using Autofac;

namespace SF.Shared.Infrastructure.CommandHandlerFramework.IoC
{
    public class ComandHandlerFrameworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<CommandDispatcher>()
                .As<ICommandDispatcher>()
                .SingleInstance();

            base.Load(builder);
        }
    }
}