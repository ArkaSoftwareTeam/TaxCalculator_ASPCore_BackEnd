using CTaxCalculator.Src.Core.Domain.TaxAggregate.ValueOBJs;
using CTaxCalculator.Src.Core.Domain.VehicleAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLCommands.Configurations.Taxes
{
    public class VehicleConfigure : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles", "TaxCalculate");
            builder.Property(x => x.PlateNumber).HasColumnType("VARCHAR").HasMaxLength(12).HasConversion(x => x.Value, x => new PlateNumber(x)).IsRequired();
            builder.Property(x => x.TotalTaxAmount).HasColumnType("MONEY").HasConversion(x => x.Amount, x => new Price(x));
            builder.Property(x => x.LastTaxPassagePrice).HasColumnType("MONEY").HasConversion(x => x.Amount, x => new Price(x));
            builder.HasIndex(x => x.PlateNumber , "VehiclesTable_ColumnPlateNumber_UniqueIndex").IsUnique();
            builder.HasIndex(x => x.TotalTaxAmount , "VehiclesTable_ColumnTotalTaxAmount_Index");
        }
    }
}
