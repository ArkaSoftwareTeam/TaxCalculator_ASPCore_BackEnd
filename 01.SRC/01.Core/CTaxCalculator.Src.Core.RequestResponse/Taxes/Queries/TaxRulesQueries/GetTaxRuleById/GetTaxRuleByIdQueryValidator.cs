using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.TaxRulesQueries.GetTaxRuleById
{
    /// <summary>
    /// Validates the <see cref="GetTaxRuleByIdQuery"/> to ensure that the input parameters are valid.
    /// This class uses FluentValidation to define the validation rules for the query.
    /// </summary>
    public class GetTaxRuleByIdQueryValidator : AbstractValidator<GetTaxRuleByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTaxRuleByIdQueryValidator"/> class.
        /// </summary>
        /// <param name="translator">An instance of <see cref="ITranslator"/> for localization of validation messages.</param>
        public GetTaxRuleByIdQueryValidator(ITranslator translator)
        {
            RuleFor(x => x.TaxRuleId)
                .NotNull().WithMessage(translator["Required", "TaxRuleId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "TaxRuleId", "0"]);
        }
    }
}
