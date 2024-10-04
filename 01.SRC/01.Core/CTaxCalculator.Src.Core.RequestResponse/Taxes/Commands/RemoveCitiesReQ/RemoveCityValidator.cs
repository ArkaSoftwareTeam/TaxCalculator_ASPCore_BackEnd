using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.RemoveCitiesReQ
{
    public class RemoveCityValidator : AbstractValidator<RemoveCity>
    {
        public RemoveCityValidator(ITranslator translator)
        {
            RuleFor(x => x.CityId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "CityId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "CityId", "0"]);
        }
    }
}
