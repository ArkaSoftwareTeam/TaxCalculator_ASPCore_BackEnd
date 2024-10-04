using CTaxCalculator.Framework.Core.Domain.Exceptions;

namespace CTaxCalculator.Framework.Core.Domain.ValueOBJs
{
    public class Description : BaseValueOBJs<Description>
    {
        #region Factories
        public static Description FromString(string value) => new Description(value);

        #endregion

        #region Properties
        public string Value { get; private set; }
        #endregion

        #region CTORs
        public Description(string value)
        {
            Validation(value);
            Value = value;
        }
        private Description() { }
        #endregion

        #region Check Validation Method
        private void Validation(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new InvalidValueObjectStateException("ValidationErrorIsRequired", nameof(Description));
            if (value.Length > 300)
                throw new InvalidValueObjectStateException("ValidationErrorStringLength", nameof(Description));

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
        public static explicit operator string(Description title) => title.Value.ToString();
        public static implicit operator Description(string value) => new Description(value);
        #endregion
    }
}
