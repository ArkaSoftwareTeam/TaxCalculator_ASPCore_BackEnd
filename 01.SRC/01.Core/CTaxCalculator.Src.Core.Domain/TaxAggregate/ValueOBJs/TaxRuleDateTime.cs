using CTaxCalculator.Framework.Core.Domain.ValueOBJs;

namespace CTaxCalculator.Src.Core.Domain.TaxAggregate.ValueOBJs
{
    public class TaxRuleDateTime:BaseValueOBJs<TaxRuleDateTime>
    {
        #region Factories
        public static TaxRuleDateTime Create(string createdAt, string expirationDate)
            => new TaxRuleDateTime(TimeOnly.Parse(createdAt), TimeOnly.Parse(expirationDate));

        #endregion

        #region Properties
        public TimeOnly StartTime { get; private set; }
        public TimeOnly EndTime { get; private set; }
        #endregion

        #region CTORs
        public TaxRuleDateTime(TimeOnly startTime, TimeOnly endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
        private TaxRuleDateTime() { }
        #endregion

        #region Class Methods Override 
        public override string ToString() => $"StartTime: {StartTime}, EndTime: {EndTime}";

        #endregion

        #region Override Methods In Parent Class
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return new { StartTime, EndTime };
        }
        #endregion

        #region Casting Excplicit And Implicit Operator Override
        public static explicit operator string(TaxRuleDateTime title) => title.ToString();
        public static implicit operator TaxRuleDateTime((TimeOnly startTime, TimeOnly endTime) value) 
            => new TaxRuleDateTime(value.startTime , value.endTime);
        #endregion

        #region Behaviors IMP
        public string StartTimeToStringFormat()
        {
            return StartTime.ToString("HH:mm");
        }

        public string EndTimeToStringFormat()
        {
            return EndTime.ToString("HH:mm");
        }

        
        #endregion


    }
}
