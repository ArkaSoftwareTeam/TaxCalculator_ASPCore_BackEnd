using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.CitiesQueries.GetCityById
{

    /// <summary>
    /// Validator for the <see cref="GetCityByIdQuery"/> class.
    /// This class ensures that the query parameters are valid before 
    /// processing the request to retrieve a city by its ID.
    /// </summary>
    public class GetCityByIdQueryValidator : AbstractValidator<GetCityByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCityByIdQueryValidator"/> class.
        /// This constructor configures validation rules for the 
        /// <see cref="GetCityByIdQuery"/> class using the specified translator.
        /// </summary>
        /// <param name="translator">An instance of <see cref="ITranslator"/> used for localizing validation messages.</param>
        public GetCityByIdQueryValidator(ITranslator translator)
        {
            RuleFor(x => x.CityId)
                .NotEmpty()
                .WithMessage(translator["Required", nameof(GetCityByIdQuery.CityId)]);
        }
    }
}
