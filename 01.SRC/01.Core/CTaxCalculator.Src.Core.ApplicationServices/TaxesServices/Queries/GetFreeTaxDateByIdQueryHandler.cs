using CTaxCalculator.Framework.Core.ApplicationServices.Queries;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.GetFreeTaxDateById;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Queries
{
    public class GetFreeTaxDateByIdQueryHandler : QueryHandler<GetFreeTaxDateByIdQuery, FreeTaxDateQri>
    {
        private readonly IFreeTaxDatesQueryRepository _freeTaxDatesQueryRepository;
        public GetFreeTaxDateByIdQueryHandler(ArkaSoftwareCMPOutServices mafiaOuterService, 
            IFreeTaxDatesQueryRepository freeTaxDatesQueryRepository) : base(mafiaOuterService)
        {
            _freeTaxDatesQueryRepository = freeTaxDatesQueryRepository;
        }

        public override async Task<QueryResult<FreeTaxDateQri>> Handle(GetFreeTaxDateByIdQuery query)
        {
            var result = await _freeTaxDatesQueryRepository.GetFreeTaxDateByIdExecuteAsync(query);
            if(result is null)
                return Result(null! , Framework.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            return Result(result);
        }
    }
}
