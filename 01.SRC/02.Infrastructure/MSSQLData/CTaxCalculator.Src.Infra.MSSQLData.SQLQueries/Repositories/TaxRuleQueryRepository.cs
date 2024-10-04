using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Infra.Data.SQLQueries.QueryRepositories;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.SearchFreeTaxDateByDateTime;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.TaxRulesQueries.GetTaxRuleById;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.TaxRulesQueries.SearchTaxRulesByInputValue;
using CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Common;
using Microsoft.EntityFrameworkCore;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Repositories
{
    public class TaxRuleQueryRepository : BaseQueryRepository<CTaxCalculatorQueryDbContext>, ITaxRuleQueryRepository
    {
        public TaxRuleQueryRepository(CTaxCalculatorQueryDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<TaxRuleQri?> GetTaxRuleByIdExecuteAsync(GetTaxRuleByIdQuery query) =>
            await _dbContext.TaxRules.Select(x => new TaxRuleQri()
            {
                TaxRuleId = x.Id,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                TaxAmount = x.TaxAmount,
            }).FirstOrDefaultAsync(x => x.TaxRuleId.Equals(query.TaxRuleId));

        public async Task<PagedData<SearchTaxRuleQri>?> SearchTaxRulesExecuteAsync(SearchTaxRuleQuery query)
        {
            PagedData<SearchTaxRuleQri> result = new();
            var queryResult = await _dbContext.TaxRules.AsNoTracking().ToListAsync();
            if (!string.IsNullOrEmpty(query.StartTime.ToString()) || !string.IsNullOrEmpty(query.EndTime.ToString()))
                queryResult = queryResult.Where(x => x.StartTime >= query.StartTime && x.EndTime >= query.EndTime).ToList();
            
            if (!string.IsNullOrEmpty(query.StartTime.ToString()))
                queryResult = queryResult.Where(x => x.StartTime >= query.StartTime).ToList();
            
            if (!string.IsNullOrEmpty(query.EndTime.ToString()))
                queryResult = queryResult.Where(x => x.EndTime <= query.EndTime).ToList();
            

            result.QueryResult = queryResult.OrderBy(x => x.Id)
                .Skip(query.SkipCount)
                .Take(query.PageSize)
                .Select(x => new SearchTaxRuleQri()
                {
                    TaxRuleId = x.Id,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    TaxAmount = x.TaxAmount,
                }).ToList();

            if (query.NeedTotalCount)
            {
                result.TotalCount = queryResult.Count();
            }
            return result;
        }
    }
}
