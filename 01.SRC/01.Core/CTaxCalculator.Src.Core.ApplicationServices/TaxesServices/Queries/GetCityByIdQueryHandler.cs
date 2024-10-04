using CTaxCalculator.Framework.Core.ApplicationServices.Queries;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.CitiesQueries.GetCityById;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Queries
{
    public class GetCityByIdQueryHandler : QueryHandler<GetCityByIdQuery, CityQri>
    {
        private ITaxCityQueryRepository _taxCityQueryRepository;
        public GetCityByIdQueryHandler(ArkaSoftwareCMPOutServices mafiaOuterService , ITaxCityQueryRepository taxCityQueryRepository) : base(mafiaOuterService)
        {
            _taxCityQueryRepository = taxCityQueryRepository;
        }

        public override async Task<QueryResult<CityQri>> Handle(GetCityByIdQuery query)
        {
            var result = await _taxCityQueryRepository.GetCitiesByIdExecuteAsync(query);
            if (result is null)
                return Result(null!, Framework.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            return Result(result!);
        }
    }
}
