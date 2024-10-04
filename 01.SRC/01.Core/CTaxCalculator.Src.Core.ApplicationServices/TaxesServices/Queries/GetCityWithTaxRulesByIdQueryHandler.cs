using CTaxCalculator.Framework.Core.ApplicationServices.Queries;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.ModelJoinQueries.GetCityWithTaxRulesById;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Queries
{
    public class GetCityWithTaxRulesByIdQueryHandler : QueryHandler<GetCityWithTaxRulesByIdQuery, CityWithTaxRulesQri>
    {
        private readonly ITaxCityQueryRepository _taxCityQueryRepository;

        public GetCityWithTaxRulesByIdQueryHandler(ArkaSoftwareCMPOutServices mafiaOuterService , ITaxCityQueryRepository taxCityQueryRepository) : base(mafiaOuterService)
        {
            _taxCityQueryRepository = taxCityQueryRepository;
        }

        public override async Task<QueryResult<CityWithTaxRulesQri>> Handle(GetCityWithTaxRulesByIdQuery query)
        {
            var result =await _taxCityQueryRepository.GetCityWithTaxRulesByIdExecuteAsync(query);
            if(result is null)
                return Result(null! , Framework.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            return Result(result);
        }
    }
}
