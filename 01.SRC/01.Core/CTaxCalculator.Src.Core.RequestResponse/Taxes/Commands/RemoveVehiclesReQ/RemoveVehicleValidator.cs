using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.RemoveVehiclesReQ
{
    public class RemoveVehicleValidator : AbstractValidator<RemoveVehicle>
    {
        public RemoveVehicleValidator(ITranslator translator)
        {
            RuleFor(x => x.CityId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "CityId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "CityId", "0"]);

            RuleFor(x => x.VehicleId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "VehicleId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "VehicleId", "0"]);
        }
    }
}
