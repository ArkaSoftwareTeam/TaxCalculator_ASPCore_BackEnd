namespace CTaxCalculator.Src.Infra.MSSQLData.SQLQueries.Entities
{
    public class PassageQueryModel
    {
        public long Id { get; set; }
        public long VehicleId { get; set; }
        public VehicleQueryModel? Vehicle { get; set; }
        public DateTime PassageDateTime { get; set; }
    }
}
