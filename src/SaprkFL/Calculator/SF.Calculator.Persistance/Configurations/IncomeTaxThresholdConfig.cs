using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Calculator.Core.Model;

namespace SF.Calculator.Persistence.Configurations
{
    public class IncomeTaxThresholdConfig : IEntityTypeConfiguration<IncomeTaxThreshold>
    {
        public void Configure(EntityTypeBuilder<IncomeTaxThreshold> builder)
        {
            builder.Property(x => x.FromAmount).HasColumnType("decimal(12,2)");
            builder.Property(x => x.Percentage).HasColumnType("decimal(2,2)");
            builder.Property(x => x.PreviusMaxTaxValue).HasColumnType("decimal(12,2)");
            builder.Property(x => x.ToAmount).HasColumnType("decimal(18,2)");
            builder.Ignore(x => x.PreviusMaxTaxValue);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.HasData(new IncomeTaxThreshold[]
            {
                new IncomeTaxThreshold(TaxationForm.LINEAR, 1, 0, int.MaxValue, 0.19m),
                new IncomeTaxThreshold(TaxationForm.GENERAL, 1, 0, 85528m, 0.18m),
                new IncomeTaxThreshold(TaxationForm.GENERAL, 2, 85528m, int.MaxValue, 0.32m),
            });
        }
    }
}