using AutoMapper;
using SF.Domain.DTO.Results;
using SF.Domain.Model;

namespace SF.API
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
        }
    }
}