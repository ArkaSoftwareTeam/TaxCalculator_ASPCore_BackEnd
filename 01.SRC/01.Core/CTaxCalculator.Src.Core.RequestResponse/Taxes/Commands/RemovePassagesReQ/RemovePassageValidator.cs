using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.RemovePassagesReQ
{
    public class RemovePassageValidator : AbstractValidator<RemovePassage>
    {
        public RemovePassageValidator(ITranslator translator)
        {
            RuleFor(x => x.CityId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "CityId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "CityId", "0"]);


            RuleFor(x => x.PassageId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "PassageId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "PassageId", "0"]);
        }
    }
}
