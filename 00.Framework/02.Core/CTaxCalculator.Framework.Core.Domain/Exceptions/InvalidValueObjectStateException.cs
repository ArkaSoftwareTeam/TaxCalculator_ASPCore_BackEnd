namespace CTaxCalculator.Framework.Core.Domain.Exceptions
{
    public class InvalidValueObjectStateException : DomainStateException
    {
        #region CTOR Generate
        public InvalidValueObjectStateException(string message, params string[] parameters) : base(message, parameters)
        {
            Parameters = parameters;
        }
        #endregion
    }
}
