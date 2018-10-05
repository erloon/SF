using AutoMapper;
using SF.Calculator.Core.DTO.Results;
using SF.Calculator.Core.Model;

namespace SF.Calculator.API.Infrastructure.Mappings
{
    public class MonthlySelfEmployeeCalculationResolver : IValueResolver<SelfEmployeeCalculation, MonthlySelfEmployeeCalculationResult, SelfEmployeeCalculationResult>
    {
        public SelfEmployeeCalculationResult Resolve(SelfEmployeeCalculation source, MonthlySelfEmployeeCalculationResult destination,
            SelfEmployeeCalculationResult destMember, ResolutionContext context)
        {
            return new SelfEmployeeCalculationResult()
            {
                IncomeCosts = source.IncomeCostsAmount,
                InsuranceContribution = new InsuranceContributionResult()
                {
                    AccidentInsurance = source.InsuranceContribution.AccidentInsurance,
                    DisabilitiInsurance = source.InsuranceContribution.DisabilitiInsurance,
                    HealthInsurance = source.InsuranceContribution.HealthInsurance,
                    LaborFoundInsurance = source.InsuranceContribution.LaborFoundInsurance,
                    MedicalInsurance = source.InsuranceContribution.MedicalInsurance,
                    RetirementInsurance = source.InsuranceContribution.RetirementInsurance
                },
                NetSalary = source.NetPay,
                NetSalaryEstimate = source.NetPayEstimate,
                TaxBase = source.TaxBaseAmount,
                VatAmount = source.VatAmount
            };
        }
    }
}