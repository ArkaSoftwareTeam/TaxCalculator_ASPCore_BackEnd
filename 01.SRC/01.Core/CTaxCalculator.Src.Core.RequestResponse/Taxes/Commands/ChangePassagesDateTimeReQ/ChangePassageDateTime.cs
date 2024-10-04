using CTaxCalculator.Framework.Core.RequestResponse.Commands;
using CTaxCalculator.Framework.Core.RequestResponse.Endpoints;

namespace CTaxCalculator.Src.Core.RequestResponse.Taxes.Commands.ChangePassagesDateTimeReQ
{
    public class ChangePassageDateTime : ICommand, IWebRequest
    {
        public long CityId { get; set; }
        public long PassageId { get; set; }
        public DateTime PassageDateTime { get; set; }

        public string Path => "api/TaxCalculator/Passage/UpdatePassageDateTime";
    }
}
