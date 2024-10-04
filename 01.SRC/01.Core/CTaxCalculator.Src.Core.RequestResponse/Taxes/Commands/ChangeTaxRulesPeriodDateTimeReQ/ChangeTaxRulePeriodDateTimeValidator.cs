using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeTaxRulesPeriodDateTimeReQ
{
    public class ChangeTaxRulePeriodDateTimeValidator : AbstractValidator<ChangeTaxRulePeriodDateTime>
    {
        public ChangeTaxRulePeriodDateTimeValidator(ITranslator translator)
        {
            RuleFor(x => x.StartTime)
                .NotNull().NotEmpty().WithMessage(translator["Required", "StartTime"]);

            RuleFor(x => x.EndTime)
                .NotNull().NotEmpty().WithMessage(translator["Required", "EndTime"]);

            RuleFor(x => x.CityId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "CityId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "CityId", "0"]);

            RuleFor(x => x.TaxRuleId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "TaxRuleId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "TaxRuleId", "0"]);
        }
    }
}
