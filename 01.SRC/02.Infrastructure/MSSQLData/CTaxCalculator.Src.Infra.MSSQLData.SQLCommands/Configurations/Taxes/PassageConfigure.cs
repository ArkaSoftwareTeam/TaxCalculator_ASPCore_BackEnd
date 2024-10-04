using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLCommands.Configurations.Taxes
{
    public class PassageConfigure : IEntityTypeConfiguration<Passage>
    {
        public void Configure(EntityTypeBuilder<Passage> builder)
        {
            builder.ToTable("Passages", "TaxCalculate");
            builder.Property(x => x.PassageDateTime).HasColumnType("DATETIME").IsRequired();
            builder.HasIndex(x => x.PassageDateTime, "PassageTable_PassageDateTimeTable_Index");
        }
    }
}
