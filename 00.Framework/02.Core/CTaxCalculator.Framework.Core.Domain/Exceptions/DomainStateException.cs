namespace CTaxCalculator.Framework.Core.Domain.Exceptions
{
    public class DomainStateException : Exception
    {
        #region Properties
        public string[] Parameters { get; set; }
        #endregion

        #region CTOR
        public DomainStateException(string message, params string[] parameters) : base(message)
        {
            Parameters = parameters;
        }
        #endregion

        #region ToString Method Override And New Impliment
        public override string ToString()
        {
            if (Parameters.Length < 0)
                return Message;
            string result = Message;
            for (int i = 0; i < Parameters.Length; i++)
            {
                string placeHolder = $"{{{i}}}";
                result = result.Replace(placeHolder, Parameters[i]);
            }
            return result;
        }
        #endregion

    }
}
