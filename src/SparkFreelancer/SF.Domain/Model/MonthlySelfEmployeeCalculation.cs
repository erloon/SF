using System;
using SF.Domain.DTO;
using SF.Infrastructure;

namespace SF.Domain.Model
{
    public class SelfEmployeeCalculation : Entity
    {
        public Month Month { get; protected set; }
        public decimal NetPay { get; protected set; }
        public decimal NetPayEstimate { get; protected set; }
        public decimal VatAmount { get; protected set; }
        public decimal IncomeCostsAmount { get; protected set; }
        public decimal TaxBaseAmount { get; protected set; }
        public decimal BaseAmount { get; protected set; }
        public decimal TaxAmount { get; protected set; }
        public decimal TaxDeductions { get; protected set; }
        private decimal _vatTaxeRate = 0.23m;
        private decimal _taxFreeAmount = 46.34m;
        public InsuranceContribution InsuranceContribution { get; protected set; }

        public SelfEmployeeCalculation(MonthlySelfEmployeeCalculationContext calculationContext)
        {
            if (calculationContext == null) throw new ArgumentNullException(nameof(calculationContext));
            if (calculationContext.BaseAmount < 0)
                throw new ArgumentOutOfRangeException(nameof(calculationContext.BaseAmount));
            if (calculationContext.IncomeCost < 0)
                throw new ArgumentOutOfRangeException(nameof(calculationContext.IncomeCost));

            this.Id = Guid.NewGuid();
            this.TaxBaseAmount = calculationContext.BaseAmount;
            this.IncomeCostsAmount = calculationContext.IncomeCost;
            this.Month = calculationContext.Month;

            CalculateVatAmount(calculationContext);
            AddInsuranceContribution(calculationContext.InsuranceContributionContext);
            CalcualteMonthlyBaseAmount(calculationContext);
            CalculateIncomeTax(calculationContext);
            CalculateNetPay(calculationContext);
            CalculateNetPayEstimate(calculationContext);
        }

        private void CalculateVatAmount(MonthlySelfEmployeeCalculationContext calculationContext)
        {
            //TODO Add vat rate to command and context
            if (calculationContext.IsGross)
                this.VatAmount = (calculationContext.BaseAmount - (calculationContext.BaseAmount / (1 + _vatTaxeRate)));
            else
                this.VatAmount = calculationContext.BaseAmount * _vatTaxeRate;
        }

        private void AddInsuranceContribution(InsuranceContributionContext insuranceContributionContext)
        {
            this.InsuranceContribution = new InsuranceContribution(insuranceContributionContext);
        }

        private void CalcualteMonthlyBaseAmount(MonthlySelfEmployeeCalculationContext context)
        {
            this.BaseAmount = Math.Round(this.TaxBaseAmount - this.IncomeCostsAmount -
                              this.InsuranceContribution.SocialInsuranceContributionSum(context.IsMedicalInsurance), 0);
        }

        private void CalculateIncomeTax(MonthlySelfEmployeeCalculationContext calculationContext)
        {
            if (this.BaseAmount <= 0)
                this.TaxAmount = 0;
            else
            {
                if (calculationContext.TaxationForm == TaxationForm.LINEAR) _taxFreeAmount = 0;
                this.TaxAmount = Math.Round(calculationContext.IncomeTaxAmmount.Invoke(CreateTaxCalculationContext(calculationContext)) - (this.InsuranceContribution.HealthInsuranceDiscount + _taxFreeAmount), 0); //TODO move to db
            }
        }

        private TaxCalculationContext CreateTaxCalculationContext(MonthlySelfEmployeeCalculationContext calculationContext)
        {
            return new TaxCalculationContext(calculationContext.PreviusMonthsIncome, this.BaseAmount, calculationContext.TaxationForm);
        }

        private void CalculateNetPay(MonthlySelfEmployeeCalculationContext context)
        {
            this.NetPay = this.TaxBaseAmount -
                          this.InsuranceContribution.InsuranceContributionsSum(context.IsMedicalInsurance) -
                          this.TaxAmount -
                          this.IncomeCostsAmount;
        }

        private void CalculateNetPayEstimate(MonthlySelfEmployeeCalculationContext context)
        {
            this.NetPayEstimate = this.TaxBaseAmount -
                                  this.InsuranceContribution.InsuranceContributionsSum(context.IsMedicalInsurance) -
                                  this.TaxAmount;
        }
    }
}