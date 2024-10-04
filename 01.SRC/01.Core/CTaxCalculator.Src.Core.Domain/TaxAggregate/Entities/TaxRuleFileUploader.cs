namespace CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities
{
    public class TaxRuleFileUploader
    {
        public long Id { get; set; }
        public string CityName { get; set; } = string.Empty;
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal TaxAmount { get; set; }
    }
}
