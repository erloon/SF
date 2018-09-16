using System;
using System.Collections.Generic;
using MediatR;
using SF.Domain.DTO;
using SF.Domain.DTO.Results;
using SF.Domain.Model;

namespace SF.Domain.Commands
{
    public class YearlySelfEmployeeCalculationCommand : IRequest<YearlySelfEmployeeCalculation>
    {
        public bool IsGross { get; set; }
        public decimal AccidentContributionPercentage { get; set; }
        public bool IsMedicalInsurance { get; set; }
        public bool IsReliefForSocialInsurance { get; set; }
        public TaxationForm TaxationForm { get; set; }

        public List<MonthlyBalanceSheetData> MonthlyBalanceSheetDatas { get; set; }


    }

}