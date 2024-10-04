using CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.CitiesQueries.SearchCityByInputValue;
using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.PassagesQueries.SearchPassagesByInputValue
{
    /// <summary>
    /// Validator for the <see cref="SearchPassageQuery"/> class.
    /// This class ensures that the query parameters are valid before 
    /// processing the request to retrieve a Passage by its ID.
    /// </summary>
    public class SearchPassageQueryValidator : AbstractValidator<SearchPassageQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchPassageQueryValidator"/> class.
        /// This constructor configures validation rules for the 
        /// <see cref="SearchPassageQuery"/> class using the specified translator.
        /// </summary>
        /// <param name="translator">An instance of <see cref="ITranslator"/> used for localizing validation messages.</param>
        public SearchPassageQueryValidator(ITranslator translator)
        {
            RuleFor(x => x.PassageId)
                .NotEmpty()
                .WithMessage(translator["Required", nameof(SearchPassageQuery.PassageId)]);

            RuleFor(x => x.PassageDateTime)
               .NotEmpty()
               .WithMessage(translator["Required", nameof(SearchPassageQuery.PassageDateTime)]);
        }
    }
}
