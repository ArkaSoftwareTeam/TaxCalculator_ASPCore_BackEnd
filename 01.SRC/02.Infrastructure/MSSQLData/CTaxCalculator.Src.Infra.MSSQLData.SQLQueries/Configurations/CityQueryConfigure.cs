using CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Configurations
{
    public class CityQueryConfigure : IEntityTypeConfiguration<CityQueryModel>
    {
        public void Configure(EntityTypeBuilder<CityQueryModel> builder)
        {
            builder.ToTable("Cities", "TaxCalculate");
            builder.Property(x => x.CityName).HasColumnName("CityName");

            builder.HasMany(c => c.TaxRules)
            .WithOne(t => t.City)
            .HasForeignKey(t => t.CityId);
        }
    }
}
