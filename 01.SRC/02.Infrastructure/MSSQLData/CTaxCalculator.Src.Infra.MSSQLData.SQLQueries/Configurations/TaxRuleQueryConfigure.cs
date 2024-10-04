using CTaxCalculator.Src.Core.Domain.TaxAggregate.ValueOBJs;
using CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Configurations
{
    public class TaxRuleQueryConfigure : IEntityTypeConfiguration<TaxRuleQueryModel>
    {
        public void Configure(EntityTypeBuilder<TaxRuleQueryModel> builder)
        {
            builder.ToTable("TaxRules", "TaxCalculate");
            builder.Property(x => x.StartTime).HasColumnName("TaxRule_StartTime").HasColumnType("TIME");
            builder.Property(x => x.EndTime).HasColumnName("TaxRule_EndTime").HasColumnType("TIME");
            builder.Property(x => x.TaxAmount).HasColumnName("TaxAmount").HasColumnType("MONEY");
        }
    }
}
