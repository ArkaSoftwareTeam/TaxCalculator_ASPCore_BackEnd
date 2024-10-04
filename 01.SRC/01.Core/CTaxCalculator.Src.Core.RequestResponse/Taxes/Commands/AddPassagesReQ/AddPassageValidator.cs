using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddPassagesReQ
{
    public class AddPassageValidator:AbstractValidator<AddPassage>
    {
        public AddPassageValidator(ITranslator translator)
        {
            RuleFor(x => x.CityId)
                .NotEmpty().WithMessage(translator["Required", "CityId"])
                .NotNull().WithMessage(translator["Required", "CityId"]);
            RuleFor(x => x.VehicleId)
                .NotEmpty().WithMessage(translator["Required", "VehicleId"])
                .NotNull().WithMessage(translator["Required", "VehicleId"]);
        }
    }
}
