using CTaxCalculator.Framework.Core.Contracts.Data.Queries;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.GetFreeTaxDateById;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.GetFreeTaxDatesAll;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.SearchFreeTaxDateByDateTime;

namespace CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries
{
    public interface IFreeTaxDatesQueryRepository:IQueryRepository
    {
        Task<FreeTaxDateQri?> GetFreeTaxDateByIdExecuteAsync(GetFreeTaxDateByIdQuery query);
        Task<List<FreeTaxDatesQri>?> GetAllFreeTaxDatesExecuteAsync(GetFreeTaxDatesReadAllQuery query);
        Task<PagedData<FreeTaxDatesSearchQri>?> SearchFreeTaxDatesByDateTimeExecuteAsync(SearchFreeTaxDatesQuery query);
    }
}
