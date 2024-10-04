using CTaxCalculator.Framework.Core.Domain.ValueOBJs;

namespace CTaxCalculator.Src.Core.Domain.TaxAggregate.ValueOBJs
{
    public class FreeTaxDateTime:BaseValueOBJs<FreeTaxDateTime>
    {
        #region Factories
        public static FreeTaxDateTime Create(string value)
            => new FreeTaxDateTime(Convert.ToDateTime(value));

        #endregion

        #region Properties
        public DateTime Value { get; private set; }
        #endregion

        #region CTORs
        public FreeTaxDateTime(DateTime value)
        {
            Value = value;
        }

        private FreeTaxDateTime() { }
        #endregion

        #region Class Methods Override 
        public override string ToString() => Value.ToString("yyyy/MM/dd");

        #endregion

        #region Override Methods In Parent Class
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        #endregion

        #region Casting Excplicit And Implicit Operator Override
        public static explicit operator string(FreeTaxDateTime title) => title.ToString();
        public static implicit operator FreeTaxDateTime(DateTime date)
            => new FreeTaxDateTime(date);
        #endregion

        #region Behaviors IMP
     
        public bool IsTollFreeDate(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

            if (date.Year == Value.Year)
            {
                if (date.Month == Value.Month && date.Day == Value.Day)
                    return true;
            }
            return false;
        }

        public bool IsTaxZero()
        {
            if (Value.TimeOfDay >= TimeSpan.FromHours(0) && Value.TimeOfDay < TimeSpan.FromHours(6))
            {
                return true;
            }
            if (Value.Date == new DateTime(Value.Year, 12, 25))
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
