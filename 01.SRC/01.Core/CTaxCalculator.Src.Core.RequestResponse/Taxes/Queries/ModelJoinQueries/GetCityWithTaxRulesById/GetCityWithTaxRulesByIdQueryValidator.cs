using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.ModelJoinQueries.GetCityWithTaxRulesById
{
    /// <summary>
    /// Validates the <see cref="GetCityWithTaxRulesByIdQuery"/> to ensure that the input parameters are valid.
    /// This class uses FluentValidation to enforce validation rules for the CityId property.
    /// </summary>
    public class GetCityWithTaxRulesByIdQueryValidator : AbstractValidator<GetCityWithTaxRulesByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCityWithTaxRulesByIdQueryValidator"/> class.
        /// </summary>
        /// <param name="translator">The translator used for localizing validation messages.</param>
        public GetCityWithTaxRulesByIdQueryValidator(ITranslator translator)
        {
            RuleFor(x => x.CityId)
                .NotEmpty().WithMessage(translator["Required", "CityId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "CityId", "0"]);
        }
    }
}
