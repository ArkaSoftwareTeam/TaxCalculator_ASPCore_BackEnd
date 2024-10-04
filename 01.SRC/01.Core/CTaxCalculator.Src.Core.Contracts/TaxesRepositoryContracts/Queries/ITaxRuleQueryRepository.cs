using CTaxCalculator.Framework.Core.Contracts.Data.Queries;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.TaxRulesQueries.GetTaxRuleById;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.TaxRulesQueries.SearchTaxRulesByInputValue;

namespace CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries
{
    public interface ITaxRuleQueryRepository:IQueryRepository
    {
        Task<TaxRuleQri?> GetTaxRuleByIdExecuteAsync(GetTaxRuleByIdQuery query);
        Task<PagedData<SearchTaxRuleQri>?> SearchTaxRulesExecuteAsync(SearchTaxRuleQuery query);
    }
}
