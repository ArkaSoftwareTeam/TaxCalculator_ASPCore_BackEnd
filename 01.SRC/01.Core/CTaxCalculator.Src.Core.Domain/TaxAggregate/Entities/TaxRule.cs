using CTaxCalculator.Framework.Core.Domain.Entities;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.ValueOBJs;

namespace CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities
{
    public class TaxRule:Entity
    {

        #region Properties
        public TaxRuleDateTime TaxRuleDateTime { get; private set; }
        public Price TaxAmount { get; private set; }
        #endregion

        #region CTORs
        public TaxRule(TaxRuleDateTime taxRuleDateTime, Price taxAmount)
        {
            TaxRuleDateTime = taxRuleDateTime;
            TaxAmount = taxAmount;
        }


        private TaxRule()
        {
            
        }
        #endregion

        #region Behaviors

        public void SetId(long id) 
        {
            Id = id;
        }
        public bool IsApplicable(DateTime startTime , DateTime endTime)
        {
            return startTime.TimeOfDay >= TaxRuleDateTime.StartTime.ToTimeSpan() && endTime.TimeOfDay <= TaxRuleDateTime.EndTime.ToTimeSpan();
        }
        public void ChangeTaxRulePeriodDateTime (TaxRuleDateTime taxRuleDateTime)
        {
            TaxRuleDateTime = taxRuleDateTime;
        }
        public void ChangeTaxAmount(Price taxAmount) 
        {
            TaxAmount = taxAmount;
        }

        public bool IsValid()
        {
            if (TaxAmount.Amount < 0) return false;
            return true;
        }

        #endregion
    }
}
