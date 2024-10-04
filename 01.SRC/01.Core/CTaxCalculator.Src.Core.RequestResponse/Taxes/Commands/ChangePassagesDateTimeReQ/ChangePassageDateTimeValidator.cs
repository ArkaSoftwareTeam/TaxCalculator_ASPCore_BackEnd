using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangePassagesDateTimeReQ
{
    public class ChangePassageDateTimeValidator : AbstractValidator<ChangePassageDateTime>
    {
        public ChangePassageDateTimeValidator(ITranslator translator)
        {
            RuleFor(x => x.PassageDateTime)
                .NotNull().NotEmpty().WithMessage(translator["Required", "PassageDateTime"]);

            RuleFor(x => x.CityId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "CityId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "CityId", "0"]);

            RuleFor(x => x.PassageId)
                .NotNull().NotEmpty().WithMessage(translator["Required", "PassageId"])
                .GreaterThan(0).WithMessage(translator["GreaterThan", "PassageId", "0"]);
        }
    }
}
