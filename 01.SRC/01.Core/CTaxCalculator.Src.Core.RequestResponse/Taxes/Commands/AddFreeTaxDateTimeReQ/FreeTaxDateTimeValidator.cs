using Extensions.Translations.Abstractions;
using FluentValidation;
namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddFreeTaxDateTimeReQ
{
    public class FreeTaxDateTimeValidator:AbstractValidator<AddFreeTaxDateTime>
    {
        public FreeTaxDateTimeValidator(ITranslator translator)
        {
            RuleFor(x => x.CityId)
                .NotEmpty().WithMessage(translator["Required", "CityId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "CityId", "0"]);

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage(translator["Required", "FreeTaxDateTime"]);
        }
    }
}
