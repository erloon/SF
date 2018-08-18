using Autofac;
using SF.Domain.Commands;
using SF.Domain.Handlers;
using SF.Infrastructure.CommandHandlerFramework;

namespace SF.Domain.Registrations
{
    public class CommandHandlersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<MonthlySelfEmployeeCalculationHandler>()
                .As<ICommandHandler<MonthlySelfEmployeeCalculationCommand>>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}