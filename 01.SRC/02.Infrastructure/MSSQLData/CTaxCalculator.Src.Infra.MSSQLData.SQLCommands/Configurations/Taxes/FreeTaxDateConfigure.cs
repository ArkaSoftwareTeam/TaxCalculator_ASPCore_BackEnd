using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.ValueOBJs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLCommands.Configurations.Taxes
{
    public class FreeTaxDateConfigure : IEntityTypeConfiguration<FreeTaxDate>
    {
        public void Configure(EntityTypeBuilder<FreeTaxDate> builder)
        {
            builder.ToTable("FreeTaxDates", "TaxCalculate");
            builder.Property(x => x.FreeTaxDateTime).HasColumnType("DATETIME").HasConversion(x => x.Value, x => new FreeTaxDateTime(x)).IsRequired();
        }
    }
}
