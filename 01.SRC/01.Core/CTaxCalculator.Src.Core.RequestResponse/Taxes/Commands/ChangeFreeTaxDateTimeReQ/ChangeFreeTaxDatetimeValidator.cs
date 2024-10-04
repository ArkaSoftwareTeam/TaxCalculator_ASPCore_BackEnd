using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeFreeTaxDateTimeReQ
{
    public class ChangeFreeTaxDatetimeValidator:AbstractValidator<ChangeFreeTaxDatetime>
    {
        public ChangeFreeTaxDatetimeValidator(ITranslator translator)
        {
            RuleFor(x => x.FreeTaxDateTime)
                .NotNull().NotEmpty().WithMessage(translator["Required", "FreeTaxDateTime"]);

            RuleFor(x => x.CityId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "CityId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "CityId", "0"]);

            RuleFor(x => x.FreeTaxDateTimeId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "FreeTaxDateTimeId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "FreeTaxDateTime", "0"]);
        }
    }
}
