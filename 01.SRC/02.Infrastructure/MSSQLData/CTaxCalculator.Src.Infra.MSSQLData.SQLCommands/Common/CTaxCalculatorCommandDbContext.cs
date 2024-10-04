using CTaxCalculator.Framework.Infra.Data.SQLCommands.Common;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLCommands.Common
{
    public class CTaxCalculatorCommandDbContext : BaseCommandDbContext
    {
        public CTaxCalculatorCommandDbContext(DbContextOptions<CTaxCalculatorCommandDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(builder);
        }


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }


        public DbSet<City> Cities { get; set; }
    }
}
