using Microsoft.Extensions.Configuration;
using Snowflake.Core;

namespace CTaxCalculator.Framework.Utilities.OutServices.Generator
{
    public class SnowflakeIdGenerator : IdGenerator
    {
        private readonly IdWorker _idWorker;
        public SnowflakeIdGenerator(IConfiguration configuration)
        {
            int datacenterId = int.Parse(configuration["datacenterId"]!);
            _idWorker = new IdWorker(datacenterId, 1);

        }
        public long Next()
        {
            return _idWorker.NextId();
        }
    }
}
