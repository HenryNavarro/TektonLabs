using TektonLabs.Challenge.Domain.Abstranctions;

namespace TektonLabs.Challenge.Domain.Products.Events;
public sealed record ProductCreatedDomainEvent(int ProductId) : IDomainEvent;

