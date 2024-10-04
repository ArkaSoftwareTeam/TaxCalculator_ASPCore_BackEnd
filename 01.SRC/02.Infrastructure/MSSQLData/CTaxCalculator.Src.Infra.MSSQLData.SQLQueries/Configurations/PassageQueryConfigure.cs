using CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Configurations
{
    public class PassageQueryConfigure : IEntityTypeConfiguration<PassageQueryModel>
    {
        public void Configure(EntityTypeBuilder<PassageQueryModel> builder)
        {
            builder.ToTable("Passages", "TaxCalculate");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.PassageDateTime).HasColumnName("PassageDateTime");
            builder.HasOne(x => x.Vehicle).WithMany(x => x.Passages).HasForeignKey(x => x.VehicleId);
        }
    }
}
