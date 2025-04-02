
namespace Clean2025.Domain.Abstractions
{
    public abstract class BaseEntity
    {

        private readonly List<IDomainEvent> _domainEvents = new();
        public Guid Id { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; init; }
        public bool IsDeleted { get; init; }
        public DateTime? DeletedAt { get; init; }
        protected BaseEntity()
        {
            
        }
        protected BaseEntity(Guid id)
        {
            Id = id;
        }
        #region  simple methods
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.ToList();
        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
        #endregion

        public static Guid NewId() => Guid.NewGuid();
        public static Guid NewGuid(Guid id)=>id;
    }
}
