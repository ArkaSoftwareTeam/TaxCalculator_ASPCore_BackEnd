using CTaxCalculator.Framework.Core.ApplicationServices.Commands;
using CTaxCalculator.Framework.Core.Domain.ValueOBJs;
using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Utilities.OutServices.Services;
using CTaxCalculator.Src.Core.Contracts.TaxesRepositoryContracts.Commands;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangePassagesDateTimeReQ;

namespace CTaxCalculator.Src.Core.ApplicationServices.TaxesServices.Commands
{
    public class UpdatePassageDateTimeCommandHandler : CommandHandler<ChangePassageDateTime>
    {
        private readonly ITaxCityCommandRepository _taxCityCommandRepository;
        public UpdatePassageDateTimeCommandHandler(ArkaSoftwareCMPOutServices mafiaOuterServices, ITaxCityCommandRepository taxCityCommandRepository) : base(mafiaOuterServices)
        {
            _taxCityCommandRepository = taxCityCommandRepository;
        }

        public override async Task<CommandResult> Handle(ChangePassageDateTime command)
        {
            City city = await _taxCityCommandRepository.GetGraphAsync(command.CityId);
            if (city is null)
                return await ResultAsync(Framework.Core.RequestResponse.Common.ApplicationServiceStatus.NotFound);
            city.ChangePassageDateTime(new PId(command.PassageId) ,command.PassageDateTime);
            await _taxCityCommandRepository.CommitAsync();
            return Ok();
        }
    }
}
