using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.RemoveTaxRulesReQ
{
    public class RemoveTaxRule : ICommand, IWebRequest
    {
        public long CityId { get; set; }
        public long TaxRuleId { get; set; }
        public string Path => "api/TaxCalculator/Passage/UpdateVehicle";
    }
}
