using CTaxCalculator.Framework.Core.ApplicationServices.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Commands;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.ValueOBJs;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeVehiclesPlateNumberReQ;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Commands
{
    public class UpdateVehiclesPlateNumberCommandHandler : CommandHandler<ChangeVehiclePlateNumber>
    {
        private readonly ITaxCityCommandRepository _taxCityCommandRepository;
        public UpdateVehiclesPlateNumberCommandHandler(ArkaSoftwareCMPOutServices mafiaOuterServices, ITaxCityCommandRepository taxCityCommandRepository) : base(mafiaOuterServices)
        {
            _taxCityCommandRepository = taxCityCommandRepository;
        }

        public override async Task<CommandResult> Handle(ChangeVehiclePlateNumber command)
        {
            City city = await _taxCityCommandRepository.GetGraphAsync(command.CityId);
            if (city is null)
                return await ResultAsync(Framework.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            city.ChangeVehiclePlateNumber(new Framework.Core.Domain.ValueOBJs.PId(command.VehicleId) ,new PlateNumber(command.VehiclePlateNumber));
            await _taxCityCommandRepository.CommitAsync();
            return Ok();
        }
    }
}
