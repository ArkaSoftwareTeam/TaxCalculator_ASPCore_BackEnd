using CTaxCalculator.Framework.Core.ApplicationServices.Queries;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.SearchFreeTaxDateByDateTime;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Queries
{
    public class SearchFreeTaxDatesByDateTimeQueryHandler : QueryHandler<SearchFreeTaxDatesQuery, PagedData<FreeTaxDatesSearchQri>>
    {
        private readonly IFreeTaxDatesQueryRepository _freeTaxDatesQueryRepository;
        public SearchFreeTaxDatesByDateTimeQueryHandler(ArkaSoftwareCMPOutServices mafiaOuterService
            , IFreeTaxDatesQueryRepository freeTaxDatesQueryRepository) : base(mafiaOuterService)
        {
            _freeTaxDatesQueryRepository = freeTaxDatesQueryRepository;
        }

        public override async Task<QueryResult<PagedData<FreeTaxDatesSearchQri>>> Handle(SearchFreeTaxDatesQuery query)
        {
            var result = await _freeTaxDatesQueryRepository.SearchFreeTaxDatesByDateTimeExecuteAsync(query);
            if (result is null)
                return await ResultAsync(null!, Framework.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            return await ResultAsync(result);
        }
    }
}
