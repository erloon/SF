using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Calculator.Core.Model;

namespace SF.Calculator.Persistence.Configurations
{
    public class BaseValuesDictionaryConfig : IEntityTypeConfiguration<BaseValuesDictionary>

    {
        public void Configure(EntityTypeBuilder<BaseValuesDictionary> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasData(new BaseValuesDictionary[]
            {
                new BaseValuesDictionary("HealthBaseAmount","3554.93"), 
                new BaseValuesDictionary("InsuranceBaseAmount","2665.8"),
                new BaseValuesDictionary("InsuranceBaseAmountWithDiscount","630"),
                new BaseValuesDictionary("MonthlyTaxFreeAmount","46.34"),
                new BaseValuesDictionary("VATTaxRate","0.23")
            });
        }
    }
}