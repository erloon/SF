using AutoMapper;
using SF.Domain.DTO.Results;
using SF.Domain.Model;

namespace SF.API.Infrastructure.Mappings
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
                .ForMember(x => x.TaxBase, o => o.MapFrom(s => s.TaxBaseAmount));

            //CreateMap<SelfEmployeeCalculation, MonthlySelfEmployeeCalculationResult>()
            //    .AfterMap((s, d) =>
            //    {
            //        d = new MonthlySelfEmployeeCalculationResult()
            //        {
            //            Month = s.Month,
            //            Result = new SelfEmployeeCalculationResult()
            //            {
            //                IncomeCosts = s.IncomeCostsAmount,
            //                //InsuranceContribution = Mapper.Map<InsuranceContributionResult>(s.InsuranceContribution),
            //                NetSalary = s.NetPay,
            //                NetSalaryEstimate = s.NetPayEstimate,
            //                TaxBase = s.TaxBaseAmount,
            //                VatAmount = s.VatAmount
            //            }
            //        };
            //    })
            //    .ForMember(x => x.Month, o => o.MapFrom(s => s.Month));

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