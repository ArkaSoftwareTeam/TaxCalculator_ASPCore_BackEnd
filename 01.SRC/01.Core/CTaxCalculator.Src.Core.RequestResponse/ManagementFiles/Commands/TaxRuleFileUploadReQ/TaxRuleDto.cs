using CTaxCalculator.Src.Core.RequestResponse.ManagementFiles.Commands.TaxRuleDateTimeFileUploadReQ;
using CTaxCalculator.Src.Core.RequestResponse.ManagementFiles.Commands.TaxRulePriceFileUploadReQ;

namespace CTaxCalculator.Src.Core.RequestResponse.ManagementFiles.Commands.TaxRuleFileUploadReQ
{
    public class TaxRuleDto
    {
        public TaxRuleDateTimeDto? TaxRuleDateTime { get; set; }
        public PriceDto? TaxAmount { get; set; }
    }
}
