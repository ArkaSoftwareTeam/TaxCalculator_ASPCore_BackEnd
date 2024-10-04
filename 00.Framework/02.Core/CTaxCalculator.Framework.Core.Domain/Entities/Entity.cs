using CTaxCalculator.Framework.Core.Domain.ValueOBJs;

namespace CTaxCalculator.Framework.Core.Domain.Entities
{
    public abstract class Entity<TId> : IAuditableEntity
        where TId : struct, IComparable, IComparable<TId>, IConvertible, IEquatable<TId>, IFormattable
    {
        #region Properties
        public TId Id { get; protected set; }
        public bool IsDelete { get; protected set; }

        public BusinessID BusinessId { get; protected set; } = BusinessID.FromGuid(Guid.NewGuid());
        #endregion

        #region CTOR
        protected Entity() { }

        #endregion

        #region Equality Checked

        public bool Equals(Entity<TId> other) => this == other;

        #endregion

        #region Override Method For Equality Checked
        public override bool Equals(object? obj) => obj is Entity<TId> otherObject && Id.Equals(otherObject.Id);

        public override int GetHashCode() => Id.GetHashCode();
        #endregion

        #region Operators Override Methods
        public static bool operator ==(Entity<TId> Left, Entity<TId> Right)
        {
            if (Left is null && Right is null) return true;
            if (Left is null || Right is null) return false;
            return Left.Equals(Right);
        }
        public static bool operator !=(Entity<TId> Left, Entity<TId> Right) => !(Right == Left);
        #endregion

    }

    public abstract class Entity : Entity<long> { }
}
