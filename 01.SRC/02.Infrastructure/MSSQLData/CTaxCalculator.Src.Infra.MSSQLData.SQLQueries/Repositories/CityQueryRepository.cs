using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Infra.Data.SQLQueries.QueryRepositories;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.CitiesQueries.GetCityById;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.CitiesQueries.SearchCityByInputValue;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.ModelJoinQueries.GetCityWithTaxRulesAll;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.ModelJoinQueries.GetCityWithTaxRulesById;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.TaxRulesQueries.GetTaxRuleById;
using CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Common;
using Microsoft.EntityFrameworkCore;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Repositories
{
    public class CityQueryRepository : BaseQueryRepository<CTaxCalculatorQueryDbContext>, ITaxCityQueryRepository
    {
        public CityQueryRepository(CTaxCalculatorQueryDbContext dbContext) : base(dbContext)
        {
        }
        async Task<List<CityWithAllTaxRulesQir>?> ITaxCityQueryRepository.GetAllCityWithTaxRulesExecuteAsync(GetCityWithTaxRulesReadAllQuery query)
        {
            var result = await _dbContext.Cities
                .Include(c => c.TaxRules)
                .Select(city => new CityWithAllTaxRulesQir
                {
                    CityName = city.CityName,
                    TaxRules = city.TaxRules.Select(tr => new TaxRuleQri
                    {
                        TaxRuleId = tr.Id,
                        StartTime = tr.StartTime,
                        EndTime = tr.EndTime,
                        TaxAmount = tr.TaxAmount
                    }).ToList()
                }).ToListAsync();

            return result;
        }

        public async Task<CityQri?> GetCitiesByIdExecuteAsync(GetCityByIdQuery query) =>
            await _dbContext.Cities.Select(x => new CityQri()
            {
                Id = x.Id,
                CityName = x.CityName,
            }).FirstOrDefaultAsync(x => x.Id.Equals(query.CityId));

        public async Task<CityWithTaxRulesQri?> GetCityWithTaxRulesByIdExecuteAsync(GetCityWithTaxRulesByIdQuery query)
        {
            var result = await _dbContext.Cities.Include(x => x.TaxRules).FirstOrDefaultAsync(x => x.Id == query.CityId);
            if (result is null)
                return null;
            CityWithTaxRulesQri cityWithTaxRulesInstance = new CityWithTaxRulesQri();
            cityWithTaxRulesInstance.CityName = result!.CityName;
            var x = result!.TaxRules.Where(x => x.CityId == query.CityId);

            foreach (var taxRule in x)
            {
                cityWithTaxRulesInstance.TaxRules.Add(new TaxRuleQri()
                {
                    TaxRuleId = taxRule.Id,
                    StartTime = taxRule.StartTime,
                    EndTime = taxRule.EndTime,
                    TaxAmount = taxRule.TaxAmount,
                });
            }
            return cityWithTaxRulesInstance;
        }

        public async Task<PagedData<SearchCityQri>?> SearchCityExecuteAsync(SearchCityQuery query)
        {
            PagedData<SearchCityQri> result = new();
            var queryResult = await _dbContext.Cities.AsNoTracking().ToListAsync();

            if (!string.IsNullOrEmpty(query.CityName!.ToString()))
            {
                queryResult = queryResult.Where(x => x.CityName.ToLower().Contains(query.CityName.ToLower())).ToList();
            }
            result.QueryResult = queryResult.OrderBy(x => x.CityName)
                .Skip(query.SkipCount)
                .Take(query.PageSize)
                .Select(x => new SearchCityQri()
                {
                    Id = x.Id,
                    CityName = x.CityName,
                }).ToList();

            if (query.NeedTotalCount)
            {
                result.TotalCount = queryResult.Count();
            }
            return result;
        }
    }
}
