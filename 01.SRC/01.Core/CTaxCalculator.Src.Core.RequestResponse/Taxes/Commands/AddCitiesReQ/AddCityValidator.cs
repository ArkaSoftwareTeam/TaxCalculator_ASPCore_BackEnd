using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddCitiesReQ
{
    public class AddCityValidator:AbstractValidator<AddCity>
    {
        public AddCityValidator(ITranslator translator)
        {
            RuleFor(x => x.CityName)
                .NotNull().WithMessage(translator["Required", "CityName"])
                .MinimumLength(2).WithMessage(translator["MinimumLength", "CityName", "2"])
                .MaximumLength(120).WithMessage(translator["MaximumLength", "CityName", "120"]);
        }
    }
}
