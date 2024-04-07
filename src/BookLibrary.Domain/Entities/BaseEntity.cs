using BookLibrary.Domain.Interfaces.SeedWork;

namespace BookLibrary.Domain.Entities
{
    public abstract class BaseEntity
    {
        private List<IEvent> _domainEvents;

        public virtual int Id { get; protected set; }

        public IReadOnlyCollection<IEvent> DomainEvents => _domainEvents?.AsReadOnly();

        public void AddDomainEvent(IEvent domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<IEvent>();
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(IEvent domainEvent)
        {
            _domainEvents?.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        public override bool Equals(object obj)
        {
            BaseEntity entity = obj as BaseEntity;
            if ((object)this == entity)
            {
                return true;
            }

            if ((object)entity == null)
            {
                return false;
            }

            return Id.Equals(entity.Id);
        }

        public static bool operator ==(BaseEntity a, BaseEntity b)
        {
            if ((object)a == null && (object)b == null)
            {
                return true;
            }

            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntity a, BaseEntity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() ^ 0x5D) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }
    }
}
