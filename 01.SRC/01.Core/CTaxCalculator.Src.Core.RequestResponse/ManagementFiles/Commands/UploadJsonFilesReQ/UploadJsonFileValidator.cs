using Extensions.Translations.Abstractions;
using FluentValidation;

namespace CTaxCalculator.Src.Core.RequestResponse.ManagementFiles.Commands.UploadJsonFilesReQ
{
    public class UploadJsonFileValidator:AbstractValidator<UploadJsonFile>  
    {
        public UploadJsonFileValidator(ITranslator translator)
        {
            RuleFor(x => x.File)
                .NotNull().NotEmpty().WithMessage(translator["Required", "Input Upload File Is Not Null"]);
        }
    }
}
