using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.RemoveFreeTaxDateTimeReQ
{
    public class RemoveFreeTaxDateTime : ICommand, IWebRequest
    {
        public long CityId { get; set; }
        public long FreeTaxDateTimeId { get; set; }
        public string Path => "api/TaxCalculator/FreeTaxDateTime/RemoveFreeTaxDateTimeById";
    }
}
