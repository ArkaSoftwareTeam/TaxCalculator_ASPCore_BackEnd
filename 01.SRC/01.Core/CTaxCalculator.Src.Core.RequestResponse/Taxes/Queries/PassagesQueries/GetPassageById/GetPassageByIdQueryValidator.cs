using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.PassagesQueries.GetPassageById
{

    /// <summary>
    /// Validator for the <see cref="GetPassageByIdQuery"/> class.
    /// This class ensures that the query parameters are valid before 
    /// processing the request to retrieve a Passage by its ID.
    /// </summary>
    public class GetPassageByIdQueryValidator : AbstractValidator<GetPassageByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPassageByIdQueryValidator"/> class.
        /// This constructor configures validation rules for the 
        /// <see cref="GetPassageByIdQuery"/> class using the specified translator.
        /// </summary>
        /// <param name="translator">An instance of <see cref="ITranslator"/> used for localizing validation messages.</param>
        public GetPassageByIdQueryValidator(ITranslator translator)
        {
            RuleFor(x => x.CityId)
                .NotEmpty()
                .WithMessage(translator["Required", nameof(GetPassageByIdQuery.CityId)]);

            RuleFor(x => x.PassageId)
                .NotEmpty()
                .WithMessage(translator["Required", nameof(GetPassageByIdQuery.PassageId)]);
        }
    }
}
