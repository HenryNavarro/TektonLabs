namespace TektonLabs.Challenge.Application.Products.Get;

public sealed class GetProductResponse
{
    public int ProductId { get; init; }
    public string? Name { get; init; }
    public string? StatusName { get; init; }
    public decimal Stock { get; init; }
    public string? Description { get; init; }
    public decimal Price { get; init; }
    public int Discount { get; init; }
    public decimal FinalPrice { get; init; }
}