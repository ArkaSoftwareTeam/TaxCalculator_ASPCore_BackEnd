using CTaxCalculator.Framework.Core.Domain.Entities;
using CTaxCalculator.Framework.Core.Domain.Events;
using System.Reflection;

namespace CTaxCalculator.Framework.Core.Domain.Aggregates
{
    public class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
        where TId : struct, IComparable, IComparable<TId>, IConvertible, IEquatable<TId>, IFormattable
    {
        #region Properties And Feild
        private readonly List<IDomainEvent>? _events;
        #endregion

        #region CTOR
        protected AggregateRoot() => _events = new List<IDomainEvent>();

        public AggregateRoot(IEnumerable<IDomainEvent> events)
        {
            if (events == null || !events.Any()) return;
            foreach (var @event in events)
            {
                Mutate(@event);
            }
        }
        #endregion

        #region Protected Methods Defind
        protected void Apply(IDomainEvent @event)
        {
            Mutate(@event);
            AddEvent(@event);
        }

        protected void AddEvent(IDomainEvent @event) => _events!.Add(@event);
        #endregion

        #region Public Methods Defind
        public void ClearEvents() => _events?.Clear();

        public IEnumerable<IDomainEvent> GetEvents() => _events!.AsEnumerable();
        #endregion

        #region Private Methods Defind
        private void Mutate(IDomainEvent @event)
        {
            var onMethod = GetType().GetMethod("On", BindingFlags.Instance | BindingFlags.NonPublic, [@event.GetType()]);
            onMethod!.Invoke(this, new[] { @event });
        }
        #endregion
    }

    public abstract class AggregateRoot : AggregateRoot<long>
    {

    }
}
