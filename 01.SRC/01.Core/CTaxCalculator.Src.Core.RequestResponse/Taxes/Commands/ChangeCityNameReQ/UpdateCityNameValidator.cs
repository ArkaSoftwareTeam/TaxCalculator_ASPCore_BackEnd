using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeCityNameReQ
{
    /// <summary>
    /// Validator for <see cref="UpdateCityName"/> to ensure the input parameters are valid.
    /// </summary>
    public class UpdateCityNameValidator : AbstractValidator<UpdateCityName>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCityNameValidator"/> class.
        /// </summary>
        /// <param name="translator">The translator used for validation messages.</param>
        public UpdateCityNameValidator(ITranslator translator)
        {
            RuleFor(x => x.CityName)
                .NotNull().WithMessage(translator["Required", "CityName"])
                .MinimumLength(2).WithMessage(translator["MinimumLength", "CityName", "2"])
                .MaximumLength(120).WithMessage(translator["MaximumLength", "CityName", "120"]);
        }
    }
}
