using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.ValueOBJs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLCommands.Configurations.Taxes
{
    public class TaxRuleConfigure : IEntityTypeConfiguration<TaxRule>
    {
        public void Configure(EntityTypeBuilder<TaxRule> builder)
        {
            builder.ToTable("TaxRules", "TaxCalculate");
            builder.OwnsOne(x => x.TaxRuleDateTime, ruleDateTime =>
            {
                ruleDateTime.Property(sDate => sDate.StartTime).HasColumnType("TIME(0)").HasColumnName("TaxRule_StartTime").IsRequired();
                ruleDateTime.Property(eDate => eDate.EndTime).HasColumnType("TIME(0)").HasColumnName("TaxRule_EndTime").IsRequired();
                ruleDateTime.HasIndex(x => new { x.StartTime , x.EndTime});
            });
            builder.Property(x => x.TaxAmount).HasColumnType("MONEY").HasConversion(x => x.Amount, x => new Price(x));
        }
    }
}
