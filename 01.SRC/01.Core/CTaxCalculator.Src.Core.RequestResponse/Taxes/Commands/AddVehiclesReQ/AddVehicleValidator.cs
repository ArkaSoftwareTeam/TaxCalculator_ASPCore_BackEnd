using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddVehiclesReQ
{
    public class AddVehicleValidator:AbstractValidator<AddVehicle>
    {
        public AddVehicleValidator(ITranslator translator)
        {
            RuleFor(x => x.VehicleType)
                .NotEmpty()
                .NotNull().WithMessage(translator["Required", "PlateNumber Is Required"]);
                
            RuleFor(x => x.PlateNumber)
                .NotEmpty().NotNull().WithMessage(translator["Required", "PlateNumber Is Required"])
                .MinimumLength(5).WithMessage(translator["MinimumLength", "PlateNumber", "5"])
                .MaximumLength(10).WithMessage(translator["MaximumLength", "PlateNumber", "10"]);
        }
    }
}
