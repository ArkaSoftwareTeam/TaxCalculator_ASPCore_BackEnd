
using CTaxCalculator.Framework.Core.Domain.Exceptions;

namespace CTaxCalculator.Framework.Core.Domain.ValueOBJs
{
    public class BusinessID : BaseValueOBJs<BusinessID>
    {
        #region Factories
        public static BusinessID FromString(string value) => new BusinessID(value);
        public static BusinessID FromGuid(Guid value) => new() { Value = value };
        #endregion

        #region Properties
        public Guid Value { get; private set; }
        #endregion

        #region CTORs
        public BusinessID(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(BusinessID));
            if (Guid.TryParse(value, out Guid tempValue))
                Value = tempValue;
            else
                throw new InvalidValueObjectStateException("ValidationErrorInvalidValue", nameof(BusinessID));
        }
        private BusinessID() { }
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
        public static explicit operator string(BusinessID title) => title.Value.ToString();
        public static implicit operator BusinessID(string value) => new BusinessID(value);

        public static explicit operator Guid(BusinessID title) => title.Value;
        public static implicit operator BusinessID(Guid value) => new() { Value = value };
        #endregion
    }
}
