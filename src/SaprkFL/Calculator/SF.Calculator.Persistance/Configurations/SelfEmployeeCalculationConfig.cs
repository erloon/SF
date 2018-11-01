using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Calculator.Core.Model;

namespace SF.Calculator.Persistence.Configurations
{
    public class SelfEmployeeCalculationConfig : IEntityTypeConfiguration<SelfEmployeeCalculation>
    {
        public void Configure(EntityTypeBuilder<SelfEmployeeCalculation> builder)
        {
            builder.Property(x => x.NetPay).HasColumnType("decimal(12,2)");
            builder.Property(x => x.NetPayEstimate).HasColumnType("decimal(12,2)");
            builder.Property(x => x.VatAmount).HasColumnType("decimal(12,2)");
            builder.Property(x => x.IncomeCostsAmount).HasColumnType("decimal(12,2)");
            builder.Property(x => x.TaxBaseAmount).HasColumnType("decimal(12,2)");
            builder.Property(x => x.TaxAmount).HasColumnType("decimal(12,2)");
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
        }
    }
}