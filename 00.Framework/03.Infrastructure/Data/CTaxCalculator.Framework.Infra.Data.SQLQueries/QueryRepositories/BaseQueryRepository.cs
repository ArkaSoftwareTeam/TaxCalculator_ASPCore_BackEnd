using CTaxCalculator.Framework.Core.Contracts.Data.Queries;
using CTaxCalculator.Framework.Infra.Data.SQLQueries.QueryDbContext;


namespace CTaxCalculator.Framework.Infra.Data.SQLQueries.QueryRepositories
{
    public class BaseQueryRepository<TDbContext> : IQueryRepository
            where TDbContext : BaseQueryDbContext
    {
        protected readonly TDbContext _dbContext;
        public BaseQueryRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
