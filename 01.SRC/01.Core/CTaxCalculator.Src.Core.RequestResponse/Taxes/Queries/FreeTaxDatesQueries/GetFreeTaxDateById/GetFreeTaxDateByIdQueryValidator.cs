using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Queries.FreeTaxDatesQueries.GetFreeTaxDateById
{

    /// <summary>
    /// Validates the <see cref="GetFreeTaxDateByIdQuery"/> to ensure that the
    /// FreeTaxDateId is provided and is a valid positive number.
    /// </summary>
    /// <remarks>
    /// This class inherits from <see cref="AbstractValidator{T}"/> and utilizes the FluentValidation
    /// library to implement validation rules for the <see cref="GetFreeTaxDateByIdQuery"/> class.
    /// It ensures that the FreeTaxDateId property meets the necessary criteria before processing
    /// the request to retrieve a free tax date.
    /// </remarks>
    public class GetFreeTaxDateByIdQueryValidator : AbstractValidator<GetFreeTaxDateByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetFreeTaxDateByIdQueryValidator"/> class.
        /// </summary>
        /// <param name="translator">The translator used for localized validation messages.</param>
        public GetFreeTaxDateByIdQueryValidator(ITranslator translator)
        {
            RuleFor(x => x.FreeTaxDateId)
                .NotEmpty().WithMessage(translator["Required", "FreeTaxDateId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "FreeTaxDateId", "0"]);
        }
    }
}
