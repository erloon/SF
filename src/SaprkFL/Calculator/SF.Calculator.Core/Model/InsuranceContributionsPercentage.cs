using System;
using SF.Shared.Infrastructure;

namespace SF.Calculator.Core.Model
{
    public class InsuranceContributionsPercentage : Entity
    {
        public decimal Accident { get; protected set; }
        public decimal Health { get; protected set; }
        public decimal Retirement { get; protected set; }
        public decimal HealthToDiscount { get; protected set; }
        public decimal Disability { get; protected set; }
        public decimal Medical { get; protected set; }
        public decimal LaborFound { get; protected set; }
        public bool IsActive { get; protected set; }
        protected InsuranceContributionsPercentage()
        {

        }

        public InsuranceContributionsPercentage(decimal accident, decimal health, decimal retirement, decimal healthToDiscount, decimal disability, decimal medical, decimal laborFound, bool isActive)
        {
            Id = Guid.NewGuid();
            Accident = accident;
            Health = health;
            Retirement = retirement;
            HealthToDiscount = healthToDiscount;
            Disability = disability;
            Medical = medical;
            LaborFound = laborFound;
            IsActive = isActive;
        }

        public void AddAccidentPercentage(decimal accidentPercentage)
        {
            this.Accident = accidentPercentage;
        }
    }
}