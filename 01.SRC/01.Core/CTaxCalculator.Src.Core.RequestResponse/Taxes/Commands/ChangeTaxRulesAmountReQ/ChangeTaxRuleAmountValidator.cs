using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeTaxRulesAmountReQ
{
    public class ChangeTaxRuleAmountValidator : AbstractValidator<ChangeTaxRuleAmount>
    {
        public ChangeTaxRuleAmountValidator(ITranslator translator)
        {
            RuleFor(x => x.TaxRuleAmount)
                .NotNull().NotEmpty().WithMessage(translator["Required", "TaxRuleAmount"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "TaxRuleAmount", "0"]);

            RuleFor(x => x.CityId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "CityId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "CityId", "0"]);

            RuleFor(x => x.TaxRuleId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "TaxRuleId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "TaxRuleId", "0"]);
        }
    }
}
