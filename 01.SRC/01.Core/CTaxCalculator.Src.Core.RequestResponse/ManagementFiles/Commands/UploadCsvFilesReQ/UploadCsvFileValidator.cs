using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.ManagementFiles.Commands.UploadCsvFilesReQ
{
    public class UploadCsvFileValidator : AbstractValidator<UploadCsvFile>
    {
        public UploadCsvFileValidator(ITranslator translator)
        {
            RuleFor(x => x.File)
                .NotNull().NotEmpty().WithMessage(translator["Required", "Input Upload File Is Not Null"]);
        }
    }
}
