namespace CTaxCalculator.Framework.Core.Domain.Exceptions
{
    public class InvalidEntityStateException : DomainStateException
    {
        #region CTOR Generate
        public InvalidEntityStateException(string message, params string[] parameters) : base(message, parameters)
        {
            Parameters = parameters;
        }
        #endregion
    }
}
