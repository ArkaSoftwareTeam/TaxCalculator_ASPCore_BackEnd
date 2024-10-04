using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using CTaxCalculator.Src.Core.Domain.UsersAggregate.ValueOBJs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLCommands.Configurations.Taxes
{
    public class CityConfigure : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities", "TaxCalculate");
            builder.Property(x => x.CityName).HasColumnType("VARCHAR").HasMaxLength(120).HasConversion(x => x.Value, x => new CityName(x));
            builder.HasIndex(x => x.CityName, "CitiesTable_CityNameColumn_Index");

        }
    }
}
