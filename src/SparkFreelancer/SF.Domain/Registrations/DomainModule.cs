using System.Collections.Generic;
using Autofac;
using MediatR;
using SF.Domain.Commands;
using SF.Domain.DTO.Results;
using SF.Domain.Handlers;
using SF.Domain.Model;
using SF.Domain.Services;
using SF.Domain.TaxCalculators;
using SF.Infrastructure.CommandHandlerFramework;

namespace SF.Domain.Registrations
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<SelfEmployeeCalculationHandler>()
                .As<IRequestHandler<SelfEmployeeCalculationCommand, SelfEmployeeCalculation>>()
                .InstancePerDependency();

            builder.RegisterType<TaxPercentagesService>()
                .As<ITaxPercentagesService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TaxCalculator>()
                .As<ITaxCalculator>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GeneralCalculatorStrategy>()
                .Keyed<ITaxCalculatorStrategy>(TaxationForm.GENERAL)
                .InstancePerLifetimeScope();

            builder.RegisterType<LinearCalculatorStrategy>()
                .Keyed<ITaxCalculatorStrategy>(TaxationForm.LINEAR)
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}