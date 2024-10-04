using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeTaxRulesPeriodDateTimeReQ
{
    public class ChangeTaxRulePeriodDateTime : ICommand, IWebRequest
    {
        public long CityId { get; set; }
        public long TaxRuleId { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public string Path => "api/TaxCalculator/TaxRule/UpdateTaxRulePeriodDateTime";
    }
}
