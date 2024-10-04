using CTaxCalculator.Framework.Core.ApplicationServices.Commands;
using CTaxCalculator.Framework.Core.Domain.ValueOBJs;
using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Commands;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using CTaxCalculator.Src.Core.Domain.VehicleAggregate.Entities;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddPassagesReQ;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Commands
{
    public class AddPassageCommandHandler : CommandHandler<AddPassage, object>
    {
        private readonly ITaxCityCommandRepository _taxCityCommandRepository;
        public AddPassageCommandHandler(ArkaSoftwareCMPOutServices mafiaOuterServices , ITaxCityCommandRepository taxCityCommandRepository) : base(mafiaOuterServices)
        {
            _taxCityCommandRepository = taxCityCommandRepository;
        }

        public override async Task<CommandResult<object>> Handle(AddPassage command)
        {
            City city = await _taxCityCommandRepository.GetGraphAsync(command.CityId);
            Passage passage = new(DateTime.UtcNow , new PId(command.VehicleId));
            Vehicle vehicle = city.Vehicles.FirstOrDefault(x => x.Id == command.VehicleId)!;
            vehicle.AddPassage(passage);
            city.AddPassage(passage);
            city.CalculateTaxAmountWithRule();
            city.GetGreatThanTaxPriceInDifferentPassages(command.VehicleId);
            await _taxCityCommandRepository.CommitAsync();
            return Ok(new { Message="Passage Added Is Success." , PassageCreatedDateTime = $"{DateTime.UtcNow.ToString("yyyy/MM/dd - HH:mm")}" });
            
        }
    }
}
