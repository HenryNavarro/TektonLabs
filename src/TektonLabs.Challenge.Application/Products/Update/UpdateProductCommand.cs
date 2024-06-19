using TektonLabs.Challenge.Application.Abstractions.Messaging;

namespace TektonLabs.Challenge.Application.Products.Update;
public record UpdateProductCommand(
        int ProductId,
        string Name,
        string Description,
        decimal Stock,
        decimal Price,
        byte Status
    ) : ICommand;
