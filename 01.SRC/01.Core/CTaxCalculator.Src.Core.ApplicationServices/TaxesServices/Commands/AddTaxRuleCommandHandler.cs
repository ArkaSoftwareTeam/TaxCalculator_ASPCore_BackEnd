using CTaxCalculator.Framework.Core.ApplicationServices.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Commands;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.ValueOBJs;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.AddTaxRulesReQ;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Commands
{
    public class AddTaxRuleCommandHandler : CommandHandler<AddTaxRule, object>
    {
        private readonly ITaxCityCommandRepository _taxCityCommandRepository;
        public AddTaxRuleCommandHandler(ArkaSoftwareCMPOutServices mafiaOuterServices, ITaxCityCommandRepository taxCityCommandRepository) : base(mafiaOuterServices)
        {
            _taxCityCommandRepository = taxCityCommandRepository;
        }
        public override async Task<CommandResult<object>> Handle(AddTaxRule command)
        {
            City city = await _taxCityCommandRepository.GetGraphAsync(command.CityId);
            TaxRule taxRule = new(new TaxRuleDateTime(command.StartTime, command.EndTime), new Price(command.TaxAmount));
            city.AddTaxRule(taxRule);
            await _taxCityCommandRepository.CommitAsync();
            return Ok(new {Message = "TaxRule Is Added Success."});
        }
    }
}
