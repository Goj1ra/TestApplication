
namespace DAL.Entities.Base
{
    public abstract class EntityBase<TId> : IEntityBase<TId>
    {
        public virtual TId Id { get; protected set; }
        private int? _requestedHashCode;
        public bool IsTransient()
        {
            return Id != null && Id.Equals(default(TId));
        }

        public override bool Equals(object? obj)
        {
            if (obj is not EntityBase<TId> item)
            {
                return false;
            }

            if (ReferenceEquals(this, item))
            {
                return true;
            }

            if (GetType() != item.GetType())
            {
                return false;
            }

            if (item.IsTransient() || IsTransient())
            {
                return false;
            }

            return item == this;
        }

        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                _requestedHashCode ??= Id.GetHashCode() ^ 31;

                return _requestedHashCode.Value;
            }

            return base.GetHashCode();
        }

        public static bool operator ==(EntityBase<TId>? left, EntityBase<TId>? right)
        {
            return Equals(left, null)
                ? Equals(right, null)
                : left.Equals(right);
        }

        public static bool operator !=(EntityBase<TId> left, EntityBase<TId> right)
        {
            return !(left == right);
        }
    }
}
