using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLCommands.Common
{
    public class CTaxCalculatorDesignTimeFactoryIMP : IDesignTimeDbContextFactory<CTaxCalculatorCommandDbContext>
    {
        public CTaxCalculatorCommandDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var optionBuilder = new DbContextOptionsBuilder<CTaxCalculatorCommandDbContext>();
            var connectionString = configuration.GetConnectionString("CommandLocalDB_ConnectionString");
            optionBuilder.UseSqlServer(connectionString);
            return new CTaxCalculatorCommandDbContext(optionBuilder.Options);
           
        }
    }
}
