using Autofac;
using MediatR;
using SF.Calculator.Core.Commands;
using SF.Calculator.Core.Handlers;
using SF.Calculator.Core.Model;
using SF.Calculator.Core.Services;
using SF.Calculator.Core.TaxCalculators;

namespace SF.Calculator.Core.Registrations
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<SelfEmployeeCalculationHandler>()
                .As<IRequestHandler<SelfEmployeeCalculationCommand, SelfEmployeeCalculation>>()
                .InstancePerDependency();

            builder.RegisterType<YearlySelfEmployeeCalculationHandler>()
                .As<IRequestHandler<YearlySelfEmployeeCalculationCommand, YearlySelfEmployeeCalculation>>()
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

            builder.RegisterType<InsuranceContributionService>()
                .As<IInsuranceContributionService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}