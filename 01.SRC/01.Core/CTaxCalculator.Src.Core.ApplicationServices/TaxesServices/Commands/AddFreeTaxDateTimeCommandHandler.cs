using CTaxCalculator.Framework.Core.ApplicationServices.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Commands;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddFreeTaxDateTimeReQ;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Commands
{
    public class AddFreeTaxDateTimeCommandHandler : CommandHandler<AddFreeTaxDateTime, object>
    {

        private readonly ITaxCityCommandRepository _taxCityCommandRepository;
        public AddFreeTaxDateTimeCommandHandler(ArkaSoftwareCMPOutServices mafiaOuterServices, ITaxCityCommandRepository taxCityCommandRepository) : base(mafiaOuterServices)
        {
            _taxCityCommandRepository = taxCityCommandRepository;
        }

        public override async Task<CommandResult<object>> Handle(AddFreeTaxDateTime command)
        {
            City city = await _taxCityCommandRepository.GetGraphAsync(command.CityId);
            DateTime InitDateTime = new DateTime(command.Date.Year, command.Date.Month, command.Date.Day, command.Date.Hour, command.Date.Minute, command.Date.Second);
            FreeTaxDate freeTaxDate = new(new Domain.TaxAggregate.ValueOBJs.FreeTaxDateTime(InitDateTime));
            city.AddFreeTaxDate(freeTaxDate);
            await _taxCityCommandRepository.CommitAsync();
            return Ok(new { Message = "Create Free Tax Datetime Is Success."  , FreeTaxDatetimeValue = $"{InitDateTime.ToString("yyyy/MM/dd - HH:mm:ss")}"});
        }
    }
}
