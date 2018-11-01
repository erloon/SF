using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Calculator.Core.Model;

namespace SF.Calculator.Persistence.Configurations
{
    public class InsuranceContributionConfig: IEntityTypeConfiguration<InsuranceContribution>
    {
        public void Configure(EntityTypeBuilder<InsuranceContribution> builder)
        {
            builder.Property(x=>x.InsuranceBaseAmount).HasColumnType("decimal(10,2)");
            builder.Property(x=>x.HealthBaseAmount).HasColumnType("decimal(10,2)");
            builder.Property(x=>x.HealthInsurance).HasColumnType("decimal(10,2)");
            builder.Property(x=>x.HealthInsuranceDiscount).HasColumnType("decimal(10,2)");
            builder.Property(x=>x.MedicalInsurance).HasColumnType("decimal(10,2)");
            builder.Property(x=>x.DisabilityInsurance).HasColumnType("decimal(10,2)");
            builder.Property(x=>x.RetirementInsurance).HasColumnType("decimal(10,2)");
            builder.Property(x=>x.AccidentInsurance).HasColumnType("decimal(10,2)");
            builder.Property(x=>x.LaborFoundInsurance).HasColumnType("decimal(10,2)");
            builder.Property(x => x.WithMedicalInsurance);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
        }
    }
}