using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.VehiclesQueries.GetVehiclesById
{
    /// <summary>
    /// Validator for <see cref="GetVehicleByIdQuery"/> to ensure valid input values.
    /// This class validates the vehicle ID to ensure it meets the necessary criteria.
    /// </summary>
    public class GetVehicleByIdQueryValidator : AbstractValidator<GetVehicleByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetVehicleByIdQueryValidator"/> class.
        /// </summary>
        /// <param name="translator">An instance of <see cref="ITranslator"/> for message localization.</param>
        public GetVehicleByIdQueryValidator(ITranslator translator)
        {
            RuleFor(x => x.VehicleId)
                .NotEmpty().WithMessage(translator["Required", "VehicleId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "VehicleId", "0"]);
        }
    }
}
