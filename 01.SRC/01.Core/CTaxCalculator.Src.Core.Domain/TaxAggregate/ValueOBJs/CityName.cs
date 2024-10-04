using CTaxCalculator.Framework.Core.Domain.Exceptions;
using CTaxCalculator.Framework.Core.Domain.ValueOBJs;

namespace CTaxCalculator.Src.Core.Domain.UsersAggregate.ValueOBJs
{
    public class CityName : BaseValueOBJs<CityName>
    {
        #region Factories
        public static CityName FromString(string value) => new CityName(value);

        #endregion

        #region Properties
        public string Value { get; private set; }
        #endregion

        #region CTORs
        public CityName(string value)
        {
            Validation(value);
            Value = value;
        }
        private CityName() { }
        #endregion

        #region Check Validation Method
        private void Validation(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new InvalidValueObjectStateException("ValidationErrorIsRequired", nameof(CityName));
            if (value.Length < 2 || value.Length > 120)
                throw new InvalidValueObjectStateException("ValidationErrorStringLength", nameof(CityName));
        }
        #endregion

        #region Class Methods Override 
        public override string ToString() => Value;
        #endregion

        #region Override Methods In Parent Class
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        #endregion

        #region Casting Excplicit And Implicit Operator Override
        public static explicit operator string(CityName title) => title.Value.ToString();
        public static implicit operator CityName(string value) => new CityName(value);
        #endregion
    }
}
