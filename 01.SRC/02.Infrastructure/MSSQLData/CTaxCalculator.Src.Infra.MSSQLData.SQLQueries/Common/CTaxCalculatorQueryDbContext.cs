using CTaxCalculator.Framework.Infra.Data.SQLQueries.QueryDbContext;
using CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Configurations;
using CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Entities;
using Microsoft.EntityFrameworkCore;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Common
{
    public partial class CTaxCalculatorQueryDbContext : BaseQueryDbContext
    {
        public CTaxCalculatorQueryDbContext(DbContextOptions<CTaxCalculatorQueryDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityQueryConfigure());
            modelBuilder.ApplyConfiguration(new TaxRuleQueryConfigure());
            modelBuilder.ApplyConfiguration(new FreeTaxDateQueryConfigure());
            modelBuilder.ApplyConfiguration(new VehicleQueryConfigure());
            modelBuilder.ApplyConfiguration(new PassageQueryConfigure());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<CityQueryModel> Cities { get; set; } = null!;
        public virtual DbSet<TaxRuleQueryModel> TaxRules { get; set; } = null!;
        public virtual DbSet<FreeTaxDateQueryModel> FreeTaxDates { get; set; } = null!;
        public virtual DbSet<VehicleQueryModel> Vehicles { get; set; } = null!;
        public virtual DbSet<PassageQueryModel> Passages { get; set; } = null!;

        
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
