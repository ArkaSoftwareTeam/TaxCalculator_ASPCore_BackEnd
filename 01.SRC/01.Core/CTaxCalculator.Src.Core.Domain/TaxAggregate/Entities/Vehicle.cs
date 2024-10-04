using CTaxCalculator.Framework.Core.Domain.Entities;
using CTaxCalculator.Framework.Core.Domain.Exceptions;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.ValueOBJs;
using CTaxCalculator.Src.Core.Domain.VehicleAggregate.Enumerations;

namespace CTaxCalculator.Src.Core.Domain.VehicleAggregate.Entities
{
    public class Vehicle:Entity
    {
        #region Properties
        public TollFreeVehicles VehicleType { get; private set; }
        public PlateNumber PlateNumber { get; private set; }
        public Price LastTaxPassagePrice { get; private set; }
        public Price TotalTaxAmount { get; private set; }
        #endregion

        #region References Properties
        public IReadOnlyList<Passage> Passages => _passages;
        private readonly List<Passage> _passages = new List<Passage>();
        #endregion

        #region CTORs
        public Vehicle(TollFreeVehicles vehicleType , PlateNumber plateNumber)
        {
            VehicleType = vehicleType;
            PlateNumber = plateNumber;
            TotalTaxAmount = new Price(0);
            LastTaxPassagePrice = new Price(0);
        }
        private Vehicle()
        {
            
        }
        #endregion

        #region Behaviors IMP
        public void AddPassage(Passage passage) 
        { 
            var passageExist = _passages.Any(x => x.Id == passage.Id);
            if (passageExist)
                throw new InvalidEntityStateException("Passage Is Exist." , nameof(passage));
            _passages.Add(passage);
        }
        public void RemovePassage(Passage passage)
        { 
            var passageExist = _passages.FirstOrDefault(x => x.Id == passage.Id);
            if(passageExist is null)
                throw new InvalidEntityStateException("Passage Is Not Defind For Remove." , nameof(passage));   
            _passages.Remove(passage); 
        }
        public void ChangeTotalAmount(Price totalAmount)
        {
            TotalTaxAmount = totalAmount;
        }
        public void ChangeLastTaxPassagePrice(Price lastTaxPassagePrice)
        {
            LastTaxPassagePrice = lastTaxPassagePrice;
        }
        public void ChangeVehicleType(TollFreeVehicles vehicleType) 
        {
            VehicleType = vehicleType;
        }
        public void ChangePlateNumber(PlateNumber plateNumber) 
        { 
            PlateNumber = plateNumber ;
        }
        public TimeSpan GetDifferentPassageTime()
        {
            DateTime x = _passages[0].PassageDateTime;
            TimeSpan differentTime = DateTime.UtcNow - x;
            return differentTime;
        }


        #endregion

    }

}
