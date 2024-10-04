using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.RemoveTaxRulesReQ
{
    public class RemoveTaxRuleValidator : AbstractValidator<RemoveTaxRule>
    {
        public RemoveTaxRuleValidator(ITranslator translator)
        {

            RuleFor(x => x.CityId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "CityId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "CityId", "0"]);


            RuleFor(x => x.TaxRuleId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "TaxRuleId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "TaxRuleId", "0"]);
        }
    }
}
