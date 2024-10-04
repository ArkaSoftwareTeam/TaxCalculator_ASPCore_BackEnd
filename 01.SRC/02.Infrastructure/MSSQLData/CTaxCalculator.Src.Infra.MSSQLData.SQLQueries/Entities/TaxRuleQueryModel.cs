namespace CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Entities
{
    public class TaxRuleQueryModel
    {
        public long Id { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public decimal TaxAmount { get; set; }

        public long CityId { get; set; }
        public CityQueryModel City { get; set; }

    }
}
