using TektonLabs.Challenge.Application.Abstractions.Messaging;
using TektonLabs.Challenge.Domain.Products;

namespace TektonLabs.Challenge.Application.Products.CreateProduct;

public record CreateProductCommand(
        int ProductId,
        string Name,
        string Description,
        decimal Stock,
        decimal Price,
        int Status
    ) : ICommand;
