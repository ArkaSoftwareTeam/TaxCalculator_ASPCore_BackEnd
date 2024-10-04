using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeVehiclesPlateNumberReQ
{
    public class ChangeVehiclePlateNumberValidator : AbstractValidator<ChangeVehiclePlateNumber>
    {
        public ChangeVehiclePlateNumberValidator(ITranslator translator)
        {
            RuleFor(x => x.CityId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "CityId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "CityId", "0"]);

            RuleFor(x => x.VehicleId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "VehicleId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "VehicleId", "0"]);

            RuleFor(x => x.VehiclePlateNumber)
                .NotNull().NotEmpty().WithMessage(translator["Required", "VehiclePlateNumber"])
                .MinimumLength(6).WithMessage(translator["MinimumLength", "VehiclePlateNumber", "6"])
                .MaximumLength(6).WithMessage(translator["MaximumLength", "PlateNumber", "6"]);
        }
    }
}
