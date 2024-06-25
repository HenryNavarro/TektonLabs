using TektonLabs.Challenge.Application.Abstractions.Messaging;
using TektonLabs.Challenge.Domain.Abstractions;
using TektonLabs.Challenge.Domain.Products.Errors;
using TektonLabs.Challenge.Domain.Products.IRepository;

namespace TektonLabs.Challenge.Application.Products.Get;

public sealed class GetProductQueryHandler
 : IQueryHandler<GetProductQuery, GetProductResponse?>
{

    private readonly IProductRepository _productRepository;
    private readonly IStatusTypeReadRepository _statusTypeRepository;

    public GetProductQueryHandler(IProductRepository productRepository, IStatusTypeReadRepository statusTypeRepository)
    {
        _productRepository = productRepository;
        _statusTypeRepository = statusTypeRepository;
    }

    public async Task<Result<GetProductResponse?>> Handle(
        GetProductQuery request,
        CancellationToken cancellationToken
    )
    {
        GetProductResponse? response = null;

        var product = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);

        if (product is null)
            return Result.Success<GetProductResponse?>(response!);

        var status = await _statusTypeRepository.GetByIdAsync(product.Status, cancellationToken);

        if (status is null)
            return Result.Failure<GetProductResponse?>(StatusTypeErrors.NotExist);

        response = new()
        {
            Discount = product.Price.DiscountPercent,
            FinalPrice = product.Price.FinalPrice,
            Price = product.Price.Value,
            Description = product.Description,
            Name = product.Name,
            ProductId = product.Id,
            StatusName = status.Name
        };

        return response;
    }
}