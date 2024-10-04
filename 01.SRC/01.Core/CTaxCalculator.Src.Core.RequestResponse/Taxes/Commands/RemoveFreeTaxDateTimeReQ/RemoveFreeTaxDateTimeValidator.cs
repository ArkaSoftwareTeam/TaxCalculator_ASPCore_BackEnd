using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.RemoveFreeTaxDateTimeReQ
{
    public class RemoveFreeTaxDateTimeValidator : AbstractValidator<RemoveFreeTaxDateTime>
    {
        public RemoveFreeTaxDateTimeValidator(ITranslator translator)
        {

            RuleFor(x => x.CityId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "CityId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "CityId", "0"]);


            RuleFor(x => x.FreeTaxDateTimeId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "FreeTaxDateTimeId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "FreeTaxDateTimeId", "0"]);
        }
    }
}
