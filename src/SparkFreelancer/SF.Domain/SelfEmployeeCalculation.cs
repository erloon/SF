using System;
using SF.Domain.DTO;
using SF.Infrastructure;

namespace SF.Domain
{
    public class SelfEmployeeCalculation : Entity
    {
        public decimal NetPay { get; protected set; }
        public decimal VatAmount { get; protected set; }
        public decimal IncomeCostsAmount { get; protected set; }
        public decimal TaxBaseAmount { get; protected set; }
        public decimal TaxDeductions { get; protected set; }
        public InsuranceContribution InsuranceContribution { get; protected set; }

        public SelfEmployeeCalculation(SelfEmployeeCalculationContext calculationContext)
        {
            if (calculationContext.BaseAmount < 0) throw new ArgumentOutOfRangeException(nameof(calculationContext.BaseAmount));
            if (calculationContext.IncomeCost < 0) throw new ArgumentOutOfRangeException(nameof(calculationContext.IncomeCost));
            if (calculationContext.VatRate < 0) throw new ArgumentOutOfRangeException(nameof(calculationContext.VatRate));

            this.TaxBaseAmount = calculationContext.BaseAmount;
            this.IncomeCostsAmount = calculationContext.IncomeCost;
            CalculateVatAmount(calculationContext.VatRate);
        }

        private void CalculateVatAmount(decimal vatRate)
        {
            if (vatRate < 0) throw new ArgumentOutOfRangeException(nameof(vatRate));

            if (this.TaxBaseAmount <= 0 || vatRate == 0) this.VatAmount = 0;

            this.VatAmount = this.TaxBaseAmount * vatRate;
        }

        private void AddInsuranceContribution(InsuranceContributionContext insuranceContributionContext)
        {
            this.InsuranceContribution = new InsuranceContribution(insuranceContributionContext);
        }

    }
}