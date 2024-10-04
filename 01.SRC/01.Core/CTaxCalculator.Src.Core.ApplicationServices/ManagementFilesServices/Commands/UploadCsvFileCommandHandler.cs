using CTaxCalculator.Framework.Core.ApplicationServices.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Commands;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.ValueOBJs;
using CTaxCalculator.Src.Core.RequestResponse.ManagementFiles.Commands.UploadCsvFilesReQ;

namespace CTaxCalculator.Src.Core.ApplicationServices.ManagementFilesServices.Commands
{
    public class UploadCsvFileCommandHandler : CommandHandler<UploadCsvFile, string>
    {
        private readonly ITaxCityCommandRepository _taxCityCommandRepository;
        public UploadCsvFileCommandHandler(ArkaSoftwareCMPOutServices mafiaOuterServices , ITaxCityCommandRepository taxCityCommandRepository) : base(mafiaOuterServices)
        {
            _taxCityCommandRepository = taxCityCommandRepository;
        }

        public override async Task<CommandResult<string>> Handle(UploadCsvFile command)
        {
            var cities = await _taxCityCommandRepository.ParseCsvFile(command.File!);
            if(cities is null)
                return Result("Csv File OR Data Is Not Valid , Not Complete Please Check File And Try Again." , Framework.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            foreach (var city in cities) 
            {
                City cityInstance = new City(city.CityName);
                foreach (var taxRule in city.TaxRules)
                {
                    TaxRuleDateTime taxRuleDateTime = new(taxRule.TaxRuleDateTime.StartTime , taxRule.TaxRuleDateTime.EndTime);
                    Price taxRulePrice = new(taxRule.TaxAmount.Amount);
                    TaxRule taxRuleInstance = new(taxRuleDateTime , taxRulePrice);
                    cityInstance.AddTaxRule(taxRuleInstance);
                }
                await _taxCityCommandRepository.InsertAsync(cityInstance);
                await _taxCityCommandRepository.CommitAsync();
            }
            
            
            return Ok("City And Tax Rules Is Saved Success.");
            
        }
    }
}
