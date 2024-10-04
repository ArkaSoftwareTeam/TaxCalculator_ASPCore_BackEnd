using CTaxCalculator.Framework.Core.Contracts.Data.Queries;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.CitiesQueries.GetCityById;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.CitiesQueries.SearchCityByInputValue;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.ModelJoinQueries.GetCityWithTaxRulesAll;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.ModelJoinQueries.GetCityWithTaxRulesById;

namespace CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries
{
    public interface ITaxCityQueryRepository:IQueryRepository
    {
        Task<CityQri?> GetCitiesByIdExecuteAsync(GetCityByIdQuery query);
        Task<List<CityWithAllTaxRulesQir>?> GetAllCityWithTaxRulesExecuteAsync(GetCityWithTaxRulesReadAllQuery query);
        Task<CityWithTaxRulesQri?> GetCityWithTaxRulesByIdExecuteAsync(GetCityWithTaxRulesByIdQuery query);
        Task<PagedData<SearchCityQri>?> SearchCityExecuteAsync(SearchCityQuery query);

    }
}
