using CTaxCalculator.Framework.Core.Domain.Exceptions;
using CTaxCalculator.Framework.Core.Domain.ValueOBJs;

namespace CTaxCalculator.Src.Core.Domain.TaxAggregate.ValueOBJs
{
    public class Price : BaseValueOBJs<Price>
    {
        #region Factories
        public static Price FromString(string value) => new Price(Convert.ToDecimal(value));
        public static Price FromDecimal(decimal value) => new Price(Convert.ToDecimal(value));
        public static Price FromDouble(double value) => new Price(Convert.ToDecimal(value));


        #endregion

        #region Properties
        public decimal Amount { get; private set; }
        #endregion

        #region CTOR
        public Price(decimal amount)
        {
            if (amount < 0)
                throw new InvalidValueObjectStateException("Amount cannot be negative", nameof(amount));
            Amount = amount;
        }
        private Price() { }
        #endregion

        #region Implementation Behavior Rich 
        public Price Add(Price other) => new Price(Amount + other.Amount);
        public Price Subtract(Price other) => new Price(Amount - other.Amount);

        #endregion

        #region Class Methods Override 
        public override string ToString() => $"{Amount:N2}";
        #endregion

        #region Override Methods In Parent Class
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
        }
        #endregion

        #region Impelementaion Operators Sum And Subtract
        public static Price operator +(Price Left, Price Right)
        {
            return new Price(Left.Amount + Right.Amount);
        }
        public static Price operator -(Price Left, Price Right)
        {
            return new Price(Left.Amount - Right.Amount);
        }
        #endregion

        #region Casting Excplicit And Implicit Operator Override
        public static explicit operator string(Price title) => title.Amount.ToString();
        public static implicit operator Price(string value) => new Price(Convert.ToDecimal(value));
        #endregion
    }
}
