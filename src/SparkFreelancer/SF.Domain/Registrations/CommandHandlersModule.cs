using System.Collections.Generic;
using Autofac;
using MediatR;
using SF.Domain.Commands;
using SF.Domain.DTO.Results;
using SF.Domain.Handlers;
using SF.Infrastructure.CommandHandlerFramework;

namespace SF.Domain.Registrations
{
    public class CommandHandlersModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           
            builder.RegisterType<SelfEmployeeCalculationHandler>()
                .As<IRequestHandler<MonthlySelfEmployeeCalculationCommand, MonthlySelfEmployeeCalculationResult>>()
                .InstancePerDependency();
            base.Load(builder);
        }
    }
}