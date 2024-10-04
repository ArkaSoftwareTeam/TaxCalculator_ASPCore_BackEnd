using CTaxCalculator.Framework.Core.ApplicationServices.Queries;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.VehiclesQueries.SearchVehicles;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Queries
{
    public class SearchVehicleQueryHandler : QueryHandler<SearchVehiclesQuery, PagedData<SearchVehiclesResQri>>
    {
        private readonly IVehicleQueryRepository _vehicleQueryRepository;
        public SearchVehicleQueryHandler(ArkaSoftwareCMPOutServices mafiaOuterService , IVehicleQueryRepository vehicleQueryRepository) : base(mafiaOuterService)
        {
            _vehicleQueryRepository = vehicleQueryRepository;
        }

        public override async Task<QueryResult<PagedData<SearchVehiclesResQri>>> Handle(SearchVehiclesQuery query)
        {
            var result = await _vehicleQueryRepository.SearchVehiclesExecuteAsync(query);
            if (query is null)
                return await ResultAsync(null!, Framework.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            return await ResultAsync(result!);
        }
    }
}
