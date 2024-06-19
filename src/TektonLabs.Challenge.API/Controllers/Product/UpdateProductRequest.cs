using MediatR;

namespace TektonLabs.Challenge.API.Controllers.Product
{
    public record UpdateProductRequest
    (
        string Name,
        string Description,
        decimal Stock,
        decimal Price,
        byte Status
    );
}
