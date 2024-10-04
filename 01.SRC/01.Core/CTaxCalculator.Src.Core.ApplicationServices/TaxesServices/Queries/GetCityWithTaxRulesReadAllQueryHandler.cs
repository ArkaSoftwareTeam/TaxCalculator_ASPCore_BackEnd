using CTaxCalculator.Framework.Core.ApplicationServices.Queries;
using CTaxCalculator.Framework.Core.RequestResponse.Queries;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Queries;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.ModelJoinQueries.GetCityWithTaxRulesAll;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Queries
{
    public class GetCityWithTaxRulesReadAllQueryHandler : QueryHandler<GetCityWithTaxRulesReadAllQuery, List<CityWithAllTaxRulesQir>>
    {
        private readonly ITaxCityQueryRepository _taxCityQueryRepository;

        public GetCityWithTaxRulesReadAllQueryHandler(ArkaSoftwareCMPOutServices mafiaOuterService, ITaxCityQueryRepository taxCityQueryRepository) : base(mafiaOuterService)
        {
            _taxCityQueryRepository = taxCityQueryRepository;
        }

        public override async Task<QueryResult<List<CityWithAllTaxRulesQir>>> Handle(GetCityWithTaxRulesReadAllQuery query)
        {
            var result = await _taxCityQueryRepository.GetAllCityWithTaxRulesExecuteAsync(query);
            if (result is null)
                return Result(null!, Framework.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            return Result(result);
        }
    }
}
