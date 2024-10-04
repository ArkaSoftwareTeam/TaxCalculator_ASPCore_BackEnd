using CTaxCalculator.Framework.Core.ApplicationServices.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Utilities.OutServices.Generator;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Commands;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using CTaxCalculator.Src.Core.RequestResponse.ManagementFiles.Commands.UploadJsonFilesReQ;

namespace CTaxCalculator.Src.Core.ApplicationServices.ManagementFilesServices.Commands
{
    public class UploadJsonFileCommandHandler : CommandHandler<UploadJsonFile, string>
    {
        private readonly ITaxCityCommandRepository _taxCityCommandRepository;
        private readonly IdGenerator _idGenerator;
        public UploadJsonFileCommandHandler(
            ArkaSoftwareCMPOutServices mafiaOuterServices , 
            ITaxCityCommandRepository taxCityCommandRepository ,
            IdGenerator idGenerator
            ) : base(mafiaOuterServices)
        {
            _taxCityCommandRepository = taxCityCommandRepository;
            _idGenerator = idGenerator;
        }

        public override async Task<CommandResult<string>> Handle(UploadJsonFile command)
        {
            string CommandHanderMessageResult = string.Empty;
            var records = await _taxCityCommandRepository.ParseJsonFile(command.File!);
            foreach (var record in records)
            {
                City city = await _taxCityCommandRepository.GetAsync(record.Id);
                if(city is null)
                {
                    City createNewCityInstance = new City(record.CityName.Value);
                    foreach (var taxRule in record.TaxRules)
                    {
                        if (!taxRule.IsValid())
                            return await ResultAsync("Value In Json File Is Not Valid", Framework.Core.RequestResponse.Common.ApplicationServiceStatus.ValidationError);
                        TaxRule newTaxRule = new(taxRule.TaxRuleDateTime, new Domain.TaxAggregate.ValueOBJs.Price(taxRule.TaxAmount.Amount));
                        createNewCityInstance.AddTaxRule(newTaxRule);
                    }
                    await _taxCityCommandRepository.InsertAsync(createNewCityInstance);
                    await _taxCityCommandRepository.CommitAsync();
                    CommandHanderMessageResult = "New City With Tax Rules Is Created Success.";
                }
                else
                {
                    CommandHanderMessageResult = $"City With Id : {record.Id} Is Exist In DataSource. Please change And Update Rule With Another Way.";
                }
                
            }
            return Ok(CommandHanderMessageResult);
        }

        
    }
}
