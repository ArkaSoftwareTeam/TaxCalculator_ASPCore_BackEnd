using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.RemoveCitiesReQ
{
    public class RemoveCity : ICommand, IWebRequest
    {
        public long CityId { get; set; }
        public string Path => "api/TaxCalculator/City/RemoveCityById";
    }
}
