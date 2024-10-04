using CTaxCalculator.Framework.Core.Domain.Entities;
using CTaxCalculator.Src.Core.Domain.TaxAggregate.ValueOBJs;

namespace CTaxCalculator.Src.Core.Domain.TaxAggregate.Entities
{
    public class FreeTaxDate:Entity
    {
        #region Properties
        public FreeTaxDateTime FreeTaxDateTime { get; private set; }
        #endregion

        #region CTORs
        public FreeTaxDate(FreeTaxDateTime datetime)
        {
            FreeTaxDateTime = datetime;
        }
        private FreeTaxDate() { }
        #endregion

        #region Behaviors
        public void ChangeFreeTaxDateTime(FreeTaxDateTime newFreeTaxDateTime) 
        { 
            FreeTaxDateTime = newFreeTaxDateTime;
        }
        #endregion
    }
}
