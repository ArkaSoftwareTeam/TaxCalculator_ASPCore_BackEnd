using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeTheCarIsCommutesReQ
{
    public class ChangeTheCarIsCommuteValidator : AbstractValidator<ChangeTheCarIsCommute>
    {
        public ChangeTheCarIsCommuteValidator(ITranslator translator)
        {
            
            RuleFor(x => x.PassageId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "PassageId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "PassageId", "0"]);


            RuleFor(x => x.VehicleId)
               .NotNull().NotEmpty().WithMessage(translator["Required", "VehicleId"])
               .GreaterThan(0).WithMessage(translator["GreaterThan", "VehicleId", "0"]);
        }
    }
}
