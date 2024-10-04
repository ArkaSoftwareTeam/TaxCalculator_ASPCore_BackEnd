using CTaxCalculator.Framework.Core.Contracts.Data.Queries;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.PassagesQueries.GetPassageById;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.PassagesQueries.SearchPassagesByInputValue;

namespace CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries
{
    public interface ITaxPassageQueryResponse: IQueryRepository
    {
        Task<PassageQri?> GetPassageByIdExecuteAsync(GetPassageByIdQuery query);
        Task<PagedData<SearchPassageQri>?> SearchPassagesExecuteAsync(SearchPassageQuery query);
    }
}
