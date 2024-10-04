using CTaxCalculator.Framework.Core.Domain.Entities;
using CTaxCalculator.Framework.Core.Domain.Exceptions;
using CTaxCalculator.Framework.Core.Domain.ValueOBJs;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.ValueOBJs;

namespace CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities
{
    public class Passage:Entity
    {
        #region Properties
        public long VehicleId { get; private set; }
        public DateTime PassageDateTime { get; private set; }

        #endregion

        #region CTORs
        public Passage(DateTime timestamp , PId VehicleId)
        {
            if (string.IsNullOrEmpty(timestamp.ToString()))
                throw new InvalidEntityStateException("Passage DateTime Is Required." , nameof(timestamp));
            PassageDateTime = timestamp;
            VehicleId = VehicleId.Value;
            
        }
        private Passage()
        {
            
        }
        #endregion

        #region Behaviors IMP
        public void ChangePassageDateTime(DateTime timestamp) 
        {
            PassageDateTime = timestamp;
        }
        public static Passage Create(DateTime timestamp , PId vehicleId) 
            => new Passage(timestamp , vehicleId);

        public void ChangeVehicleInPassageWithId(long vehicleId)
        {
            VehicleId = vehicleId;
        }
        
        #endregion
    }
}
