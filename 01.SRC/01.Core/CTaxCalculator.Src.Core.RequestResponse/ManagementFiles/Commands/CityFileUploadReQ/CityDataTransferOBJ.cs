using CTaxCalculator.Src.Core.RequestResponse.ManagementFiles.Commands.TaxRuleFileUploadReQ;

namespace CTaxCalculator.Src.Core.RequestResponse.ManagementFiles.Commands.CityFileUploadReQ
{
    public class CityDataTransferOBJ
    {
        public long Id { get; set; }
        public string CityName { get; set; } = string.Empty;
        public List<TaxRuleDto> TaxRules { get; set; } = new List<TaxRuleDto>();
    }
}
