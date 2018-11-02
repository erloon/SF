using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Calculator.Core.Model;

namespace SF.Calculator.Persistence.Configurations
{
    public class InsuranceContributionsPercentageConfig : IEntityTypeConfiguration<InsuranceContributionsPercentage>
    {
        public void Configure(EntityTypeBuilder<InsuranceContributionsPercentage> builder)
        {
            builder.Property(x => x.Accident); 
            builder.Property(x => x.Disability);
            builder.Property(x => x.Health); 
            builder.Property(x => x.HealthToDiscount); 
            builder.Property(x => x.LaborFound); 
            builder.Property(x => x.Medical);
            builder.Property(x => x.Retirement);
            builder.Property(x => x.IsActive);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);

            builder.HasData(new InsuranceContributionsPercentage[]
            {
                new InsuranceContributionsPercentage(0,0.09m,0.1952m,0.0775m,0.08m, 0.0245m,0.0245m,true)
            });
        }
    }
}