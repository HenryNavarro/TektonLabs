using TektonLabs.Challenge.Domain.Abstractions;

namespace TektonLabs.Challenge.Domain.Products.Events;
public sealed record ProductCreatedDomainEvent(int ProductId) : IDomainEvent;

