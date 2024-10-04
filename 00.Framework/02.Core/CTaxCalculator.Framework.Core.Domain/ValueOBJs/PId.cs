using CTaxCalculator.Framework.Core.Domain.Exceptions;

namespace CTaxCalculator.Framework.Core.Domain.ValueOBJs
{
    public class PId : BaseValueOBJs<PId>
    {
        #region Factories
        public static PId FromString(string value) => new PId(long.Parse(value));
        public static PId FromInt(int value) => new PId(value);
        public static PId FromLong(long value) => new PId(value);

        #endregion

        #region Properties
        public long Value { get; private set; }
        #endregion

        #region CTORs
        public PId(long value)
        {
            if (value == 0)
                throw new InvalidValueObjectStateException("ValidationErrorValueIsNotZero", nameof(PId));
            if (value < 0)
                throw new InvalidValueObjectStateException("ValidationErrorValueIsNotSmallThanZero", nameof(PId));
            Value = value;
        }
        private PId() { }
        #endregion

        #region Class Methods Override 
        public override string ToString()
        {
            return Value.ToString();
        }
        #endregion

        #region Override Methods In Parent Class
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        #endregion

        #region Casting Excplicit And Implicit Operator Override
        public static explicit operator string(PId title) => title.Value.ToString();
        public static implicit operator PId(long value) => new PId(value);
        #endregion
    }
}
