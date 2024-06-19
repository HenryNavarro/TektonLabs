using MediatR;
using TektonLabs.Challenge.Application.Abstractions.Email;
using TektonLabs.Challenge.Domain.Products.Events;
using TektonLabs.Challenge.Domain.Products.IRepository;

namespace TektonLabs.Challenge.Application.Products.CreateProduct;

internal sealed class CreateProductDomainEventHandler : INotificationHandler<ProductCreatedDomainEvent>
{
    private readonly IProductRepository _productRepository;
    private readonly IEmailService _emailService;

    public CreateProductDomainEventHandler(IProductRepository productRepository, IEmailService emailService)
    {
        _productRepository = productRepository;
        _emailService = emailService;
    }

    public async Task Handle(ProductCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(notification.ProductId, cancellationToken);

        if(product is null) { return; }

        await _emailService.SendAsync("correologistico@configuracion.com", "Creación Producto", "Plantilla para Email...");
    }
}
