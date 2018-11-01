using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Calculator.Core.Model;

namespace SF.Calculator.Persistence.Configurations
{
    public class InsuranceContributionsPercentageConfig : IEntityTypeConfiguration<InsuranceContributionsPercentage>
    {
        public void Configure(EntityTypeBuilder<InsuranceContributionsPercentage> builder)
        {
            builder.Property(x => x.Accident); //.HasColumnType("decimal(2,4)");
            builder.Property(x => x.Disability); //.HasColumnType("decimal(2,4)");
            builder.Property(x => x.Health); //.HasColumnType("decimal(2,4)");
            builder.Property(x => x.HealthToDiscount); //.HasColumnType("decimal(2,4)");
            builder.Property(x => x.LaborFound); //.HasColumnType("decimal(2,4)");
            builder.Property(x => x.Medical); //.HasColumnType("decimal(2,4)");
            builder.Property(x => x.Retirement); //.HasColumnType("decimal(2,4)");
            builder.Property(x => x.IsActive); //.HasColumnType("decimal(2,4)");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);

            //builder.HasData(new InsuranceContributionsPercentage[]
            //{
            //    new InsuranceContributionsPercentage(0,0.09m,0.1952m,0.0775m,0.08m, 0.0245m,0.0245m,true)
            //});
        }
    }
}