using CTaxCalculator.Framework.Core.Domain.Aggregates;
using CTaxCalculator.Framework.Core.Domain.Exceptions;
using CTaxCalculator.Framework.Core.Domain.ValueOBJs;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.Events;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.ValueOBJs;
using CTaxCalculator.Src.Core.Domain.UsersAggregate.ValueOBJs;
using CTaxCalculator.Src.Core.Domain.VehicleAggregate.Entities;
using CTaxCalculator.Src.Core.Domain.VehicleAggregate.Enumerations;

namespace CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities
{
    public class City : AggregateRoot
    {

        #region Properties
        public CityName CityName { get;private set; }

        #endregion

        #region References Properties

        public IReadOnlyList<TaxRule> TaxRules => _taxRules;
        private readonly List<TaxRule> _taxRules = new List<TaxRule>();
        public IReadOnlyList<FreeTaxDate> FreeTaxDates => _freeTaxDates;
        private readonly List<FreeTaxDate> _freeTaxDates = new List<FreeTaxDate>();
        public IReadOnlyList<Passage> Passages => _passages;
        private readonly List<Passage> _passages = new List<Passage>();

        public IReadOnlyList<Vehicle> Vehicles => _vehicles;
        private readonly List<Vehicle> _vehicles = new List<Vehicle>();
        #endregion

        #region CTORs
        public City(CityName cityName)
        {
            CityName = cityName;
            AddEvent(new CityAdded(cityName.Value));
        }
        private City()
        {

        }
        #endregion

