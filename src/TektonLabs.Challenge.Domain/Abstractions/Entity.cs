namespace TektonLabs.Challenge.Domain.Abstractions;
public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public int Id { get; init; }
    protected Entity() { }
    protected Entity(int id)
    {
        Id = id;
    }

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvents)
    {
        _domainEvents.Add(domainEvents);
    }
}

