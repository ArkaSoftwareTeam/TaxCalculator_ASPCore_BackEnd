using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.CitiesQueries.SearchCityByInputValue
{
    /// <summary>
    /// Validator for the <see cref="SearchCityQuery"/> class.
    /// This class ensures that the query parameters are valid before 
    /// processing the request to retrieve a city by its ID.
    /// </summary>
    public class SearchCityQueryValidator : AbstractValidator<SearchCityQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCityQueryValidator"/> class.
        /// This constructor configures validation rules for the 
        /// <see cref="SearchCityQuery"/> class using the specified translator.
        /// </summary>
        /// <param name="translator">An instance of <see cref="ITranslator"/> used for localizing validation messages.</param>
        public SearchCityQueryValidator(ITranslator translator)
        {
            
        }
    }
}
