using AutoMapper;
using SF.Calculator.Core.DTO.Results;
using SF.Calculator.Core.Model;

namespace SF.Calculator.API.Infrastructure.Mappings
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<InsuranceContribution, InsuranceContributionResult>();


            CreateMap<SelfEmployeeCalculation, SelfEmployeeCalculationResult>()
                .ForMember(x => x.IncomeCosts, o => o.MapFrom(s => s.IncomeCostsAmount))
                .ForMember(x => x.VatAmount, o => o.MapFrom(s => s.VatAmount))
                .ForMember(x => x.NetSalary, o => o.MapFrom(s => s.NetPay))
                .ForMember(x => x.NetSalaryEstimate, o => o.MapFrom(s => s.NetPayEstimate))
                .ForMember(x => x.TaxAmount, o => o.MapFrom(s => s.TaxAmount))
                .ForMember(x => x.TaxBase, o => o.MapFrom(s => s.TaxBaseAmount));

            CreateMap<SelfEmployeeCalculation, MonthlySelfEmployeeCalculationResult>()
                .ForMember(x => x.Month, o => o.MapFrom(s => s.Month))
                .ForMember(x => x.Result, o => o.ResolveUsing<MonthlySelfEmployeeCalculationResolver>());

            CreateMap<YearlySelfEmployeeCalculation, YearlySelfEmployeeCalculationResult>()
                .ForMember(x => x.IncomeCostsSum, o => o.MapFrom(s => s.TotalIncomes))
                .ForMember(x => x.NetSalarySum, o => o.MapFrom(s => s.TotalIncomes))
                .ForMember(x => x.MonthlyResults, o => o.MapFrom(s => s.Calculations));


        }
    }
}