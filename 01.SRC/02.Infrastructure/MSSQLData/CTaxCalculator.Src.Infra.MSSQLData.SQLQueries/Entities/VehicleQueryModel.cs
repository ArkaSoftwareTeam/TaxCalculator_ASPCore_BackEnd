using CTaxCalculator.Src.Core.Domain.VehicleAggregate.Enumerations;

namespace CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Entities
{
    public class VehicleQueryModel
    {
        public long VehicleId { get; set; }
        public TollFreeVehicles VehicleType { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public long CityId { get; set; }
        public CityQueryModel? City { get; set; }
        public decimal LastTaxPassageAmount { get; set; }
        public decimal TotalTaxAmount { get; set; }


        public List<PassageQueryModel> Passages { get; set; } = new List<PassageQueryModel>();
    }
}
