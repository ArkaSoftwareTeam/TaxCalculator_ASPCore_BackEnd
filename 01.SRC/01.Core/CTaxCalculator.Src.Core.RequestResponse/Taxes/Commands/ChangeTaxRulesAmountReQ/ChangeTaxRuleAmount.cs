using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangeTaxRulesAmountReQ
{
    public class ChangeTaxRuleAmount : ICommand, IWebRequest
    {
        public long CityId { get; set; }
        public long TaxRuleId { get; set; }
        public decimal TaxRuleAmount { get; set; }

        public string Path => "api/TaxCalculator/FreeTaxDateTime/UpdateDateTime";
    }
}
