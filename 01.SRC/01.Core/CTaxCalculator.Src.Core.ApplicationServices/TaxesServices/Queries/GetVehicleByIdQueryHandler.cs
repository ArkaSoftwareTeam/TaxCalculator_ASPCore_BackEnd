using CTaxCalculator.Framework.Core.ApplicationServices.Queries;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.VehiclesQueries.GetVehiclesById;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Queries
{
    public class GetVehicleByIdQueryHandler : QueryHandler<GetVehicleByIdQuery, VehicleResQri>
    {
        private readonly IVehicleQueryRepository _vehicleQueryRepository;
        public GetVehicleByIdQueryHandler(ArkaSoftwareCMPOutServices mafiaOuterService 
            , IVehicleQueryRepository vehicleQueryRepository) : base(mafiaOuterService)
        {
            _vehicleQueryRepository = vehicleQueryRepository;
        }

        public override async Task<QueryResult<VehicleResQri>> Handle(GetVehicleByIdQuery query)
        {
            var result = await _vehicleQueryRepository.GetVehicleByIdExecuteAsync(query);
            if(query is null)
                return await ResultAsync(null! , Framework.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            return await ResultAsync(result!);
        }
    }
}
