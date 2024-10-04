using CTaxCalculator.Framework.Core.ApplicationServices.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Commands;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using CTaxCalculator.Src.Core.Domain.VehicleAggregate.Enumerations;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeVehiclesTypeReQ;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Commands
{
    public class UpdateVehiclesTypeCommandHandler : CommandHandler<ChangeVehicleType>
    {
        private readonly ITaxCityCommandRepository _taxCityCommandRepository;
        public UpdateVehiclesTypeCommandHandler(ArkaSoftwareCMPOutServices mafiaOuterServices, ITaxCityCommandRepository taxCityCommandRepository) : base(mafiaOuterServices)
        {
            _taxCityCommandRepository = taxCityCommandRepository;
        }

        public override async Task<CommandResult> Handle(ChangeVehicleType command)
        {
            City city = await _taxCityCommandRepository.GetGraphAsync(command.CityId);
            if (city is null)
                return await ResultAsync(Framework.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            city.ChangeVehicleType(new Framework.Core.Domain.ValueOBJs.PId(command.VehicleId), (TollFreeVehicles)command.VehicleType);
            await _taxCityCommandRepository.CommitAsync();
            return Ok();
        }
    }
}
