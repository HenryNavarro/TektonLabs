using TektonLabs.Challenge.Application.Abstractions.Discount;
using TektonLabs.Challenge.Application.Abstractions.Messaging;
using TektonLabs.Challenge.Domain.Abstranctions;
using TektonLabs.Challenge.Domain.Products;
using TektonLabs.Challenge.Domain.Products.Errors;
using TektonLabs.Challenge.Domain.Products.IRepository;

namespace TektonLabs.Challenge.Application.Products.CreateProduct;

public sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductExternalService _discountProvider;

    public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IProductExternalService discountProvider)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _discountProvider = discountProvider;

    }

    public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var discount = await _discountProvider.GetDiscountFromProduct(request.ProductId);

        if (discount is null)
            return Result.Failure(PriceErrors.DiscountNotExits);

        var price = Price.Create(request.Price, discount.Value);

        if (price.IsFailure)
            return price;

        Product product = Product.Create(request.ProductId
            , request.Name
            , request.Description
            , price.Value
            , request.Stock
            , request.Status
            );

        _productRepository.Add(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

}

