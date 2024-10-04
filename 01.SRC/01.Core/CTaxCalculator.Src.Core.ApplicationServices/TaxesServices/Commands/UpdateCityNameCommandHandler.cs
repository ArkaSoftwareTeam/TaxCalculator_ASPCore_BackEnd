using CTaxCalculator.Framework.Core.ApplicationServices.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Commands;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeCityNameReQ;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Commands
{
    public class UpdateCityNameCommandHandler : CommandHandler<UpdateCityName>
    {
        private readonly ITaxCityCommandRepository _taxCityCommandRepository;
        public UpdateCityNameCommandHandler(ArkaSoftwareCMPOutServices mafiaOuterServices , ITaxCityCommandRepository taxCityCommandRepository) : base(mafiaOuterServices)
        {
            _taxCityCommandRepository = taxCityCommandRepository;
        }

        public override async Task<CommandResult> Handle(UpdateCityName command)
        {
            City city = await _taxCityCommandRepository.GetAsync(command.CityId);
            if(city is null)
                return await ResultAsync(Framework.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            city.ChangeCityName(command.CityName);
            await _taxCityCommandRepository.CommitAsync();
            return Ok();
        
        }
    }
}
