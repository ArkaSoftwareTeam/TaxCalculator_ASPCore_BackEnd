using CTaxCalculator.Framework.Core.ApplicationServices.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Commands;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using CTaxCalculator.Src.Core.Domain.VehicleAggregate.Entities;
using CTaxCalculator.Src.Core.Domain.VehicleAggregate.Enumerations;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddVehiclesReQ;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Commands
{
    public class AddVehicleCommandHandler : CommandHandler<AddVehicle, string>
    {
        private readonly ITaxCityCommandRepository _taxCityCommandRepository;
        public AddVehicleCommandHandler(ArkaSoftwareCMPOutServices mafiaOuterServices , ITaxCityCommandRepository taxCityCommandRepository) : base(mafiaOuterServices)
        {
            _taxCityCommandRepository = taxCityCommandRepository;
        }

        public override async Task<CommandResult<string>> Handle(AddVehicle command)
        {
            try
            {
                City city = await _taxCityCommandRepository.GetGraphAsync(command.CityId);
                if (city is null)
                    return Result("City With Id Is Not Defind", Framework.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
                Vehicle vehicle = new(
                    (TollFreeVehicles)Enum.Parse(typeof(TollFreeVehicles), command.VehicleType.ToLower()),
                    new Domain.TaxAggregate.ValueOBJs.PlateNumber(command.PlateNumber)
                    );
                city!.AddVehicle(vehicle);
                await _taxCityCommandRepository.CommitAsync();
                return Ok("Vehicle Added Is Success.");
            }
            catch
            {
                return Result("Vehicle Create Is Problem Please Check Input Value And Try Again!!", Framework.Core.RequestResponse.Common.ApplicationServiceStatus.Exception);
            }

        }
    }
}
