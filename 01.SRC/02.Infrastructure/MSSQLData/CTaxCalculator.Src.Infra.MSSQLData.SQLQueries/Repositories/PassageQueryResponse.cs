using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Infra.Data.SQLQueries.QueryRepositories;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.PassagesQueries.GetPassageById;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.PassagesQueries.SearchPassagesByInputValue;
using CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Common;
using Microsoft.EntityFrameworkCore;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Repositories
{
    public class PassageQueryResponse : BaseQueryRepository<CTaxCalculatorQueryDbContext>, ITaxPassageQueryResponse
    {
        public PassageQueryResponse(CTaxCalculatorQueryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PassageQri?> GetPassageByIdExecuteAsync(GetPassageByIdQuery query)
            => await _dbContext.Passages.Where(x => x.Id == query.PassageId).Select(x => new PassageQri()
            {
                Id = x.Id,
                PassageDateTime = Convert.ToDateTime(x.PassageDateTime.ToString("yyyy-MM-dd")),
               
            }).FirstOrDefaultAsync();

        public async Task<PagedData<SearchPassageQri>?> SearchPassagesExecuteAsync(SearchPassageQuery query)
        {
            PagedData<SearchPassageQri> result = new();
            var queryResult = await _dbContext.Passages.AsNoTracking().ToListAsync();
            if (!string.IsNullOrEmpty(query.PassageDateTime.ToString()))
            {
                queryResult = queryResult.Where(x => x.PassageDateTime == query.PassageDateTime).ToList();
            }
            result.QueryResult = queryResult.OrderBy(x => x.Id)
                .Skip(query.SkipCount)
                .Take(query.PageSize)
                .Select(x => new SearchPassageQri()
                {
                    PassageId = x.Id,
                    PassageDateTime = Convert.ToDateTime(x.PassageDateTime.ToString("yyyy-MM-dd")),
                    
                }).ToList();

            if (query.NeedTotalCount)
            {
                result.TotalCount = queryResult.Count();
            }
            return result;
        }
    }
}
