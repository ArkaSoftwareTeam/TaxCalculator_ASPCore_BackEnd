using CTaxCalculator.Framework.Core.ApplicationServices.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Commands;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.RemoveCitiesReQ;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Commands
{
    public class RemoveCityCommandHandler : CommandHandler<RemoveCity>
    {
        private readonly ITaxCityCommandRepository _taxCityCommandRepository;
        public RemoveCityCommandHandler(ArkaSoftwareCMPOutServices mafiaOuterServices, ITaxCityCommandRepository taxCityCommandRepository) : base(mafiaOuterServices)
        {
            _taxCityCommandRepository = taxCityCommandRepository;
        }

        public override async Task<CommandResult> Handle(RemoveCity command)
        {
            City city = await _taxCityCommandRepository.GetGraphAsync(command.CityId);
            if (city is null)
                return await ResultAsync(Framework.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            _taxCityCommandRepository.Delete(command.CityId);
            await _taxCityCommandRepository.CommitAsync();
            return Ok();
        }
    }
}
