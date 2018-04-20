using System;
using SF.Domain.DTO;
using SF.Infrastructure;

namespace SF.Domain
{
    public class InsuranceContribution : Entity
    {
        public decimal InsuranceBaseAmount { get; protected set; } // Podstawa wymiaru skladek
        public decimal HealthBaseAmount { get; protected set; } // kwota bazowa dla skladki zdrowotnej 
        public decimal HealthInsurance { get; protected set; } // zdrowotne
        public decimal HealthInsuranceDiscount { get; protected set; } // zdrowotne do us
        public decimal MedicalInsurance { get; protected set; } // Chorobowe
        public decimal DisabilitiInsurance { get; protected set; } // rentowe
        public decimal RetirementInsurance { get; protected set; } // emerytalne
        public decimal AccidentInsurance { get; protected set; } //wypadkowe
        public decimal LaborFoundInsurance { get; protected set; } // Składka na fundusz pracy

        protected InsuranceContribution() { }
        public InsuranceContribution(InsuranceContributionContext contributionContext)
        {
            if (contributionContext.InsuranceBaseAmount <= 0) throw new ArgumentOutOfRangeException(nameof(contributionContext.InsuranceBaseAmount));
            if (contributionContext.HealthBaseAmount <= 0) throw new ArgumentOutOfRangeException(nameof(contributionContext.HealthBaseAmount));
            if (contributionContext.Percentage == null) throw new ArgumentNullException(nameof(contributionContext.Percentage));

            this.Id = new Guid();
            this.InsuranceBaseAmount = contributionContext.InsuranceBaseAmount;
            this.HealthBaseAmount = contributionContext.HealthBaseAmount;

            CalculateInsuranceParts(contributionContext.Percentage);
        }

        public decimal InsuranceContributionsSum()
        {

            return Math.Round((HealthInsurance + MedicalInsurance + DisabilitiInsurance + RetirementInsurance + AccidentInsurance), 2);
        }

        public decimal SocialInsuranceSum()
        {
            return Math.Round((MedicalInsurance + DisabilitiInsurance + RetirementInsurance + AccidentInsurance), 2);
        }

        private void CalculateInsuranceParts(InsuranceContributionsPercentage insuranceContributionsPercentage)
        {
            CalculateHealthInsurance(insuranceContributionsPercentage, this.HealthBaseAmount);
            CalculateMedicalInsurance(insuranceContributionsPercentage.Medical, this.InsuranceBaseAmount);
            CalculateDisabilitiInsurance(insuranceContributionsPercentage.Disabiliti, this.InsuranceBaseAmount);
            CalculateRetirementInsurance(insuranceContributionsPercentage.Retirement, this.InsuranceBaseAmount);
            CalculateAccidentInsurance(insuranceContributionsPercentage.Accident, this.InsuranceBaseAmount);
            CalculatLaborFoundInsurance(insuranceContributionsPercentage.LaborFound, this.InsuranceBaseAmount);
        }

        private void CalculatLaborFoundInsurance(decimal laborFound, decimal insuranceBaseAmount)
        {
            this.LaborFoundInsurance = CalculateInsurance(laborFound, insuranceBaseAmount);
        }

        private void CalculateAccidentInsurance(decimal accident, decimal insuranceBaseAmount)
        {
            this.AccidentInsurance = CalculateInsurance(accident, insuranceBaseAmount);
        }

        private void CalculateRetirementInsurance(decimal retirement, decimal insuranceBaseAmount)
        {
            this.RetirementInsurance = CalculateInsurance(retirement, insuranceBaseAmount);
        }

        private void CalculateDisabilitiInsurance(decimal disabiliti, decimal insuranceBaseAmount)
        {
            this.DisabilitiInsurance = CalculateInsurance(disabiliti, insuranceBaseAmount);
        }

        private void CalculateMedicalInsurance(decimal medical, decimal insuranceBaseAmount)
        {
            this.MedicalInsurance = CalculateInsurance(medical, insuranceBaseAmount);
        }

        private void CalculateHealthInsurance(InsuranceContributionsPercentage insuranceContributionsPercentage, decimal healthBaseAmount)
        {
            this.HealthInsurance = CalculateInsurance(insuranceContributionsPercentage.Health, healthBaseAmount);
            this.HealthInsuranceDiscount = CalculateInsurance(insuranceContributionsPercentage.HealthToDiscount, healthBaseAmount);
        }

        private decimal CalculateInsurance(decimal percentage, decimal baseAmount)
        {
            return Math.Round((percentage * baseAmount), 2);
        }

    }
}