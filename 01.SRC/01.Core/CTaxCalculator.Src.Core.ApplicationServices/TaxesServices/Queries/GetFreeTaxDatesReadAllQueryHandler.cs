using CTaxCalculator.Framework.Core.ApplicationServices.Queries;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.GetFreeTaxDatesAll;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.SearchFreeTaxDateByDateTime;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Queries
{
    public class GetFreeTaxDatesReadAllQueryHandler : QueryHandler<GetFreeTaxDatesReadAllQuery, List<FreeTaxDatesQri>>
    {
        private readonly IFreeTaxDatesQueryRepository _freeTaxDatesQueryRepository;
        public GetFreeTaxDatesReadAllQueryHandler(ArkaSoftwareCMPOutServices mafiaOuterService , IFreeTaxDatesQueryRepository freeTaxDatesQueryRepository) : base(mafiaOuterService)
        {
            _freeTaxDatesQueryRepository = freeTaxDatesQueryRepository;
        }

        public override async Task<QueryResult<List<FreeTaxDatesQri>>> Handle(GetFreeTaxDatesReadAllQuery query)
        {
            var result = await _freeTaxDatesQueryRepository.GetAllFreeTaxDatesExecuteAsync(query);
            if(result is null)
                return Result(null! , Framework.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            return Result(result);
        }
    }
}
