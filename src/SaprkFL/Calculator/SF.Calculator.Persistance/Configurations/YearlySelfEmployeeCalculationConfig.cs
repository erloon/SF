using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Calculator.Core.Model;

namespace SF.Calculator.Persistence.Configurations
{
    public class YearlySelfEmployeeCalculationConfig : IEntityTypeConfiguration<YearlySelfEmployeeCalculation>
    {
        public void Configure(EntityTypeBuilder<YearlySelfEmployeeCalculation> builder)
        {
            builder.Property(x => x.TotalIncomes).HasColumnType("decimal(12,2)");
            builder.Property(x => x.TotalCosts).HasColumnType("decimal(12,2)");
            builder.HasMany(x => x.Calculations).WithOne().HasForeignKey(x => x.Id); 
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
        }
    }
}