using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.VehiclesQueries.SearchVehicles
{
    /// <summary>
    /// Validator for <see cref="SearchVehiclesQuery"/> to ensure the input parameters are valid.
    /// </summary>
    public class SearchVehiclesQueryValidator : AbstractValidator<SearchVehiclesQuery>
    {
        public SearchVehiclesQueryValidator(ITranslator translator)
        {
            // Validate the PlateNumber length
            RuleFor(x => x.PlateNumber)
                .MinimumLength(2).WithMessage(translator["MinimumLength", "PlateNumber", "2"])
                .MaximumLength(12).WithMessage(translator["MaximumLength", "PlateNumber", "12"]);

            // Validate the CityName length
            RuleFor(x => x.CityName)
                .MinimumLength(2).WithMessage(translator["MinimumLength", "CityName", "2"])
                .MaximumLength(120).WithMessage(translator["MaximumLength", "CityName", "120"]);

            // Optional: Add validation for VehicleType if needed
            RuleFor(x => x.VehicleType)
                .MaximumLength(50).WithMessage(translator["MaximumLength", "VehicleType", "50"]);
        }
    }
}
