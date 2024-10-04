using CTaxCalculator.Framework.Core.ApplicationServices.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Commands;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using CTaxCalculator.Src.Core.Domain.UsersAggregate.ValueOBJs;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddCitiesReQ;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Commands
{
    public class AddCityCommandHandler : CommandHandler<AddCity, object>
    {
        private readonly ITaxCityCommandRepository _taxCityCommandRepository;
        public AddCityCommandHandler(ArkaSoftwareCMPOutServices mafiaOuterServices , ITaxCityCommandRepository taxCityCommandRepository) : base(mafiaOuterServices)
        {
            _taxCityCommandRepository = taxCityCommandRepository;
        }

        public override async Task<CommandResult<object>> Handle(AddCity command)
        {
            try
            {
                City city = new City(new CityName(command.CityName));
                await _taxCityCommandRepository.InsertAsync(city);
                await _taxCityCommandRepository.CommitAsync();
                return Ok(new { Message = "City Add Is Success.", Name = city.CityName });
            }
            catch
            {

                return Result(new {Message="Create City is Problem, Please Check Input Data And try again!!!" }, Framework.Core.RequestResponse.Common.ApplicationServiceStatus.Exception);
            }
        }
    }
}
