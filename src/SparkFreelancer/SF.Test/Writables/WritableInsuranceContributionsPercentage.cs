using SF.Domain;
using SF.Domain.Model;

namespace SF.Test.Writables
{
    public class WritableInsuranceContributionsPercentage : InsuranceContributionsPercentage
    {
        public WritableInsuranceContributionsPercentage WithAccident(decimal accident)
        {
            this.Accident = accident;
            return this;
        }
        public WritableInsuranceContributionsPercentage WithHealth(decimal health)
        {
            this.Health = health;
            return this;
        }
        public WritableInsuranceContributionsPercentage WithRetirement(decimal retirement)
        {
            this.Retirement = retirement;
            return this;
        }
        public WritableInsuranceContributionsPercentage WithHealthToDiscount(decimal healthToDiscount)
        {
            this.HealthToDiscount = healthToDiscount;
            return this;
        }
        public WritableInsuranceContributionsPercentage WithDisabiliti(decimal disabiliti)
        {
            this.Disabiliti = disabiliti;
            return this;
        }
        public WritableInsuranceContributionsPercentage WithMedical(decimal medical)
        {
            this.Medical = medical;
            return this;
        }
        public WritableInsuranceContributionsPercentage WithLaborFound(decimal laborFound)
        {
            this.LaborFound = laborFound;
            return this;
        }
    }
}