        #region Behaviors
        public void SetId(long id)
        {
            Id = id;
        }
        public void AddTaxRule(TaxRule taxRule)
        {
            TaxRule taxRuleExist = _taxRules.FirstOrDefault(x => x.TaxRuleDateTime == taxRule.TaxRuleDateTime && x.TaxAmount == taxRule.TaxAmount)!;
            if (taxRuleExist is not null)
                throw new InvalidEntityStateException($"Tax Rule With Id : {taxRule.Id} is Not Defind.", nameof(TaxRule));
            _taxRules.Add(taxRule);
            AddEvent(new TaxRuleAdded(taxRule.TaxRuleDateTime.StartTime , taxRule.TaxRuleDateTime.EndTime , taxRule.TaxAmount.Amount));
        }
        public void AddFreeTaxDate(FreeTaxDate freeTaxDate) 
        { 
            bool freeTaxDateExist = _freeTaxDates.Any(x => x.FreeTaxDateTime == freeTaxDate.FreeTaxDateTime);
            if(freeTaxDateExist)
                throw new InvalidEntityStateException("Free Tax Date Is Exist." , nameof(freeTaxDate));
            _freeTaxDates.Add(freeTaxDate);
            AddEvent(new FreeTaxDateAdded(freeTaxDate.FreeTaxDateTime.Value));
        }
        public void AddVehicle(Vehicle vehicle) 
        { 
            bool vehicleExist = _vehicles.Any(x => x.PlateNumber == vehicle.PlateNumber);
            if(vehicleExist)
                throw new InvalidEntityStateException("Vehicle Is Exist." , nameof(vehicle));
            _vehicles.Add(vehicle);
            AddEvent(new VehicleAdded(vehicle.VehicleType , vehicle.PlateNumber.Value , vehicle.TotalTaxAmount.Amount));
        }
        public void AddPassage(Passage passage)
        {
            bool passageExist = _passages.Any(x => x.Id == passage.Id);
            if (passageExist)
                throw new InvalidEntityStateException("Passage Is Exist.", nameof(Passage));
            _passages.Add(passage);
            AddEvent(new PassageAdded(passage.PassageDateTime));
        }
        public void ChangeCityName(CityName cityName)
        {
            CityName = cityName;
            AddEvent(new CityNameChanged(cityName.Value));
        }
        public decimal CalculateTaxAmountWithRule()
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            var priceRange = _taxRules.FirstOrDefault(pr => 
            {
                var startTime = pr.TaxRuleDateTime.StartTime.ToTimeSpan();
                var endTime = pr.TaxRuleDateTime.EndTime.ToTimeSpan();
                if (startTime > endTime)
                {
                    return currentTime >= startTime || currentTime <= endTime;
                }
                else
                {
                    return currentTime >= startTime && currentTime <= endTime;
                }
            });
            if (priceRange is null)
                throw new InvalidEntityStateException("The Tax Rule Is Not Valid.", nameof(priceRange));
            AddEvent(new TaxAmountWasCalculated(priceRange!.TaxAmount.Amount));
            return priceRange.TaxAmount.Amount;
        }
        public void GetGreatThanTaxPriceInDifferentPassages(PId vehicleId)
        {
            var vehicleResult = _vehicles.FirstOrDefault(x => x.Id == vehicleId.Value);
            TimeSpan differentPassageTime = vehicleResult!.GetDifferentPassageTime();
            if(differentPassageTime.TotalMinutes < 60)
                vehicleResult.ChangeLastTaxPassagePrice(new ValueOBJs.Price(GetMaxPrice()));
            else
            {
                vehicleResult.ChangeTotalAmount(new ValueOBJs.Price(CalculateTaxAmountWithRule()));
                IncrementTaxTotalPrice(Id , vehicleResult.LastTaxPassagePrice);
            }
                
            AddEvent(new VehicleTotalAmountChanged(vehicleId.Value , CalculateTaxAmountWithRule()));
        }
        public decimal GetMaxPrice()
        {
            var priceEvents = GetEvents()
                .OfType<TaxAmountWasCalculated>()
                .ToList();
            if (priceEvents.Any())
            {
                return priceEvents.Max(pe => pe.TaxAmount);
            }
            return 0;
        }
        public void ChangeFreeTaxDateTime(PId  freeTaxDateId ,FreeTaxDateTime freeTaxDateTime)
        {
            FreeTaxDate freeTaxDate = _freeTaxDates.FirstOrDefault(x => x.Id == freeTaxDateId.Value)!;
            if (freeTaxDate is null)
                throw new InvalidEntityStateException($"Free Tax Date With Id : {freeTaxDateId} Is Not Defind.", nameof(FreeTaxDate));
            freeTaxDate.ChangeFreeTaxDateTime(freeTaxDateTime);
            AddEvent(new FreeTaxDateTimeChanged(freeTaxDateId.Value , freeTaxDateTime.Value));
        }
        public void ChangePassageDateTime(PId passageId , DateTime newDateTime)
        {
            Passage passage = _passages.FirstOrDefault(x => x.Id == passageId.Value)!;
            if (passage is null)
                throw new InvalidEntityStateException($"Passage With Id : {passageId.Value} Is Not Defind.", nameof(Passage));
            passage.ChangePassageDateTime(newDateTime);
            AddEvent(new PassageDateTimeChanged(passageId.Value , newDateTime));    
        }
        public void ChangeVehicleInPassage(PId passageId , PId vehicleId)
        {
            Passage passage = _passages.FirstOrDefault(x => x.Id == passageId.Value)!;
            if (passage is null)
                throw new InvalidEntityStateException($"Passage With Id : {passageId.Value} Is Not Defind.", nameof(Passage));
            passage.ChangeVehicleInPassageWithId(vehicleId.Value);
            AddEvent(new VehicleInPassageChanged(passageId.Value , vehicleId.Value));   
        }
        public void ChangeTaxRulePeriodDateTime(PId taxRuleId , TimeOnly startTime , TimeOnly endTime)
        {
            TaxRule taxRule = _taxRules.FirstOrDefault(x => x.Id == taxRuleId.Value)!;
            if (taxRule is null)
                throw new InvalidEntityStateException($"Tax Rule With Id : {taxRuleId.Value} is Not Defind.", nameof(TaxRule));
            taxRule.ChangeTaxRulePeriodDateTime(new TaxRuleDateTime(startTime, endTime));
            AddEvent(new TaxRulePeriodDateTimeChanged(taxRuleId.Value, startTime, endTime));
        }
        public void ChangeTaxRuleAmount(PId taxRuleId, Price taxAmount)
        {
            TaxRule taxRule = _taxRules.FirstOrDefault(x => x.Id == taxRuleId.Value)!;
            if (taxRule is null)
                throw new InvalidEntityStateException($"Tax Rule With Id : {taxRuleId.Value} is Not Defind.", nameof(TaxRule));
            taxRule.ChangeTaxAmount(taxAmount);
            AddEvent(new TaxRuleAmountChanged(taxRuleId.Value, taxAmount.Amount));
        }
        public void ChangeVehicleType(PId vehicleId , TollFreeVehicles newVehicleType)
        {
            Vehicle vehicle = _vehicles.FirstOrDefault(x => x.Id == vehicleId.Value)!;
            if(vehicle is null)
                throw new InvalidEntityStateException($"Vehicle With Id : {vehicleId.Value} Is Not Defind." , nameof(Vehicle));
            vehicle.ChangeVehicleType(newVehicleType);
            AddEvent(new VehicleTypeChanged(vehicleId.Value, newVehicleType));


        }
        public void ChangeVehiclePlateNumber(PId vehicleId, PlateNumber plateNumber)
        {
            Vehicle vehicle = _vehicles.FirstOrDefault(x => x.Id == vehicleId.Value)!;
            if (vehicle is null)
                throw new InvalidEntityStateException($"Vehicle With Id : {vehicleId.Value} Is Not Defind.", nameof(Vehicle));
            vehicle.ChangePlateNumber(plateNumber);
            AddEvent(new VehiclePlateNumberChanged(vehicleId.Value, plateNumber.Value));
        }
        public void IncrementTaxTotalPrice(PId vehicleId ,Price amount)
        {
            Vehicle vehicle = _vehicles.FirstOrDefault(x => x.Id == vehicleId.Value)!;
            if (vehicle is null)
                throw new InvalidEntityStateException($"Vehicle With Id : {vehicleId.Value} Is Not Defind.", nameof(Vehicle));
            var newPrice = vehicle.TotalTaxAmount.Add(amount);
            vehicle.ChangeTotalAmount(newPrice);
            AddEvent(new VehicleTotalAmountChanged(vehicleId.Value , newPrice.Amount));

        }
        public void DecrementTaxTotalPrice(PId vehicleId, Price amount)
        {
            Vehicle vehicle = _vehicles.FirstOrDefault(x => x.Id == vehicleId.Value)!;
            if (vehicle is null)
                throw new InvalidEntityStateException($"Vehicle With Id : {vehicleId.Value} Is Not Defind.", nameof(Vehicle));
            var newPrice = vehicle.TotalTaxAmount.Subtract(amount);
            vehicle.ChangeTotalAmount(newPrice);
            AddEvent(new VehicleTotalAmountChanged(vehicleId.Value, newPrice.Amount));
        }
        public void IsApplicableTaxRule(PId taxRuleId , DateTime startTime , DateTime endTime)
        {
            TaxRule taxRule = _taxRules.FirstOrDefault(x => x.Id == taxRuleId.Value)!;
            if (taxRule is null)
                throw new InvalidEntityStateException($"Tax Rule With Id : {taxRuleId.Value} is Not Defind.", nameof(TaxRule));
            bool taxRuleApplicable = taxRule.IsApplicable(startTime , endTime);
            if (!taxRuleApplicable)
                throw new InvalidEntityStateException($"The tax law is not applicable at this time:\nstartTime => {startTime.ToString("yyyy-MM-dd - HH:mm")} And endTime => {endTime.ToString("yyyy-MM-dd - HH:mm")}.\nCorrect the time." , nameof(TaxRule));
        }
        public bool CheckAndValidateFileExtension(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return false;
            if (fileName.EndsWith(".json") || fileName.EndsWith(".JSON"))
                return true;
            return false;
        }
        public void RemoveTaxRuleById(PId taxRuleId)
        {
            TaxRule taxRuleExist = _taxRules.FirstOrDefault(x => x.Id == taxRuleId.Value)!;
            if (taxRuleExist is null)
                throw new InvalidEntityStateException($"Tax Rule by Id : {taxRuleId} Is Not Exist.", nameof(TaxRule));
            _taxRules.Remove(taxRuleExist);
            AddEvent(new TaxRuleRemoved(taxRuleId.Value));
        }
        public  void RemoveAllTaxRulesInCity()
        {
            _taxRules.Clear();
            AddEvent(new AllTaxRuleIsRemoved());
        }
        public void RemoveFreeTaxDateTime(long freeTaxDateTimeId)
        {
            FreeTaxDate freeTaxDate = _freeTaxDates.FirstOrDefault(x => x.Id == freeTaxDateTimeId)!;
            if (freeTaxDate is null)
                throw new InvalidEntityStateException($"FreeTax DateTime Object With Id : {freeTaxDateTimeId} Is Not Defind.");
            _freeTaxDates.Remove(freeTaxDate);
            AddEvent(new FreeTaxDateTimeRemoved(freeTaxDateTimeId));

        }
        public void RemovePassage(long passageId)
        {
            Passage passage = _passages.FirstOrDefault(x => x.Id == passageId)!;
            if (passage is null)
                throw new InvalidEntityStateException($"Passage Object With Id : {passageId} Is Not Defind.");
            _passages.Remove(passage);
            AddEvent(new PassageRemoved(passageId));

        }
        public void RemoveVehicle(long vehicleId)
        {
            Vehicle vehicle = _vehicles.FirstOrDefault(x => x.Id == vehicleId)!;
            if (vehicle is null)
                throw new InvalidEntityStateException($"Vehicle Object With Id : {vehicleId} Is Not Defind.");
            _vehicles.Remove(vehicle);
            AddEvent(new VehicleRemoved(vehicleId));

        }
        #endregion
    }
}
