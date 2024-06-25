using TektonLabs.Challenge.Application.Abstractions.Discount;
using TektonLabs.Challenge.Application.Abstractions.Messaging;
using TektonLabs.Challenge.Domain.Abstractions;
using TektonLabs.Challenge.Domain.Products;
using TektonLabs.Challenge.Domain.Products.Errors;
using TektonLabs.Challenge.Domain.Products.IRepository;

namespace TektonLabs.Challenge.Application.Products.Update;
internal sealed class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductExternalService _discountProvider;

    public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork, IProductExternalService discountProvider)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _discountProvider = discountProvider;

    }

    public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.ProductId);

        if (product is null)
            return Result.Failure(ProductErrors.ProductNotExits);

        var price = Price.Create(request.Price, product.Price.DiscountPercent, product.Price.CurrencyType);
        if (price.IsFailure)
            return price;

        var status = StatusType.Create(request.Status);
        if (status.IsFailure)
            return status;

        product.Update(
             request.Name
            , request.Description
            , price.Value
            , request.Stock
            , request.Status
            );

        _productRepository.Update(product);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

}