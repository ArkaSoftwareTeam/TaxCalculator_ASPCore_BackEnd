using CTaxCalculator.Framework.Core.Contracts.Data.Queries;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.VehiclesQueries.GetVehiclesById;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.VehiclesQueries.SearchVehicles;

namespace CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries
{
    public interface IVehicleQueryRepository:IQueryRepository
    {
        public Task<VehicleResQri?> GetVehicleByIdExecuteAsync(GetVehicleByIdQuery query);
        public Task<PagedData<SearchVehiclesResQri>?> SearchVehiclesExecuteAsync(SearchVehiclesQuery query);
    }
}
