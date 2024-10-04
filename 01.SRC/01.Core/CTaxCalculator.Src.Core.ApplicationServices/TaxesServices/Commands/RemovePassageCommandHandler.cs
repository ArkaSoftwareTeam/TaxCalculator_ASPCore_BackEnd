using CTaxCalculator.Framework.Core.ApplicationServices.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Commands;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.RemovePassagesReQ;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Commands
{
    public class RemovePassageCommandHandler : CommandHandler<RemovePassage>
    {
        private readonly ITaxCityCommandRepository _taxCityCommandRepository;
        public RemovePassageCommandHandler(ArkaSoftwareCMPOutServices mafiaOuterServices, ITaxCityCommandRepository taxCityCommandRepository) : base(mafiaOuterServices)
        {
            _taxCityCommandRepository = taxCityCommandRepository;
        }

        public override async Task<CommandResult> Handle(RemovePassage command)
        {
            City city = await _taxCityCommandRepository.GetGraphAsync(command.CityId);
            if (city is null)
                return await ResultAsync(Framework.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            city.RemovePassage(command.PassageId);
            await _taxCityCommandRepository.CommitAsync();
            return Ok();
        }
    }
}
