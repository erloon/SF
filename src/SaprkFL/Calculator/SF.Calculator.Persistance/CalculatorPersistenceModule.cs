﻿using Autofac;
using SF.Calculator.Core.Repositories;
using SF.Calculator.Persistence.Repositories;

namespace SF.Calculator.Persistence
{
    public class CalculatorPersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IncomeTaxThresholdRepository>()
                .As<IIncomeTaxThresholdRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<InsuranceContributionRepository>()
                .As<IInsuranceContributionRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<BaseValuesDictionaryRepository>()
                .As<IBaseValuesDictionaryRepository>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}