using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddTaxRulesReQ
{
    public class AddTaxRuleValidator:AbstractValidator<AddTaxRule>
    {
        public AddTaxRuleValidator(ITranslator translator)
        {
            RuleFor(x => x.StartTime)
                .NotEmpty().WithMessage(translator["Required", "StartTime"])
                .NotNull().WithMessage(translator["Required", "StartTime"]);
            RuleFor(x => x.EndTime)
                .NotEmpty().WithMessage(translator["Required", "EndTime"])
                .NotNull().WithMessage(translator["Required", "EndTime"]);
            RuleFor(x => x.TaxAmount)
                .NotEmpty().WithMessage(translator["Required", "TaxAmountPrice"]);
        }
    }
}
