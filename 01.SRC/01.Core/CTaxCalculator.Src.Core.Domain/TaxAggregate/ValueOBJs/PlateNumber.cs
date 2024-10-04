using CTaxCalculator.Framework.Core.Domain.Exceptions;
using CTaxCalculator.Framework.Core.Domain.ValueOBJs;
using System.Text.RegularExpressions;

namespace CTaxCalculator.Src.Core.Domain.TaxAggregate.ValueOBJs
{
    public class PlateNumber:BaseValueOBJs<PlateNumber>
    {
        #region Factories
        /// <summary>
        /// The factory method that is responsible for creating the valueObject
        /// </summary>
        /// <param name="value">Amount of license plate number</param>
        /// <returns>Returns a new object of license plate number</returns>
        public static PlateNumber FromString(string value) => new PlateNumber(value);

        #endregion

        #region Properties
        // Regex For Check Validation PlateNumber <-- :
        private static readonly Regex LicensePlateRegex = new Regex(@"^[A-Z]{3}[0-9]{3}$", RegexOptions.Compiled);
        public string Value { get; private set; }
        #endregion

        #region CTORs
        /// <summary>
        /// Constructor method related to Value Object plate number.
        /// </summary>
        /// <param name="plateNumber">The license plate number is a string input that specifies the car's license plate number.</param>
        public PlateNumber(string plateNumber)
        {
            Validation(plateNumber);  // Check Plate Number Is Valid <-- :
            plateNumber = plateNumber.Trim().ToUpper(); // Remove spaces <-- :
            Value = plateNumber;  // Set PlateNumber In Value Properties <-- :
        }

        /// <summary>
        /// Parameterless and private constructor to follow the rules of the Entity Framework
        /// </summary>
        private PlateNumber() { }
        #endregion

        #region Check Validation Method
        /// <summary>
        /// Validation method related to the value of the license plate number.
        /// </summary>
        /// <param name="value">Validation method related to the value of the license plate number.</param>
        /// <exception cref="InvalidValueObjectStateException">If the license plate number is empty or incorrect, this error will be thrown.</exception>
        private void Validation(string value)
        {
            // Check PlateNumber Value <-- :
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidValueObjectStateException("License plate cannot be empty.", nameof(PlateNumber));
            if (!IsValid(value))
                throw new InvalidValueObjectStateException("Invalid license plate format.", nameof(PlateNumber));
          
        }
        #endregion

        #region Class Methods Override 
        /// <summary>
        /// Override the ToString() method
        /// </summary>
        /// <returns>Returns the value of the license plate number</returns>
        public override string ToString() => Value;
        #endregion

        #region Override Methods In Parent Class
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        #endregion

        #region Casting Excplicit And Implicit Operator Override
        public static explicit operator string(PlateNumber title) => title.Value.ToString();
        public static implicit operator PlateNumber(string value) => new PlateNumber(value);
        #endregion

        #region Behaviors IMP
        /// <summary>
        /// This method takes an input as license plate number and verifies the value based on the pattern.
        /// </summary>
        /// <param name="plateNumber">The number plate input is a string.</param>
        /// <returns>It returns a Boolean value, if it is true, it outputs the true value.</returns>
        private static bool IsValid(string plateNumber)
        {
            return LicensePlateRegex.IsMatch(plateNumber);
        }
        #endregion
    }
}
