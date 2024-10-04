using CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Configurations
{
    public class FreeTaxDateQueryConfigure : IEntityTypeConfiguration<FreeTaxDateQueryModel>
    {
        public void Configure(EntityTypeBuilder<FreeTaxDateQueryModel> builder)
        {
            builder.ToTable("FreeTaxDates", "TaxCalculate");
            builder.HasKey(x => x.FreeTaxDateId);
            builder.Property(x => x.FreeTaxDateId).HasColumnName("Id");
            builder.Property(x => x.FreeTaxDatetimeValue).HasColumnName("FreeTaxDateTime");
        }
    }
}
