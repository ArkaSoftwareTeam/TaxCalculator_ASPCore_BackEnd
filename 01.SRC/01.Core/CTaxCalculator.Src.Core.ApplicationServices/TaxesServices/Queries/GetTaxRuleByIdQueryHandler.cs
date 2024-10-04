using CTaxCalculator.Framework.Core.ApplicationServices.Queries;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.TaxRulesQueries.GetTaxRuleById;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Queries
{
    public class GetTaxRuleByIdQueryHandler : QueryHandler<GetTaxRuleByIdQuery, TaxRuleQri>
    {
        private readonly ITaxRuleQueryRepository _taxRuleQueryRepository;
        public GetTaxRuleByIdQueryHandler(ArkaSoftwareCMPOutServices mafiaOuterService , ITaxRuleQueryRepository taxRuleQueryRepository) : base(mafiaOuterService)
        {
            _taxRuleQueryRepository = taxRuleQueryRepository;
        }

        public override async Task<QueryResult<TaxRuleQri>> Handle(GetTaxRuleByIdQuery query)
        {
            var result = await _taxRuleQueryRepository.GetTaxRuleByIdExecuteAsync(query);
            if(result is null)
                return Result(null!, Framework.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            return Result(result);
        }
    }
}
