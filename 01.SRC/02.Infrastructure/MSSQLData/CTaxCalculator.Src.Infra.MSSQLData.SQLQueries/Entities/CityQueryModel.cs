namespace CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Entities
{
    public partial class CityQueryModel
    {
        public long Id { get; set; }
        public string CityName { get; set; } = string.Empty;
        public List<TaxRuleQueryModel> TaxRules { get; set; } = new List<TaxRuleQueryModel>();

        public List<VehicleQueryModel> Vehicles { get; set; } = new List<VehicleQueryModel>();

    }
}
