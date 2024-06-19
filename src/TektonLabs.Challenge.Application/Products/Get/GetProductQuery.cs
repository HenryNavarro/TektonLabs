using TektonLabs.Challenge.Application.Abstractions.Messaging;

namespace TektonLabs.Challenge.Application.Products.Get;
public sealed record GetProductQuery(int ProductId) : IQuery<GetProductResponse?>;
