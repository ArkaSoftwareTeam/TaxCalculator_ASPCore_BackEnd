using CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Configurations
{
    public class VehicleQueryConfigure : IEntityTypeConfiguration<VehicleQueryModel>
    {
        public void Configure(EntityTypeBuilder<VehicleQueryModel> builder)
        {
            builder.ToTable("Vehicles", "TaxCalculate");
            builder.HasKey(x => x.VehicleId);
            builder.Property(x => x.VehicleId).HasColumnName("Id");
            builder.Property(x => x.VehicleType).HasColumnName("VehicleType");
            builder.Property(x => x.PlateNumber).HasColumnName("PlateNumber");
            builder.Property(x => x.LastTaxPassageAmount).HasColumnName("LastTaxPassagePrice");
            builder.Property(x => x.TotalTaxAmount).HasColumnName("TotalTaxAmount");
            builder.HasOne(x => x.City).WithMany(x => x.Vehicles).HasForeignKey(x => x.CityId);
        }
    }
}
