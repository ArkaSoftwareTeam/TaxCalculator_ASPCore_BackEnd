using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Infra.Data.SQLQueries.QueryRepositories;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.GetFreeTaxDateById;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.GetFreeTaxDatesAll;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.SearchFreeTaxDateByDateTime;
using CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Common;
using Microsoft.EntityFrameworkCore;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Repositories
{
    class FreeTaxDateQueryRepository : BaseQueryRepository<CTaxCalculatorQueryDbContext>, IFreeTaxDatesQueryRepository
    {
        public FreeTaxDateQueryRepository(CTaxCalculatorQueryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<FreeTaxDatesQri>?> GetAllFreeTaxDatesExecuteAsync(GetFreeTaxDatesReadAllQuery query) =>
            await _dbContext.FreeTaxDates.Select(x => new FreeTaxDatesQri()
            {
                FreeTaxDateId = x.FreeTaxDateId,
                Date = Convert.ToDateTime(x.FreeTaxDatetimeValue.ToString("yyyy-MM-dd")),
                Time = Convert.ToDateTime(x.FreeTaxDatetimeValue.ToString("HH:MM")),
                
            }).ToListAsync();

        public async Task<FreeTaxDateQri?> GetFreeTaxDateByIdExecuteAsync(GetFreeTaxDateByIdQuery query) =>
            await _dbContext.FreeTaxDates.Where(x => x.FreeTaxDateId == query.FreeTaxDateId).Select(x => new FreeTaxDateQri() 
                { 
                    FreeTaxDateId = x.FreeTaxDateId,
                    Date = Convert.ToDateTime(x.FreeTaxDatetimeValue.ToString("yyyy-MM-dd")),  
                    Time = Convert.ToDateTime(x.FreeTaxDatetimeValue.ToString("HH:MM")),
                }).FirstOrDefaultAsync();

        public async Task<PagedData<FreeTaxDatesSearchQri>?> SearchFreeTaxDatesByDateTimeExecuteAsync(SearchFreeTaxDatesQuery query)
        {
            PagedData<FreeTaxDatesSearchQri> result = new();
            var queryResult = await _dbContext.FreeTaxDates.AsNoTracking().ToListAsync();
            if (!string.IsNullOrEmpty(query.DateTime.ToString()))
            {
                queryResult = queryResult.Where(x => x.FreeTaxDatetimeValue >=  query.DateTime && x.FreeTaxDatetimeValue >= query.DateTime).ToList();
            }
            result.QueryResult = queryResult.OrderBy(x => x.FreeTaxDateId)
                .Skip(query.SkipCount)
                .Take(query.PageSize)
                .Select(x => new FreeTaxDatesSearchQri()
                {
                    FreeTaxDateId = x.FreeTaxDateId,
                    Date = Convert.ToDateTime(x.FreeTaxDatetimeValue.ToString("yyyy-MM-dd")),
                    Time = Convert.ToDateTime(x.FreeTaxDatetimeValue.ToString("HH:MM")),
                }).ToList();

            if (query.NeedTotalCount) 
            {
                result.TotalCount = queryResult.Count();
            }
            return result;
        }
            
    }
}
