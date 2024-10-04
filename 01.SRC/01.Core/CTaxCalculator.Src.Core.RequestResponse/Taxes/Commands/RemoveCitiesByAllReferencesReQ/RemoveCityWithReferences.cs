using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.RemoveCitiesByAllReferencesReQ
{
    public class RemoveCityWithReferences : ICommand, IWebRequest
    {
        public long CityId { get; set; }
        public string Path => "api/TaxCalculator/City/RemoveCityWithAllReferencesById";
    }
}
