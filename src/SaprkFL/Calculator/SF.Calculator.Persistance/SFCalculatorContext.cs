using Microsoft.EntityFrameworkCore;
using SF.Calculator.Core.Model;
using SF.Calculator.Persistence.Configurations;

namespace SF.Calculator.Persistence
{
    public class SFCalculatorContext : DbContext
    {
        public DbSet<IncomeTaxThreshold> IncomeTaxThresholds { get; set; }
        public DbSet<InsuranceContributionsPercentage> InsuranceContributionsPercentages { get; set; }
        public DbSet<InsuranceContribution> InsuranceContributions { get; set; }
        public DbSet<SelfEmployeeCalculation> SelfEmployeeCalculations { get; set; }
        public DbSet<YearlySelfEmployeeCalculation> YearlySelfEmployeeCalculations { get; set; }
        public DbSet<BaseValuesDictionary> BaseValuesDictionaries { get; set; }

        public SFCalculatorContext(DbContextOptions<SFCalculatorContext> options): base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IncomeTaxThresholdConfig());
            modelBuilder.ApplyConfiguration(new InsuranceContributionsPercentageConfig());
            modelBuilder.ApplyConfiguration(new InsuranceContributionConfig());
            modelBuilder.ApplyConfiguration(new SelfEmployeeCalculationConfig());
            modelBuilder.ApplyConfiguration(new YearlySelfEmployeeCalculationConfig());
            modelBuilder.ApplyConfiguration(new BaseValuesDictionaryConfig());
            base.OnModelCreating(modelBuilder);
        }
    }

}