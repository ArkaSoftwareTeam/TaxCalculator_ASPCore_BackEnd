using CTaxCalculator.Framework.Core.ApplicationServices.Queries;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.CitiesQueries.SearchCityByInputValue;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Queries
{
    public class SearchCitiesQueryHandler : QueryHandler<SearchCityQuery, PagedData<SearchCityQri>>
    {
        private readonly ITaxCityQueryRepository _cityQueryRepository;
        public SearchCitiesQueryHandler(ArkaSoftwareCMPOutServices mafiaOuterService, ITaxCityQueryRepository cityQueryRepository) : base(mafiaOuterService)
        {
            _cityQueryRepository = cityQueryRepository;
        }

        public override async Task<QueryResult<PagedData<SearchCityQri>>> Handle(SearchCityQuery query)
        {
            var result = await _cityQueryRepository.SearchCityExecuteAsync(query);
            if (query is null)
                return await ResultAsync(null!, Framework.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            return await ResultAsync(result!);
        }
    }
}
