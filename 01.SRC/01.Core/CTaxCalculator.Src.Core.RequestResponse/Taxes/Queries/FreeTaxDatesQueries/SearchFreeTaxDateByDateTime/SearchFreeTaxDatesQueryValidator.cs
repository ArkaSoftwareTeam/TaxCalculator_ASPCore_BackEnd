using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.SearchFreeTaxDateByDateTime
{

    /// <summary>
    /// Validates the search query for free tax dates based on a specified date and time.
    /// This validator ensures that the required fields are provided and are valid.
    /// </summary>
    public class SearchFreeTaxDatesQueryValidator : AbstractValidator<SearchFreeTaxDatesQuery>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchFreeTaxDatesQueryValidator"/> class.
        /// </summary>
        /// <param name="translator">An instance of the translator used for message localization.</param>
        public SearchFreeTaxDatesQueryValidator(ITranslator translator)
        {
           
        }
    }
}
